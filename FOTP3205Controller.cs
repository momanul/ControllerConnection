using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStorePro.Context;
using BookStorePro.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using BookStorePro.CModels;
using System.Runtime.InteropServices;
using System.Management;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace BookStorePro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FOTP3205Controller : ControllerBase
    {

        string connectionString = "";
        private readonly IConfiguration configuration;

        public FOTP3205Controller(IConfiguration config)
        {

            configuration = config;
            connectionString = configuration.GetConnectionString("DBConnection");
        }


        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "ambit00005@123";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string EncryptByAES(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {
                rijndaelManaged.Mode = CipherMode.CBC;
                rijndaelManaged.Padding = PaddingMode.PKCS7;
                rijndaelManaged.FeedbackSize = 128;

                rijndaelManaged.Key = Encoding.UTF8.GetBytes("ambit0000005@123");
                rijndaelManaged.IV = Encoding.UTF8.GetBytes("1234567890050505");

                ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(input);
                        }
                        byte[] bytes = msEncrypt.ToArray();
                        return Convert.ToBase64String(bytes);
                    }
                }
            }
        }

        [Route("OTPVER/{phoneNo}/{otpFor}")]
        [HttpGet]

        public async Task<ActionResult<List<OTPGrid>>> insertFOTP3205(string phoneNo, string otpFor)
        {

            try
            {
                string sendCode = "";
                List<OTPGrid> gridlst = await Task.Run(() => new List<OTPGrid>());

                if (otpFor != "logincheck")
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            var param = new SqlParameter[] {
                                new SqlParameter() {
                                    ParameterName = "@pHO",
                                    SqlDbType =   SqlDbType.NVarChar,
                                    Direction =  ParameterDirection.Input,
                                    Value =  phoneNo
                                },
                                new SqlParameter() {
                                    ParameterName = "@oTP_For",
                                    SqlDbType =  SqlDbType.NVarChar,
                                    Direction =  ParameterDirection.Input,
                                    Value = otpFor
                                },

                            };

                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "insertFOTP3205";
                            cmd.Parameters.AddRange(param);
                            con.Open();
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    sendCode = sdr["otpSend"].ToString();
                                    gridlst.Add(new OTPGrid
                                    {
                                        pHO = phoneNo,
                                        oTP_For = otpFor,
                                        lOG_In_ID = Convert.ToDecimal(sdr["uS_Id"]),
                                        uS_Nm = sdr["uS_Nm"].ToString(),
                                        tYP = Convert.ToInt32(sdr["tYP"]),
                                        oTP_Code = EncryptByAES(sdr["otpSend"].ToString()),
                                        fR_Dat = Convert.ToDateTime(sdr["fR_Dat"]),
                                        tO_Dat = Convert.ToDateTime(sdr["tO_Dat"])
                                    });
                                }

                            }

                            if (phoneNo.Length == 11 && gridlst[0].oTP_Code != "")
                            {
                                SmsApi _smsApi = new SmsApi();
                                _smsApi.SmsSend(phoneNo, sendCode, true);
                            }
                            con.Close();

                        }
                    }
                    return gridlst;
                }
                else
                {
                    string processorID = "";
                    string MacAddr = "";
                    string VolumeSlNumber = "";

                    {

                        ManagementClass processor = new ManagementClass("win32_processor");
                        ManagementObjectCollection manageobcl = processor.GetInstances();
                        String Id = String.Empty;
                        foreach (ManagementObject myObj in manageobcl)
                        {

                            Id = myObj.Properties["processorID"].Value.ToString();
                            break;
                        }
                        processorID = Encrypt(Id);

                    }

                    {
                        ManagementClass mangnmt = new ManagementClass("Win32_LogicalDisk");
                        ManagementObjectCollection mcol = mangnmt.GetInstances();
                        string result = "";
                        foreach (ManagementObject strt in mcol)
                        {
                            result += Convert.ToString(strt["VolumeSerialNumber"]);
                        }
                        VolumeSlNumber = Encrypt(result);
                    }

                    {
                        ManagementClass mancl = new ManagementClass("Win32_NetworkAdapterConfiguration");
                        ManagementObjectCollection manageobject = mancl.GetInstances();
                        string MACAddress = String.Empty;
                        foreach (ManagementObject myObj in manageobject)
                        {
                            if (MACAddress == String.Empty)
                            {
                                if ((bool)myObj["IPEnabled"] == true) MACAddress = myObj["MacAddress"].ToString();
                            }
                            myObj.Dispose();
                        }

                        MACAddress = MACAddress.Replace(":", "");
                        MacAddr = Encrypt(MACAddress);

                    }

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            var param = new SqlParameter[] {
                                new SqlParameter() {
                                    ParameterName = "@pHO",
                                    SqlDbType =   SqlDbType.NVarChar,
                                    Direction =  ParameterDirection.Input,
                                    Value =  phoneNo
                                },
                                new SqlParameter() {
                                    ParameterName = "@PD",
                                    SqlDbType =  SqlDbType.NVarChar,
                                    Direction =  ParameterDirection.Input,
                                    Value = processorID
                                },
                                new SqlParameter() {
                                    ParameterName = "@HDD",
                                    SqlDbType =  SqlDbType.NVarChar,
                                    Direction =  ParameterDirection.Input,
                                    Value = VolumeSlNumber
                                },
                                new SqlParameter() {
                                    ParameterName = "@MD",
                                    SqlDbType =  SqlDbType.NVarChar,
                                    Direction =  ParameterDirection.Input,
                                    Value = MacAddr
                                },

                            };

                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "INSFCO36I08";
                            cmd.Parameters.AddRange(param);
                            con.Open();

                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    sendCode = sdr["otpSend"].ToString();
                                    gridlst.Add(new OTPGrid
                                    {
                                        pHO = phoneNo,
                                        oTP_For = otpFor,
                                        lOG_In_ID = Convert.ToDecimal(sdr["uS_Id"]),
                                        uS_Nm = sdr["uS_Nm"].ToString(),
                                        tYP = Convert.ToInt32(sdr["tYP"]),
                                        oTP_Code = EncryptByAES(sdr["otpSend"].ToString()),
                                        fR_Dat = Convert.ToDateTime(sdr["fR_Dat"]),
                                        tO_Dat = Convert.ToDateTime(sdr["tO_Dat"])
                                    });
                                }

                            }
                            con.Close();


                        }
                    }
                    return gridlst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public class OTPGrid
        {
            public string pHO { get; set; }
            public string oTP_For { get; set; }
            public decimal lOG_In_ID { get; set; }
            public int tYP { get; set; }
            public string uS_Nm { get; set; }
            public string oTP_Code { get; set; }
            public DateTime fR_Dat { get; set; }
            public DateTime tO_Dat { get; set; }

        }


    }
}
