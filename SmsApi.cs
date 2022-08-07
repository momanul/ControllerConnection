using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookStorePro.CModels
{
    public class SmsApi
    {
        public SmsApi() { }


        WebRequest request = null;
        HttpWebResponse response = null;
        public void SmsSend(string recPhoneNumber, string otpText, bool isSignup)
        {
            string result = "";
            String message = "";
            try
            {
                String to = recPhoneNumber; //Recipient Phone Number multiple number must be separated by comma
                String token = "792e6150fba0efbd84e3a69dde648cd6"; //generate token from the control panel
                if (isSignup == true)
                {
                    message = System.Uri.EscapeUriString("লগইন করতে " + otpText + " কোডটি ব্যবহার করুন।\n Encash"); //do not use single quotation (') in the message to avoid forbidden result
                }

                else
                {
                    message = "";// System.Uri.EscapeUriString("Use " + otpText + " to validate your price. \n BiratHaat"); //do not use single quotation (') in the message to avoid forbidden result

                }
                String url = "http://api.greenweb.com.bd/api.php?token=" + token + "&to=" + to + "&message=" + message;
                request = WebRequest.Create(url);

                // Send the 'HttpWebRequest' and wait for response.
                response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                Encoding ec = System.Text.Encoding.GetEncoding("utf-8");
                StreamReader reader = new
                System.IO.StreamReader(stream, ec);
                result = reader.ReadToEnd();
                // Console.WriteLine(result);
                reader.Close();

                stream.Close();


            }
            catch (Exception exp)
            {
                // Console.WriteLine(exp.ToString());
            }
            finally
            {
                if (response != null)
                    response.Close();
            }

        }
    }
}

