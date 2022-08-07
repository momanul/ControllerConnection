using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BookStorePro.CModels;
using BookStorePro.Context;
using BookStorePro.Models;
using BookStorePro.Models.RptModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookStorePro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GridDataController : ControllerBase
    {



        string connectionString = "";
        private readonly IConfiguration configuration;

        public GridDataController(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("DBConnection");

        }


        [Route("ACT01001GR/pn/{pageNo}/ps/{pageSize}/sR/{searchCol?}")]
        [HttpGet]
        public async Task<ActionResult<List<ProductCategoryGrid>>> ACT01001GR(int pageNo = 1, int pageSize = 20, string searchCol = "")
        {
            decimal totRows = 0.0m;
            List<ProductCategoryGrid> gridlst = await Task.Run(() => new List<ProductCategoryGrid>());
            List<ACT01001GR> productCategory = await Task.Run(() => new List<ACT01001GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {

                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                                                 new SqlParameter() {
                            ParameterName = "@searchCol",
                            SqlDbType =  SqlDbType.NVarChar ,
                            Direction =  ParameterDirection.Input,
                            Value =  searchCol
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ACT01001GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                productCategory.Add(new ACT01001GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), sR_Nm = sdr["sR_Nm"].ToString(), cT_Cod = sdr["cT_Cod"].ToString(), Under = sdr["Under"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new ProductCategoryGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = productCategory });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("ABR02002GR/pn/{pageNo}/ps/{pageSize}/sR/{searchCol?}")]
        [HttpGet]
        public async Task<ActionResult<List<BrandGrid>>> ABR02002GR(int pageNo = 1, int pageSize = 20, string searchCol = "")
        {
            decimal totRows = 0.0m;
            List<BrandGrid> gridlst = await Task.Run(() => new List<BrandGrid>());
            List<ABR02002GR> brands = await Task.Run(() => new List<ABR02002GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },

                           new SqlParameter() {
                            ParameterName = "@searchCol",
                            SqlDbType =  SqlDbType.NVarChar ,
                            Direction =  ParameterDirection.Input,
                            Value =  searchCol
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ABR02002GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                brands.Add(new ABR02002GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), sR_Nm = sdr["sR_Nm"].ToString(), bR_Cod = sdr["bR_Cod"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new BrandGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = brands });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("AMNF0303GR/pn/{pageNo}/ps/{pageSize}/sR/{searchCol?}")]
        [HttpGet]
        public async Task<ActionResult<List<ManufacturerGrid>>> AMNF0303GR(int pageNo = 1, int pageSize = 20, string searchCol = "")
        {
            decimal totRows = 0.0m;
            List<ManufacturerGrid> gridlst = await Task.Run(() => new List<ManufacturerGrid>());
            List<AMNF0303GR> manufacturer = await Task.Run(() => new List<AMNF0303GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                         new SqlParameter() {
                            ParameterName = "@searchCol",
                            SqlDbType =  SqlDbType.NVarChar ,
                            Direction =  ParameterDirection.Input,
                            Value =  searchCol
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "AMNF0303GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {

                                manufacturer.Add(new AMNF0303GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), sR_Nm = sdr["sR_Nm"].ToString(), mNF_Cod = sdr["mNF_Cod"].ToString(), mS_Cod = sdr["mS_Cod"].ToString(),
                                    dIS = Convert.ToDecimal(sdr["dIS"]), aDDR = sdr["aDDR"].ToString(), cON = sdr["cON"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), edit = sdr["edit"].ToString() });

                            }
                        }



                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new ManufacturerGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = manufacturer });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("AFI04M04GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<FilterMasterGrid>>> AFI04M04GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<FilterMasterGrid> gridlst = await Task.Run(() => new List<FilterMasterGrid>());
            List<AFI04M04GR> filterMaster = await Task.Run(() => new List<AFI04M04GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "AFI04M04GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    filterMaster.Add(new AFI04M04GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), fM_Nm = sdr["fM_Nm"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }

                            totRows = Convert.ToDecimal(totalDataRows.Value);
                            con.Close();

                        }
                    }

                    gridlst.Add(new FilterMasterGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = filterMaster });
                    return gridlst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        [Route("AFI05V05GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<FilterValueMasterGrid>>> AFI05V05GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<FilterValueMasterGrid> gridlst = await Task.Run(() => new List<FilterValueMasterGrid>());
            List<AFI05V05GR> filterValueMaster = await Task.Run(() => new List<AFI05V05GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },

                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "AFI05V05GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                filterValueMaster.Add(new AFI05V05GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), fV_Nm = sdr["fV_Nm"].ToString(), fM_Nm = sdr["fM_Nm"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new FilterValueMasterGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = filterValueMaster });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("AGE06006GR/pn/{pageNo}/ps/{pageSize}/sR/{searchCol?}")]
        [HttpGet]
        public async Task<ActionResult<List<GenericGrid>>> AGE06006GR(int pageNo = 1, int pageSize = 20, string searchCol = "")
        {
            decimal totRows = 0.0m;
            List<GenericGrid> gridlst = await Task.Run(() => new List<GenericGrid>());
            List<AGE06006GR> generic = await Task.Run(() => new List<AGE06006GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                         new SqlParameter() {
                            ParameterName = "@searchCol",
                            SqlDbType =  SqlDbType.NVarChar ,
                            Direction =  ParameterDirection.Input,
                            Value =  searchCol
                        },
                            totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "AGE06006GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                generic.Add(new AGE06006GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), sR_Nm = sdr["sR_Nm"].ToString(), gEN_Cod = sdr["gEN_Cod"].ToString(), iSBN = sdr["iSBN"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new GenericGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = generic });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("CSCH3807GR/pn/{pageNo}/ps/{pageSize}/sR/{searchCol?}")]
        [HttpGet]
        public async Task<ActionResult<List<SchoolGrid>>> CSCH3807GR(int pageNo = 1, int pageSize = 20, string searchCol = "")
        {
            decimal totRows = 0.0m;
            List<SchoolGrid> gridlst = await Task.Run(() => new List<SchoolGrid>());
            List<CSCH3807GR> schoollist = await Task.Run(() => new List<CSCH3807GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {

                            new SqlParameter() {
                                ParameterName = "@PageNo",
                                SqlDbType =   SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value =  pageNo
                            },
                            new SqlParameter() {
                                ParameterName = "@PageSize",
                                SqlDbType =  SqlDbType.Int,
                                Direction =  ParameterDirection.Input,

                                Value = pageSize
                            },
                            new SqlParameter() {
                                ParameterName = "@searchCol",
                                SqlDbType =  SqlDbType.NVarChar ,
                                Direction =  ParameterDirection.Input,
                                Value =  searchCol
                            },
                          totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "CSCH3807GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                schoollist.Add(new CSCH3807GR { SL = Convert.ToDecimal(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), sR_Nm = sdr["sR_Nm"].ToString(), pHO = sdr["pHO"].ToString(), aDDR = sdr["aDDR"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new SchoolGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = schoollist });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("Sales_GETUPDATE/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<ChalanUpdate>>> GETUPDESA06M48(string vT_No)
        {
            List<ChalanUpdate> gridlst = await Task.Run(() => new List<ChalanUpdate>());
            M34M38M48M57CM_UPDATE m34M38M48M57CM = await Task.Run(() => new M34M38M48M57CM_UPDATE());
            List<D35D39D49D58CM_UPDATE> d35D39D49D58CM = await Task.Run(() => new List<D35D39D49D58CM_UPDATE>());
            UPDCCUS3201CM uPDCCUS3201CM = new UPDCCUS3201CM();


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                                ParameterName = "@vT_No",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  vT_No
                            },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDESA06M48";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                m34M38M48M57CM.ID = Convert.ToDecimal(sdr["ID"]);
                                m34M38M48M57CM.vT_No = sdr["vT_No"].ToString();
                                m34M38M48M57CM.iNV_No = sdr["iNV_No"].ToString();
                                m34M38M48M57CM.lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]);
                                m34M38M48M57CM.p_lGR_Id = Convert.ToDecimal(sdr["p_lGR_Id"]);
                                m34M38M48M57CM.lGR_Nm = (sdr["lGR_Nm"].ToString());
                                m34M38M48M57CM.p_lGR_Nm = (sdr["p_lGR_Nm"].ToString());
                                m34M38M48M57CM.dAT = (sdr["dAT"].ToString());
                                m34M38M48M57CM.e_Id = Convert.ToInt32(sdr["e_Id"]);
                                m34M38M48M57CM.sCUN_Id = Convert.ToDecimal(sdr["sCUN_Id"]);
                                m34M38M48M57CM.cUS_Id = Convert.ToDecimal(sdr["cUS_Id"]);
                                m34M38M48M57CM.pOS = sdr.IsDBNull(sdr.GetOrdinal("pOS")) ? false : Convert.ToBoolean(sdr["pOS"]);
                                m34M38M48M57CM.gR_Tot = Convert.ToDecimal(sdr["gR_Tot"]);
                                m34M38M48M57CM.pRE_Due = Convert.ToDecimal(sdr["pRE_Due"]);
                                m34M38M48M57CM.bIL_Dis = Convert.ToDecimal(sdr["bIL_Dis"]);
                                m34M38M48M57CM.aDD_Cst = Convert.ToDecimal(sdr["aDD_Cst"]);
                                m34M38M48M57CM.pPKT_Cst = Convert.ToDecimal(sdr["pPKT_Cst"]);
                                m34M38M48M57CM.pKT_Qty = Convert.ToDecimal(sdr["pKT_Qty"]);
                                m34M38M48M57CM.pBDL_Cst = Convert.ToDecimal(sdr["pBDL_Cst"]);
                                m34M38M48M57CM.bDL_Qty = Convert.ToDecimal(sdr["bDL_Qty"]);
                                m34M38M48M57CM.sP_Dis = Convert.ToDecimal(sdr["sP_Dis"]);
                                m34M38M48M57CM.tOT_Amt = Convert.ToDecimal(sdr["tOT_Amt"]);
                                m34M38M48M57CM.p_Amt = Convert.ToDecimal(sdr["p_Amt"]);
                            }
                        }

                        con.Close();
                        

                    }
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                                ParameterName = "@vT_No",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  vT_No
                            },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDESA07D49";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                d35D39D49D58CM.Add(new D35D39D49D58CM_UPDATE
                                {
                                    sl = Convert.ToDecimal(sdr["SL"]),
                                    id = Convert.ToDecimal(sdr["sKU_Id"]),
                                    bR_Nm = sdr["bR_Nm"].ToString(),
                                    cT_Nm = sdr["cT_Nm"].ToString(),
                                    gEN_Nm = sdr["gEN_Nm"].ToString(),
                                    mNF_Nm = sdr["mNF_Nm"].ToString(),
                                    mNF_Cod = sdr["mNF_Cod"].ToString(),
                                    sKU_Cod = sdr["sKU_Cod"].ToString(),
                                    cUR_Stok = Convert.ToDecimal(sdr["cUR_Stok"]),
                                    s_Id = Convert.ToDecimal(sdr["s_Id"]),
                                    s_Nm = sdr["s_Nm"].ToString(),
                                    uN_Id = Convert.ToDecimal(sdr["uN_Id"]),
                                    uN_Nm = sdr["uN_Nm"].ToString(),
                                    sAL_Rat = Convert.ToDecimal(sdr["sAL_Rat"]),
                                    qTY = Convert.ToDecimal(sdr["qTY"]),
                                    gR_Amt = Convert.ToDecimal(sdr["gR_Amt"]),
                                    dIS = Convert.ToDecimal(sdr["dIS"]),
                                    dIS_Tp = Convert.ToInt32(sdr["discountType"]),
                                    nET_Amt = Convert.ToDecimal(sdr["nET_Amt"])
                                });
                            }
                        }

                        con.Close();


                    }

                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@cUS_Id",
                                SqlDbType =   SqlDbType.Decimal,
                                Direction =  ParameterDirection.Input,
                                Value =  m34M38M48M57CM.cUS_Id
                            },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDCCUS3201";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                uPDCCUS3201CM.cUS_Nm = sdr["cUS_Nm"].ToString();
                                uPDCCUS3201CM.aDDr = sdr["aDDr"].ToString();
                                uPDCCUS3201CM.pHO = sdr["pHO"].ToString();

                            }
                        }

                        con.Close();

                    }

                }

                gridlst.Add(new ChalanUpdate { masterData = m34M38M48M57CM, detailData = d35D39D49D58CM, Customer = uPDCCUS3201CM });

                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Challan Return GET
        [Route("SalesRet_GETUPDATE/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<ChalanUpdate>>> GETUPDESR15M57(string vT_No)
        {
            List<ChalanUpdate> gridlst = await Task.Run(() => new List<ChalanUpdate>());
            M34M38M48M57CM_UPDATE m34M38M48M57CM = await Task.Run(() => new M34M38M48M57CM_UPDATE());
            List<D35D39D49D58CM_UPDATE> d35D39D49D58CM = await Task.Run(() => new List<D35D39D49D58CM_UPDATE>());
            UPDCCUS3201CM uPDCCUS3201CM = new UPDCCUS3201CM();


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@vT_No",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  vT_No
                        },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDESR15M57";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                m34M38M48M57CM.ID = Convert.ToDecimal(sdr["ID"]);
                                m34M38M48M57CM.vT_No = sdr["vT_No"].ToString();
                                m34M38M48M57CM.iNV_No = sdr["iNV_No"].ToString();
                                m34M38M48M57CM.lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]);
                                m34M38M48M57CM.p_lGR_Id = Convert.ToDecimal(sdr["p_lGR_Id"]);
                                m34M38M48M57CM.lGR_Nm = (sdr["lGR_Nm"].ToString());
                                m34M38M48M57CM.p_lGR_Nm = (sdr["p_lGR_Nm"].ToString());
                                m34M38M48M57CM.dAT = (sdr["dAT"].ToString());
                                m34M38M48M57CM.e_Id = Convert.ToInt32(sdr["e_Id"]);
                                m34M38M48M57CM.sCUN_Id = Convert.ToDecimal(sdr["sCUN_Id"]);
                                m34M38M48M57CM.cUS_Id = Convert.ToDecimal(sdr["cUS_Id"]);
                                m34M38M48M57CM.pOS = sdr.IsDBNull(sdr.GetOrdinal("pOS")) ? false : Convert.ToBoolean(sdr["pOS"]);
                                m34M38M48M57CM.gR_Tot = Convert.ToDecimal(sdr["gR_Tot"]);
                                m34M38M48M57CM.pRE_Due = Convert.ToDecimal(sdr["pRE_Due"]);
                                m34M38M48M57CM.bIL_Dis = Convert.ToDecimal(sdr["bIL_Dis"]);
                                m34M38M48M57CM.aDD_Cst = Convert.ToDecimal(sdr["aDD_Cst"]);
                                m34M38M48M57CM.sP_Dis = Convert.ToDecimal(sdr["sP_Dis"]);
                                m34M38M48M57CM.tOT_Amt = Convert.ToDecimal(sdr["tOT_Amt"]);
                                m34M38M48M57CM.p_Amt = Convert.ToDecimal(sdr["p_Amt"]);


                            }
                        }

                        con.Close();


                    }
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@vT_No",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  vT_No
                        },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDESR16D58";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                d35D39D49D58CM.Add(new D35D39D49D58CM_UPDATE
                                {
                                    sl = Convert.ToDecimal(sdr["SL"]),
                                    id = Convert.ToDecimal(sdr["sKU_Id"]),
                                    bR_Nm = sdr["bR_Nm"].ToString(),
                                    cT_Nm = sdr["cT_Nm"].ToString(),
                                    gEN_Nm = sdr["gEN_Nm"].ToString(),
                                    mNF_Nm = sdr["mNF_Nm"].ToString(),
                                    mNF_Cod = sdr["mNF_Cod"].ToString(),
                                    sKU_Cod = sdr["sKU_Cod"].ToString(),
                                    cUR_Stok = Convert.ToDecimal(sdr["cUR_Stok"]),
                                    s_Id = Convert.ToDecimal(sdr["s_Id"]),
                                    s_Nm = sdr["s_Nm"].ToString(),
                                    uN_Id = Convert.ToDecimal(sdr["uN_Id"]),
                                    uN_Nm = sdr["uN_Nm"].ToString(),
                                    sAL_Rat = Convert.ToDecimal(sdr["sAL_Rat"]),
                                    qTY = Convert.ToDecimal(sdr["qTY"]),
                                    gR_Amt = Convert.ToDecimal(sdr["gR_Amt"]),
                                    dIS = Convert.ToDecimal(sdr["dIS"]),
                                    dIS_Tp = Convert.ToInt32(sdr["discountType"]),
                                    nET_Amt = Convert.ToDecimal(sdr["nET_Amt"])


                                });
                            }

                        }
                        con.Close();
                    }

                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@cUS_Id",
                                SqlDbType =   SqlDbType.Decimal,
                                Direction =  ParameterDirection.Input,
                                Value =  m34M38M48M57CM.cUS_Id
                            },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDCCUS3201";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                uPDCCUS3201CM.cUS_Nm = sdr["cUS_Nm"].ToString();
                                uPDCCUS3201CM.aDDr = sdr["aDDr"].ToString();
                                uPDCCUS3201CM.pHO = sdr["pHO"].ToString();

                            }
                        }

                        con.Close();

                    }

                }

                gridlst.Add(new ChalanUpdate { masterData = m34M38M48M57CM, detailData = d35D39D49D58CM, Customer = uPDCCUS3201CM });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        [Route("Specimen_GETUPDATE/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<ChalanUpdate>>> GETUPDSpecimen(string vT_No)
        {
            List<ChalanUpdate> gridlst = await Task.Run(() => new List<ChalanUpdate>());
            M34M38M48M57CM_UPDATE specimen = await Task.Run(() => new M34M38M48M57CM_UPDATE());
            List<D35D39D49D58CM_UPDATE> updateest23p65 = await Task.Run(() => new List<D35D39D49D58CM_UPDATE>());
            UPDCCUS3201CM uPDCCUS3201CM = new UPDCCUS3201CM();


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                                ParameterName = "@vT_No",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  vT_No
                            },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDELG61P03";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                specimen.ID = Convert.ToDecimal(sdr["ID"]);
                                specimen.vT_No = sdr["vT_No"].ToString();
                                specimen.lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]);
                                specimen.lGR_Nm = (sdr["lGR_Nm"].ToString());
                                specimen.dAT = (sdr["dAT"].ToString());
                                specimen.cUS_Id = Convert.ToDecimal(sdr["cUS_Id"]);
                                specimen.tOT_Amt = Convert.ToDecimal(sdr["tOT_Amt"]);


                            }
                        }

                        con.Close();


                    }
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                                ParameterName = "@vT_No",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  vT_No
                            },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDEST23P65";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                updateest23p65.Add(new D35D39D49D58CM_UPDATE
                                {
                                    sl = Convert.ToDecimal(sdr["SL"]),
                                    id = Convert.ToDecimal(sdr["sKU_Id"]),
                                    bR_Nm = sdr["bR_Nm"].ToString(),
                                    cT_Nm = sdr["cT_Nm"].ToString(),
                                    gEN_Nm = sdr["gEN_Nm"].ToString(),
                                    mNF_Nm = sdr["mNF_Nm"].ToString(),
                                    mNF_Cod = sdr["mNF_Cod"].ToString(),
                                    sKU_Cod = sdr["sKU_Cod"].ToString(),
                                    cUR_Stok = Convert.ToDecimal(sdr["cUR_Stok"]),
                                    uN_Id = Convert.ToDecimal(sdr["uN_Id"]),
                                    uN_Nm = sdr["uN_Nm"].ToString(),
                                    pUR_Rat = Convert.ToDecimal(sdr["pUR_Rat"]),
                                    qTY = Convert.ToDecimal(sdr["qTY"])
                                });
                            }
                        }

                        con.Close();


                    }

                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@cUS_Id",
                                SqlDbType =   SqlDbType.Decimal,
                                Direction =  ParameterDirection.Input,
                                Value =  specimen.cUS_Id
                            },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDCCUS3201";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                uPDCCUS3201CM.cUS_Nm = sdr["cUS_Nm"].ToString();
                                uPDCCUS3201CM.aDDr = sdr["aDDr"].ToString();
                                uPDCCUS3201CM.pHO = sdr["pHO"].ToString();

                            }
                        }

                        con.Close();

                    }

                }

                gridlst.Add(new ChalanUpdate { masterData = specimen, detailData = updateest23p65, Customer = uPDCCUS3201CM });

                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        //Purchase GET
        [Route("Purchase_GETUPDATE/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<ChalanUpdate>>> GETUPDEPC92M34(string vT_No)
        {
            List<ChalanUpdate> gridlst = await Task.Run(() => new List<ChalanUpdate>());
            M34M38M48M57CM_UPDATE m34M38M48M57CM = await Task.Run(() => new M34M38M48M57CM_UPDATE());
            List<D35D39D49D58CM_UPDATE> d35D39D49D58CM = await Task.Run(() => new List<D35D39D49D58CM_UPDATE>());


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@vT_No",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  vT_No
                            },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDEPC92M34";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                m34M38M48M57CM.ID = Convert.ToDecimal(sdr["ID"]);
                                m34M38M48M57CM.vT_No = sdr["vT_No"].ToString();
                                m34M38M48M57CM.iNV_No = sdr["iNV_No"].ToString();
                                m34M38M48M57CM.lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]);
                                m34M38M48M57CM.p_lGR_Id = Convert.ToDecimal(sdr["p_lGR_Id"]);
                                m34M38M48M57CM.lGR_Nm = (sdr["lGR_Nm"].ToString());
                                m34M38M48M57CM.p_lGR_Nm = (sdr["p_lGR_Nm"].ToString());
                                m34M38M48M57CM.dAT = (sdr["dAT"].ToString());
                                m34M38M48M57CM.e_Id = Convert.ToInt32(sdr["e_Id"]);
                                m34M38M48M57CM.gR_Tot = Convert.ToDecimal(sdr["gR_Tot"]);
                                m34M38M48M57CM.bIL_Dis = Convert.ToDecimal(sdr["bIL_Dis"]);
                                m34M38M48M57CM.aDD_Cst = Convert.ToDecimal(sdr["aDD_Cst"]);
                                m34M38M48M57CM.sP_Dis = Convert.ToDecimal(sdr["sP_Dis"]);
                                m34M38M48M57CM.tOT_Amt = Convert.ToDecimal(sdr["tOT_Amt"]);
                                m34M38M48M57CM.p_Amt = Convert.ToDecimal(sdr["p_Amt"]);

                            }
                        }

                        con.Close();


                    }
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                                ParameterName = "@vT_No",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  vT_No
                            },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDEPC93D35";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                d35D39D49D58CM.Add(new D35D39D49D58CM_UPDATE
                                {
                                    sl = Convert.ToDecimal(sdr["SL"]),
                                    id = Convert.ToDecimal(sdr["sKU_Id"]),
                                    bR_Nm = sdr["bR_Nm"].ToString(),
                                    cT_Nm = sdr["cT_Nm"].ToString(),
                                    gEN_Nm = sdr["gEN_Nm"].ToString(),
                                    mNF_Nm = sdr["mNF_Nm"].ToString(),
                                    mNF_Cod = sdr["mNF_Cod"].ToString(),
                                    sKU_Cod = sdr["sKU_Cod"].ToString(),
                                    cUR_Stok = Convert.ToDecimal(sdr["cUR_Stok"]),
                                    s_Id = Convert.ToDecimal(sdr["s_Id"]),
                                    s_Nm = sdr["s_Nm"].ToString(),
                                    uN_Id = Convert.ToDecimal(sdr["uN_Id"]),
                                    uN_Nm = sdr["uN_Nm"].ToString(),
                                    pUR_Rat = Convert.ToDecimal(sdr["pUR_Rat"]),
                                    qTY = Convert.ToDecimal(sdr["qTY"]),
                                    gR_Amt = Convert.ToDecimal(sdr["gR_Amt"]),
                                    dIS = Convert.ToDecimal(sdr["dIS"]),
                                    dIS_Tp = Convert.ToInt32(sdr["discountType"]),
                                    nET_Amt = Convert.ToDecimal(sdr["nET_Amt"])


                                });
                            }
                        }

                        con.Close();


                    }

                }


                gridlst.Add(new ChalanUpdate { masterData = m34M38M48M57CM, detailData = d35D39D49D58CM });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Purchase Return GET
        [Route("PurchaseRET_GETUPDATE/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<ChalanUpdate>>> GETUPDEPR96M38(string vT_No)
        {
            List<ChalanUpdate> gridlst = await Task.Run(() => new List<ChalanUpdate>());
            M34M38M48M57CM_UPDATE m34M38M48M57CM = await Task.Run(() => new M34M38M48M57CM_UPDATE());
            List<D35D39D49D58CM_UPDATE> d35D39D49D58CM = await Task.Run(() => new List<D35D39D49D58CM_UPDATE>());

            //warrantyTime warranty = new warrantyTime();


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@vT_No",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  vT_No
                            },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDEPR96M38";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                m34M38M48M57CM.ID = Convert.ToDecimal(sdr["ID"]);
                                m34M38M48M57CM.vT_No = sdr["vT_No"].ToString();
                                m34M38M48M57CM.iNV_No = sdr["iNV_No"].ToString();
                                m34M38M48M57CM.lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]);
                                m34M38M48M57CM.p_lGR_Id = Convert.ToDecimal(sdr["p_lGR_Id"]);
                                m34M38M48M57CM.lGR_Nm = (sdr["lGR_Nm"].ToString());
                                m34M38M48M57CM.p_lGR_Nm = (sdr["p_lGR_Nm"].ToString());
                                m34M38M48M57CM.dAT = (sdr["dAT"].ToString());
                                m34M38M48M57CM.e_Id = Convert.ToInt32(sdr["e_Id"]);
                                m34M38M48M57CM.gR_Tot = Convert.ToDecimal(sdr["gR_Tot"]);
                                m34M38M48M57CM.bIL_Dis = Convert.ToDecimal(sdr["bIL_Dis"]);
                                m34M38M48M57CM.aDD_Cst = Convert.ToDecimal(sdr["aDD_Cst"]);
                                m34M38M48M57CM.sP_Dis = Convert.ToDecimal(sdr["sP_Dis"]);
                                m34M38M48M57CM.tOT_Amt = Convert.ToDecimal(sdr["tOT_Amt"]);
                                m34M38M48M57CM.p_Amt = Convert.ToDecimal(sdr["p_Amt"]);


                            }
                        }

                        con.Close();


                    }
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@vT_No",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  vT_No
                            },
                        };


                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDEPR97D39";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                d35D39D49D58CM.Add(new D35D39D49D58CM_UPDATE
                                {
                                    sl = Convert.ToDecimal(sdr["SL"]),
                                    id = Convert.ToDecimal(sdr["sKU_Id"]),
                                    bR_Nm = sdr["bR_Nm"].ToString(),
                                    cT_Nm = sdr["cT_Nm"].ToString(),
                                    gEN_Nm = sdr["gEN_Nm"].ToString(),
                                    mNF_Nm = sdr["mNF_Nm"].ToString(),
                                    mNF_Cod = sdr["mNF_Cod"].ToString(),
                                    sKU_Cod = sdr["sKU_Cod"].ToString(),
                                    cUR_Stok = Convert.ToDecimal(sdr["cUR_Stok"]),
                                    s_Id = Convert.ToDecimal(sdr["s_Id"]),
                                    s_Nm = sdr["s_Nm"].ToString(),
                                    uN_Id = Convert.ToDecimal(sdr["uN_Id"]),
                                    uN_Nm = sdr["uN_Nm"].ToString(),
                                    pUR_Rat = Convert.ToDecimal(sdr["pUR_Rat"]),
                                    qTY = Convert.ToDecimal(sdr["qTY"]),
                                    gR_Amt = Convert.ToDecimal(sdr["gR_Amt"]),
                                    dIS = Convert.ToDecimal(sdr["dIS"]),
                                    dIS_Tp = Convert.ToInt32(sdr["discountType"]),
                                    nET_Amt = Convert.ToDecimal(sdr["nET_Amt"])

                                });
                            }
                        }
                        con.Close();
                    }
                }

                gridlst.Add(new ChalanUpdate { masterData = m34M38M48M57CM, detailData = d35D39D49D58CM });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("ASKU0707GR/pn/{pageNo}/ps/{pageSize}/{sKU_Cod}/{gEN_Id}/{bR_Id}/{cT_Id}/{mNF_Id}/sR/{searchCol?}")]
        [HttpGet]
        public async Task<ActionResult<List<ProductSKUGrid>>> ASKU0707GR(int pageNo, int pageSize, string sKU_Cod, string bR_Id, string cT_Id, string gEN_Id, string mNF_Id, string searchCol = "")
        {
            decimal totRows = 0.0m;
            List<ProductSKUGrid> gridlst = await Task.Run(() => new List<ProductSKUGrid>());
            List<ASKU0707GR> productSKU = await Task.Run(() => new List<ASKU0707GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@PageNo",
                                SqlDbType =   SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value =  pageNo
                            },
                            new SqlParameter() {
                                ParameterName = "@PageSize",
                                SqlDbType =  SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value = pageSize
                            },
                            new SqlParameter() {
                                ParameterName = "@sKU_Cod",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  sKU_Cod
                            },

                            new SqlParameter() {
                                ParameterName = "@bR_Id",
                                SqlDbType =  SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value = bR_Id
                            },
                            new SqlParameter() {
                                ParameterName = "@cT_Id",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  cT_Id
                            },
                            new SqlParameter() {
                                ParameterName = "@gEN_Id",
                                SqlDbType =  SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value = gEN_Id
                            },

                            new SqlParameter() {
                                ParameterName = "@mNF_Id",
                                SqlDbType =  SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value = mNF_Id
                            },
                            new SqlParameter() {
                                ParameterName = "@searchCol",
                                SqlDbType =  SqlDbType.NVarChar ,
                                Direction =  ParameterDirection.Input,
                                Value =  searchCol
                            },
                          totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ASKU0707GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    productSKU.Add(new ASKU0707GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), sKU_Cod = sdr["sKU_Cod"].ToString(), pR_Cod = sdr["pR_Cod"].ToString(), mNF_Nm = sdr["mNF_Nm"].ToString(), cT_Nm = sdr["cT_Nm"].ToString(), bR_Nm = sdr["bR_Nm"].ToString(), gEN_Nm = sdr["gEN_Nm"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new ProductSKUGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = productSKU });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("GETASKU0707/pn/{pageNo}/ps/{pageSize}/{sKU_Cod}/{gEN_Id}/{bR_Id}/{cT_Id}/{mNF_Id}/sR/{searchCol?}")]
        [HttpGet]
        public async Task<ActionResult<List<SearchFilterGrid>>> GETASKU0707(int pageNo, int pageSize, string sKU_Cod, string bR_Id, string cT_Id, string gEN_Id, string mNF_Id, string searchCol = "")
       {
            decimal totRows = 0.0m;


            List<SearchFilterGrid> gridlst = await Task.Run(() => new List<SearchFilterGrid>());
            List<GETASKU0707> searchFilter = await Task.Run(() => new List<GETASKU0707>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value = pageSize
                        },
                        new SqlParameter() {
                            ParameterName = "@sKU_Cod",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  sKU_Cod
                        },

                        new SqlParameter() {
                            ParameterName = "@bR_Id",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value = bR_Id
                        },
                        new SqlParameter() {
                            ParameterName = "@cT_Id",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  cT_Id
                        },
                        new SqlParameter() {
                            ParameterName = "@gEN_Id",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value = gEN_Id
                        },

                        new SqlParameter() {
                            ParameterName = "@mNF_Id",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value = mNF_Id
                        },
                        new SqlParameter() {
                            ParameterName = "@searchCol",
                            SqlDbType =  SqlDbType.NVarChar ,
                            Direction =  ParameterDirection.Input,
                            Value =  searchCol
                        },

                        totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETASKU0707GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {

                            while (sdr.Read())
                            {
                                searchFilter.Add(new GETASKU0707
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    ID = Convert.ToDecimal(sdr["ID"]),
                                    mNF_Nm = sdr["mNF_Nm"].ToString(),
                                    mNF_Cod = sdr["mNF_Cod"].ToString(),
                                    gEN_Nm = sdr["gEN_Nm"].ToString(),
                                    cT_Nm = sdr["cT_Nm"].ToString(),
                                    bR_Nm = sdr["bR_Nm"].ToString(),
                                    sKU_Cod = sdr["sKU_Cod"].ToString(),
                                    cUR_Stok = Convert.ToDecimal(sdr["cUR_Stok"]),
                                    uN_Id = Convert.ToInt32(sdr["uN_Id"]),
                                    uN_Nm = sdr["uN_Nm"].ToString(),
                                    pUR_Rat = Convert.ToDecimal(sdr["pUR_Rat"]),
                                    sAL_Rat = Convert.ToDecimal(sdr["sAL_Rat"]),
                                    mRP = Convert.ToDecimal(sdr["mRP"]),
                                    lstPurRate = Convert.ToDecimal(sdr["lstPurRate"]),
                                    uNC_ID = Convert.ToDecimal(sdr["uNC_ID"]),
                                    conUnit = sdr["conUnit"].ToString(),
                                    conRate = Convert.ToDecimal(sdr["conRate"]),
                                    dIS = Convert.ToDecimal(sdr["dIS"]),
                                    dIS_Tp = Convert.ToInt32(sdr["dIS_Tp"]),
                                    p_dIS = Convert.ToDecimal(sdr["p_dIS"]),
                                    qTY = Convert.ToDecimal(sdr["qTY"]),
                                    rEO = Convert.ToDecimal(sdr["rEO"])

                                });
                            }

                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();


                    }
                }

                gridlst.Add(new SearchFilterGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = searchFilter });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //for product rate Grid
        [Route("GETAPR13R13GR/pn/{pageNo}/ps/{pageSize}/{sKU_Cod}/{gEN_Id}/{bR_Id}/{cT_Id}/{mNF_Id}")]
        [HttpGet]
        public async Task<ActionResult<List<GetProductrateGrid>>> GETAPR13R13GR(int pageNo, int pageSize, string sKU_Cod, string bR_Id, string cT_Id, string gEN_Id, string mNF_Id)
        {
            decimal totRows = 0.0m;
            List<GetProductrateGrid> gridlst = await Task.Run(() => new List<GetProductrateGrid>());
            List<GETASKU0707> prodactRateGR = await Task.Run(() => new List<GETASKU0707>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                        new SqlParameter() {
                            ParameterName = "@sKU_Cod",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  sKU_Cod
                        },

                        new SqlParameter() {
                            ParameterName = "@bR_Id",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value = bR_Id
                        },
                        new SqlParameter() {
                            ParameterName = "@cT_Id",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  cT_Id
                        },
                        new SqlParameter() {
                            ParameterName = "@gEN_Id",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,

                            Value = gEN_Id
                        },

                        new SqlParameter() {
                            ParameterName = "@mNF_Id",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value = mNF_Id
                        },

                        totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETAPR13R13GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {

                            while (sdr.Read())
                            {
                                prodactRateGR.Add(new GETASKU0707
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    ID = Convert.ToDecimal(sdr["ID"]),
                                    mNF_Nm = sdr["mNF_Nm"].ToString(),
                                    mNF_Cod = sdr["mNF_Cod"].ToString(),
                                    gEN_Nm = sdr["gEN_Nm"].ToString(),
                                    cT_Nm = sdr["cT_Nm"].ToString(),
                                    bR_Nm = sdr["bR_Nm"].ToString(),
                                    sKU_Cod = sdr["sKU_Cod"].ToString(),
                                    cUR_Stok = Convert.ToDecimal(sdr["cUR_Stok"]),
                                    uN_Id = Convert.ToInt32(sdr["uN_Id"]),
                                    uN_Nm = sdr["uN_Nm"].ToString(),
                                    pUR_Rat = Convert.ToDecimal(sdr["pUR_Rat"]),
                                    sAL_Rat = Convert.ToDecimal(sdr["sAL_Rat"]),
                                    lstPurRate = Convert.ToDecimal(sdr["lstPurRate"]),
                                    dIS_Tp = Convert.ToInt32(sdr["dIS_Tp"]),
                                    dIS = Convert.ToDecimal(sdr["dIS"]),
                                    qTY = Convert.ToDecimal(sdr["qTY"]),
                                    rEO = Convert.ToDecimal(sdr["rEO"])

                                });
                            }

                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new GetProductrateGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = prodactRateGR });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("GETBKASKU07007/{sKU_Id}")]
        [HttpGet]
        public async Task<ActionResult<List<GETBKASKU07007>>> GETBKASKU07007(decimal sKU_Id)
        {
            List<GETBKASKU07007> gETBKASKU07007 = await Task.Run(() => new List<GETBKASKU07007>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@sKU_Id";
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Decimal;
                        param.Value = sKU_Id;


                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETBKASKU07007";
                        cmd.Parameters.Add(param);
                        con.Open();


                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    gETBKASKU07007.Add(new GETBKASKU07007
                                    {
                                        SL = Convert.ToDecimal(sdr["sl"]),
                                        sKU_Id = Convert.ToDecimal(sdr["sKU_Id"]),
                                        gEN_Nm = sdr["gEN_Nm"].ToString(),
                                        mNF_Nm = sdr["mNF_Nm"].ToString(),
                                        cT_Nm = sdr["cT_Nm"].ToString(),
                                        sAL_Rat = Convert.ToDecimal(sdr["sAL_Rat"]),
                                        dIS = Convert.ToDecimal(sdr["dIS"])
                                    });

                                }
                            }
                        }

                        con.Close();

                    }
                }

                return gETBKASKU07007;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("GETBKProduct/{sC_Id}/{cT_Id}/{sKU_Cod}")]
        [HttpGet]
        public async Task<ActionResult<List<GETBKASKU07007>>> GETBKProduct(decimal sC_Id, int cT_Id, string sKU_Cod)
        {
            List<GETBKASKU07007> gETBKASKU07007 = await Task.Run(() => new List<GETBKASKU07007>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@sC_Id",
                                SqlDbType =   SqlDbType.Decimal,
                                Direction =  ParameterDirection.Input,
                                Value =  sC_Id
                            },
                            new SqlParameter() {
                                ParameterName = "@cT_Id",
                                SqlDbType =  SqlDbType.Int,
                                Direction =  ParameterDirection.Input,

                                Value = cT_Id
                            },
                            new SqlParameter() {
                                ParameterName = "@sKU_Cod",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  sKU_Cod
                            }

                        };


                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETBKProduct";
                        cmd.Parameters.AddRange(param);
                        con.Open();


                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    gETBKASKU07007.Add(new GETBKASKU07007
                                    {
                                        SL = Convert.ToDecimal(sdr["sl"]),
                                        bLM_Id = Convert.ToDecimal(sdr["bLM_Id"]),
                                        sKU_Id = Convert.ToDecimal(sdr["sKU_Id"]),
                                        gEN_Nm = sdr["gEN_Nm"].ToString(),
                                        mNF_Nm = sdr["mNF_Nm"].ToString(),
                                        cT_Nm = sdr["cT_Nm"].ToString(),
                                        sKU_Cod = sdr["sKU_Cod"].ToString(),
                                        uN_Id = Convert.ToInt32(sdr["uN_Id"]),
                                        sAL_Rat = Convert.ToDecimal(sdr["sAL_Rat"]),
                                        dIS = Convert.ToDecimal(sdr["dIS"]),
                                        dIS_Amt = Convert.ToDecimal(sdr["sAL_Rat"]) * Convert.ToDecimal(sdr["dIS"]) / 100,
                                        total = Convert.ToDecimal(sdr["sAL_Rat"]) - (Convert.ToDecimal(sdr["sAL_Rat"]) * Convert.ToDecimal(sdr["dIS"]) / 100),
                                    });

                                }
                            }
                        }

                        con.Close();

                    }
                }

                return gETBKASKU07007;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("ABK39L22GR/pn/{pageNo}/ps/{pageSize}/{sC_Id}/{cT_Id}/{sKU_Cod}")]
        [HttpGet]
        public async Task<ActionResult<List<BookListGrid>>> GETABK39L22GR(int pageNo, int pageSize, decimal sC_Id, int cT_Id, string sKU_Cod)
        {
            decimal totRows = 0.0m;
            List<BookListGrid> gridlst = await Task.Run(() => new List<BookListGrid>());
            List<ABK39L22GR> bookList = await Task.Run(() => new List<ABK39L22GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@PageNo",
                                SqlDbType =   SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value =  pageNo
                            },
                            new SqlParameter() {
                                ParameterName = "@PageSize",
                                SqlDbType =  SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value = pageSize
                            },
                            new SqlParameter() {
                                ParameterName = "@sC_Id",
                                SqlDbType =   SqlDbType.Decimal,
                                Direction =  ParameterDirection.Input,
                                Value =  sC_Id
                            },
                            new SqlParameter() {
                                ParameterName = "@cT_Id",
                                SqlDbType =  SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value = cT_Id
                            },
                            new SqlParameter() {
                                ParameterName = "@sKU_Cod",
                                SqlDbType =  SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value = sKU_Cod
                            },

                            totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ABK39L22GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    bookList.Add(new ABK39L22GR
                                    {
                                        SL = Convert.ToDecimal(sdr["SL"]),
                                        ID = Convert.ToDecimal(sdr["ID"]),
                                        sC_Nm = sdr["sC_Nm"].ToString(),
                                        cT_Nm = sdr["cT_Nm"].ToString(),
                                        sKU_Cod = sdr["sKU_Cod"].ToString(),
                                        qTY = Convert.ToDecimal(sdr["qTY"])
                                    });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new BookListGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = bookList });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("ABK40D23GR/{bLM_Id}")]
        [HttpGet]
        public async Task<ActionResult<List<ABK40D23GR>>> GETABK40D23GR(decimal bLM_Id)
        {

            List<ABK40D23GR> detailslist = await Task.Run(() => new List<ABK40D23GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@bLM_Id";
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Decimal;
                        param.Value = bLM_Id;


                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ABK40D23GR";
                        cmd.Parameters.Add(param);
                        con.Open();


                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    detailslist.Add(new ABK40D23GR
                                    {
                                        SL = Convert.ToDecimal(sdr["SL"]),
                                        ID = Convert.ToDecimal(sdr["ID"]),
                                        bLM_Id = Convert.ToInt32(sdr["bLM_Id"]),
                                        sKU_Id = Convert.ToDecimal(sdr["sKU_Id"]),
                                        gEN_Nm = sdr["gEN_Nm"].ToString(),
                                        mNF_Nm = sdr["mNF_Nm"].ToString(),
                                        mRP = Convert.ToDecimal(sdr["mRP"]),
                                        dIS = Convert.ToDecimal(sdr["dIS"])

                                    });

                                }
                            }
                        }

                        con.Close();

                    }
                }

                return detailslist;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("GETUPDABK39L22/{bLM_Id}")]
        [HttpGet]
        public async Task<ActionResult<List<BookListUpdate>>> GETUPDABK39L22(decimal bLM_Id)
        {
            List<BookListUpdate> gridlst = await Task.Run(() => new List<BookListUpdate>());
            ABK39L22GR aBK39L22GR = await Task.Run(() => new ABK39L22GR());
            List<ABK40D23GR> aBK40D23GR = await Task.Run(() => new List<ABK40D23GR>());


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@bLM_Id",
                            SqlDbType =   SqlDbType.Decimal,
                            Direction =  ParameterDirection.Input,
                            Value =  bLM_Id
                            },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDABK39L22";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                aBK39L22GR.SL = Convert.ToDecimal(sdr["SL"]);
                                aBK39L22GR.ID = Convert.ToDecimal(sdr["ID"]);
                                aBK39L22GR.sC_Id = Convert.ToDecimal(sdr["sC_Id"]);
                                aBK39L22GR.sC_Nm = sdr["sC_Nm"].ToString();
                                aBK39L22GR.cT_Id = Convert.ToInt32(sdr["cT_Id"]);
                                aBK39L22GR.cT_Nm = sdr["cT_Nm"].ToString();
                                aBK39L22GR.sKU_Cod = sdr["sKU_Cod"].ToString();
                                aBK39L22GR.qTY = Convert.ToDecimal(sdr["qTY"]);

                            }
                        }

                        con.Close();


                    }
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                                ParameterName = "@bLM_Id",
                                SqlDbType =   SqlDbType.Decimal,
                                Direction =  ParameterDirection.Input,
                                Value =  bLM_Id
                            },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ABK40D23GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                aBK40D23GR.Add(new ABK40D23GR
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    ID = Convert.ToDecimal(sdr["ID"]),
                                    bLM_Id = Convert.ToInt32(sdr["bLM_Id"]),
                                    sKU_Id = Convert.ToDecimal(sdr["sKU_Id"]),
                                    gEN_Nm = sdr["gEN_Nm"].ToString(),
                                    mNF_Nm = sdr["mNF_Nm"].ToString(),
                                    mRP = Convert.ToDecimal(sdr["mRP"]),
                                    dIS = Convert.ToDecimal(sdr["dIS"])


                                });
                            }
                        }

                        con.Close();


                    }

                }


                gridlst.Add(new BookListUpdate { masterData = aBK39L22GR, detailData = aBK40D23GR });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("AUN10010GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<UnitGrid>>> AUN10010GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<UnitGrid> gridlst = await Task.Run(() => new List<UnitGrid>());
            List<AUN10010GR> unit = await Task.Run(() => new List<AUN10010GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "AUN10010GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    unit.Add(new AUN10010GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), uN_Nm = sdr["uN_Nm"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new UnitGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = unit });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("AUN11C11GR/pn/{pageNo}/ps/{pageSize}/sR/{searchCol?}")]
        [HttpGet]
        public async Task<ActionResult<List<UnitConversionGrid>>> AUN11C11GR(int pageNo = 1, int pageSize = 20, string searchCol = "")
        {
            decimal totRows = 0.0m;
            List<UnitConversionGrid> gridlst = await Task.Run(() => new List<UnitConversionGrid>());
            List<AUN11C11GR> unitConversion = await Task.Run(() => new List<AUN11C11GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                          new SqlParameter() {
                            ParameterName = "@searchCol",
                            SqlDbType =  SqlDbType.NVarChar ,
                            Direction =  ParameterDirection.Input,
                            Value =  searchCol
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "AUN11C11GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                unitConversion.Add(new AUN11C11GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), mNF_Nm = sdr["mNF_Nm"].ToString(), gEN_Nm = sdr["gEN_Nm"].ToString(), bR_Nm = sdr["bR_Nm"].ToString(), cT_Nm = sdr["cT_Nm"].ToString(), uU_Qty = Convert.ToDecimal(sdr["uU_Qty"]), UpUnit = sdr["UpUnit"].ToString(), lU_Qty = Convert.ToDecimal(sdr["lU_Qty"]), LoUnit = sdr["LoUnit"].ToString() });
                            }
                        }
                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new UnitConversionGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = unitConversion });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("AST14R14GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<StandardRateGrid>>> AST14R14GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<StandardRateGrid> gridlst = await Task.Run(() => new List<StandardRateGrid>());
            List<AST14R14GR> standardRate = await Task.Run(() => new List<AST14R14GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "AST14R14GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    standardRate.Add(new AST14R14GR { SL = Convert.ToDecimal(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), sKU_Cod = sdr["sKU_Cod"].ToString(), bCH_Cod = sdr["bCH_Cod"].ToString(), uN_Nm = sdr["uN_Nm"].ToString(), sND_Rat = Convert.ToDecimal(sdr["sND_Rat"]), ADAT_From = Convert.ToDateTime(sdr["ADAT_From"]), ADAT_To = Convert.ToDateTime(sdr["ADAT_To"]), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });

                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new StandardRateGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = standardRate });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("ABAR1616GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<BarcodeGrid>>> ABAR1616GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<BarcodeGrid> gridlst = await Task.Run(() => new List<BarcodeGrid>());
            List<ABAR1616GR> barcode = await Task.Run(() => new List<ABAR1616GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ABAR1616GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    barcode.Add(new ABAR1616GR { SL = Convert.ToDecimal(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), bAR_Cod = sdr["bAR_Cod"].ToString(), sKU_Cod = sdr["sKU_Cod"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });

                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new BarcodeGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = barcode });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("ABCH1717GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<BatchGrid>>> ABCH1717GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<BatchGrid> gridlst = await Task.Run(() => new List<BatchGrid>());
            List<ABCH1717GR> batch = await Task.Run(() => new List<ABCH1717GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ABCH1717GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    batch.Add(new ABCH1717GR { SL = Convert.ToDecimal(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), bCH_Cod = sdr["bCH_Cod"].ToString(), sKU_Cod = sdr["sKU_Cod"].ToString(), mFG_Dat = Convert.ToDateTime(sdr["mFG_Dat"]), eXP_Dat = Convert.ToDateTime(sdr["eXP_Dat"]), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });

                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new BatchGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = batch });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        [Route("BST18001GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<StoreGrid>>> BST18001GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<StoreGrid> gridlst = await Task.Run(() => new List<StoreGrid>());
            List<BST18001GR> store = await Task.Run(() => new List<BST18001GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BST18001GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                store.Add(new BST18001GR { SL = Convert.ToDecimal(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), s_Nm = sdr["s_Nm"].ToString(), under = sdr["under"].ToString(), s_Loc = sdr["s_Loc"].ToString(), cON_Num = sdr["cON_Num"].ToString(), eMAL = sdr["eMAL"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new StoreGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = store });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("BST20R03GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<StoreRequisitionGrid>>> BST20R03GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<StoreRequisitionGrid> gridlst = await Task.Run(() => new List<StoreRequisitionGrid>());
            List<BST20R03GR> storeRequisition = await Task.Run(() => new List<BST20R03GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BST20R03GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                storeRequisition.Add(new BST20R03GR { SL = Convert.ToDecimal(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), s_Nm = sdr["s_Nm"].ToString(), e_Name = sdr["e_Name"].ToString(), dAT = Convert.ToDateTime(sdr["dAT"]).ToString("dd-MM-yyyy"), sR_Ttl = sdr["sR_Ttl"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new StoreRequisitionGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = storeRequisition });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("BST24M07GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<StockMovmentGrid>>> BST24M07GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<StockMovmentGrid> gridlst = await Task.Run(() => new List<StockMovmentGrid>());
            List<BST24M07GR> stockMovment = await Task.Run(() => new List<BST24M07GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BST24M07GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                stockMovment.Add(new BST24M07GR { SL = Convert.ToDecimal(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), m_Ttl = sdr["m_Ttl"].ToString(), dAT = Convert.ToDateTime(sdr["dAT"]).ToString("dd-MM-yyyy"), m_Re = sdr["m_Re"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new StockMovmentGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = stockMovment });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("BSA26C09GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<SalesCounterGrid>>> BSA26C09GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<SalesCounterGrid> gridlst = await Task.Run(() => new List<SalesCounterGrid>());
            List<BSA26C09GR> salesCounter = await Task.Run(() => new List<BSA26C09GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BSA26C09GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                salesCounter.Add(new BSA26C09GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), dMR_Nm = sdr["dMR_Nm"].ToString(), sCUN_Nm = sdr["sCUN_Nm"].ToString(), sCUN_Addr = sdr["sCUN_Addr"].ToString(), cON_Num = sdr["cON_Num"].ToString(), cON_Per = sdr["cON_Per"].ToString(), eMAL = sdr["eMAL"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new SalesCounterGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = salesCounter });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("BDMR2710GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<DemarcationGrid>>> BDMR2710GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<DemarcationGrid> gridlst = await Task.Run(() => new List<DemarcationGrid>());
            List<BDMR2710GR> demarcation = await Task.Run(() => new List<BDMR2710GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BDMR2710GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    demarcation.Add(new BDMR2710GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), dMR_Nm = sdr["dMR_Nm"].ToString(), under = sdr["under"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new DemarcationGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = demarcation });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("BDA28T11GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<DeliveryAgentTypeGrid>>> BDA28T11GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<DeliveryAgentTypeGrid> gridlst = await Task.Run(() => new List<DeliveryAgentTypeGrid>());
            List<BDA28T11GR> deliveryAgentType = await Task.Run(() => new List<BDA28T11GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BDA28T11GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                deliveryAgentType.Add(new BDA28T11GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), dAGT_Nm = sdr["dAGT_Nm"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();


                    }
                }

                gridlst.Add(new DeliveryAgentTypeGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = deliveryAgentType });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [Route("BDL29A12GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<DeliveryAgentGrid>>> BDL29A12GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<DeliveryAgentGrid> gridlst = await Task.Run(() => new List<DeliveryAgentGrid>());
            List<BDL29A12GR> deliveryAgent = await Task.Run(() => new List<BDL29A12GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BDL29A12GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    deliveryAgent.Add(new BDL29A12GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), dAGT_Nm = sdr["dAGT_Nm"].ToString(), dAG_Nm = sdr["dAG_Nm"].ToString(), dAG_Addr = sdr["dAG_Addr"].ToString(), cON_Num = sdr["cON_Num"].ToString(), cON_Per = sdr["cON_Per"].ToString(), eMAL = sdr["eMAL"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new DeliveryAgentGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = deliveryAgent });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("BAG30R13GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<AgentRateGrid>>> BAG30R13GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<AgentRateGrid> gridlst = await Task.Run(() => new List<AgentRateGrid>());
            List<BAG30R13GR> agentRate = await Task.Run(() => new List<BAG30R13GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BAG30R13GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                agentRate.Add(new BAG30R13GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), dAG_Nm = sdr["dAG_Nm"].ToString(), cH_Amt = Convert.ToDecimal(sdr["cH_Amt"]), sTR_Place = sdr["sTR_Place"].ToString(), dST_Place = sdr["dST_Place"].ToString(), uN_Nm = sdr["uN_Nm"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new AgentRateGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = agentRate });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("BCLM3114GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<ClaimGrid>>> BCLM3114GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<ClaimGrid> gridlst = await Task.Run(() => new List<ClaimGrid>());
            List<BCLM3114GR> claim = await Task.Run(() => new List<BCLM3114GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BCLM3114GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    claim.Add(new BCLM3114GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), dAG_Nm = sdr["dAG_Nm"].ToString(), sKU_Cod = sdr["sKU_Cod"].ToString(), cLIM = sdr["cLIM"].ToString(), cLIM_Dat = Convert.ToDateTime(sdr["cLIM_Dat"]), qTY = Convert.ToDecimal(sdr["qTY"]), uN_Nm = sdr["uN_Nm"].ToString(), uN_Pr = Convert.ToDecimal(sdr["uN_Pr"]), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new ClaimGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = claim });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("BOR33015GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<OrderGrid>>> BOR33015GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<OrderGrid> gridlst = await Task.Run(() => new List<OrderGrid>());
            List<BOR33015GR> order = await Task.Run(() => new List<BOR33015GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BOR33015GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                order.Add(new BOR33015GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), cUS_Nm = sdr["cUS_Nm"].ToString(), cUS_Cod = sdr["cUS_Cod"].ToString(), aDDR = sdr["aDDR"].ToString(), dAT = Convert.ToDateTime(sdr["dAT"]).ToString("dd-MM-yyyy"), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new OrderGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = order });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("BOR35T17GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<OrderTrackingGrid>>> BOR35T17GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<OrderTrackingGrid> gridlst = await Task.Run(() => new List<OrderTrackingGrid>());
            List<BOR35T17GR> orderTracking = await Task.Run(() => new List<BOR35T17GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BOR35T17GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                orderTracking.Add(new BOR35T17GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), cUS_Nm = sdr["cUS_Nm"].ToString(), dAT = Convert.ToDateTime(sdr["dAT"]).ToString("dd-MM-yyyy"), oR_Id = Convert.ToDecimal(sdr["oR_Id"]), cHAL_Id = Convert.ToDecimal(sdr["cHAL_Id"]), oRTA_Id = Convert.ToInt32(sdr["oRTA_Id"]), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new OrderTrackingGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = orderTracking });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("CCUS3201GR/pn/{pageNo}/ps/{pageSize}/sR/{searchCol?}")]
        [HttpGet]
        public async Task<ActionResult<List<CustomerInfoGrid>>> CCUS3201GR(int pageNo = 1, int pageSize = 20, string searchCol = "")
        {
            decimal totRows = 0.0m;
            List<CustomerInfoGrid> gridlst = await Task.Run(() => new List<CustomerInfoGrid>());
            List<CCUS3201GR> customerInfo = await Task.Run(() => new List<CCUS3201GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                                                 new SqlParameter() {
                            ParameterName = "@searchCol",
                            SqlDbType =  SqlDbType.NVarChar ,
                            Direction =  ParameterDirection.Input,
                            Value =  searchCol
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "CCUS3201GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    customerInfo.Add(new CCUS3201GR { SL = Convert.ToDecimal(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), cUS_Nm = sdr["cUS_Nm"].ToString(), cUS_Cod = sdr["cUS_Cod"].ToString(), sR_Nm = sdr["sR_Nm"].ToString(), aDDr = sdr["aDDr"].ToString(), eMAL = sdr["eMAL"].ToString(), dOB = sdr.IsDBNull(sdr.GetOrdinal("dOB")) ? "" : Convert.ToDateTime(sdr["dOB"]).ToString("dd-MM-yyyy"), cTY = sdr["cTY"].ToString(), cNTRY = sdr["cNTRY"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });




                                }
                            }
                        }


                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new CustomerInfoGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = customerInfo });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("CNOT3302GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<NotificationGrid>>> CNOT3302GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<NotificationGrid> gridlst = await Task.Run(() => new List<NotificationGrid>());
            List<CNOT3302GR> notification = await Task.Run(() => new List<CNOT3302GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "CNOT3302GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    notification.Add(new CNOT3302GR { SL = Convert.ToDecimal(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), nOT_Ttl = sdr["nOT_Ttl"].ToString(), nOT_Bod = sdr["nOT_Bod"].ToString(), dAT = Convert.ToDateTime(sdr["dAT"]).ToString("dd-MM-yyyy"), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }


                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new NotificationGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = notification });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("CNO34D03GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<NotificationDetailsGrid>>> CNO34D03GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<NotificationDetailsGrid> gridlst = await Task.Run(() => new List<NotificationDetailsGrid>());
            List<CNO34D03GR> notificationDetails = await Task.Run(() => new List<CNO34D03GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "CNO34D03GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    notificationDetails.Add(new CNO34D03GR { SL = Convert.ToDecimal(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), nOT_Ttl = sdr["nOT_Ttl"].ToString(), sKU_Cod = sdr["sKU_Cod"].ToString(), rEC_Id = Convert.ToDecimal(sdr["rEC_Id"]), rEC_Tp = Convert.ToInt32(sdr["rEC_Tp"]), edit = sdr["edit"].ToString() });
                                }


                            }
                        }


                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new NotificationDetailsGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = notificationDetails });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("COF35T04GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<OfferTypeGrid>>> COF35T04GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<OfferTypeGrid> gridlst = await Task.Run(() => new List<OfferTypeGrid>());
            List<COF35T04GR> offerType = await Task.Run(() => new List<COF35T04GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "COF35T04GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    offerType.Add(new COF35T04GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), oFTP_Nm = sdr["oFTP_Nm"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }


                            }
                        }


                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new OfferTypeGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = offerType });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("COF36M05GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<OfferMasterGrid>>> COF36M05GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<OfferMasterGrid> gridlst = await Task.Run(() => new List<OfferMasterGrid>());
            List<COF36M05GR> offerMaster = await Task.Run(() => new List<COF36M05GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "COF36M05GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    offerMaster.Add(new COF36M05GR { SL = Convert.ToDecimal(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), oFR_Nm = sdr["oFR_Nm"].ToString(), oFTP_Nm = sdr["oFTP_Nm"].ToString(), sTR_Dat = Convert.ToDateTime(sdr["sTR_Dat"]), eXP_Dat = Convert.ToDateTime(sdr["eXP_Dat"]), iS_Avil = sdr.IsDBNull(sdr.GetOrdinal("iS_Avil")) ? false : Convert.ToBoolean(sdr["iS_Avil"]), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }


                            }
                        }


                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new OfferMasterGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = offerMaster });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("COF37D06GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<OfferDetailsGrid>>> COF37D06GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<OfferDetailsGrid> gridlst = await Task.Run(() => new List<OfferDetailsGrid>());
            List<COF37D06GR> offerDetails = await Task.Run(() => new List<COF37D06GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "COF37D06GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    offerDetails.Add(new COF37D06GR { SL = Convert.ToDecimal(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), vAL_Amt = Convert.ToDecimal(sdr["vAL_Amt"]), dIS_Amt = Convert.ToDecimal(sdr["dIS_Amt"]), oFR_Dts = sdr["oFR_Dts"].ToString(), edit = sdr["edit"].ToString() });
                                }


                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new OfferDetailsGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = offerDetails });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("DEM38T01GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<EmployeeTypeGrid>>> DEM38T01GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<EmployeeTypeGrid> gridlst = await Task.Run(() => new List<EmployeeTypeGrid>());
            List<DEM38T01GR> employeeType = await Task.Run(() => new List<DEM38T01GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "DEM38T01GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    employeeType.Add(new DEM38T01GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), eT_Nm = sdr["eT_Nm"].ToString(), under = sdr["under"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new EmployeeTypeGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = employeeType });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("DDG39002GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<DesignationGrid>>> DDG39002GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<DesignationGrid> gridlst = await Task.Run(() => new List<DesignationGrid>());
            List<DDG39002GR> designation = await Task.Run(() => new List<DDG39002GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "DDG39002GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    designation.Add(new DDG39002GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), dGN_Nm = sdr["dGN_Nm"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), dES = sdr["dES"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new DesignationGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = designation });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("DDP40003GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<DepartmentGrid>>> DDP40003GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<DepartmentGrid> gridlst = await Task.Run(() => new List<DepartmentGrid>());
            List<DDP40003GR> department = await Task.Run(() => new List<DDP40003GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "DDP40003GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    department.Add(new DDP40003GR { SL = Convert.ToInt32(sdr["SL"]), id = Convert.ToInt32(sdr["Id"]), dP_Nm = sdr["dP_Nm"].ToString(), under = sdr["under"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), des = sdr["dES"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new DepartmentGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = department });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        [Route("DEM41I04GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<EmployeeInfoGrid>>> DEM41I04GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<EmployeeInfoGrid> gridlst = await Task.Run(() => new List<EmployeeInfoGrid>());
            List<DEM41I04GR> employeeInfo = await Task.Run(() => new List<DEM41I04GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "DEM41I04GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                employeeInfo.Add(new DEM41I04GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), e_Cod = sdr["e_Cod"].ToString(), e_Name = sdr["e_Name"].ToString(), eT_Nm = sdr["eT_Nm"].ToString(), dGN_Nm = sdr["dGN_Nm"].ToString(), dP_Nm = sdr["dP_Nm"].ToString(), fA_Nm = sdr["fA_Nm"].ToString(), mA_Nm = sdr["mA_Nm"].ToString(), dOB = Convert.ToDateTime(sdr["dOB"]).ToString("dd-MM-yyyy"), eMAL = sdr["eMAL"].ToString(), gEN = sdr["gEN"].ToString(), nID = sdr["nID"].ToString(), bLD_Gr = sdr["bLD_Gr"].ToString(), mAR_Sts = sdr["mAR_Sts"].ToString(), cON_Num = sdr["cON_Num"].ToString(), eMR_CoN = sdr["eMR_CoN"].ToString(), pRE_Addr = sdr["pRE_Addr"].ToString(), tHNA = sdr["tHNA"].ToString(), dOJ = Convert.ToDateTime(sdr["dOJ"]), cON_Per = sdr["cON_Per"].ToString(), tER_Dat = Convert.ToDateTime(sdr["tER_Dat"]), bNK_Ac = sdr["bNK_Ac"].ToString(), bNK_Nm = sdr["bNK_Nm"].ToString(), bR_Nm = sdr["bR_Nm"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), iMG = sdr["iMG"].ToString(), edit = sdr["edit"].ToString() });
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new EmployeeInfoGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = employeeInfo });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("DSC42005GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<ScheduleGrid>>> DSC42005GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<ScheduleGrid> gridlst = await Task.Run(() => new List<ScheduleGrid>());
            List<DSC42005GR> schedule = await Task.Run(() => new List<DSC42005GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "DSC42005GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    schedule.Add(new DSC42005GR
                                    {
                                        SL = Convert.ToInt32(sdr["SL"]),
                                        Id = Convert.ToInt32(sdr["Id"]),
                                        sCH_Nm = sdr["sCH_Nm"].ToString(),
                                        sTR_Tm = sdr["sTR_Tm"].ToString(),
                                        eND_Tm = sdr["eND_Tm"].ToString(),
                                        gRA_Tm = sdr["gRA_Tm"].ToString(),
                                        sTS_Nm = sdr["sTS_Nm"].ToString(),
                                        nAR = sdr["nAR"].ToString(),
                                        edit = sdr["Edit"].ToString()
                                    });

                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new ScheduleGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = schedule });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("DEM43S06GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<EmployeeScheduleGrid>>> DEM43S06GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<EmployeeScheduleGrid> gridlst = await Task.Run(() => new List<EmployeeScheduleGrid>());
            List<DEM43S06GR> employeeSchedule = await Task.Run(() => new List<DEM43S06GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "DEM43S06GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    employeeSchedule.Add(new DEM43S06GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), e_Name = sdr["e_Name"].ToString(), dAT = Convert.ToDateTime(sdr["dAT"]).ToString("dd-MM-yyyy"), sCH_Nm = sdr["sCH_Nm"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new EmployeeScheduleGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = employeeSchedule });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("DEMSCHDETALL")]
        [HttpGet]
        public async Task<ActionResult<List<DEMSCHDETALL>>> EEMSCHDETALL()
        {


            List<DEMSCHDETALL> lst = await Task.Run(() => new List<DEMSCHDETALL>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {


                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "DEMSCHDETALL";

                        con.Open();
                        cmd.ExecuteScalar();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    lst.Add(new DEMSCHDETALL
                                    {
                                        SL = Convert.ToInt32(sdr["SL"]),
                                        Id = Convert.ToInt32(sdr["Id"]),
                                        EmployeeName = sdr["Employee_Name"].ToString(),
                                        dAT = Convert.ToDateTime(sdr["dAT"]),
                                        dP_Nm = sdr["dP_Nm"].ToString(),
                                        dGN_Nm = sdr["dGN_Nm"].ToString(),
                                        eT_Nm = sdr["eT_Nm"].ToString(),
                                        dOJ = Convert.ToDateTime(sdr["dOJ"]),
                                        sCH_Nm = sdr["sCH_Nm"].ToString()


                                    });
                                }
                            }
                        }
                        con.Close();

                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("DLE44M07GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<LeaveMasterGrid>>> DLE44M07GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<LeaveMasterGrid> gridlst = await Task.Run(() => new List<LeaveMasterGrid>());
            List<DLE44M07GR> leaveMaster = await Task.Run(() => new List<DLE44M07GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "DLE44M07GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    leaveMaster.Add(new DLE44M07GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), lE_Ttl = sdr["lE_Ttl"].ToString(), iS_Encs = sdr.IsDBNull(sdr.GetOrdinal("is_Encs")) ? "" : (sdr["iS_Encs"]).ToString(), qTY = Convert.ToDecimal(sdr["qTY"]), yER = Convert.ToInt32(sdr["yER"]), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new LeaveMasterGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = leaveMaster });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("DEM45LEAVE")]
        [HttpGet]
        public async Task<ActionResult<List<DEM45LEAVE>>> LEVMASDET()
        {


            List<DEM45LEAVE> lst = await Task.Run(() => new List<DEM45LEAVE>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {


                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select lM_Id ,lE_Ttl, qTY  From DLE44M07";

                        con.Open();
                        cmd.ExecuteScalar();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    lst.Add(new DEM45LEAVE
                                    {
                                        lM_Id = Convert.ToInt32(sdr["lM_Id"]),
                                        lE_Ttl = sdr["lE_Ttl"].ToString(),
                                        qTY = Convert.ToDecimal(sdr["qTY"])

                                    });
                                }
                            }
                        }
                        con.Close();

                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("DEM45L08GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<EmployeeLeaveGrid>>> DEM45L08GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<EmployeeLeaveGrid> gridlst = await Task.Run(() => new List<EmployeeLeaveGrid>());
            List<DEM45L08GR> employeeLeave = await Task.Run(() => new List<DEM45L08GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "DEM45L08GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    employeeLeave.Add(new DEM45L08GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), lE_Ttl = sdr["lE_Ttl"].ToString(), e_Name = sdr["e_Name"].ToString(), qTY = Convert.ToDecimal(sdr["qTY"]), yER = Convert.ToInt32(sdr["yER"]), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new EmployeeLeaveGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = employeeLeave });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("DLE46A09GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<LeaveApprovedGrid>>> DLE46A09GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<LeaveApprovedGrid> gridlst = await Task.Run(() => new List<LeaveApprovedGrid>());
            List<DLE46A09GR> leaveApproved = await Task.Run(() => new List<DLE46A09GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "DLE46A09GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    leaveApproved.Add(new DLE46A09GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), eLEA_Id = Convert.ToInt32(sdr["eLEA_Id"]), lE_Ttl = sdr["lE_Ttl"].ToString(), e_Name = sdr["e_Name"].ToString(), aPL_Dys = Convert.ToInt32(sdr["aPL_Dys"]), aPV_Dys = Convert.ToInt32(sdr["aPV_Dys"]), uS_Nm = sdr["uS_Nm"].ToString(), aPL_Dat = Convert.ToDateTime(sdr["aPL_Dat"]), aPV_Dat = Convert.ToDateTime(sdr["aPV_Dat"]), lEFO_Dat = Convert.ToDateTime(sdr["lEFO_Dat"]), lETO_Dat = Convert.ToDateTime(sdr["lETO_Dat"]), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new LeaveApprovedGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = leaveApproved });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("DHO47D10GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<HolidayDeclarationGrid>>> DHO47D10GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<HolidayDeclarationGrid> gridlst = await Task.Run(() => new List<HolidayDeclarationGrid>());
            List<DHO47D10GR> holidayDeclaration = await Task.Run(() => new List<DHO47D10GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "DHO47D10GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    holidayDeclaration.Add(new DHO47D10GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), tITL = sdr["tITL"].ToString(), dES = sdr["dES"].ToString(), yER = Convert.ToInt32(sdr["yER"]), qTY = Convert.ToDecimal(sdr["qTY"]), sTS_Nm = sdr["sTS_Nm"].ToString(), edit = sdr["edit"].ToString() });

                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new HolidayDeclarationGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = holidayDeclaration });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("DHO48S11GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<HolidaySetupGrid>>> DHO48S11GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<HolidaySetupGrid> gridlst = await Task.Run(() => new List<HolidaySetupGrid>());
            List<DHO48S11GR> holidaySetup = await Task.Run(() => new List<DHO48S11GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "DHO48S11GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    holidaySetup.Add(new DHO48S11GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), tITL = sdr["tITL"].ToString(), dAT = Convert.ToDateTime(sdr["dAT"]).ToString("dd-MM-yyyy"), yER = Convert.ToInt32(sdr["yER"]), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new HolidaySetupGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = holidaySetup });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("DEM49A12GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<AttendanceGrid>>> DEM49A12GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<AttendanceGrid> gridlst = await Task.Run(() => new List<AttendanceGrid>());
            List<DEM49A12GR> attendance = await Task.Run(() => new List<DEM49A12GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "DEM49A12GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    attendance.Add(new DEM49A12GR { sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new AttendanceGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = attendance });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("DPA50H13GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<PayHeadGrid>>> DPA50H13GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<PayHeadGrid> gridlst = await Task.Run(() => new List<PayHeadGrid>());
            List<DPA50H13GR> payHead = await Task.Run(() => new List<DPA50H13GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "DPA50H13GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    payHead.Add(new DPA50H13GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), pAH_Nm = sdr["pAH_Nm"].ToString(), tYP = sdr["tYP"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new PayHeadGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = payHead });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("DSA51P14GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<SalaryPackageGrid>>> DSA51P14GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<SalaryPackageGrid> gridlst = await Task.Run(() => new List<SalaryPackageGrid>());
            List<DSA51P14GR> salaryPackage = await Task.Run(() => new List<DSA51P14GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "DSA51P14GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    salaryPackage.Add(new DSA51P14GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), sAP_Nm = sdr["sAP_Nm"].ToString(), tOT_Amt = Convert.ToDecimal(sdr["tOT_Amt"]), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new SalaryPackageGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = salaryPackage });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("DSA53D16GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<SalaryDetailsGrid>>> DSA53D16GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<SalaryDetailsGrid> gridlst = await Task.Run(() => new List<SalaryDetailsGrid>());
            List<DSA53D16GR> salaryDetails = await Task.Run(() => new List<DSA53D16GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "DSA53D16GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    salaryDetails.Add(new DSA53D16GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), e_Name = sdr["e_Name"].ToString(), sAP_Nm = sdr["sAP_Nm"].ToString(), tOT_Amt = Convert.ToDecimal(sdr["tOT_Amt"]), sTS_Nm = sdr["sTS_Nm"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new SalaryDetailsGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = salaryDetails });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("DEMSALAYDTL")]
        [HttpGet]
        public async Task<ActionResult<List<DEMSALAYDTL>>> DEMSALAYDTL()
        {


            List<DEMSALAYDTL> lst = await Task.Run(() => new List<DEMSALAYDTL>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {


                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "DEMSALAYDTL";

                        con.Open();
                        cmd.ExecuteScalar();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    lst.Add(new DEMSALAYDTL
                                    {
                                        SL = Convert.ToInt32(sdr["SL"]),
                                        Id = Convert.ToInt32(sdr["Id"]),
                                        sAP_Nm = sdr["sAP_Nm"].ToString(),
                                        EmployeeName = sdr["Employee Name"].ToString(),
                                        dP_Nm = sdr["dP_Nm"].ToString(),
                                        dGN_Nm = sdr["dGN_Nm"].ToString(),
                                        eT_Nm = sdr["eT_Nm"].ToString(),


                                    });
                                }
                            }
                        }
                        con.Close();

                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        [Route("DBO56D19GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<BonusDeductionGrid>>> DBO56D19GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<BonusDeductionGrid> gridlst = await Task.Run(() => new List<BonusDeductionGrid>());
            List<DBO56D19GR> bonusDeduction = await Task.Run(() => new List<DBO56D19GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "DBO56D19GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    bonusDeduction.Add(new DBO56D19GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), e_Name = sdr["e_Name"].ToString(), mNTH = Convert.ToInt32(sdr["mNTH"]), yER = Convert.ToInt32(sdr["yER"]), bO_Ttl = sdr["bO_Ttl"].ToString(), bO_Amt = Convert.ToDecimal(sdr["bO_Amt"]), dEDC_Amt = Convert.ToDecimal(sdr["dEDC_Amt"]), iSAW_Sal = sdr.IsDBNull(sdr.GetOrdinal("iSAW_Sal")) ? "" : (sdr["iSAW_Sal"]).ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new BonusDeductionGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = bonusDeduction });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("EMSD/{Year}/{Month}")]
        [HttpGet]
        public async Task<ActionResult<List<EMSD>>> EMSD(int Year, int Month)
        {


            List<EMSD> eMSDs = await Task.Run(() => new List<EMSD>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@Year",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  Year
                        },
                        new SqlParameter() {
                            ParameterName = "@Month",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = Month
                        },

                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "EMSD";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        cmd.ExecuteScalar();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    eMSDs.Add(new EMSD
                                    {
                                        ID = Convert.ToInt32(sdr["ID"]),
                                        EmpId = Convert.ToInt32(sdr["EmpId"]),
                                        EmployeeName = sdr["Employee Name"].ToString(),
                                        dP_Nm = sdr["dP_Nm"].ToString(),
                                        dGN_Nm = sdr["dGN_Nm"].ToString(),
                                        eT_Nm = sdr["eT_Nm"].ToString(),
                                        dOJ = Convert.ToDateTime(sdr["dOJ"]),
                                        Mo = Convert.ToInt32(sdr["Mo"]),
                                        Yr = Convert.ToInt32(sdr["Yr"]),
                                        TWD = sdr.IsDBNull(sdr.GetOrdinal("TWD")) ? 0 : Convert.ToInt32(sdr["TWD"]),
                                        TAD = sdr.IsDBNull(sdr.GetOrdinal("TAD")) ? 0 : Convert.ToInt32(sdr["TAD"]),
                                        TLD = sdr.IsDBNull(sdr.GetOrdinal("TLD")) ? 0 : Convert.ToInt32(sdr["TLD"]),
                                        LDD = sdr.IsDBNull(sdr.GetOrdinal("LDD")) ? 0 : Convert.ToInt32(sdr["LDD"]),
                                        LD = sdr.IsDBNull(sdr.GetOrdinal("LD")) ? 0 : Convert.ToInt32(sdr["LD"]),
                                        LWP = sdr.IsDBNull(sdr.GetOrdinal("LWP")) ? 0 : Convert.ToInt32(sdr["LWP"]),
                                        TPD = sdr.IsDBNull(sdr.GetOrdinal("TPD")) ? 0 : Convert.ToInt32(sdr["TPD"]),
                                        GS = sdr.IsDBNull(sdr.GetOrdinal("GS")) ? 0.0m : Convert.ToDecimal(sdr["GS"]),
                                        PA = sdr.IsDBNull(sdr.GetOrdinal("PA")) ? 0.0m : Convert.ToDecimal(sdr["PA"]),
                                        CT = sdr.IsDBNull(sdr.GetOrdinal("CT")) ? 0.0m : Convert.ToDecimal(sdr["CT"]),
                                        AV = sdr.IsDBNull(sdr.GetOrdinal("AV")) ? 0.0m : Convert.ToDecimal(sdr["AV"]),
                                        OD = sdr.IsDBNull(sdr.GetOrdinal("OD")) ? 0.0m : Convert.ToDecimal(sdr["OD"]),
                                        BO = sdr.IsDBNull(sdr.GetOrdinal("BO")) ? 0.0m : Convert.ToDecimal(sdr["BO"]),
                                        np = sdr.IsDBNull(sdr.GetOrdinal("np")) ? 0.0m : Convert.ToDecimal(sdr["np"]),



                                    });
                                }
                            }
                        }
                        con.Close();

                    }
                }


                return eMSDs;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("DMO57S20GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<MonthlySalaryGrid>>> DMO57S20GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<MonthlySalaryGrid> gridlst = await Task.Run(() => new List<MonthlySalaryGrid>());
            List<DMO57S20GR> monthlySalary = await Task.Run(() => new List<DMO57S20GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "DMO57S20GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    monthlySalary.Add(new DMO57S20GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), p_Mon = Convert.ToInt32(sdr["p_Mon"]), p_Yer = Convert.ToInt32(sdr["p_Yer"]), p_Dat = Convert.ToDateTime(sdr["p_Dat"]), tOT_Amt = Convert.ToDecimal(sdr["tOT_Amt"]), iS_Apv = sdr.IsDBNull(sdr.GetOrdinal("iS_Apv")) ? "" : (sdr["iS_Apv"]).ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new MonthlySalaryGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = monthlySalary });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }





        [Route("EAC59G01GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<AccountGroupGrid>>> EAC59G01GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<AccountGroupGrid> gridlst = await Task.Run(() => new List<AccountGroupGrid>());
            List<EAC59G01GR> accountGroup = await Task.Run(() => new List<EAC59G01GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "EAC59G01GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    accountGroup.Add(new EAC59G01GR { SL = Convert.ToDecimal(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), aG_Nm = sdr["aG_Nm"].ToString(), under = sdr["under"].ToString(), iS_Def = sdr.IsDBNull(sdr.GetOrdinal("iS_Def")) ? "" : (sdr["iS_Def"]).ToString(), nTR = sdr["nTR"].ToString(), aFG_Prof = sdr["aFG_Prof"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new AccountGroupGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = accountGroup });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("EAC60L02GR/pn/{pageNo}/ps/{pageSize}/sR/{searchCol?}")]
        [HttpGet]
        public async Task<ActionResult<List<AccountLedgerGrid>>> EAC60L02GR(int pageNo = 1, int pageSize = 20, string searchCol = "")
        {
            decimal totRows = 0.0m;
            List<AccountLedgerGrid> gridlst = await Task.Run(() => new List<AccountLedgerGrid>());
            List<EAC60L02GR> accountLedger = await Task.Run(() => new List<EAC60L02GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                          new SqlParameter() {
                            ParameterName = "@searchCol",
                            SqlDbType =  SqlDbType.NVarChar ,
                            Direction =  ParameterDirection.Input,
                            Value =  searchCol
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "EAC60L02GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    accountLedger.Add(new EAC60L02GR
                                    {
                                        SL = Convert.ToInt32(sdr["SL"]),
                                        Id = Convert.ToDecimal(sdr["Id"]),
                                        aG_Nm = sdr["aG_Nm"].ToString(),
                                        sR_Nm = sdr["sR_Nm"].ToString(),
                                        lGR_Nm = sdr["lGR_Nm"].ToString(),
                                        oPEN_Dat = Convert.ToDateTime(sdr["oPEN_Dat"]).ToString("dd-MM-yyyy"),
                                        oPEN_Bal = Convert.ToDecimal(sdr["oPEN_Bal"]),
                                        cR_Dr = sdr["cR_Dr"].ToString(),
                                        aDDR = sdr["aDDR"].ToString(),
                                        pHO = sdr["pHO"].ToString(),
                                        mOB = sdr["mOB"].ToString(),
                                        eML = sdr["eML"].ToString(),
                                        nID = sdr["nID"].ToString(),
                                        thana = sdr["thana"].ToString(),
                                        district = sdr["district"].ToString(),
                                        sTS_Nm = sdr["sTS_Nm"].ToString(),
                                        nAR = sdr["nAR"].ToString(),
                                        edit = sdr["edit"].ToString(),
                                        del = sdr["del"].ToString()
                                    });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new AccountLedgerGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = accountLedger });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("GETEAC60L02Party/pn/{pageNo}/ps/{pageSize}/{dMR_Id}/{plabel}/sR/{searchCol?}")]
        [HttpGet]
        public async Task<ActionResult<List<PartySuplierGrid>>> GETEAC60L02Party(int pageNo = 1, int pageSize = 20, int dMR_Id = 1, int plabel = 0, string searchCol = "")
        {
            decimal totRows = 0.0m;
            List<PartySuplierGrid> gridlst = await Task.Run(() => new List<PartySuplierGrid>());
            List<EAC60L02GR> partySuplier = await Task.Run(() => new List<EAC60L02GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@PageNo",
                                SqlDbType =   SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value =  pageNo
                            },
                            new SqlParameter() {
                                ParameterName = "@PageSize",
                                SqlDbType =  SqlDbType.Int,
                                Direction =  ParameterDirection.Input,

                                Value = pageSize
                            },
                            new SqlParameter() {
                                ParameterName = "@dMR_Id",
                                SqlDbType =  SqlDbType.Int ,
                                Direction =  ParameterDirection.Input,
                                Value =  dMR_Id
                            },
                            new SqlParameter() {
                                ParameterName = "@plabel",
                                SqlDbType =  SqlDbType.Int ,
                                Direction =  ParameterDirection.Input,
                                Value =  plabel
                            },
                            new SqlParameter() {
                                ParameterName = "@searchCol",
                                SqlDbType =  SqlDbType.NVarChar ,
                                Direction =  ParameterDirection.Input,
                                Value =  searchCol
                            },
                          totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETEAC60L02Party";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    partySuplier.Add(new EAC60L02GR
                                    {
                                        SL = Convert.ToDecimal(sdr["SL"]),
                                        Id = Convert.ToDecimal(sdr["Id"]),
                                        pAR_Id = sdr["pAR_Id"].ToString(),
                                        aG_Nm = sdr["aG_Nm"].ToString(),
                                        region = sdr["region"].ToString(),
                                        division = sdr["division"].ToString(),
                                        sR_Nm = sdr["sR_Nm"].ToString(),
                                        lGR_Nm = sdr["lGR_Nm"].ToString(),
                                        oPEN_Dat = sdr.IsDBNull(sdr.GetOrdinal("oPEN_Dat")) ? "" : Convert.ToDateTime(sdr["oPEN_Dat"]).ToString("dd-MM-yyyy"),
                                        oPEN_Bal = Convert.ToDecimal(sdr["oPEN_Bal"]),
                                        propitor = sdr["propitor"].ToString(),
                                        mOB = sdr["mOB"].ToString(),
                                        manager = sdr["manager"].ToString(),
                                        mN_Mob = sdr["mN_Mob"].ToString(),
                                        sMS_Mob = sdr["sMS_Mob"].ToString(),
                                        eML = sdr["eML"].ToString(),
                                        aDDR = sdr["aDDR"].ToString(),
                                        district = sdr["district"].ToString(),
                                        thana = sdr["thana"].ToString(),
                                        sTS_Nm = sdr["sTS_Nm"].ToString(),
                                        edit = sdr["edit"].ToString()

                                    });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new PartySuplierGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = partySuplier });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("GETUPDEAC60L02/{lGR_Id}")]
        [HttpGet]
        public async Task<ActionResult<List<EAC60L02GR>>> GETUPDEAC60L02(decimal lGR_Id)
        {


            List<EAC60L02GR> partyData = await Task.Run(() => new List<EAC60L02GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@lGR_Id";
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Decimal;
                        param.Value = lGR_Id;


                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDEAC60L02";
                        cmd.Parameters.Add(param);
                        con.Open();


                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    partyData.Add(new EAC60L02GR
                                    {
                                        Id = Convert.ToDecimal(sdr["lGR_Id"]),
                                        aG_Id = Convert.ToDecimal(sdr["aG_Id"]),
                                        rGN_Id = Convert.ToInt32(sdr["rGN_Id"]),
                                        dIV_Id = Convert.ToInt32(sdr["dIV_Id"]),
                                        division = sdr["division"].ToString(),
                                        sR_Nm = sdr["lGR_Nm"].ToString(),
                                        lGR_Nm = sdr["lGR_Nm_Bn"].ToString(),
                                        oPEN_Dat = sdr.IsDBNull(sdr.GetOrdinal("oPEN_Dat")) ? "" : Convert.ToDateTime(sdr["oPEN_Dat"]).ToString("dd-MM-yyyy"),
                                        oPEN_Bal = Convert.ToDecimal(sdr["oPEN_Bal"]),
                                        propitor = sdr["propitor"].ToString(),
                                        mOB = sdr["mOB"].ToString(),
                                        manager = sdr["manager"].ToString(),
                                        mN_Mob = sdr["mN_Mob"].ToString(),
                                        sMS_Mob = sdr["sMS_Mob"].ToString(),
                                        eML = sdr["eML"].ToString(),
                                        aDDR = sdr["aDDR"].ToString(),
                                        dIST_Id = Convert.ToInt32(sdr["dIST_Id"]),
                                        district = sdr["district"].ToString(),
                                        tHNA_Id = Convert.ToInt32(sdr["tHNA_Id"]),
                                        thana = sdr["thana"].ToString(),
                                        cRD_Lm = Convert.ToInt32(sdr["cRD_Lm"]),
                                        cRD_Per = sdr["cRD_Per"].ToString(),
                                        sTS_Nm = sdr["sTS"].ToString()



                                    });

                                }
                            }
                        }

                        con.Close();

                    }
                }

                return partyData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("ManufactuerWiseSalesProfit/{FromDate}/{ToDate}/{mNF_Id?}")]
        [HttpGet]
        public async Task<ActionResult<List<ManufactuerWiseSalesProfit>>> GetManufactuerWiseSalesProfit(string FromDate, string ToDate, int mNF_Id )
        {
            List<ManufactuerWiseSalesProfit> lst = await Task.Run(() => new List<ManufactuerWiseSalesProfit>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                            
                            new SqlParameter() {
                                ParameterName = "@FromDate",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  FromDate
                            },
                            new SqlParameter() {
                                ParameterName = "@ToDate",
                                SqlDbType =  SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value = ToDate
                            },
                            new SqlParameter() {
                              ParameterName = "@mNF_Id",
                              SqlDbType =  SqlDbType.Int,
                              Direction =  ParameterDirection.Input,
                              Value = mNF_Id
                            },
                        };


                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ManufactuerWiseSalesProfit";
                        cmd.Parameters.AddRange(param);

                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lst.Add(new ManufactuerWiseSalesProfit
                                {
                                    mNF_Id = Convert.ToInt32(sdr["mNF_Id"]),
                                    mNF_Nm = sdr["mNF_Nm"].ToString(),
                                    pUR_Amt = Convert.ToDecimal(sdr["pUR_Amt"]),
                                    pUR_Ret_Amt = Convert.ToDecimal(sdr["pUR_Ret_Amt"]),
                                    pUR_Net = Convert.ToDecimal(sdr["pUR_Net"]),
                                    sAL_Amt = Convert.ToDecimal(sdr["sAL_Amt"]),
                                    sAL_Ret_Amt = Convert.ToDecimal(sdr["sAL_Ret_Amt"]),
                                    sAL_Net = Convert.ToDecimal(sdr["sAL_Net"]),
                                    dIS = Convert.ToDecimal(sdr["dIS"])
                                });
                            }

                        }
                        con.Close();
                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("CURRENTBALEAC60L02/{lGR_Id}")]
        [HttpGet]
        public async Task<ActionResult<List<CURRENTBALEAC60L02>>> CURRENTBALEAC60L02(decimal lGR_Id)
        {


            List<CURRENTBALEAC60L02> currentBalanceLgr = await Task.Run(() => new List<CURRENTBALEAC60L02>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@lGR_Id";
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Decimal;
                        param.Value = lGR_Id;


                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "CURRENTBALFAC48L02";
                        cmd.Parameters.Add(param);
                        con.Open();


                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    currentBalanceLgr.Add(new CURRENTBALEAC60L02
                                    {
                                        CurrentBalance = Convert.ToDecimal(sdr["CurrentBalance"])

                                    });

                                }
                            }
                        }

                        con.Close();

                    }
                }

                return currentBalanceLgr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        [Route("CURRENTBALALLLGR/{lGR_Id}")]
        [HttpGet]
        public async Task<ActionResult<List<CURRENTBALEAC60L02>>> CURRENTBALALLLGR(decimal lGR_Id)
        {


            List<CURRENTBALEAC60L02> CURRENTBAL = await Task.Run(() => new List<CURRENTBALEAC60L02>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@lGR_Id";
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Decimal;
                        param.Value = lGR_Id;


                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "CURRENTBALALLLGR";
                        cmd.Parameters.Add(param);
                        con.Open();


                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    CURRENTBAL.Add(new CURRENTBALEAC60L02
                                    {
                                        CurrentBalance = Convert.ToDecimal(sdr["CurrentBalance"])

                                    });

                                }
                            }
                        }

                        con.Close();

                    }
                }

                return CURRENTBAL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("EAD63P05GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<AdvanchedPaymentGrid>>> EAD63P05GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<AdvanchedPaymentGrid> gridlst = await Task.Run(() => new List<AdvanchedPaymentGrid>());
            List<EAD63P05GR> advanchedPayment = await Task.Run(() => new List<EAD63P05GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "EAD63P05GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    advanchedPayment.Add(new EAD63P05GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), e_Name = sdr["e_Name"].ToString(), lGR_Nm = sdr["lGR_Nm"].ToString(), vT_No = sdr["vT_No"].ToString(), iNV_No = sdr["iNV_No"].ToString(), dAT = Convert.ToDateTime(sdr["dAT"]).ToString("dd-MM-yyyy"), aMT = Convert.ToDecimal(sdr["aMT"]), sLR_Mon = Convert.ToDateTime(sdr["sLR_Mon"]), cEQ_Num = sdr["cEQ_Num"].ToString(), cEQ_Dat = Convert.ToDateTime(sdr["cEQ_Dat"]), sFX = sdr["sFX"].ToString(), pFX = sdr["pFX"].ToString(), vT_Nm = sdr["vT_Nm"].ToString(), fY_Id = Convert.ToInt32(sdr["fY_Id"]), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new AdvanchedPaymentGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = advanchedPayment });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("EBN64R06GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<BankReconcilationGrid>>> EBN64R06GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<BankReconcilationGrid> gridlst = await Task.Run(() => new List<BankReconcilationGrid>());
            List<EBN64R06GR> bankReconcilation = await Task.Run(() => new List<EBN64R06GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "EBN64R06GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    bankReconcilation.Add(new EBN64R06GR { SL = Convert.ToDecimal(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), lGRP_Id = Convert.ToDecimal(sdr["lGRP_Id"]), sTD_Dat = Convert.ToDateTime(sdr["sTD_Dat"]).ToString("dd-MM-yyyy"), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new BankReconcilationGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = bankReconcilation });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("ECUR6911GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<CurrencyGrid>>> ECUR6911GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<CurrencyGrid> gridlst = await Task.Run(() => new List<CurrencyGrid>());
            List<ECUR6911GR> currency = await Task.Run(() => new List<ECUR6911GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@PageNo",
                                SqlDbType =   SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value =  pageNo
                            },
                            new SqlParameter() {
                                ParameterName = "@PageSize",
                                SqlDbType =  SqlDbType.Int,
                                Direction =  ParameterDirection.Input,

                                Value = pageSize
                            },
                          totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ECUR6911GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    currency.Add(new ECUR6911GR { SL = Convert.ToDecimal(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), cUR_Sym = sdr["cUR_Sym"].ToString(), cUR_Nm = sdr["cUR_Nm"].ToString(), sBU_Nm = sdr["sBU_Nm"].ToString(), nODC_Plc = Convert.ToInt32(sdr["nODC_Plc"]), iS_Def = sdr.IsDBNull(sdr.GetOrdinal("iS_Def")) ? "" : (sdr["iS_Def"]).ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new CurrencyGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = currency });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        [Route("EFN77Y19GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<FinancialYearGrid>>> EFN77Y19GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<FinancialYearGrid> gridlst = await Task.Run(() => new List<FinancialYearGrid>());
            List<EFN77Y19GR> financialYear = await Task.Run(() => new List<EFN77Y19GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@PageNo",
                                SqlDbType =   SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value =  pageNo
                            },
                            new SqlParameter() {
                                ParameterName = "@PageSize",
                                SqlDbType =  SqlDbType.Int,
                                Direction =  ParameterDirection.Input,

                                Value = pageSize
                            },
                           totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "EFN77Y19GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {

                            while (sdr.Read())
                            {
                                financialYear.Add(new EFN77Y19GR
                                {
                                    SL = Convert.ToInt32(sdr["SL"]),
                                    Id = Convert.ToInt32(sdr["Id"]),
                                    fR_Dat = Convert.ToDateTime(sdr["fR_Dat"]).ToString("dd-MM-yyyy"),
                                    tO_Dat = Convert.ToDateTime(sdr["tO_Dat"]).ToString("dd-MM-yyyy"),
                                    iS_Def = sdr.IsDBNull(sdr.GetOrdinal("iS_Def")) ? false : Convert.ToBoolean(sdr["iS_Def"]),
                                    sTS_Nm = sdr["sTS_Nm"].ToString(),
                                    nAR = sdr["nAR"].ToString()
                                });
                            }

                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new FinancialYearGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = financialYear });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("EVC26T68GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<VoucherTypeGrid>>> EVC26T68GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<VoucherTypeGrid> gridlst = await Task.Run(() => new List<VoucherTypeGrid>());
            List<EVC26T68GR> voucherType = await Task.Run(() => new List<EVC26T68GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@PageNo",
                                SqlDbType =   SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value =  pageNo
                            },
                            new SqlParameter() {
                                ParameterName = "@PageSize",
                                SqlDbType =  SqlDbType.Int,
                                Direction =  ParameterDirection.Input,

                                Value = pageSize
                            },
                          totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "EVC26T68GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    voucherType.Add(new EVC26T68GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), vT_Nm = sdr["vT_Nm"].ToString(), tOV = sdr["tOV"].ToString(), mOV_Num = sdr["mOV_Num"].ToString(), iS_Act = sdr.IsDBNull(sdr.GetOrdinal("is_Act")) ? "" : (sdr["iS_Act"]).ToString(), iS_Def = sdr.IsDBNull(sdr.GetOrdinal("is_Def")) ? "" : (sdr["iS_Def"]).ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new VoucherTypeGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = voucherType });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("FUS28I01GR/pn/{pageNo}/ps/{pageSize}/{uS_Id?}")]
        [HttpGet]
        public async Task<ActionResult<List<UserInfoGrid>>> FUS28I01GR(int pageNo, int pageSize, decimal uS_Id)
        {
            decimal totRows = 0.0m;
            List<UserInfoGrid> gridlst = await Task.Run(() => new List<UserInfoGrid>());
            List<FUS28I01GR> userInfo = await Task.Run(() => new List<FUS28I01GR>());
            try
            {
                UserAuth user = new UserAuth(Request.Headers["Authorization"].ToString());
                if (user.UserId != 0.0m && user.UserName != "")
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            SqlParameter totalDataRows = new SqlParameter();
                            totalDataRows.ParameterName = "@TotalRow";
                            totalDataRows.Direction = ParameterDirection.Output;
                            totalDataRows.DbType = DbType.Decimal;

                            var param = new SqlParameter[] {
                                new SqlParameter() {
                                    ParameterName = "@PageNo",
                                    SqlDbType =   SqlDbType.Int,
                                    Direction =  ParameterDirection.Input,
                                    Value =  pageNo
                                },
                                new SqlParameter() {
                                    ParameterName = "@PageSize",
                                    SqlDbType =  SqlDbType.Int,
                                    Direction =  ParameterDirection.Input,
                                    Value = pageSize
                                },
                                new SqlParameter() {
                                    ParameterName = "@uS_Id",
                                    SqlDbType =  SqlDbType.Decimal,
                                    Direction =  ParameterDirection.Input,
                                    Value = uS_Id
                                },
                                totalDataRows
                            };

                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "FUS28I01GR";
                            cmd.Parameters.AddRange(param);
                            con.Open();
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                {
                                    while (sdr.Read())
                                    {
                                        userInfo.Add(new FUS28I01GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), uS_Nm = sdr["uS_Nm"].ToString(), pHO = sdr["pHO"].ToString(), uS_Pas = (sdr["uS_Pas"].ToString()), uS_Rol = Convert.ToInt32(sdr["tYP"]), sTS = sdr["sTS"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString() });
                                    }
                                }
                            }

                            totRows = Convert.ToDecimal(totalDataRows.Value);
                            con.Close();

                        }
                    }

                    gridlst.Add(new UserInfoGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = userInfo });
                    return gridlst;
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("FMEN2902GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<MenuGrid>>> FMEN2902GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<MenuGrid> gridlst = await Task.Run(() => new List<MenuGrid>());
            List<FMEN2902GR> menu = await Task.Run(() => new List<FMEN2902GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@PageNo",
                                SqlDbType =   SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value =  pageNo
                            },
                            new SqlParameter() {
                                ParameterName = "@PageSize",
                                SqlDbType =  SqlDbType.Int,
                                Direction =  ParameterDirection.Input,

                                Value = pageSize
                            },
                           totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "FMEN2902GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    menu.Add(new FMEN2902GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), mNU_Nm = sdr["mNU_Nm"].ToString(), mNU_NmB = sdr["mNU_NmB"].ToString(), cOD = sdr["cOD"].ToString(), under = sdr["under"].ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new MenuGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = menu });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("FPER3003GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<PermissionGrid>>> FPER3003GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<PermissionGrid> gridlst = await Task.Run(() => new List<PermissionGrid>());
            List<FPER3003GR> permission = await Task.Run(() => new List<FPER3003GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@PageNo",
                                SqlDbType =   SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value =  pageNo
                            },
                            new SqlParameter() {
                                ParameterName = "@PageSize",
                                SqlDbType =  SqlDbType.Int,
                                Direction =  ParameterDirection.Input,

                                Value = pageSize
                            },
                          totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "FPER3003GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    permission.Add(new FPER3003GR
                                    {
                                        SL = Convert.ToInt32(sdr["SL"]),
                                        Id = Convert.ToDecimal(sdr["Id"]),
                                        pER_Nm = sdr["pER_Nm"].ToString(),
                                        pER_NmB = sdr["pER_NmB"].ToString(),
                                        cOD = sdr["cOD"].ToString(),
                                        mNU_Nm = sdr["mNU_Nm"].ToString(),
                                        sTS_Nm = sdr["sTS_Nm"].ToString(),
                                        nAR = sdr["nAR"].ToString(),
                                        edit = sdr["edit"].ToString()
                                    });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new PermissionGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = permission });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("FUS31P04GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<UserPermissionGrid>>> FUS31P04GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<UserPermissionGrid> gridlst = await Task.Run(() => new List<UserPermissionGrid>());
            List<FUS31P04GR> userPermission = await Task.Run(() => new List<FUS31P04GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@PageNo",
                                SqlDbType =   SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value =  pageNo
                            },
                            new SqlParameter() {
                                ParameterName = "@PageSize",
                                SqlDbType =  SqlDbType.Int,
                                Direction =  ParameterDirection.Input,

                                Value = pageSize
                            },
                           totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "FUS31P04GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    userPermission.Add(new FUS31P04GR { SL = Convert.ToInt32(sdr["SL"]), Id = Convert.ToInt32(sdr["Id"]), uS_Nm = sdr["uS_Nm"].ToString(), pER_Nm = sdr["pER_Nm"].ToString(), iS_Act = sdr.IsDBNull(sdr.GetOrdinal("iS_Act")) ? "" : (sdr["iS_Act"]).ToString(), sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new UserPermissionGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = userPermission });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("GRINFOFORFUS28I01/{TypeId}/{Code?}/{name?}/{phone?}/{email?}")]
        [HttpGet]
        public async Task<ActionResult<List<GRINFOFORFUS28I01>>> GRINFOFORFUS28I01(int TypeId, string? Code, string? name, string? phone, string? email)
        {
            List<GRINFOFORFUS28I01> lst = await Task.Run(() => new List<GRINFOFORFUS28I01>());

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var Parame = new SqlParameter[]
                        {
                            new SqlParameter()
                            {
                                ParameterName = "@TypeId",
                                SqlDbType=SqlDbType.Int,
                                Direction=ParameterDirection.Input,
                                Value=TypeId
                            },
                            new SqlParameter()
                            {
                                ParameterName="@Code",
                                SqlDbType=SqlDbType.NVarChar,
                                Direction=ParameterDirection.Input,

                                Value = Code == null ? string .Empty : Code
                            },
                            new SqlParameter()
                            {
                                ParameterName="@name",
                                SqlDbType=SqlDbType.NVarChar,
                                Direction=ParameterDirection.Input,
                                Value= name == null ? string .Empty : name
                            },
                            new SqlParameter()
                            {
                                ParameterName="@phone",
                                SqlDbType=SqlDbType.NVarChar,
                                Direction=ParameterDirection.Input,
                                Value=phone  == null ? string .Empty : phone
                            },
                            new SqlParameter()
                            {
                                ParameterName="@email",
                                SqlDbType=SqlDbType.NVarChar,
                                Direction=ParameterDirection.Input,
                                Value=email  == null ? string .Empty : email
                            }
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GRINFOFORFUS28I01";
                        cmd.Parameters.AddRange(Parame);

                        con.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lst.Add(new GRINFOFORFUS28I01
                                {
                                    ID = Convert.ToInt32(sdr["ID"]),
                                    R_Name = sdr["R_Name"].ToString(),
                                    Code = sdr["Code"].ToString(),
                                    Phone = sdr["Phone"].ToString(),
                                    Email = sdr["Email"].ToString()


                                });
                            }
                        }
                        con.Close();
                    }
                }
                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Route("EMPDEM49A12/{sCH_Id}/{inOut}")]
        [HttpGet]
        public async Task<ActionResult<List<EMPDEM49A12>>> EMPDEM49A12(int sCH_Id, string inOut)
        {
            List<EMPDEM49A12> lst = await Task.Run(() => new List<EMPDEM49A12>());

            string inOrOut = inOut;


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var Parame = new SqlParameter[]
                        {
                            new SqlParameter()
                            {
                                ParameterName = "@sCH_Id",
                                SqlDbType=SqlDbType.Int,
                                Direction=ParameterDirection.Input,
                                Value=sCH_Id
                            },
                            new SqlParameter()
                            {
                                ParameterName="@inOut",
                                SqlDbType=SqlDbType.NVarChar,
                                Direction=ParameterDirection.Input,

                                Value = inOut
                            },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "EMPDEM49A12";
                        cmd.Parameters.AddRange(Parame);

                        con.Open();
                        if (inOrOut == "IN")
                        {
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    lst.Add(new EMPDEM49A12
                                    {
                                        SL = Convert.ToInt32(sdr["SL"]),
                                        Id = Convert.ToInt32(sdr["SL"]),
                                        EmployeeName = sdr["Employee_Name"].ToString(),
                                        dAT = Convert.ToDateTime(sdr["dAT"]),
                                        dP_Nm = sdr["dP_Nm"].ToString(),
                                        dGN_Nm = sdr["dGN_Nm"].ToString(),
                                        eT_Nm = sdr["eT_Nm"].ToString(),
                                        sCH_Id = Convert.ToInt32(sdr["sCH_Id"]),
                                        sCH_Nm = sdr["sCH_Nm"].ToString(),
                                        sTR_Tm = sdr["sTR_Tm"].ToString(),


                                    });
                                }
                            }
                        }

                        else
                        {
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    lst.Add(new EMPDEM49A12
                                    {
                                        SL = Convert.ToInt32(sdr["SL"]),
                                        Id = Convert.ToInt32(sdr["SL"]),
                                        EmployeeName = sdr["Employee_Name"].ToString(),
                                        dAT = Convert.ToDateTime(sdr["dAT"]),
                                        dP_Nm = sdr["dP_Nm"].ToString(),
                                        dGN_Nm = sdr["dGN_Nm"].ToString(),
                                        eT_Nm = sdr["eT_Nm"].ToString(),
                                        sCH_Id = Convert.ToInt32(sdr["sCH_Id"]),
                                        sCH_Nm = sdr["sCH_Nm"].ToString(),
                                        eND_Tm = sdr["eND_Tm"].ToString()


                                    });
                                }
                            }
                        }
                        con.Close();
                    }
                }
                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("ECN65M07GR/pn/{pageNo}/ps/{pageSize}/Fr/{From}/To/{To}/{lGR_Id}/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<ContraVoucherGrid>>> ECN65M07GR(int pageNo = 1, int pageSize = 20, string From = "", string To = "", decimal lGR_Id = 0, string vT_No = "0")
        {
            decimal totRows = 0.0m;
            List<ContraVoucherGrid> gridlst = await Task.Run(() => new List<ContraVoucherGrid>());
            List<ECN65M07GR> contraVoucher = await Task.Run(() => new List<ECN65M07GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@PageNo",
                                SqlDbType =   SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value =  pageNo
                            },
                            new SqlParameter() {
                                ParameterName = "@PageSize",
                                SqlDbType =  SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value = pageSize
                            },
                            new SqlParameter() {
                                ParameterName = "@FromDate",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  From
                            },
                            new SqlParameter() {
                                ParameterName = "@ToDate",
                                SqlDbType =  SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value = To
                            },
                            new SqlParameter() {
                                ParameterName = "@lGR_Id",
                                SqlDbType =  SqlDbType.Decimal,
                                Direction =  ParameterDirection.Input,
                                Value = lGR_Id
                            },
                            new SqlParameter() {
                                ParameterName = "@vT_No",
                                SqlDbType =  SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value = vT_No
                            },

                            totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ECN65M07GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    contraVoucher.Add(new ECN65M07GR
                                    {
                                        SL = Convert.ToInt32(sdr["SL"]),
                                        ID = Convert.ToDecimal(sdr["ID"]),
                                        vT_No = sdr["vT_No"].ToString(),
                                        tYP = sdr["tYP"].ToString(),
                                        lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]),
                                        lGR_Nm = sdr["lGR_Nm"].ToString(),
                                        dAT = sdr.IsDBNull(sdr.GetOrdinal("dAT")) ? "" : Convert.ToDateTime(sdr["dAT"]).ToString("dd-MM-yyyy"),
                                        tOT_Amt = Convert.ToDecimal(sdr["tOT_Amt"]),
                                        fN_year = sdr["fN_year"].ToString(),
                                        iNV_No = sdr["iNV_No"].ToString(),
                                        sTS_Nm = sdr["sTS_Nm"].ToString(),
                                        nAR = sdr["nAR"].ToString()
                                    });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new ContraVoucherGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = contraVoucher });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("ECN66D08GR/{cNM_Id}")]
        [HttpGet]
        public async Task<ActionResult<List<ECN66D08GR>>> ECN66D08GR(decimal cNM_Id)
        {


            List<ECN66D08GR> contraVoucherDetails = await Task.Run(() => new List<ECN66D08GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@cNM_Id";
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Decimal;
                        param.Value = cNM_Id;


                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ECN66D08GR";
                        cmd.Parameters.Add(param);
                        con.Open();


                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    contraVoucherDetails.Add(new ECN66D08GR
                                    {
                                        SL = Convert.ToInt32(sdr["SL"]),
                                        ID = Convert.ToDecimal(sdr["ID"]),
                                        cNM_Id = Convert.ToInt32(sdr["cNM_Id"]),
                                        lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]),
                                        lGR_Nm = sdr["lGR_Nm"].ToString(),
                                        aMT = Convert.ToDecimal(sdr["aMT"]),
                                        cEQ_No = sdr["cEQ_No"].ToString(),
                                        cEQ_Dat = sdr.IsDBNull(sdr.GetOrdinal("cEQ_Dat")) ? "" : Convert.ToDateTime(sdr["cEQ_Dat"]).ToString("dd-MM-yyyy"),

                                    });

                                }
                            }
                        }

                        con.Close();

                    }
                }

                return contraVoucherDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("ERE98M40NESTGR/pn/{pageNo}/ps/{pageSize}/Fr/{From}/To/{To}/{lGR_Id}/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<ReceiptMasterGrid>>> ERE98M40NESTGR(int pageNo = 1, int pageSize = 20, string From = "", string To = "", decimal lGR_Id = 0, string vT_No = "0")
        {
            decimal totRows = 0.0m;
            List<ReceiptMasterGrid> gridlst = await Task.Run(() => new List<ReceiptMasterGrid>());
            List<ERE98M40NESTGR> receiptMaster = await Task.Run(() => new List<ERE98M40NESTGR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },

                         new SqlParameter() {
                            ParameterName = "@FromDate",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  From
                        },
                        new SqlParameter() {
                            ParameterName = "@Todate",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value = To
                        },
                           new SqlParameter() {
                            ParameterName = "@lGR_Id",
                            SqlDbType =  SqlDbType.Decimal,
                            Direction =  ParameterDirection.Input,

                            Value = lGR_Id
                        },
                           new SqlParameter() {
                            ParameterName = "@vT_No",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,

                            Value = vT_No
                        },

                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ERE98M40NESTGR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    receiptMaster.Add(new ERE98M40NESTGR
                                    {
                                        SL = Convert.ToInt32(sdr["SL"]),
                                        ID = Convert.ToDecimal(sdr["ID"]),
                                        vT_No = sdr["vT_No"].ToString(),
                                        iNV_No = sdr["iNV_No"].ToString(),
                                        vT_Nm = sdr["vT_Nm"].ToString(),
                                        lGR_Nm = sdr["lGR_Nm"].ToString(),
                                        partyName = sdr["partyName"].ToString(),
                                        dAT = sdr.IsDBNull(sdr.GetOrdinal("dAT")) ? "" : Convert.ToDateTime(sdr["dAT"]).ToString("dd-MM-yyyy"),
                                        tOT_Amt = Convert.ToDecimal(sdr["tOT_Amt"]),
                                        fN_year = sdr["fN_year"].ToString(),
                                        sTS_Nm = sdr["sTS_Nm"].ToString(),
                                        nAR = sdr["nAR"].ToString()

                                    });

                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new ReceiptMasterGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = receiptMaster });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("ERE99D41NESTGR/{rM_Id}")]
        [HttpGet]
        public async Task<ActionResult<List<ERE99D41NESTGR>>> ERE99D41NESTGR(decimal rM_Id)
        {


            List<ERE99D41NESTGR> receiveMasterDetail = await Task.Run(() => new List<ERE99D41NESTGR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@rM_Id";
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Decimal;
                        param.Value = rM_Id;


                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ERE99D41NESTGR";
                        cmd.Parameters.Add(param);
                        con.Open();


                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    receiveMasterDetail.Add(new ERE99D41NESTGR
                                    {
                                        SL = Convert.ToDecimal(sdr["SL"]),
                                        ID = Convert.ToDecimal(sdr["ID"]),
                                        rM_Id = Convert.ToDecimal(sdr["rM_Id"]),
                                        vT_No = sdr["vT_No"].ToString(),
                                        lGR_Nm = sdr["lGR_Nm"].ToString(),
                                        aMT = Convert.ToDecimal(sdr["aMT"]),
                                        cEQ_No = sdr["cEQ_No"].ToString(),
                                        cEQ_Dat = sdr.IsDBNull(sdr.GetOrdinal("cEQ_Dat")) ? "" : Convert.ToDateTime(sdr["cEQ_Dat"]).ToString("dd-MM-yyyy"),

                                    });

                                }
                            }
                        }

                        con.Close();

                    }
                }

                return receiveMasterDetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        [Route("NESTEJR78M20GR/pn/{pageNo}/ps/{pageSize}/Fr/{From}/To/{To}/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<JournalVoucherGrid>>> NESTEJR78M20GR(int pageNo = 1, int pageSize = 20, string From = "", string To = "", string vT_No = "0")
        {
            decimal totRows = 0.0m;

            List<JournalVoucherGrid> gridlst = await Task.Run(() => new List<JournalVoucherGrid>());
            List<NESTEJR78M20GR> nESTFAC48L02GRs = await Task.Run(() => new List<NESTEJR78M20GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value = pageSize
                        },

                        new SqlParameter() {
                            ParameterName = "@FromDate",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  From
                        },
                        new SqlParameter() {
                            ParameterName = "@ToDate",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value = To
                        },
                         new SqlParameter() {
                            ParameterName = "@vT_No",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,

                            Value = vT_No
                        },
                            totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "NESTEJR78M20GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    nESTFAC48L02GRs.Add(new NESTEJR78M20GR
                                    {
                                        SL = Convert.ToDecimal(sdr["SL"]),
                                        ID = Convert.ToDecimal(sdr["ID"]),
                                        vT_No = sdr["vT_No"].ToString(),
                                        vT_Id = Convert.ToInt32(sdr["vT_Id"]),
                                        vT_Nm = sdr["vT_Nm"].ToString(),
                                        dAT = sdr.IsDBNull(sdr.GetOrdinal("dAT")) ? "" : Convert.ToDateTime(sdr["dAT"]).ToString("dd-MM-yyyy"),
                                        tOT_Amt = Convert.ToDecimal(sdr["tOT_Amt"]),
                                        fN_year = sdr["fN_year"].ToString(),
                                        iNV_No = sdr["iNV_No"].ToString(),
                                        sTS_Nm = sdr["sTS_Nm"].ToString(),
                                        nAR = sdr["nAR"].ToString(),

                                    });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }
                gridlst.Add(new JournalVoucherGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = nESTFAC48L02GRs });
                return gridlst;


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("NESTEJR79D21GR/{jMS_Id}")]
        [HttpGet]
        public async Task<ActionResult<List<NESTEJR79D21GR>>> NESTEJR79D21GR(decimal jMS_Id)
        {

            List<NESTEJR79D21GR> nESTDPR23F11GRs = await Task.Run(() => new List<NESTEJR79D21GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@jMS_Id";
                        param.Direction = ParameterDirection.Input;
                        param.SqlDbType = SqlDbType.Decimal;
                        param.Value = jMS_Id;


                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "NESTEJR79D21GR";
                        cmd.Parameters.Add(param);
                        con.Open();


                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    nESTDPR23F11GRs.Add(new NESTEJR79D21GR
                                    {
                                        SL = Convert.ToInt32(sdr["SL"]),
                                        ID = Convert.ToDecimal(sdr["ID"]),
                                        jMS_Id = Convert.ToDecimal(sdr["jMS_Id"]),
                                        vT_No = sdr["vT_No"].ToString(),
                                        lGR_Nm = sdr["lGR_Nm"].ToString(),
                                        cRD = sdr.IsDBNull(sdr.GetOrdinal("cRD")) ? 0.0M : Convert.ToDecimal(sdr["cRD"]),
                                        dBIT = sdr.IsDBNull(sdr.GetOrdinal("dBIT")) ? 0.0M : Convert.ToDecimal(sdr["dBIT"])

                                    });

                                }
                            }
                        }

                        con.Close();

                    }
                }

                return nESTDPR23F11GRs;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [Route("EPA83M25NESTGR/pn/{pageNo}/ps/{pageSize}/Fr/{From}/To/{To}/{lGR_Id}/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<PaymentMastGrid>>> EPA83M25NESTGR(int pageNo = 1, int pageSize = 20, string From = "", string To = "", decimal lGR_Id = 0, string vT_No = "0")
        {
            decimal totRows = 0.0m;
            List<PaymentMastGrid> gridlst = await Task.Run(() => new List<PaymentMastGrid>());
            List<EPA83M25NESTGR> paymeentMaster = await Task.Run(() => new List<EPA83M25NESTGR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value = pageSize
                        },
                        new SqlParameter() {
                            ParameterName = "@FromDate",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  From
                        },
                        new SqlParameter() {
                            ParameterName = "@ToDate",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value = To
                        },
                        new SqlParameter() {
                            ParameterName = "@lGR_Id",
                            SqlDbType =  SqlDbType.Decimal,
                            Direction =  ParameterDirection.Input,

                            Value = lGR_Id
                        },
                           new SqlParameter() {
                            ParameterName = "@vT_No",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,

                            Value = vT_No
                        },
                            totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "EPA83M25NESTGR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    paymeentMaster.Add(new EPA83M25NESTGR
                                    {
                                        SL = Convert.ToInt32(sdr["SL"]),
                                        ID = Convert.ToDecimal(sdr["ID"]),
                                        vT_No = sdr["vT_No"].ToString(),
                                        iNV_No = sdr["iNV_No"].ToString(),
                                        vT_Nm = sdr["vT_Nm"].ToString(),
                                        lGR_Nm = sdr["lGR_Nm"].ToString(),
                                        partyName = sdr["partyName"].ToString(),
                                        dAT = sdr.IsDBNull(sdr.GetOrdinal("dAT")) ? "" : Convert.ToDateTime(sdr["dAT"]).ToString("dd-MM-yyyy"),
                                        tOT_Amt = Convert.ToDecimal(sdr["tOT_Amt"]),
                                        fN_year = sdr["fN_year"].ToString(),
                                        sTS_Nm = sdr["sTS_Nm"].ToString(),
                                        nAR = sdr["nAR"].ToString()

                                    });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new PaymentMastGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = paymeentMaster });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("EPA84D26GR/{pM_Id}")]
        [HttpGet]
        public async Task<ActionResult<List<EPA84D26GR>>> EPA84D26GR(decimal pM_Id)
        {


            List<EPA84D26GR> PaymentDetails = await Task.Run(() => new List<EPA84D26GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@pM_Id";
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Decimal;
                        param.Value = pM_Id;


                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "EPA84D26GR";
                        cmd.Parameters.Add(param);
                        con.Open();


                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    PaymentDetails.Add(new EPA84D26GR
                                    {
                                        SL = Convert.ToInt32(sdr["SL"]),
                                        ID = Convert.ToDecimal(sdr["ID"]),
                                        pM_Id = Convert.ToInt32(sdr["pM_Id"]),
                                        lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]),
                                        lGR_Nm = sdr["lGR_Nm"].ToString(),
                                        aMT = Convert.ToDecimal(sdr["aMT"]),
                                        cEQ_No = sdr["cEQ_No"].ToString(),
                                        cEQ_Dat = sdr.IsDBNull(sdr.GetOrdinal("cEQ_Dat")) ? "" : Convert.ToDateTime(sdr["cEQ_Dat"]).ToString("dd-MM-yyyy")

                                    });

                                }
                            }
                        }

                        con.Close();

                    }
                }

                return PaymentDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("ReceiveVoucher/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<VoucherUpdate>>> GETReceiveVoucher(string vT_No)
        {
            List<VoucherUpdate> gridlst = await Task.Run(() => new List<VoucherUpdate>());
            GETUPDM07M20M25M40 eTUPDM07M20M25M40 = new GETUPDM07M20M25M40();
            List<GETUPDD08D21D26D41> gETUPDD08D21D26D41s = await Task.Run(() => new List<GETUPDD08D21D26D41>());

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@vT_No",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  vT_No
                            },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDERE98M40";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                eTUPDM07M20M25M40.SL = Convert.ToDecimal(sdr["SL"]);
                                eTUPDM07M20M25M40.Id = Convert.ToDecimal(sdr["ID"]);
                                eTUPDM07M20M25M40.dAT = sdr.IsDBNull(sdr.GetOrdinal("dAT")) ? "" : Convert.ToDateTime(sdr["dAT"]).ToString("dd-MM-yyyy");
                                eTUPDM07M20M25M40.vT_No = sdr["vT_No"].ToString();
                                eTUPDM07M20M25M40.iNV_No = sdr["iNV_No"].ToString();
                                eTUPDM07M20M25M40.lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]);
                                eTUPDM07M20M25M40.lGR_Nm = sdr["lGR_Nm"].ToString();
                                eTUPDM07M20M25M40.tOT_Amt = Convert.ToDecimal(sdr["tOT_Amt"]);
                                eTUPDM07M20M25M40.nAR = sdr["nAR"].ToString();

                            }
                        }

                        con.Close();


                    }
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@vT_No",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  vT_No
                            },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDERE99D41";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                gETUPDD08D21D26D41s.Add(new GETUPDD08D21D26D41
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    Id = Convert.ToDecimal(sdr["ID"]),
                                    lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]),
                                    lGR_Nm = sdr["lGR_Nm"].ToString(),
                                    aMT = Convert.ToDecimal(sdr["aMT"]),
                                    cEQ_No = sdr["cEQ_No"].ToString(),
                                    //cEQ_Dat = Convert.ToDateTime(sdr["cEQ_Dat"])
                                    cEQ_Dat = sdr.IsDBNull(sdr.GetOrdinal("cEQ_Dat")) ? "" : Convert.ToDateTime(sdr["cEQ_Dat"]).ToString("dd-MM-yyyy")


                                });
                            }
                        }

                        con.Close();


                    }

                }

                gridlst.Add(new VoucherUpdate { masterData = eTUPDM07M20M25M40, detailData = gETUPDD08D21D26D41s });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("PaymentVoucher/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<VoucherUpdate>>> GETPaymentVoucher(string vT_No)
        {
            List<VoucherUpdate> gridlst = await Task.Run(() => new List<VoucherUpdate>());
            GETUPDM07M20M25M40 eTUPDM07M20M25M40 = new GETUPDM07M20M25M40();
            List<GETUPDD08D21D26D41> gETUPDD08D21D26D41s = await Task.Run(() => new List<GETUPDD08D21D26D41>());

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@vT_No",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  vT_No
                            },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDEPA83M25";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                eTUPDM07M20M25M40.SL = Convert.ToDecimal(sdr["SL"]);
                                eTUPDM07M20M25M40.Id = Convert.ToDecimal(sdr["ID"]);
                                eTUPDM07M20M25M40.dAT = sdr.IsDBNull(sdr.GetOrdinal("dAT")) ? "" : Convert.ToDateTime(sdr["dAT"]).ToString("dd-MM-yyyy");
                                eTUPDM07M20M25M40.vT_No = sdr["vT_No"].ToString();
                                eTUPDM07M20M25M40.iNV_No = sdr["iNV_No"].ToString();
                                eTUPDM07M20M25M40.lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]);
                                eTUPDM07M20M25M40.lGR_Nm = sdr["lGR_Nm"].ToString();
                                eTUPDM07M20M25M40.tOT_Amt = Convert.ToDecimal(sdr["tOT_Amt"]);
                                eTUPDM07M20M25M40.nAR = sdr["nAR"].ToString();

                            }
                        }
                        con.Close();
                    }
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@vT_No",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  vT_No
                            },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDEPA84D26";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                gETUPDD08D21D26D41s.Add(new GETUPDD08D21D26D41
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    Id = Convert.ToDecimal(sdr["ID"]),
                                    lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]),
                                    lGR_Nm = sdr["lGR_Nm"].ToString(),
                                    aMT = Convert.ToDecimal(sdr["aMT"]),
                                    cEQ_No = sdr["cEQ_No"].ToString(),
                                    //cEQ_Dat = Convert.ToDateTime(sdr["cEQ_Dat"])
                                    cEQ_Dat = sdr.IsDBNull(sdr.GetOrdinal("cEQ_Dat")) ? "" : Convert.ToDateTime(sdr["cEQ_Dat"]).ToString("dd-MM-yyyy")


                                });

                            }
                        }

                        con.Close();


                    }

                }

                gridlst.Add(new VoucherUpdate { masterData = eTUPDM07M20M25M40, detailData = gETUPDD08D21D26D41s });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("ContraVoucher/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<VoucherUpdate>>> GETContraVoucher(string vT_No)
        {
            List<VoucherUpdate> gridlst = await Task.Run(() => new List<VoucherUpdate>());
            GETUPDM07M20M25M40 eTUPDM07M20M25M40 = new GETUPDM07M20M25M40();
            List<GETUPDD08D21D26D41> gETUPDD08D21D26D41s = await Task.Run(() => new List<GETUPDD08D21D26D41>());

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@vT_No",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  vT_No
                        },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDECN65M07";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                eTUPDM07M20M25M40.SL = Convert.ToDecimal(sdr["SL"]);
                                eTUPDM07M20M25M40.Id = Convert.ToDecimal(sdr["ID"]);
                                eTUPDM07M20M25M40.dAT = sdr.IsDBNull(sdr.GetOrdinal("dAT")) ? "" : Convert.ToDateTime(sdr["dAT"]).ToString("dd-MM-yyyy");
                                eTUPDM07M20M25M40.vT_No = sdr["vT_No"].ToString();
                                eTUPDM07M20M25M40.iNV_No = sdr["iNV_No"].ToString();
                                eTUPDM07M20M25M40.lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]);
                                eTUPDM07M20M25M40.lGR_Nm = sdr["lGR_Nm"].ToString();
                                eTUPDM07M20M25M40.tYP = sdr["tYP"].ToString();
                                eTUPDM07M20M25M40.tOT_Amt = Convert.ToDecimal(sdr["tOT_Amt"]);
                                eTUPDM07M20M25M40.nAR = sdr["nAR"].ToString();

                            }
                        }

                        con.Close();


                    }
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@vT_No",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  vT_No
                        },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDECN66D08";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                gETUPDD08D21D26D41s.Add(new GETUPDD08D21D26D41
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    Id = Convert.ToDecimal(sdr["ID"]),
                                    lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]),
                                    lGR_Nm = sdr["lGR_Nm"].ToString(),
                                    aMT = Convert.ToDecimal(sdr["aMT"]),
                                    cEQ_No = sdr["cEQ_No"].ToString(),
                                    //cEQ_Dat = Convert.ToDateTime(sdr["cEQ_Dat"])
                                    cEQ_Dat = sdr.IsDBNull(sdr.GetOrdinal("cEQ_Dat")) ? "" : Convert.ToDateTime(sdr["cEQ_Dat"]).ToString("dd-MM-yyyy")


                                });
                            }
                        }

                        con.Close();


                    }

                }

                gridlst.Add(new VoucherUpdate { masterData = eTUPDM07M20M25M40, detailData = gETUPDD08D21D26D41s });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("JournalVoucher/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<JournalVoucherUpdate>>> GETJournalVoucher(string vT_No)
        {
            List<JournalVoucherUpdate> gridlst = await Task.Run(() => new List<JournalVoucherUpdate>());
            GETUPDM07M20M25M40 eTUPDM07M20M25M40 = new GETUPDM07M20M25M40();
            List<GETUPDD08D21D26D41> gETUPDD08D21D26D41CR = await Task.Run(() => new List<GETUPDD08D21D26D41>());
            List<GETUPDD08D21D26D41DR> gETUPDD08D21D26D41DR = await Task.Run(() => new List<GETUPDD08D21D26D41DR>());

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@vT_No",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  vT_No
                            },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDEJR78M20";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                eTUPDM07M20M25M40.SL = Convert.ToDecimal(sdr["SL"]);
                                eTUPDM07M20M25M40.Id = Convert.ToDecimal(sdr["ID"]);
                                eTUPDM07M20M25M40.dAT = sdr.IsDBNull(sdr.GetOrdinal("dAT")) ? "" : Convert.ToDateTime(sdr["dAT"]).ToString("dd-MM-yyyy");
                                eTUPDM07M20M25M40.vT_No = sdr["vT_No"].ToString();
                                eTUPDM07M20M25M40.iNV_No = sdr["iNV_No"].ToString();
                                eTUPDM07M20M25M40.tOT_Amt = Convert.ToDecimal(sdr["tOT_Amt"]);
                                eTUPDM07M20M25M40.nAR = sdr["nAR"].ToString();

                            }
                        }
                        con.Close();
                    }
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@vT_No",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  vT_No
                            },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDEJR79D21CR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                gETUPDD08D21D26D41CR.Add(new GETUPDD08D21D26D41
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    Id = Convert.ToDecimal(sdr["ID"]),
                                    lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]),
                                    lGR_Nm = sdr["lGR_Nm"].ToString(),
                                    dBIT = Convert.ToDecimal(sdr["dBIT"]),
                                    cRD = Convert.ToDecimal(sdr["cRD"]),
                                    cEQ_No = sdr["cEQ_No"].ToString(),
                                    //cEQ_Dat = Convert.ToDateTime(sdr["cEQ_Dat"])
                                    cEQ_Dat = sdr.IsDBNull(sdr.GetOrdinal("cEQ_Dat")) ? "" : Convert.ToDateTime(sdr["cEQ_Dat"]).ToString("dd-MM-yyyy")


                                });

                            }
                        }

                        con.Close();


                    }

                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@vT_No",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  vT_No
                            },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GETUPDEJR79D21DR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                gETUPDD08D21D26D41DR.Add(new GETUPDD08D21D26D41DR
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    Id = Convert.ToDecimal(sdr["ID"]),
                                    lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]),
                                    lGR_Nm = sdr["lGR_Nm"].ToString(),
                                    dBIT = Convert.ToDecimal(sdr["dBIT"]),
                                    cRD = Convert.ToDecimal(sdr["cRD"]),
                                    cEQ_No = sdr["cEQ_No"].ToString(),
                                    //cEQ_Dat = Convert.ToDateTime(sdr["cEQ_Dat"])
                                    cEQ_Dat = sdr.IsDBNull(sdr.GetOrdinal("cEQ_Dat")) ? "" : Convert.ToDateTime(sdr["cEQ_Dat"]).ToString("dd-MM-yyyy")


                                });

                            }
                        }

                        con.Close();


                    }

                }

                gridlst.Add(new JournalVoucherUpdate { masterData = eTUPDM07M20M25M40, rightData = gETUPDD08D21D26D41CR, leftData = gETUPDD08D21D26D41DR });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("PRINTESA06M48/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<PRINTESA06M48>>> GetPRINTESA06M48(string vT_No)
        {
            List<PRINTESA06M48> lst = await Task.Run(() => new List<PRINTESA06M48>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@vT_No",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value = vT_No
                        }
                        };



                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "PRINTESA06M48";
                        cmd.Parameters.AddRange(param);

                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lst.Add(new PRINTESA06M48
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    Id = Convert.ToDecimal(sdr["ID"]),
                                    vT_No = sdr["vT_No"].ToString(),
                                    dAT = sdr["dAT"].ToString(),
                                    lGR_Nm = sdr["lGR_Nm"].ToString(),
                                    mOB = sdr["mOB"].ToString(),
                                    item = sdr["item"].ToString(),
                                    sKU_Cod = sdr["sKU_Cod"].ToString(),
                                    qTY = Convert.ToDecimal(sdr["qTY"]),
                                    uN_Nm = sdr["uN_Nm"].ToString(),
                                    rAT = Convert.ToDecimal(sdr["rAT"]),
                                    dIS = Convert.ToDecimal(sdr["dIS"]),
                                    nET_Amt = Convert.ToDecimal(sdr["nET_Amt"])

                                });
                            }


                        }
                        con.Close();
                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("PartySalesDetails/{From}/{To}/{lGR_Id}")]
        [HttpGet]
        public async Task<ActionResult<List<PRINTESA06M48>>> GetPartySalesDetails(string From, string To, decimal lGR_Id)
        {
            List<PRINTESA06M48> lst = await Task.Run(() => new List<PRINTESA06M48>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@FromDate",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  From
                            },
                            new SqlParameter() {
                                ParameterName = "@ToDate",
                                SqlDbType =  SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value = To
                            },
                            new SqlParameter() {
                                ParameterName = "@lGR_Id",
                                SqlDbType =  SqlDbType.Decimal,
                                Direction =  ParameterDirection.Input,
                                Value = lGR_Id
                            },
                        };



                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "RptPartySales";
                        cmd.Parameters.AddRange(param);

                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lst.Add(new PRINTESA06M48
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    Id = Convert.ToDecimal(sdr["ID"]),
                                    vT_No = sdr["vT_No"].ToString(),
                                    dAT = sdr["dAT"].ToString(),
                                    lGR_Nm = sdr["lGR_Nm"].ToString(),
                                    mOB = sdr["mOB"].ToString(),
                                    item = sdr["item"].ToString(),
                                    mNF_Nm = sdr["mNF_Nm"].ToString(),
                                    sKU_Cod = sdr["sKU_Cod"].ToString(),
                                    qTY = Convert.ToDecimal(sdr["qTY"]),
                                    uN_Nm = sdr["uN_Nm"].ToString(),
                                    rAT = Convert.ToDecimal(sdr["rAT"]),
                                    dIS = Convert.ToDecimal(sdr["dIS"]),
                                    nET_Amt = Convert.ToDecimal(sdr["nET_Amt"])

                                });
                            }


                        }
                        con.Close();
                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("RptLedgerSummary/{From}/{To}/{aG_Id}")]
        [HttpGet]
        public async Task<ActionResult<List<RptLedgerSummary>>> GetRptLedgerSummary(string From, string To, decimal aG_Id)
        {
            List<RptLedgerSummary> lst = await Task.Run(() => new List<RptLedgerSummary>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@FromDate",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  From
                        },
                        new SqlParameter() {
                            ParameterName = "@ToDate",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value = To
                        },
                        new SqlParameter() {
                            ParameterName = "@aG_Id",
                            SqlDbType =  SqlDbType.Decimal,
                            Direction =  ParameterDirection.Input,
                            Value = aG_Id
                        },

                        };



                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "RptLedgerSummary";
                        cmd.Parameters.AddRange(param);

                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lst.Add(new RptLedgerSummary
                                {
                                    sl = Convert.ToDecimal(sdr["SL"]),
                                    aG_Nm = sdr["aG_Nm"].ToString(),
                                    lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]),
                                    lGR_Nm = sdr["lGR_Nm"].ToString(),
                                    aDDR = sdr["aDDR"].ToString(),
                                    mOB = sdr["mOB"].ToString(),
                                    dR_Amt = Convert.ToDecimal(sdr["dR_Amt"]),
                                    cR_Amt = Convert.ToDecimal(sdr["cR_Amt"]),
                                    Bal = Convert.ToDecimal(sdr["Bal"])

                                });
                            }

                        }
                        con.Close();
                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("RptLedgerTransaction/{From}/{To}/{lGR_Id}")]
        [HttpGet]
        public async Task<ActionResult<List<RptLedgerTransaction>>> GetRptLedgerTransaction(string From, string To, decimal lGR_Id)
        {
            List<RptLedgerTransaction> lst = await Task.Run(() => new List<RptLedgerTransaction>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@FromDate",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  From
                        },
                        new SqlParameter() {
                            ParameterName = "@ToDate",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value = To
                        },
                        new SqlParameter() {
                            ParameterName = "@lGR_Id",
                            SqlDbType =  SqlDbType.Decimal,
                            Direction =  ParameterDirection.Input,
                            Value = lGR_Id
                        },

                        };



                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "RptLedgerTransaction";
                        cmd.Parameters.AddRange(param);

                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lst.Add(new RptLedgerTransaction
                                {
                                    sl = Convert.ToDecimal(sdr["SL"]),
                                    dAT = sdr["dAT"].ToString(),
                                    lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]),
                                    lGR_Nm = sdr["lGR_Nm"].ToString(),
                                    aDDR = sdr["aDDR"].ToString(),
                                    mOB = sdr["mOB"].ToString(),
                                    vT_No = sdr["vT_No"].ToString(),
                                    vT_Nm = sdr["vT_Nm"].ToString(),
                                    dR_Amt = Convert.ToDecimal(sdr["dR_Amt"]),
                                    cR_Amt = Convert.ToDecimal(sdr["cR_Amt"])

                                });
                            }

                        }
                        con.Close();
                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("RptCurrentStock/{From}/{To}/{s_Id}/{mNF_Id}/{cT_Id}/{gEN_Id}/{bR_Id}")]
        [HttpGet]
        public async Task<ActionResult<List<RptCurrentStock>>> GetRptCurrentStock(string From, string To, decimal s_Id, string mNF_Id, string cT_Id, string gEN_Id, string bR_Id)
        {
            List<RptCurrentStock> lst = await Task.Run(() => new List<RptCurrentStock>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@FromDate",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  From
                        },
                        new SqlParameter() {
                            ParameterName = "@ToDate",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value = To
                        },
                        new SqlParameter() {
                            ParameterName = "@s_Id",
                            SqlDbType =   SqlDbType.Decimal,
                            Direction =  ParameterDirection.Input,
                            Value =  s_Id
                        },

                        new SqlParameter() {
                            ParameterName = "@mNF_Id",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,

                            Value = mNF_Id
                        },
                        new SqlParameter() {
                            ParameterName = "@cT_Id",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,

                            Value = cT_Id
                        },
                        new SqlParameter() {
                            ParameterName = "@gEN_Id",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,

                            Value = gEN_Id
                        },

                        new SqlParameter() {
                            ParameterName = "@bR_Id",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,

                            Value = bR_Id
                        },

                        };

                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "RptCurrentStock";
                        cmd.Parameters.AddRange(param);

                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lst.Add(new RptCurrentStock
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    items = sdr["items"].ToString(),
                                    rAT = Convert.ToDecimal(sdr["rAT"]),
                                    OpenQty = Convert.ToDecimal(sdr["OpenQty"]),
                                    iNW_Qty = Convert.ToDecimal(sdr["iNW_Qty"]),
                                    oUW_Qty = Convert.ToDecimal(sdr["oUW_Qty"]),
                                    Balance_Qty = Convert.ToDecimal(sdr["Balance_Qty"])
                                });
                            }

                        }
                        con.Close();
                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("RptSalesSummary/{From}/{To}/{lGR_Id}/{dMR_Id}/{plabel}")]
        [HttpGet]
        public async Task<ActionResult<List<RptSalesSummary>>> GetRptSalesSummary(string From, string To, decimal lGR_Id, int dMR_Id, int plabel)
        {
            List<RptSalesSummary> lst = await Task.Run(() => new List<RptSalesSummary>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@FromDate",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  From
                            },
                            new SqlParameter() {
                                ParameterName = "@ToDate",
                                SqlDbType =  SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value = To
                            },
                            new SqlParameter() {
                                ParameterName = "@lGR_Id",
                                SqlDbType =  SqlDbType.Decimal,
                                Direction =  ParameterDirection.Input,
                                Value = lGR_Id
                            },
                            new SqlParameter() {
                                ParameterName = "@dMR_Id",
                                SqlDbType =  SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value = dMR_Id
                            },
                            new SqlParameter() {
                                ParameterName = "@plabel",
                                SqlDbType =  SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value = plabel
                            },

                        };



                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "RptSalesSummary";
                        cmd.Parameters.AddRange(param);

                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lst.Add(new RptSalesSummary
                                {
                                    sl = Convert.ToDecimal(sdr["SL"]),
                                    lGR_Nm = sdr["lGR_Nm"].ToString(),
                                    aDDR = sdr["aDDR"].ToString(),
                                    dMR_Nm = sdr["dMR_Nm"].ToString(),
                                    OpBal = Convert.ToDecimal(sdr["OpBal"]),
                                    TotChlAmt = Convert.ToDecimal(sdr["TotChlAmt"]),
                                    TotChlDisAmt = Convert.ToDecimal(sdr["TotChlDisAmt"]),
                                    TotChlAddCst = Convert.ToDecimal(sdr["TotChlAddCst"]),
                                    TotRtnAmt = Convert.ToDecimal(sdr["TotRtnAmt"]),
                                    TotRtnDisAmt = Convert.ToDecimal(sdr["TotRtnDisAmt"]),
                                    TotRtnAddCst = Convert.ToDecimal(sdr["TotRtnAddCst"]),
                                    TotDepAmt = Convert.ToDecimal(sdr["TotDepAmt"])
                                });
                            }

                        }
                        con.Close();
                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("RptPurchaseSummary/{From}/{To}/{lGR_Id}")]
        [HttpGet]
        public async Task<ActionResult<List<RptPurchaseSummary>>> GetRptPurchaseSummary(string From, string To, decimal lGR_Id)
        {
            List<RptPurchaseSummary> lst = await Task.Run(() => new List<RptPurchaseSummary>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@FromDate",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  From
                        },
                        new SqlParameter() {
                            ParameterName = "@ToDate",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value = To
                        },
                        new SqlParameter() {
                            ParameterName = "@lGR_Id",
                            SqlDbType =  SqlDbType.Decimal,
                            Direction =  ParameterDirection.Input,
                            Value = lGR_Id
                        },

                        };



                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "RptPurchaseSummary";
                        cmd.Parameters.AddRange(param);

                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lst.Add(new RptPurchaseSummary
                                {
                                    sl = Convert.ToDecimal(sdr["SL"]),
                                    lGR_Nm = sdr["lGR_Nm"].ToString(),
                                    aDDR = sdr["aDDR"].ToString(),
                                    dMR_Nm = sdr["dMR_Nm"].ToString(),
                                    OpBal = Convert.ToDecimal(sdr["OpBal"]),
                                    TotPurAmt = Convert.ToDecimal(sdr["TotPurAmt"]),
                                    TotPurDisAmt = Convert.ToDecimal(sdr["TotPurDisAmt"]),
                                    TotPurAddCst = Convert.ToDecimal(sdr["TotPurAddCst"]),
                                    TotPurRtnAmt = Convert.ToDecimal(sdr["TotPurRtnAmt"]),
                                    TotPurRtnDisAmt = Convert.ToDecimal(sdr["TotPurRtnDisAmt"]),
                                    TotPurRtnAddCst = Convert.ToDecimal(sdr["TotPurRtnAddCst"]),
                                    TotPayAmt = Convert.ToDecimal(sdr["TotPayAmt"])
                                });
                            }

                        }
                        con.Close();
                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("RptStockMovement/{From}/{To}/{sKU_Id}")]
        [HttpGet]
        public async Task<ActionResult<List<RptCurrentStock>>> GetRptStockMovement(string From, string To, decimal sKU_Id)
        {
            List<RptCurrentStock> lst = await Task.Run(() => new List<RptCurrentStock>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@FromDate",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  From
                        },
                        new SqlParameter() {
                            ParameterName = "@ToDate",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value = To
                        },
                        new SqlParameter() {
                            ParameterName = "@sKU_Id",
                            SqlDbType =  SqlDbType.Decimal,
                            Direction =  ParameterDirection.Input,
                            Value = sKU_Id
                        },

                        };



                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "RptStockMovement";
                        cmd.Parameters.AddRange(param);

                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lst.Add(new RptCurrentStock
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    dAT = sdr["dAT"].ToString(),
                                    vT_No = sdr["vT_No"].ToString(),
                                    items = sdr["items"].ToString(),
                                    OpenQty = Convert.ToDecimal(sdr["OpenQty"]),
                                    iNW_Qty = Convert.ToDecimal(sdr["iNW_Qty"]),
                                    oUW_Qty = Convert.ToDecimal(sdr["oUW_Qty"]),
                                    Balance_Qty = Convert.ToDecimal(sdr["CloQty"])
                                });
                            }

                        }
                        con.Close();
                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        [Route("RptCusSalesAmt/pn/{pageNo}/ps/{pageSize}/{From}/{To}/{lGR_Id}/{vT_No}/{isChecked}")]
        [HttpGet]
        public async Task<ActionResult<List<RptCusSalesAmtGrid>>> RptCusSalesAmt(int pageNo = 1, int pageSize = 20, string From = "", string To = "", decimal lGR_Id = 0, string vT_No = "0", bool isChecked = false)
        {
            decimal totRows = 0.0m;
            List<RptCusSalesAmtGrid> gridlst = await Task.Run(() => new List<RptCusSalesAmtGrid>());
            List<RptCusSalesAmt> rptSalesParchase = await Task.Run(() => new List<RptCusSalesAmt>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@PageNo",
                                SqlDbType =   SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value =  pageNo
                            },
                            new SqlParameter() {
                                ParameterName = "@PageSize",
                                SqlDbType =  SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value = pageSize
                            },
                            new SqlParameter() {
                                ParameterName = "@FromDate",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  From
                            },
                            new SqlParameter() {
                                ParameterName = "@ToDate",
                                SqlDbType =  SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value = To
                            },
                            new SqlParameter() {
                                ParameterName = "@lGR_Id",
                                SqlDbType =  SqlDbType.Decimal,
                                Direction =  ParameterDirection.Input,
                                Value = lGR_Id
                            },
                            new SqlParameter() {
                                ParameterName = "@vT_No",
                                SqlDbType =  SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value = vT_No
                            },
                            new SqlParameter() {
                                ParameterName = "@isChecked",
                                SqlDbType =  SqlDbType.Bit,
                                Direction =  ParameterDirection.Input,
                                Value = isChecked
                            },

                            totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "RptCusSalesAmt";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                rptSalesParchase.Add(new RptCusSalesAmt
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    Id = Convert.ToDecimal(sdr["ID"]),
                                    dAT = sdr["dAT"].ToString(),
                                    vT_No = sdr["vT_No"].ToString(),
                                    iNV_No = sdr["iNV_No"].ToString(),
                                    lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]),
                                    lGR_Nm = sdr["lGR_Nm"].ToString(),
                                    aDDR = sdr["aDDR"].ToString(),
                                    gR_Tot = Convert.ToDecimal(sdr["gR_Tot"]),
                                    bIL_Dis = Convert.ToDecimal(sdr["bIL_Dis"]),
                                    aDD_Cst = Convert.ToDecimal(sdr["aDD_Cst"]),
                                    TotalAmount = Convert.ToDecimal(sdr["TotalAmount"]),
                                    sP_Dis = Convert.ToDecimal(sdr["sP_Dis"]),
                                    Paid_amt = Convert.ToDecimal(sdr["Paid_amt"]),
                                    Due = Convert.ToDecimal(sdr["Due"])
                                });
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new RptCusSalesAmtGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = rptSalesParchase });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("RptCusReturnAmt/pn/{pageNo}/ps/{pageSize}/{From}/{To}/{lGR_Id}/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<RptSalesReturnGrid>>> GetRptCusReturnAmt(int pageNo = 1, int pageSize = 20, string From = "", string To = "", decimal lGR_Id = 0, string vT_No = "0")
        {
            decimal totRows = 0.0m;
            List<RptSalesReturnGrid> gridlst = await Task.Run(() => new List<RptSalesReturnGrid>());
            List<RptCusSalesAmt> rptSalesreturn = await Task.Run(() => new List<RptCusSalesAmt>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value = pageSize
                        },
                        new SqlParameter() {
                            ParameterName = "@FromDate",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  From
                        },
                        new SqlParameter() {
                            ParameterName = "@ToDate",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value = To
                        },
                           new SqlParameter() {
                            ParameterName = "@lGR_Id",
                            SqlDbType =  SqlDbType.Decimal,
                            Direction =  ParameterDirection.Input,

                            Value = lGR_Id
                        },
                           new SqlParameter() {
                            ParameterName = "@vT_No",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,

                            Value = vT_No
                        },

                            totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "RptCusReturnAmt";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                rptSalesreturn.Add(new RptCusSalesAmt
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    Id = Convert.ToDecimal(sdr["ID"]),
                                    dAT = sdr["dAT"].ToString(),
                                    vT_No = sdr["vT_No"].ToString(),
                                    iNV_No = sdr["iNV_No"].ToString(),
                                    lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]),
                                    lGR_Nm = sdr["lGR_Nm"].ToString(),
                                    aDDR = sdr["aDDR"].ToString(),
                                    gR_Tot = Convert.ToDecimal(sdr["gR_Tot"]),
                                    bIL_Dis = Convert.ToDecimal(sdr["bIL_Dis"]),
                                    aDD_Cst = Convert.ToDecimal(sdr["aDD_Cst"]),
                                    TotalAmount = Convert.ToDecimal(sdr["TotalAmount"]),
                                    sP_Dis = Convert.ToDecimal(sdr["sP_Dis"]),
                                    Paid_amt = Convert.ToDecimal(sdr["Paid_amt"]),
                                    Due = Convert.ToDecimal(sdr["Due"])
                                });
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new RptSalesReturnGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = rptSalesreturn });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("RptComPurchaseAmt/pn/{pageNo}/ps/{pageSize}/{From}/{To}/{lGR_Id}/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<RptPurchaseVoucherGrid>>> GetRptComPurchaseAmt(int pageNo = 1, int pageSize = 20, string From = "", string To = "", decimal lGR_Id = 0, string vT_No = "0")
        {
            decimal totRows = 0.0m;
            List<RptPurchaseVoucherGrid> gridlst = await Task.Run(() => new List<RptPurchaseVoucherGrid>());
            List<RptComPurchaseAmt> rptParchase = await Task.Run(() => new List<RptComPurchaseAmt>());

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value = pageSize
                        },
                        new SqlParameter() {
                            ParameterName = "@FromDate",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  From
                        },
                        new SqlParameter() {
                            ParameterName = "@ToDate",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value = To
                        },
                           new SqlParameter() {
                            ParameterName = "@lGR_Id",
                            SqlDbType =  SqlDbType.Decimal,
                            Direction =  ParameterDirection.Input,

                            Value = lGR_Id
                        },
                           new SqlParameter() {
                            ParameterName = "@vT_No",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,

                            Value = vT_No
                        },

                            totalDataRows
                        };


                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "RptComPurchaseAmt";
                        cmd.Parameters.AddRange(param);

                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                rptParchase.Add(new RptComPurchaseAmt
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    Id = Convert.ToDecimal(sdr["ID"]),
                                    dAT = sdr["dAT"].ToString(),
                                    vT_No = sdr["vT_No"].ToString(),
                                    iNV_No = sdr["iNV_No"].ToString(),
                                    lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]),
                                    lGR_Nm = sdr["lGR_Nm"].ToString(),
                                    aDDR = sdr["aDDR"].ToString(),
                                    gR_Tot = Convert.ToDecimal(sdr["gR_Tot"]),
                                    bIL_Dis = Convert.ToDecimal(sdr["bIL_Dis"]),
                                    aDD_Cst = Convert.ToDecimal(sdr["aDD_Cst"]),
                                    TotalAmount = Convert.ToDecimal(sdr["TotalAmount"]),
                                    sP_Dis = Convert.ToDecimal(sdr["sP_Dis"]),
                                    Paid_amt = Convert.ToDecimal(sdr["Paid_amt"]),
                                    Due = Convert.ToDecimal(sdr["Due"])

                                });
                            }

                        }
                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();
                    }
                }
                gridlst.Add(new RptPurchaseVoucherGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = rptParchase });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("RptComReturnAmt/pn/{pageNo}/ps/{pageSize}/{From}/{To}/{lGR_Id}/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<RptPurchaseReturnGrid>>> GetRptComReturnAmt(int pageNo = 1, int pageSize = 20, string From = "", string To = "", decimal lGR_Id = 0, string vT_No = "0")
        {
            decimal totRows = 0.0m;
            List<RptPurchaseReturnGrid> gridlst = await Task.Run(() => new List<RptPurchaseReturnGrid>());
            List<RptComPurchaseAmt> rptParchaseReturn = await Task.Run(() => new List<RptComPurchaseAmt>());

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@PageNo",
                                SqlDbType =   SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value =  pageNo
                            },
                            new SqlParameter() {
                                ParameterName = "@PageSize",
                                SqlDbType =  SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value = pageSize
                            },
                            new SqlParameter() {
                                ParameterName = "@FromDate",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  From
                            },
                            new SqlParameter() {
                                ParameterName = "@ToDate",
                                SqlDbType =  SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value = To
                            },
                            new SqlParameter() {
                                ParameterName = "@lGR_Id",
                                SqlDbType =  SqlDbType.Decimal,
                                Direction =  ParameterDirection.Input,

                                Value = lGR_Id
                            },
                            new SqlParameter() {
                                ParameterName = "@vT_No",
                                SqlDbType =  SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,

                                Value = vT_No
                            },

                            totalDataRows
                        };


                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "RptComReturnAmt";
                        cmd.Parameters.AddRange(param);

                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                rptParchaseReturn.Add(new RptComPurchaseAmt
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    Id = Convert.ToDecimal(sdr["ID"]),
                                    dAT = sdr["dAT"].ToString(),
                                    vT_No = sdr["vT_No"].ToString(),
                                    iNV_No = sdr["iNV_No"].ToString(),
                                    lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]),
                                    lGR_Nm = sdr["lGR_Nm"].ToString(),
                                    aDDR = sdr["aDDR"].ToString(),
                                    gR_Tot = Convert.ToDecimal(sdr["gR_Tot"]),
                                    bIL_Dis = Convert.ToDecimal(sdr["bIL_Dis"]),
                                    aDD_Cst = Convert.ToDecimal(sdr["aDD_Cst"]),
                                    TotalAmount = Convert.ToDecimal(sdr["TotalAmount"]),
                                    sP_Dis = Convert.ToDecimal(sdr["sP_Dis"]),
                                    Paid_amt = Convert.ToDecimal(sdr["Paid_amt"]),
                                    Due = Convert.ToDecimal(sdr["Due"])

                                });
                            }

                        }
                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();
                    }
                }
                gridlst.Add(new RptPurchaseReturnGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = rptParchaseReturn });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("RptSalesReturnVoucher/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<PRINTESA06M48>>> GetRptSalesReturnVoucher(string vT_No)
        {
            List<PRINTESA06M48> lst = await Task.Run(() => new List<PRINTESA06M48>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@vT_No",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value = vT_No
                        },
                        };



                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "RptSalesReturnVoucher";
                        cmd.Parameters.AddRange(param);

                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lst.Add(new PRINTESA06M48
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    Id = Convert.ToDecimal(sdr["ID"]),
                                    vT_No = sdr["vT_No"].ToString(),
                                    dAT = sdr["dAT"].ToString(),
                                    lGR_Nm = sdr["lGR_Nm"].ToString(),
                                    mOB = sdr["mOB"].ToString(),
                                    item = sdr["item"].ToString(),
                                    sKU_Cod = sdr["sKU_Cod"].ToString(),
                                    qTY = Convert.ToDecimal(sdr["qTY"]),
                                    uN_Nm = sdr["uN_Nm"].ToString(),
                                    rAT = Convert.ToDecimal(sdr["rAT"]),
                                    dIS = Convert.ToDecimal(sdr["dIS"]),
                                    nET_Amt = Convert.ToDecimal(sdr["nET_Amt"])

                                });
                            }


                        }
                        con.Close();
                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("RptCusReceiptAmt/{From}/{To}/{lGR_Id}/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<RptReceiptAmt>>> GetRptCusReceiptAmt(string From, string To, decimal lGR_Id, string vT_No)
        {
            List<RptReceiptAmt> lst = await Task.Run(() => new List<RptReceiptAmt>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@FromDate",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  From
                        },
                        new SqlParameter() {
                            ParameterName = "@ToDate",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value = To
                        },
                        new SqlParameter() {
                            ParameterName = "@lGR_Id",
                            SqlDbType =  SqlDbType.Decimal,
                            Direction =  ParameterDirection.Input,
                            Value = lGR_Id
                        },
                        new SqlParameter() {
                            ParameterName = "@vT_No",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,

                            Value = vT_No
                        },
                        };



                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "RptCusReceiptAmt";
                        cmd.Parameters.AddRange(param);

                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lst.Add(new RptReceiptAmt
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    dAT = sdr["dAT"].ToString(),
                                    //dAT = Convert.ToDateTime(sdr["dAT"]).ToString("dd-MM-yyyy"),
                                    vT_No = sdr["vT_No"].ToString(),
                                    lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]),
                                    lGR_Nm = sdr["lGR_Nm"].ToString(),
                                    aDDR = sdr["aDDR"].ToString(),
                                    aMT = Convert.ToDecimal(sdr["aMT"]),
                                    cEQ_No = sdr["cEQ_No"].ToString(),
                                    cEQ_Dat = sdr["cEQ_Dat"].ToString()

                                });
                            }

                        }
                        con.Close();
                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("RptComPaymentAmt/{From}/{To}/{lGR_Id}/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<RptReceiptAmt>>> GetRptComPaymentAmt(string From, string To, decimal lGR_Id, string vT_No)
        {
            List<RptReceiptAmt> lst = await Task.Run(() => new List<RptReceiptAmt>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@FromDate",
                            SqlDbType =   SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value =  From
                        },
                        new SqlParameter() {
                            ParameterName = "@ToDate",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value = To
                        },
                        new SqlParameter() {
                            ParameterName = "@lGR_Id",
                            SqlDbType =  SqlDbType.Decimal,
                            Direction =  ParameterDirection.Input,
                            Value = lGR_Id
                        },
                        new SqlParameter() {
                            ParameterName = "@vT_No",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,

                            Value = vT_No
                        },
                        };



                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "RptComPaymentAmt";
                        cmd.Parameters.AddRange(param);

                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lst.Add(new RptReceiptAmt
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    dAT = sdr["dAT"].ToString(),
                                    //dAT = Convert.ToDateTime(sdr["dAT"]).ToString("dd-MM-yyyy"),
                                    vT_No = sdr["vT_No"].ToString(),
                                    lGR_Id = Convert.ToDecimal(sdr["lGR_Id"]),
                                    lGR_Nm = sdr["lGR_Nm"].ToString(),
                                    aDDR = sdr["aDDR"].ToString(),
                                    aMT = Convert.ToDecimal(sdr["aMT"]),
                                    cEQ_No = sdr["cEQ_No"].ToString(),
                                    cEQ_Dat = sdr["cEQ_Dat"].ToString()


                                });
                            }

                        }
                        con.Close();
                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("RptPurchaseVoucher/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<RptPurchaseVoucher>>> GetRptPurchaseVoucher(string vT_No)
        {
            List<RptPurchaseVoucher> lst = await Task.Run(() => new List<RptPurchaseVoucher>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@vT_No",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value = vT_No
                        },

                        };



                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "RptPurchaseVoucher";
                        cmd.Parameters.AddRange(param);

                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lst.Add(new RptPurchaseVoucher
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    Id = Convert.ToDecimal(sdr["ID"]),
                                    vT_No = sdr["vT_No"].ToString(),
                                    dAT = sdr["dAT"].ToString(),
                                    lGR_Nm = sdr["lGR_Nm"].ToString(),
                                    mOB = sdr["mOB"].ToString(),
                                    item = sdr["item"].ToString(),
                                    sKU_Cod = sdr["sKU_Cod"].ToString(),
                                    qTY = Convert.ToDecimal(sdr["qTY"]),
                                    uN_Nm = sdr["uN_Nm"].ToString(),
                                    rAT = Convert.ToDecimal(sdr["rAT"]),
                                    dIS = Convert.ToDecimal(sdr["dIS"]),
                                    nET_Amt = Convert.ToDecimal(sdr["nET_Amt"])

                                });
                            }


                        }
                        con.Close();
                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("RptPurchaseReturnVoucher/{vT_No}")]
        [HttpGet]
        public async Task<ActionResult<List<RptPurchaseVoucher>>> GetRptPurchaseReturnVoucher(string vT_No)
        {
            List<RptPurchaseVoucher> lst = await Task.Run(() => new List<RptPurchaseVoucher>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@vT_No",
                            SqlDbType =  SqlDbType.NVarChar,
                            Direction =  ParameterDirection.Input,
                            Value = vT_No
                        },

                        };



                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "RptPurchaseReturnVoucher";
                        cmd.Parameters.AddRange(param);

                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lst.Add(new RptPurchaseVoucher
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    Id = Convert.ToDecimal(sdr["ID"]),
                                    vT_No = sdr["vT_No"].ToString(),
                                    dAT = sdr["dAT"].ToString(),
                                    lGR_Nm = sdr["lGR_Nm"].ToString(),
                                    mOB = sdr["mOB"].ToString(),
                                    item = sdr["item"].ToString(),
                                    sKU_Cod = sdr["sKU_Cod"].ToString(),
                                    qTY = Convert.ToDecimal(sdr["qTY"]),
                                    uN_Nm = sdr["uN_Nm"].ToString(),
                                    rAT = Convert.ToDecimal(sdr["rAT"]),
                                    dIS = Convert.ToDecimal(sdr["dIS"]),
                                    nET_Amt = Convert.ToDecimal(sdr["nET_Amt"])
                                });
                            }


                        }
                        con.Close();
                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("DayBook/{FromDate}/{ToDate}/{vT_Id}/{lGR_Id}")]
        [HttpGet]
        public async Task<ActionResult<List<DayBook>>> GetCashFlow(DateTime FromDate, DateTime ToDate, int vT_Id = 0, decimal lGR_Id = 0)
        {
            List<DayBook> lst = await Task.Run(() => new List<DayBook>());
            try
            {
                
                DataSet dsetDayBook = new DataSet();
                DataTable dtbl = new DataTable();



                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    using (SqlCommand cmd = new SqlCommand())
                    {



                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "DayBook";
                        cmd.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = FromDate;
                        cmd.Parameters.Add("@toDate", SqlDbType.DateTime).Value = ToDate;
                        cmd.Parameters.Add("@vT_Id", SqlDbType.Int).Value = vT_Id;
                        cmd.Parameters.Add("@lGR_Id", SqlDbType.Decimal).Value = lGR_Id;

                        adapter.SelectCommand = cmd;
                        con.Open();
                        adapter.Fill(dsetDayBook);
                        con.Close();



                        DataTable dtDayBook = new DataTable();
                        dtDayBook.Columns.Add("Date");
                        dtDayBook.Columns.Add("Particulars");
                        dtDayBook.Columns.Add("voucherType");
                        dtDayBook.Columns.Add("vT_No");
                        dtDayBook.Columns.Add("iNV_No");
                        dtDayBook.Columns.Add("Description");
                        dtDayBook.Columns.Add("dR_Inw");
                        dtDayBook.Columns.Add("cR_Outw");
                        dtDayBook.Columns.Add("MasterId");
                        DataRow drow = null;


                        dtbl = dsetDayBook.Tables[0];
                        foreach (DataRow rw in dtbl.Rows)
                        {

                            drow = dtDayBook.NewRow();
                            drow["Date"] = rw["Date"].ToString();
                            drow["Particulars"] = rw["Particulars"].ToString();
                            drow["voucherType"] = rw["voucherType"].ToString();
                            drow["vT_No"] = rw["vT_No"].ToString();
                            drow["iNV_No"] = rw["iNV_No"].ToString();
                            drow["Description"] = rw["Description"].ToString();
                            drow["dR_Inw"] = rw["dR_Inw"].ToString();
                            drow["cR_Outw"] = rw["cR_Outw"].ToString();
                            drow["MasterId"] = rw["MasterId"].ToString();
                            dtDayBook.Rows.Add(drow);


                        }

                        dtbl = dsetDayBook.Tables[1];
                        foreach (DataRow rw in dtbl.Rows)
                        {


                            drow = dtDayBook.NewRow();
                            drow["Date"] = rw["Date"].ToString();
                            drow["Particulars"] = rw["Particulars"].ToString();
                            drow["voucherType"] = rw["voucherType"].ToString();
                            drow["vT_No"] = rw["vT_No"].ToString();
                            drow["iNV_No"] = rw["iNV_No"].ToString();
                            drow["Description"] = rw["Description"].ToString();
                            drow["dR_Inw"] = rw["dR_Inw"].ToString();
                            drow["cR_Outw"] = rw["cR_Outw"].ToString();
                            drow["MasterId"] = rw["MasterId"].ToString();
                            dtDayBook.Rows.Add(drow);


                        }

                        for (int i = 0; i < dtDayBook.Rows.Count; i++)
                        {
                            lst.Add(new DayBook()
                            {
                                Id = (i+1 ).ToString(),
                                Date = dtDayBook.Rows[i][0].ToString(),
                                Particulars = dtDayBook.Rows[i][1].ToString(),
                                voucherType = dtDayBook.Rows[i][2].ToString(),
                                vT_No = dtDayBook.Rows[i][3].ToString(),
                                iNV_No = dtDayBook.Rows[i][4].ToString(),
                                Description = dtDayBook.Rows[i][5].ToString(),
                                dR_Inw = dtDayBook.Rows[i][6].ToString(),
                                cR_Outw = dtDayBook.Rows[i][7].ToString()
                               
                            });


                        }

                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        [Route("CashFlow/{FromDate}/{ToDate}")]
        [HttpGet]
        public async Task<ActionResult<List<CashFlow>>> GetCashFlow(DateTime FromDate, DateTime ToDate)
        {
            List<CashFlow> lst = await Task.Run(() => new List<CashFlow>());
            try
            {
                int inDecimalPlaces = 2;
                DataSet dsetFinancial = new DataSet();
                DataTable dtbl = new DataTable();
                decimal dcTotInflow = 0;
                decimal dcTotOutflow = 0;


                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter1 = new SqlDataAdapter();

                    using (SqlCommand cmd1 = new SqlCommand())
                    {



                        cmd1.Connection = con;
                        cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd1.CommandText = "CashFlow";
                        cmd1.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = FromDate;
                        cmd1.Parameters.Add("@toDate", SqlDbType.DateTime).Value = ToDate;
                        adapter1.SelectCommand = cmd1;
                        con.Open();
                        adapter1.Fill(dsetFinancial);
                        con.Close();


                        DataTable dtCashFlow = new DataTable();
                        dtCashFlow.Columns.Add("dgvtxtID1");
                        dtCashFlow.Columns.Add("dgvtxtParticulars");
                        dtCashFlow.Columns.Add("dgvtxtinflow");
                        dtCashFlow.Columns.Add("dgvtxtID2");
                        dtCashFlow.Columns.Add("dgvtxtParticulars1");
                        dtCashFlow.Columns.Add("dgvtxtoutflow");
                        DataRow drow = null;




                        for (int i = 0; i < 8; i++)
                        {
                            dtbl = dsetFinancial.Tables[i];
                            foreach (DataRow rw in dtbl.Rows)
                            {

                                drow = dtCashFlow.NewRow();
                                drow["dgvtxtID1"] = "";
                                drow["dgvtxtParticulars"] = "";
                                drow["dgvtxtinflow"] = "";
                                drow["dgvtxtID2"] = "";
                                drow["dgvtxtParticulars1"] = "";
                                drow["dgvtxtoutflow"] = "";
                                dtCashFlow.Rows.Add(drow);

                                dtCashFlow.Rows[dtCashFlow.Rows.Count - 1]["dgvtxtParticulars"] = rw["aG_Nm"].ToString();
                                dtCashFlow.Rows[dtCashFlow.Rows.Count - 1]["dgvtxtinflow"] = rw["Balance"].ToString();
                                dtCashFlow.Rows[dtCashFlow.Rows.Count - 1]["dgvtxtID1"] = rw["aG_Id"].ToString();
                            }
                        }
                        //-------------------------------Calculating TotalInflow-----------------------------------------
                        decimal dcTotalInflow = 0m;
                        if (dtbl.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtCashFlow.Rows.Count; i++)
                            {
                                decimal dcTotalIn = decimal.Parse(dtCashFlow.Rows[i]["dgvtxtinflow"].ToString());
                                dcTotalInflow += dcTotalIn;
                            }
                            dcTotInflow = dcTotalInflow;
                        }
                        //-----------------Outflow------------------------------
                        int index = 0;
                        for (int i = 8; i < 15; i++)
                        {
                            dtbl = new DataTable();
                            dtbl = dsetFinancial.Tables[i];
                            foreach (DataRow rw in dtbl.Rows)
                            {
                                if (index < dtCashFlow.Rows.Count)
                                {
                                    dtCashFlow.Rows[index]["dgvtxtParticulars1"] = rw["aG_Nm1"].ToString();
                                    dtCashFlow.Rows[index]["dgvtxtoutflow"] = rw["Balance1"].ToString();
                                    dtCashFlow.Rows[index]["dgvtxtID2"] = rw["aG_Id"].ToString();
                                }
                                else
                                {

                                    drow = dtCashFlow.NewRow();
                                    drow["dgvtxtID1"] = "";
                                    drow["dgvtxtParticulars"] = "";
                                    drow["dgvtxtinflow"] = "";
                                    drow["dgvtxtID2"] = "";
                                    drow["dgvtxtParticulars1"] = "";
                                    drow["dgvtxtoutflow"] = "";
                                    dtCashFlow.Rows.Add(drow);
                                    dtCashFlow.Rows[dtCashFlow.Rows.Count - 1]["dgvtxtParticulars1"] = rw["aG_Nm1"].ToString();
                                    dtCashFlow.Rows[dtCashFlow.Rows.Count - 1]["dgvtxtoutflow"] = rw["Balance1"].ToString();
                                    dtCashFlow.Rows[dtCashFlow.Rows.Count - 1]["dgvtxtID2"] = rw["aG_Id"].ToString();
                                }
                                index++;
                            }
                        }
                        //-------------------------------Calculating TotalOutflow-----------------------------------------
                        decimal dcTotalOutflow = 0m;
                        if (dtbl.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtCashFlow.Rows.Count - 1; i++)
                            {
                                decimal dcTotalIn = decimal.Parse(dtCashFlow.Rows[i]["dgvtxtoutflow"].ToString());
                                dcTotalOutflow += dcTotalIn;
                            }
                            dcTotOutflow = dcTotalOutflow;
                        }

                        drow = dtCashFlow.NewRow();
                        drow["dgvtxtID1"] = "";
                        drow["dgvtxtParticulars"] = "";
                        drow["dgvtxtinflow"] = "";
                        drow["dgvtxtID2"] = "";
                        drow["dgvtxtParticulars1"] = "";
                        drow["dgvtxtoutflow"] = "";
                        dtCashFlow.Rows.Add(drow);
                        dtCashFlow.Rows[dtCashFlow.Rows.Count - 1]["dgvtxtinflow"] = "__________________";
                        dtCashFlow.Rows[dtCashFlow.Rows.Count - 1]["dgvtxtoutflow"] = "__________________";

                        drow = dtCashFlow.NewRow();
                        drow["dgvtxtID1"] = "";
                        drow["dgvtxtParticulars"] = "";
                        drow["dgvtxtinflow"] = "";
                        drow["dgvtxtID2"] = "";
                        drow["dgvtxtParticulars1"] = "";
                        drow["dgvtxtoutflow"] = "";
                        dtCashFlow.Rows.Add(drow);

                        dtCashFlow.Rows[dtCashFlow.Rows.Count - 1]["dgvtxtParticulars"] = "Total";
                        dtCashFlow.Rows[dtCashFlow.Rows.Count - 1]["dgvtxtParticulars1"] = "Total";
                        dtCashFlow.Rows[dtCashFlow.Rows.Count - 1]["dgvtxtinflow"] = Math.Round((dcTotalInflow), inDecimalPlaces);
                        dtCashFlow.Rows[dtCashFlow.Rows.Count - 1]["dgvtxtoutflow"] = Math.Round((dcTotalOutflow), inDecimalPlaces);


                        for (int i = 0; i < dtCashFlow.Rows.Count; i++)
                        {
                            lst.Add(new CashFlow()
                            {
                                Particulars = dtCashFlow.Rows[i][1].ToString(),
                                inflow = dtCashFlow.Rows[i][2].ToString(),
                                Particulars1 = dtCashFlow.Rows[i][4].ToString(),
                                outflow = dtCashFlow.Rows[i][5].ToString()
                            });


                        }

                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("TrialBalance/{FromDate}/{ToDate}")]
        [HttpGet]
        public async Task<ActionResult<List<TrialBalance>>> GetTrialBalanace(DateTime FromDate, DateTime ToDate)
        {
            List<TrialBalance> lst = await Task.Run(() => new List<TrialBalance>());
            try
            {
                int inDecimalPlaces = 2;
                DataSet DsetTrailbalance = new DataSet();
                DataTable dtbl = new DataTable();
                decimal dcTotalCredit = 0;
                decimal dcTotalDebit = 0;

                DataTable dtblTrail = new DataTable();
                DataTable dtblTrail1 = new DataTable();
                DataTable dtblProfitAndLossAcc = new DataTable();
                DataTable dtblProfitAndLossAcc1 = new DataTable();
                DataSet dsTrial = new DataSet();

                DataSet DsetBalanceSheet = new DataSet();


                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter1 = new SqlDataAdapter();
                    SqlDataAdapter adapter2 = new SqlDataAdapter();


                    using (SqlCommand cmd1 = new SqlCommand())
                    {
                        SqlCommand cmd2 = new SqlCommand();
                        SqlCommand cmd3 = new SqlCommand();



                        cmd1.Connection = con;
                        cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd1.CommandText = "Trialbalance";
                        cmd1.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = FromDate;
                        cmd1.Parameters.Add("@toDate", SqlDbType.DateTime).Value = ToDate;
                        adapter1.SelectCommand = cmd1;
                        con.Open();
                        adapter1.Fill(dsTrial);
                        con.Close();

                        cmd2.Connection = con;
                        cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd2.CommandText = "BalanceSheet";
                        cmd2.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = FromDate;
                        cmd2.Parameters.Add("@toDate", SqlDbType.DateTime).Value = ToDate;
                        adapter2.SelectCommand = cmd2;
                        con.Open();
                        adapter2.Fill(DsetBalanceSheet);
                        con.Close();

                        dtblTrail = dsTrial.Tables[3];
                        decimal dcClosingStock = Convert.ToDecimal(dtblTrail.Rows[0]["cLOSE_Stock"]);
                        dcClosingStock = Math.Round(dcClosingStock, inDecimalPlaces);
                        //---------------------Opening Stock-----------------------
                        decimal dcOpeninggStock = Convert.ToDecimal(dtblTrail.Rows[0]["oP_Stock"]);



                        DataTable dtTrialBal = new DataTable();
                        dtTrialBal.Columns.Add("dgvtxtSlNo");
                        dtTrialBal.Columns.Add("dgvtxtAccountGroupId");
                        dtTrialBal.Columns.Add("accountGroupName");
                        dtTrialBal.Columns.Add("openingBalance");
                        dtTrialBal.Columns.Add("Debit");
                        dtTrialBal.Columns.Add("Credit");
                        dtTrialBal.Columns.Add("dgvtxtBalance");
                        dtTrialBal.Columns.Add("dgvtxtLedgerId");
                        DataRow drow = null;

                        dtblTrail = dsTrial.Tables[0];
                        dtblProfitAndLossAcc = dsTrial.Tables[1];
                        if (dtTrialBal.Rows.Count > 0)
                        {
                            dcTotalCredit = decimal.Parse(dtblTrail.Compute("Sum(cR_Amt)", string.Empty).ToString());
                            dcTotalDebit = decimal.Parse(dtblTrail.Compute("Sum(dR_Amt)", string.Empty).ToString());
                        }
                        for (int i = 0; i < dtblTrail.Rows.Count; ++i)
                        {
                            drow = dtTrialBal.NewRow();
                            drow["dgvtxtSlNo"] = "";
                            drow["dgvtxtAccountGroupId"] = "";
                            drow["accountGroupName"] = "";
                            drow["openingBalance"] = "";
                            drow["Debit"] = "";
                            drow["Credit"] = "";
                            drow["dgvtxtBalance"] = "";
                            drow["dgvtxtLedgerId"] = "";
                            dtTrialBal.Rows.Add(drow);


                            if (Convert.ToDecimal(dtblTrail.Rows[i]["aG_Id"].ToString()) != 6)
                            {
                                dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["dgvtxtAccountGroupId"] = dtblTrail.Rows[i]["aG_Id"];
                                dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["accountGroupName"] = dtblTrail.Rows[i]["name"];
                                dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["openingBalance"] = dtblTrail.Rows[i]["OpeningBalance"];
                                dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["dgvtxtBalance"] = dtblTrail.Rows[i]["Balance"];
                                dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["credit"] = dtblTrail.Rows[i]["cR_Amt"];
                                dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["debit"] = dtblTrail.Rows[i]["dR_Amt"];
                                dcTotalCredit += decimal.Parse(dtblTrail.Rows[i]["cR_Amt"].ToString());
                                dcTotalDebit += decimal.Parse(dtblTrail.Rows[i]["dR_Amt"].ToString());
                            }
                            else
                            {
                                decimal decOpBalance = dcOpeninggStock + Convert.ToDecimal(dtblTrail.Rows[i]["OpBalance"].ToString());
                                decimal decBalance = dcOpeninggStock + Convert.ToDecimal(dtblTrail.Rows[i]["Balance1"].ToString());
                                string strOpBalance = string.Empty;
                                string strBalance = string.Empty;
                                if (decOpBalance < 0)
                                {
                                    strOpBalance = Math.Round(decOpBalance, 2).ToString() + "Cr";
                                }
                                else
                                {
                                    strOpBalance = Math.Round(decOpBalance, 2).ToString() + "Dr";
                                }
                                if (decBalance < 0)
                                {
                                    strBalance = Math.Round(decBalance, 2).ToString() + "Cr";
                                }
                                else
                                {
                                    strBalance = Math.Round(decBalance, 2).ToString() + "Dr";
                                }
                                dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["dgvtxtAccountGroupId"] = dtblTrail.Rows[i]["aG_Id"];
                                dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["accountGroupName"] = dtblTrail.Rows[i]["name"];
                                dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["openingBalance"] = strOpBalance;
                                dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["dgvtxtBalance"] = strBalance;
                                dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["credit"] = dtblTrail.Rows[i]["cR_Amt"];
                                dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["debit"] = dtblTrail.Rows[i]["dR_Amt"];
                                dcTotalCredit += decimal.Parse(dtblTrail.Rows[i]["cR_Amt"].ToString());
                                dcTotalDebit += decimal.Parse(dtblTrail.Rows[i]["dR_Amt"].ToString());
                            }
                        }
                        decimal OpeningProfit;
                        dtblProfitAndLossAcc1 = dsTrial.Tables[2];
                        if (dtTrialBal.Rows.Count > 0)
                        {
                            decimal dcTotalCredit1 = decimal.Parse(dtblTrail.Compute("Sum(cR_Amt)", string.Empty).ToString());
                            decimal dcTotalDebit1 = decimal.Parse(dtblTrail.Compute("Sum(dR_Amt)", string.Empty).ToString());
                            OpeningProfit = dcTotalCredit1 + dcTotalDebit1;
                        }

                        DataTable dtblProf = new DataTable();
                        decimal dcProfitOpening = 0;
                        dtblProf = DsetBalanceSheet.Tables[2];
                        decimal decProfitLedger = 0;
                        if (dtblProf.Rows.Count > 0)
                        {
                            decProfitLedger = decimal.Parse(dtblProf.Compute("Sum(Balance)", string.Empty).ToString());
                        }
                        DataTable dtblProfitLedgerOpening = new DataTable();
                        dtblProfitLedgerOpening = DsetBalanceSheet.Tables[3];
                        decimal decProfitLedgerOpening = 0;
                        foreach (DataRow dRow in dtblProfitLedgerOpening.Rows)
                        {
                            decProfitLedgerOpening += decimal.Parse(dRow["Balance"].ToString());
                        }
                        decimal decTotalProfitAndLoss = decProfitLedger;
                        decimal OpeningProfit1;
                        decimal openingBalance;


                        drow = dtTrialBal.NewRow();
                        drow["dgvtxtSlNo"] = "";
                        drow["dgvtxtAccountGroupId"] = "";
                        drow["accountGroupName"] = "";
                        drow["openingBalance"] = "";
                        drow["Debit"] = "";
                        drow["Credit"] = "";
                        drow["dgvtxtBalance"] = "";
                        drow["dgvtxtLedgerId"] = "";
                        dtTrialBal.Rows.Add(drow);

                        dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["dgvtxtSlNo"] = "  ";
                        dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["accountGroupName"] = "Profit and Loss";
                        dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["dgvtxtAccountGroupId"] = "0";
                        openingBalance = Convert.ToDecimal(dtblProfitAndLossAcc.Rows[0]["OpeningBalance"].ToString());
                        {
                            if (openingBalance > 0)
                            {
                                dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["openingBalance"] = openingBalance + "Dr";
                            }
                            else
                                dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["openingBalance"] = (-1) * openingBalance + "Cr";
                        }
                        dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["dgvtxtSlNo"] = dtTrialBal.Rows.Count.ToString();

                        dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["credit"] = dtblProfitAndLossAcc.Rows[0]["cR_Amt"].ToString();
                        dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["debit"] = dtblProfitAndLossAcc.Rows[0]["dR_Amt"].ToString();
                        OpeningProfit1 = (Convert.ToDecimal(dtblProfitAndLossAcc.Rows[0]["OpeningBalance"].ToString())) + Convert.ToDecimal(dtblProfitAndLossAcc.Rows[0]["dR_Amt"].ToString()) - Convert.ToDecimal(dtblProfitAndLossAcc.Rows[0]["cR_Amt"].ToString());
                        {
                            if (OpeningProfit1 > 0)
                            {

                                dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["dgvtxtBalance"] = decTotalProfitAndLoss + "Dr";
                            }
                            else

                                dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["dgvtxtBalance"] = (-1) * decTotalProfitAndLoss + "Cr";
                        };
                        dcTotalCredit = dcTotalCredit + Convert.ToDecimal(dtblProfitAndLossAcc.Rows[0]["cR_Amt"].ToString());
                        dcTotalDebit = dcTotalDebit + Convert.ToDecimal(dtblProfitAndLossAcc.Rows[0]["dR_Amt"].ToString());
                        //=================================Net profit and NetLoss transation for previousyear==============
                        decimal decprofitLossbal = 0;
                        decimal decbalance = 0;
                        decimal decProfitAndLossOfPrevious = decProfitLedgerOpening;



                        drow = dtTrialBal.NewRow();
                        drow["dgvtxtSlNo"] = "";
                        drow["dgvtxtAccountGroupId"] = "";
                        drow["accountGroupName"] = "";
                        drow["openingBalance"] = "";
                        drow["Debit"] = "";
                        drow["Credit"] = "";
                        drow["dgvtxtBalance"] = "";
                        drow["dgvtxtLedgerId"] = "";
                        dtTrialBal.Rows.Add(drow);

                        if (dcProfitOpening > 0)
                        {
                            dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["openingBalance"] = dcProfitOpening + "Dr";
                            decprofitLossbal = dcProfitOpening;
                        }
                        if (dcProfitOpening <= 0)
                        {
                            dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["openingBalance"] = (-1) * dcProfitOpening + "Cr";
                            decprofitLossbal = dcProfitOpening;
                        }
                        dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["dgvtxtSlNo"] = "  ";
                        dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["accountGroupName"] = "Profit and Loss Opening";
                        dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["openingBalance"] = "0.00Dr";

                        dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["dgvtxtAccountGroupId"] = "0";
                        if (decProfitAndLossOfPrevious > 0)
                        {
                            dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["debit"] = decProfitAndLossOfPrevious;
                            dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["credit"] = "0.00";
                            decbalance = (decProfitAndLossOfPrevious);
                        }
                        if (decProfitAndLossOfPrevious <= 0)
                        {
                            dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["credit"] = (-1) * (decProfitAndLossOfPrevious);
                            dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["debit"] = "0.00";
                            decbalance = ((decProfitAndLossOfPrevious));
                        }
                        if (decbalance >= 0)
                        {
                            dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["dgvtxtBalance"] = decbalance + decprofitLossbal + "Dr";
                        }
                        if (decbalance < 0)
                        {
                            decbalance = -(decbalance);
                            dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["dgvtxtBalance"] = decbalance + decprofitLossbal + "Cr";
                        }

                        drow = dtTrialBal.NewRow();
                        drow["dgvtxtSlNo"] = "";
                        drow["dgvtxtAccountGroupId"] = "";
                        drow["accountGroupName"] = "";
                        drow["openingBalance"] = "";
                        drow["Debit"] = "";
                        drow["Credit"] = "";
                        drow["dgvtxtBalance"] = "";
                        drow["dgvtxtLedgerId"] = "";
                        dtTrialBal.Rows.Add(drow);

                        dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["dgvtxtSlNo"] = "  ";
                        dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["accountGroupName"] = "Total:";
                        dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["dgvtxtSlNo"] = string.Empty;

                        dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["credit"] = dcTotalCredit;
                        dtTrialBal.Rows[dtTrialBal.Rows.Count - 1]["debit"] = dcTotalDebit;

                        for (int i = 0; i < dtTrialBal.Rows.Count; i++)
                        {
                            lst.Add(new TrialBalance()
                            {
                                SlNo = (i + 1).ToString(),
                                AccountGroup = dtTrialBal.Rows[i][2].ToString(),
                                OpeningBalance = dtTrialBal.Rows[i][3].ToString(),
                                Debit = dtTrialBal.Rows[i][4].ToString(),
                                Credit = dtTrialBal.Rows[i][5].ToString(),
                                Balance = dtTrialBal.Rows[i][6].ToString(),


                            });


                        }

                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("BalanceSheet/{FromDate}/{ToDate}")]
        [HttpGet]
        public async Task<ActionResult<List<BalanceSheet>>> GetBalanceSheet(DateTime FromDate, DateTime ToDate)
        {
            List<BalanceSheet> lst = await Task.Run(() => new List<BalanceSheet>());
            try
            {
                int inDecimalPlaces = 2;
                DataSet DsetBalanceSheet = new DataSet();
                DataSet dsetProfitAndLoss = new DataSet();
                DataSet dsetProfitAndLossOpening = new DataSet();

                DataTable dtbl = new DataTable();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter1 = new SqlDataAdapter();
                    SqlDataAdapter adapter2 = new SqlDataAdapter();
                    SqlDataAdapter adapter3 = new SqlDataAdapter();

                    using (SqlCommand cmd1 = new SqlCommand())
                    {
                        SqlCommand cmd2 = new SqlCommand();
                        SqlCommand cmd3 = new SqlCommand();



                        cmd1.Connection = con;
                        cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd1.CommandText = "BalanceSheet";
                        cmd1.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = FromDate;
                        cmd1.Parameters.Add("@toDate", SqlDbType.DateTime).Value = ToDate;
                        adapter1.SelectCommand = cmd1;
                        con.Open();
                        adapter1.Fill(DsetBalanceSheet);
                        con.Close();

                        cmd2.Connection = con;
                        cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd2.CommandText = "ProfitAndLossAnalysisUpToaDateForBalansheet";
                        cmd2.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = FromDate;
                        cmd2.Parameters.Add("@toDate", SqlDbType.DateTime).Value = ToDate;
                        adapter2.SelectCommand = cmd2;
                        con.Open();
                        adapter2.Fill(dsetProfitAndLoss);
                        con.Close();

                        cmd3.Connection = con;
                        cmd3.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd3.CommandText = "ProfitAndLossAnalysisUpToaDateForPreviousYears";
                        cmd3.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = FromDate;
                        adapter3.SelectCommand = cmd3;
                        con.Open();
                        adapter3.Fill(dsetProfitAndLossOpening);
                        con.Close();





                        DataTable dtBal = new DataTable();
                        dtBal.Columns.Add("txtLiability");
                        dtBal.Columns.Add("Amount2");
                        dtBal.Columns.Add("txtAsset");
                        dtBal.Columns.Add("Amount1");
                        DataRow drow = null;




                        //------------------- Asset -------------------------------// 
                        dtbl = DsetBalanceSheet.Tables[0];
                        foreach (DataRow rw in dtbl.Rows)
                        {
                            drow = dtBal.NewRow();
                            drow["txtAsset"] = rw["Name"].ToString();
                            drow["Amount1"] = rw["Balance"].ToString();
                            dtBal.Rows.Add(drow);



                        }
                        decimal dcTotalAsset = 0;
                        if (dtbl.Rows.Count > 0)
                        {
                            dcTotalAsset = decimal.Parse(dtbl.Compute("Sum(Balance)", string.Empty).ToString());
                        }

                        //------------------------ Liability ---------------------//
                        dtbl = new DataTable();
                        dtbl = DsetBalanceSheet.Tables[1];
                        int index = 0;
                        foreach (DataRow rw in dtbl.Rows)
                        {
                            if (index < dtBal.Rows.Count)
                            {
                                dtBal.Rows[index]["txtLiability"] = rw["Name"].ToString();
                                dtBal.Rows[index]["Amount2"] = rw["Balance"].ToString();

                            }
                            else
                            {
                                drow = dtBal.NewRow();
                                drow["txtAsset"] = "";
                                drow["Amount1"] = "";
                                drow["txtLiability"] = "";
                                drow["Amount2"] = "";
                                dtBal.Rows.Add(drow);
                                dtBal.Rows[dtBal.Rows.Count - 1]["txtLiability"] = rw["Name"].ToString();
                                dtBal.Rows[dtBal.Rows.Count - 1]["Amount2"] = rw["Balance"].ToString();


                            }
                            index++;
                        }
                        decimal dcTotalLiability = 0;
                        if (dtbl.Rows.Count > 0)
                        {
                            dcTotalLiability = decimal.Parse(dtbl.Compute("Sum(Balance)", string.Empty).ToString());
                        }


                        dtbl = new DataTable();
                        dtbl = DsetBalanceSheet.Tables[5];
                        decimal dcClosingStock = Convert.ToDecimal(dtbl.Rows[0]["cLOSE_Stock"].ToString());

                        dcClosingStock = Math.Round(dcClosingStock, inDecimalPlaces);

                        //---------------------Opening Stock---------------------------------------------------------------------------------------------------------------
                        decimal dcOpeninggStock = Convert.ToDecimal(dtbl.Rows[0]["oP_Stock"].ToString());

                        decimal dcProfit = 0;

                        DataTable dtblProfit = new DataTable();
                        dtblProfit = dsetProfitAndLoss.Tables[0];
                        for (int i = 0; i < dsetProfitAndLoss.Tables.Count; ++i)
                        {
                            dtbl = dsetProfitAndLoss.Tables[i];
                            decimal dcSum = 0;
                            if (i == 0 || (i % 2) == 0)
                            {
                                if (dtbl.Rows.Count > 0)
                                {
                                    dcSum = decimal.Parse(dtbl.Compute("Sum(dR_Amt)", string.Empty).ToString());
                                    dcProfit = dcProfit - dcSum;
                                }
                            }
                            else
                            {
                                if (dtbl.Rows.Count > 0)
                                {
                                    dcSum = decimal.Parse(dtbl.Compute("Sum(cR_Amt)", string.Empty).ToString());
                                    dcProfit = dcProfit + dcSum;
                                }
                            }
                        }
                        decimal decCurrentProfitLoss = 0;
                        decCurrentProfitLoss = dcProfit + (dcClosingStock - dcOpeninggStock);
                        decimal dcProfitOpening = 0;

                        DataTable dtblProfitOpening = new DataTable();
                        dtblProfitOpening = dsetProfitAndLossOpening.Tables[0];
                        for (int i = 0; i < dsetProfitAndLossOpening.Tables.Count; ++i)
                        {
                            dtbl = dsetProfitAndLossOpening.Tables[i];
                            decimal dcSum = 0;
                            if (i == 0 || (i % 2) == 0)
                            {
                                if (dtbl.Rows.Count > 0)
                                {
                                    dcSum = decimal.Parse(dtbl.Compute("Sum(dR_Amt)", string.Empty).ToString());
                                    dcProfitOpening = dcProfitOpening - dcSum;
                                }
                            }
                            else
                            {
                                if (dtbl.Rows.Count > 0)
                                {
                                    dcSum = decimal.Parse(dtbl.Compute("Sum(cR_Amt)", string.Empty).ToString());
                                    dcProfitOpening = dcProfitOpening + dcSum;
                                }
                            }
                        }
                        DataTable dtblProfitLedgerOpening = new DataTable();
                        dtblProfitLedgerOpening = DsetBalanceSheet.Tables[3];
                        decimal decProfitLedgerOpening = 0;
                        foreach (DataRow dRow in dtblProfitLedgerOpening.Rows)
                        {
                            decProfitLedgerOpening += decimal.Parse(dRow["Balance"].ToString());
                        }
                        DataTable dtblProf = new DataTable();
                        dtblProf = DsetBalanceSheet.Tables[2];
                        decimal decProfitLedger = 0;
                        if (dtblProf.Rows.Count > 0)
                        {
                            decProfitLedger = decimal.Parse(dtblProf.Compute("Sum(Balance)", string.Empty).ToString());
                        }
                        decimal decTotalProfitAndLoss = 0;
                        if (dcProfitOpening >= 0)
                        {
                            decTotalProfitAndLoss = decProfitLedger;
                        }
                        else if (dcProfitOpening < 0)
                        {
                            decTotalProfitAndLoss = decProfitLedger;
                        }
                        index = 0;
                        if (dcClosingStock >= 0)
                        {
                            //---------- Asset ----------//
                            drow = dtBal.NewRow();
                            drow["txtAsset"] = "";
                            drow["Amount1"] = "";
                            drow["txtLiability"] = "";
                            drow["Amount2"] = "";
                            dtBal.Rows.Add(drow);


                            //dgvReport.Rows.Add();
                            dtBal.Rows[dtBal.Rows.Count - 1]["txtAsset"] = "Closing Stock";
                            dtBal.Rows[dtBal.Rows.Count - 1]["Amount1"] = Math.Round(dcClosingStock, inDecimalPlaces);

                            dcTotalAsset += dcClosingStock;
                        }
                        else
                        {
                            //--------- Liability ---------//
                            drow = dtBal.NewRow();
                            drow["txtAsset"] = "";
                            drow["Amount1"] = "";
                            drow["txtLiability"] = "";
                            drow["Amount2"] = "";
                            dtBal.Rows.Add(drow);
                            //dgvReport.Rows.Add();
                            dtBal.Rows[dtBal.Rows.Count - 1]["txtLiability"] = "Closing Stock";
                            dtBal.Rows[dtBal.Rows.Count - 1]["Amount2"] = -(Math.Round(dcClosingStock, inDecimalPlaces));


                            dcTotalLiability += -dcClosingStock;
                        }


                        drow = dtBal.NewRow();
                        drow["txtAsset"] = "";
                        drow["Amount1"] = "";
                        drow["txtLiability"] = "";
                        drow["Amount2"] = "";
                        dtBal.Rows.Add(drow);

                        decimal decOpeningOfProfitAndLoss = decProfitLedgerOpening + dcProfitOpening;
                        decimal decTotalProfitAndLossOverAll = decTotalProfitAndLoss + decOpeningOfProfitAndLoss + decCurrentProfitLoss;
                        if (decTotalProfitAndLossOverAll <= 0)
                        {


                            drow = dtBal.NewRow();
                            drow["txtAsset"] = "";
                            drow["Amount1"] = "";
                            drow["txtLiability"] = "";
                            drow["Amount2"] = "";
                            dtBal.Rows.Add(drow);

                            dtBal.Rows[dtBal.Rows.Count - 1]["txtAsset"] = "----------------------------------------";

                            foreach (DataRow dRow in dtblProf.Rows)
                            {
                                if (dRow["Name"].ToString() == "Profit And Loss Account")
                                {

                                    drow = dtBal.NewRow();
                                    drow["txtAsset"] = "";
                                    drow["Amount1"] = "";
                                    drow["txtLiability"] = "";
                                    drow["Amount2"] = "";
                                    dtBal.Rows.Add(drow);


                                    dtBal.Rows[dtBal.Rows.Count - 1]["txtAsset"] = dRow["Name"].ToString();
                                    if (decCurrentProfitLoss < 0)
                                    {
                                        decCurrentProfitLoss = decCurrentProfitLoss * -1;
                                    }
                                    dtBal.Rows[dtBal.Rows.Count - 1]["Amount1"] = Math.Round(decTotalProfitAndLoss + decCurrentProfitLoss, 2);

                                }
                            }
                            //-------------- Asset ---------------//

                            drow = dtBal.NewRow();
                            drow["txtAsset"] = "";
                            drow["Amount1"] = "";
                            drow["txtLiability"] = "";
                            drow["Amount2"] = "";
                            dtBal.Rows.Add(drow);

                            dtBal.Rows[dtBal.Rows.Count - 1]["txtAsset"] = "Profit And Loss (Opening)";
                            dtBal.Rows[dtBal.Rows.Count - 1]["Amount1"] = Math.Round(decTotalProfitAndLoss, 2);


                            //-------------- Asset ---------------//

                            drow = dtBal.NewRow();
                            drow["txtAsset"] = "";
                            drow["Amount1"] = "";
                            drow["txtLiability"] = "";
                            drow["Amount2"] = "";
                            dtBal.Rows.Add(drow);

                            dtBal.Rows[dtBal.Rows.Count - 1]["txtAsset"] = "Current Period";
                            dtBal.Rows[dtBal.Rows.Count - 1]["Amount1"] = Math.Round(decCurrentProfitLoss, 2);
                            dcTotalAsset = dcTotalAsset + (decCurrentProfitLoss + decTotalProfitAndLoss);


                            drow = dtBal.NewRow();
                            drow["txtAsset"] = "";
                            drow["Amount1"] = "";
                            drow["txtLiability"] = "";
                            drow["Amount2"] = "";
                            dtBal.Rows.Add(drow);
                            dtBal.Rows[dtBal.Rows.Count - 1]["txtAsset"] = "----------------------------------------";

                        }
                        else if (decTotalProfitAndLossOverAll > 0)
                        {

                            drow = dtBal.NewRow();
                            drow["txtAsset"] = "";
                            drow["Amount1"] = "";
                            drow["txtLiability"] = "";
                            drow["Amount2"] = "";
                            dtBal.Rows.Add(drow);

                            dtBal.Rows[dtBal.Rows.Count - 1]["txtLiability"] = "----------------------------------------";

                            foreach (DataRow dRow in dtblProf.Rows)
                            {
                                if (dRow["Name"].ToString() == "Profit And Loss Account")
                                {

                                    drow = dtBal.NewRow();
                                    drow["txtAsset"] = "";
                                    drow["Amount1"] = "";
                                    drow["txtLiability"] = "";
                                    drow["Amount2"] = "";
                                    dtBal.Rows.Add(drow);
                                    dtBal.Rows[dtBal.Rows.Count - 1]["txtLiability"] = dRow[1].ToString();
                                    dtBal.Rows[dtBal.Rows.Count - 1]["Amount2"] = Math.Round(decTotalProfitAndLoss + decCurrentProfitLoss, 2);

                                }
                            }
                            //------------ Liability ------------//

                            drow = dtBal.NewRow();
                            drow["txtAsset"] = "";
                            drow["Amount1"] = "";
                            drow["txtLiability"] = "";
                            drow["Amount2"] = "";
                            dtBal.Rows.Add(drow);

                            dtBal.Rows[dtBal.Rows.Count - 1]["txtLiability"] = "Profit And Loss (Opening)";
                            dtBal.Rows[dtBal.Rows.Count - 1]["Amount2"] = Math.Round(decTotalProfitAndLoss, inDecimalPlaces);

                            dcTotalLiability += decOpeningOfProfitAndLoss;
                            //------------ Liability ------------//

                            drow = dtBal.NewRow();
                            drow["txtAsset"] = "";
                            drow["Amount1"] = "";
                            drow["txtLiability"] = "";
                            drow["Amount2"] = "";
                            dtBal.Rows.Add(drow);

                            dtBal.Rows[dtBal.Rows.Count - 1]["txtLiability"] = "Current Period";
                            dtBal.Rows[dtBal.Rows.Count - 1]["Amount2"] = Math.Round(decCurrentProfitLoss, inDecimalPlaces);

                            dcTotalLiability = dcTotalLiability + (decCurrentProfitLoss + decTotalProfitAndLoss);

                            drow = dtBal.NewRow();
                            drow["txtAsset"] = "";
                            drow["Amount1"] = "";
                            drow["txtLiability"] = "";
                            drow["Amount2"] = "";
                            dtBal.Rows.Add(drow);

                            dtBal.Rows[dtBal.Rows.Count - 1]["txtLiability"] = "----------------------------------------";

                        }

                        drow = dtBal.NewRow();
                        drow["txtAsset"] = "";
                        drow["Amount1"] = "";
                        drow["txtLiability"] = "";
                        drow["Amount2"] = "";
                        dtBal.Rows.Add(drow);

                        decimal dcDiffAsset = 0;
                        decimal dcDiffLiability = 0;
                        decimal dcTotalValue = dcTotalAsset;
                        if (dcTotalAsset != dcTotalLiability)
                        {
                            if (dcTotalAsset > dcTotalLiability)
                            {
                                //--------------- Liability exceeds so in asset side ----------------//

                                drow = dtBal.NewRow();
                                drow["txtAsset"] = "";
                                drow["Amount1"] = "";
                                drow["txtLiability"] = "";
                                drow["Amount2"] = "";
                                dtBal.Rows.Add(drow);
                                dtBal.Rows[dtBal.Rows.Count - 1]["txtLiability"] = "Difference";
                                dtBal.Rows[dtBal.Rows.Count - 1]["Amount2"] = Math.Round((dcTotalAsset - dcTotalLiability), inDecimalPlaces);

                                dcDiffLiability = dcTotalAsset - dcTotalLiability;
                            }
                            else
                            {
                                //--------------- Asset exceeds so in liability side ----------------//
                                //dgvReport.Rows.Add();
                                drow = dtBal.NewRow();
                                drow["txtAsset"] = "";
                                drow["Amount1"] = "";
                                drow["txtLiability"] = "";
                                drow["Amount2"] = "";
                                dtBal.Rows.Add(drow);
                                dtBal.Rows[dtBal.Rows.Count - 1]["txtAsset"] = "Difference";
                                dtBal.Rows[dtBal.Rows.Count - 1]["Amount1"] = Math.Round((dcTotalLiability - dcTotalAsset), inDecimalPlaces); ;

                                dcDiffAsset = dcTotalLiability - dcTotalAsset;
                            }
                        }

                        drow = dtBal.NewRow();
                        drow["txtAsset"] = "";
                        drow["Amount1"] = "";
                        drow["txtLiability"] = "";
                        drow["Amount2"] = "";
                        dtBal.Rows.Add(drow);
                        drow = dtBal.NewRow();
                        drow["txtAsset"] = "";
                        drow["Amount1"] = "";
                        drow["txtLiability"] = "";
                        drow["Amount2"] = "";
                        dtBal.Rows.Add(drow);

                        dtBal.Rows[dtBal.Rows.Count - 1]["Amount1"] = "___________________";
                        dtBal.Rows[dtBal.Rows.Count - 1]["Amount2"] = "___________________";


                        drow = dtBal.NewRow();
                        drow["txtAsset"] = "";
                        drow["Amount1"] = "";
                        drow["txtLiability"] = "";
                        drow["Amount2"] = "";
                        dtBal.Rows.Add(drow);

                        dtBal.Rows[dtBal.Rows.Count - 1]["txtLiability"] = "Total";
                        dtBal.Rows[dtBal.Rows.Count - 1]["txtAsset"] = "Total";
                        dtBal.Rows[dtBal.Rows.Count - 1]["Amount1"] = Math.Round((dcTotalAsset + dcDiffAsset), inDecimalPlaces);
                        dtBal.Rows[dtBal.Rows.Count - 1]["Amount2"] = Math.Round((dcTotalLiability + dcDiffLiability), inDecimalPlaces);




                        for (int i = 0; i < dtBal.Rows.Count; i++)
                        {
                            lst.Add(new BalanceSheet()
                            {
                                Liability = dtBal.Rows[i][0].ToString(),
                                Amount2 = dtBal.Rows[i][1].ToString(),
                                Asset = dtBal.Rows[i][2].ToString(),
                                Amount1 = dtBal.Rows[i][3].ToString()
                            });


                        }

                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        [Route("ProfitAndLossAnalysis/{FromDate}/{ToDate}")]
        [HttpGet]
        public async Task<ActionResult<List<ProfitAndLossAnalysis>>> GetProfitAndLossAnalysis(DateTime FromDate, DateTime ToDate)
        {
            List<ProfitAndLossAnalysis> lst = await Task.Run(() => new List<ProfitAndLossAnalysis>());
            try
            {
                int inDecimalPlaces = 2;
                decimal decgranExTotal = 0;
                decimal decgranIncTotal = 0;
                DataTable dtblFinancial = new DataTable();
                DataSet DsetProfitAndLoss = new DataSet();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {

                        new SqlParameter() {
                            ParameterName = "@fromDate",
                            SqlDbType =  SqlDbType.DateTime,
                            Direction =  ParameterDirection.Input,
                            Value = FromDate
                        },

                           new SqlParameter() {
                            ParameterName = "@toDate",
                            SqlDbType =  SqlDbType.DateTime,
                            Direction =  ParameterDirection.Input,
                            Value = ToDate
                          },

                        };

                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "ProfitAndLossAnalysis";
                        cmd.Parameters.AddRange(param);

                        adapter.SelectCommand = cmd;

                        con.Open();
                        adapter.Fill(DsetProfitAndLoss);
                        con.Close();



                        DataTable dtblProfit = new DataTable();
                        dtblProfit.Columns.Add("Expenses");
                        dtblProfit.Columns.Add("Amount1");
                        dtblProfit.Columns.Add("Income");
                        dtblProfit.Columns.Add("Amount2");

                        DataRow drow = null;

                        //---- Opening Stock
                        dtblFinancial = new DataTable();
                        dtblFinancial = DsetProfitAndLoss.Tables[6];

                        drow = dtblProfit.NewRow();
                        drow["Expenses"] = "Opening Stock";

                        decimal dcOpeningStock = 0;
                        if (dtblFinancial.Rows.Count > 0)
                        {
                            foreach (DataRow rw in dtblFinancial.Rows)
                            {
                                decimal dcOpStock = Convert.ToDecimal(rw["oP_Stock"].ToString());
                                dcOpeningStock += dcOpStock;
                            }
                        }
                        drow["Amount1"] = Math.Round(dcOpeningStock, inDecimalPlaces);

                        //if (dcOpeningStock > 0)
                        //{
                        //    drow["Amount1"] = Math.Round(dcOpeningStock, inDecimalPlaces);
                        //}
                        //else
                        //{
                        //    drow["Amount1"] = -(Math.Round(dcOpeningStock, inDecimalPlaces));
                        //}


                        //Closing Stock 

                        dtblFinancial = new DataTable();
                        dtblFinancial = DsetProfitAndLoss.Tables[6];
                        drow["Income"] = "Closing Stock";
                        decimal dcClosingStock = 0;

                        if (dtblFinancial.Rows.Count > 0)
                        {
                            foreach (DataRow rw in dtblFinancial.Rows)
                            {
                                decimal dcClsStock = Convert.ToDecimal(rw["cLOSE_Stock"].ToString());
                                dcClosingStock += dcClsStock;
                            }
                        }
                        drow["Amount2"] = Math.Round(dcClosingStock, inDecimalPlaces);
                        dtblProfit.Rows.Add(drow);

                        drow = dtblProfit.NewRow();
                        drow["Expenses"] = "";
                        drow["Amount1"] = "";
                        drow["Income"] = "";
                        drow["Amount2"] = "";
                        dtblProfit.Rows.Add(drow);

                        /// ---Purchase Account  - Debit
                        dtblFinancial = new DataTable();
                        dtblFinancial = DsetProfitAndLoss.Tables[0];

                        drow = dtblProfit.NewRow();
                        drow["Expenses"] = "Purchase Accounts";
                        decimal dcPurchaseAccount = 0m;
                        if (dtblFinancial.Rows.Count > 0)
                        {
                            foreach (DataRow rw in dtblFinancial.Rows)
                            {
                                decimal dcBalance = decimal.Parse(rw["dR_Amt"].ToString().ToString());
                                dcPurchaseAccount += dcBalance;
                            }

                        }
                        drow["Amount1"] = dcPurchaseAccount.ToString();


                        //---Sales Account  -cR_Amt
                        dtblFinancial = new DataTable();
                        dtblFinancial = DsetProfitAndLoss.Tables[1];
                        drow["Income"] = "Sales Accounts";
                        decimal dcSalesAccount = 0m;
                        if (dtblFinancial.Rows.Count > 0)
                        {
                            foreach (DataRow rw in dtblFinancial.Rows)
                            {
                                decimal dcBalance = decimal.Parse(rw["cR_Amt"].ToString().ToString());
                                dcSalesAccount += dcBalance;
                            }

                        }
                        drow["Amount2"] = dcSalesAccount.ToString();
                        dtblProfit.Rows.Add(drow);

                        drow = dtblProfit.NewRow();
                        drow["Expenses"] = "";
                        drow["Amount1"] = "";
                        drow["Income"] = "";
                        drow["Amount2"] = "";
                        dtblProfit.Rows.Add(drow);

                        drow = dtblProfit.NewRow();
                        //---Direct Expense
                        dtblFinancial = new DataTable();
                        dtblFinancial = DsetProfitAndLoss.Tables[2];
                        drow["Expenses"] = "Direct Expenses";
                        decimal dcDirectExpense = 0m;
                        if (dtblFinancial.Rows.Count > 0)
                        {
                            foreach (DataRow rw in dtblFinancial.Rows)
                            {
                                decimal dcBalance = Convert.ToDecimal(rw["dR_Amt"].ToString());
                                dcDirectExpense += dcBalance;
                            }

                        }
                        drow["Amount1"] = dcDirectExpense.ToString();



                        //----Direct Income 
                        dtblFinancial = new DataTable();
                        dtblFinancial = DsetProfitAndLoss.Tables[3];
                        drow["Income"] = "Direct Incomes";
                        decimal dcDirectIncoome = 0m;
                        if (dtblFinancial.Rows.Count > 0)
                        {
                            foreach (DataRow rw in dtblFinancial.Rows)
                            {
                                decimal dcBalance = Convert.ToDecimal(rw["cR_Amt"].ToString());
                                dcDirectIncoome += dcBalance;
                            }

                        }
                        drow["Amount2"] = dcDirectIncoome.ToString();
                        dtblProfit.Rows.Add(drow);


                        drow = dtblProfit.NewRow();
                        drow["Expenses"] = "";
                        drow["Amount1"] = "";
                        drow["Income"] = "";
                        drow["Amount2"] = "";
                        dtblProfit.Rows.Add(drow);



                        drow = dtblProfit.NewRow();
                        drow["Expenses"] = "";
                        drow["Amount1"] = "";
                        drow["Income"] = "";
                        drow["Amount2"] = "";
                        dtblProfit.Rows.Add(drow);



                        drow = dtblProfit.NewRow();
                        drow["Expenses"] = "";
                        drow["Amount1"] = "";
                        drow["Income"] = "";
                        drow["Amount2"] = "";
                        dtblProfit.Rows.Add(drow);

                        dtblProfit.Rows[dtblProfit.Rows.Count - 1]["Amount1"] = "_______________________";
                        dtblProfit.Rows[dtblProfit.Rows.Count - 1]["Amount2"] = "_______________________";

                        drow = dtblProfit.NewRow();
                        drow["Expenses"] = "";
                        drow["Amount1"] = "";
                        drow["Income"] = "";
                        drow["Amount2"] = "";
                        dtblProfit.Rows.Add(drow);

                        drow = dtblProfit.NewRow();
                        drow["Expenses"] = "";
                        drow["Amount1"] = "";
                        drow["Income"] = "";
                        drow["Amount2"] = "";
                        dtblProfit.Rows.Add(drow);

                        drow = dtblProfit.NewRow();
                        drow["Expenses"] = "";
                        drow["Amount1"] = "";
                        drow["Income"] = "";
                        drow["Amount2"] = "";
                        dtblProfit.Rows.Add(drow);

                        decimal dcTotalExpense = 0;
                        decimal dcTotalIncome = 0;
                        dcTotalExpense = dcOpeningStock + dcPurchaseAccount + dcDirectExpense;
                        dcTotalIncome = dcClosingStock + dcSalesAccount + dcDirectIncoome;
                        dcTotalExpense = Math.Round(dcTotalExpense, inDecimalPlaces);
                        dcTotalIncome = Math.Round(dcTotalIncome, inDecimalPlaces);
                        //  dgvProfitAndLoss.Rows[dgvProfitAndLoss.Rows.Count - 1].DefaultCellStyle.Font = newFont;
                        dtblProfit.Rows[dtblProfit.Rows.Count - 3]["Expenses"] = "Total";
                        dtblProfit.Rows[dtblProfit.Rows.Count - 3]["Income"] = "Total";
                        decimal dcGrossProfit = 0;
                        decimal dcGrossLoss = 0;
                        if (dcTotalExpense > dcTotalIncome)
                        {
                            dtblProfit.Rows[dtblProfit.Rows.Count - 3]["Amount1"] = dcTotalExpense.ToString();
                            dtblProfit.Rows[dtblProfit.Rows.Count - 3]["Amount2"] = dcTotalExpense.ToString();
                            dtblProfit.Rows[dtblProfit.Rows.Count - 5]["Income"] = "Gross Loss b/d ";
                            dtblProfit.Rows[dtblProfit.Rows.Count - 5]["Amount2"] = dcTotalExpense - dcTotalIncome;
                            //  dgvProfitAndLoss.Rows[dgvProfitAndLoss.Rows.Count - 3]["dgvtxtAmount2"].Style.ForeColor = Color.Red;
                            // dgvProfitAndLoss.Rows[dgvProfitAndLoss.Rows.Count - 3]["dgvtxtIncome"].Style.ForeColor = Color.Red;

                            dtblProfit.Rows[dtblProfit.Rows.Count - 1]["Expenses"] = "Gross Loss b/d ";
                            dtblProfit.Rows[dtblProfit.Rows.Count - 1]["Amount1"] = dcTotalExpense - dcTotalIncome;
                            dcGrossLoss = dcTotalExpense - dcTotalIncome;
                        }
                        else
                        {
                            dtblProfit.Rows[dtblProfit.Rows.Count - 3]["Amount1"] = dcTotalIncome.ToString();
                            dtblProfit.Rows[dtblProfit.Rows.Count - 3]["Amount2"] = dcTotalIncome.ToString();
                            dtblProfit.Rows[dtblProfit.Rows.Count - 5]["Expenses"] = "Gross Profit c/d ";
                            dtblProfit.Rows[dtblProfit.Rows.Count - 5]["Amount1"] = dcTotalIncome - dcTotalExpense;
                            // dgvProfitAndLoss.Rows[dgvProfitAndLoss.Rows.Count - 3]["dgvtxtAmount1"].Style.ForeColor = Color.Green;
                            //dgvProfitAndLoss.Rows[dgvProfitAndLoss.Rows.Count - 3]["dgvtxtExpenses"].Style.ForeColor = Color.Green;

                            dtblProfit.Rows[dtblProfit.Rows.Count - 1]["Income"] = "Gross Profit c/d ";
                            dtblProfit.Rows[dtblProfit.Rows.Count - 1]["Amount2"] = dcTotalIncome - dcTotalExpense;
                            dcGrossProfit = dcTotalIncome - dcTotalExpense;
                        }



                        drow = dtblProfit.NewRow();
                        drow["Expenses"] = "";
                        drow["Amount1"] = "";
                        drow["Income"] = "";
                        drow["Amount2"] = "";
                        dtblProfit.Rows.Add(drow);




                        ///------Indirect Expense 
                        dtblFinancial = new DataTable();
                        dtblFinancial = DsetProfitAndLoss.Tables[4];


                        drow = dtblProfit.NewRow();
                        drow["Expenses"] = "Indirect Expenses";
                        decimal dcIndirectExpense = 0;
                        if (dtblFinancial.Rows.Count > 0)
                        {
                            foreach (DataRow rw in dtblFinancial.Rows)
                            {
                                decimal dcBalance = Convert.ToDecimal(rw["dR_Amt"].ToString());
                                dcIndirectExpense += dcBalance;
                            }

                        }
                        drow["Amount1"] = dcIndirectExpense.ToString();
                        ///---Indirect Income 
                        dtblFinancial = new DataTable();
                        dtblFinancial = DsetProfitAndLoss.Tables[5];
                        drow["Income"] = "Indirect Incomes";
                        decimal dcIndirectIncome = 0m;
                        if (dtblFinancial.Rows.Count > 0)
                        {
                            foreach (DataRow rw in dtblFinancial.Rows)
                            {
                                decimal dcBalance = Convert.ToDecimal(rw["cR_Amt"].ToString());
                                dcIndirectIncome += dcBalance;
                            }

                        }
                        drow["Amount2"] = dcIndirectIncome.ToString();
                        dtblProfit.Rows.Add(drow);


                        drow = dtblProfit.NewRow();
                        drow["Expenses"] = "";
                        drow["Amount1"] = "";
                        drow["Income"] = "";
                        drow["Amount2"] = "";
                        dtblProfit.Rows.Add(drow);

                        //---- Calculating Grand total
                        decimal dcGrandTotalExpense = dcGrossLoss + dcIndirectExpense;
                        decimal dcGrandTotalIncome = dcGrossProfit + dcIndirectIncome;

                        drow = dtblProfit.NewRow();
                        drow["Expenses"] = "";
                        drow["Amount1"] = "";
                        drow["Income"] = "";
                        drow["Amount2"] = "";
                        dtblProfit.Rows.Add(drow);

                        drow = dtblProfit.NewRow();
                        drow["Expenses"] = "";
                        drow["Amount1"] = "";
                        drow["Income"] = "";
                        drow["Amount2"] = "";
                        dtblProfit.Rows.Add(drow);



                        dtblProfit.Rows[dtblProfit.Rows.Count - 1]["Amount1"] = "_______________________";
                        dtblProfit.Rows[dtblProfit.Rows.Count - 1]["Amount2"] = "_______________________";

                        drow = dtblProfit.NewRow();
                        drow["Expenses"] = "";
                        drow["Amount1"] = "";
                        drow["Income"] = "";
                        drow["Amount2"] = "";
                        dtblProfit.Rows.Add(drow);

                        dtblProfit.Rows[dtblProfit.Rows.Count - 1]["Expenses"] = "Grand Total";
                        dtblProfit.Rows[dtblProfit.Rows.Count - 1]["Income"] = "Grand Total";

                        //dgvProfitAndLoss.Rows[dgvProfitAndLoss.Rows.Count - 1].DefaultCellStyle.Font = newFont;
                        if (dcGrandTotalExpense > dcGrandTotalIncome)
                        {
                            dtblProfit.Rows[dtblProfit.Rows.Count - 1]["Amount1"] = dcGrandTotalExpense.ToString();
                            dtblProfit.Rows[dtblProfit.Rows.Count - 1]["Amount2"] = dcGrandTotalExpense.ToString();
                            dtblProfit.Rows[dtblProfit.Rows.Count - 3]["Income"] = "Net Loss ";
                            dtblProfit.Rows[dtblProfit.Rows.Count - 3]["Amount2"] = dcGrandTotalExpense - dcGrandTotalIncome;
                            //dtblProfit.Rows[dtblProfit.Rows.Count - 3]["dgvtxtIncome"].Style.ForeColor = Color.Red;
                            // dtblProfit.Rows[dtblProfit.Rows.Count - 3]["dgvtxtAmount2"].Style.ForeColor = Color.Red;
                            // dtblProfit.Rows[dtblProfit.Rows.Count - 3].DefaultCellStyle.Font = newFont;
                            decgranExTotal = dcGrandTotalExpense;
                        }
                        else
                        {
                            dtblProfit.Rows[dtblProfit.Rows.Count - 1]["Amount1"] = dcGrandTotalIncome.ToString();
                            dtblProfit.Rows[dtblProfit.Rows.Count - 1]["Amount2"] = dcGrandTotalIncome.ToString();
                            dtblProfit.Rows[dtblProfit.Rows.Count - 3]["Expenses"] = "Net Profit";
                            dtblProfit.Rows[dtblProfit.Rows.Count - 3]["Amount1"] = dcGrandTotalIncome - dcGrandTotalExpense;
                            //  dgvProfitAndLoss.Rows[dgvProfitAndLoss.Rows.Count - 3]["dgvtxtExpenses"].Style.ForeColor = Color.Green;
                            //  dgvProfitAndLoss.Rows[dgvProfitAndLoss.Rows.Count - 3]["dgvtxtAmount1"].Style.ForeColor = Color.Green;
                            //  dgvProfitAndLoss.Rows[dgvProfitAndLoss.Rows.Count - 3].DefaultCellStyle.Font = newFont;
                            decgranIncTotal = dcGrandTotalIncome;
                        }




                        for (int i = 0; i < dtblProfit.Rows.Count; i++)
                        {
                            lst.Add(new ProfitAndLossAnalysis()
                            {
                                Expenses = dtblProfit.Rows[i][0].ToString(),
                                Amount1 = dtblProfit.Rows[i][1].ToString(),
                                Income = dtblProfit.Rows[i][2].ToString(),
                                Amount2 = dtblProfit.Rows[i][3].ToString()
                            });


                        }




                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("RptBooklistSales/pn/{pageNo}/ps/{pageSize}/{sC_Id}/{sKU_Cod}/{FromDate}/{ToDate}")]
        [HttpGet]
        public async Task<ActionResult<List<RptBooklistSalesGrid>>> GetRptBooklistSalesGrid(int pageNo, int pageSize, decimal sC_Id, string sKU_Cod, DateTime FromDate, DateTime ToDate)
        {
            decimal totRows = 0.0m;

            List<RptBooklistSalesGrid> gridlst = await Task.Run(() => new List<RptBooklistSalesGrid>());
            List<RptBooklistSales> booklstsale = await Task.Run(() => new List<RptBooklistSales>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;

                        var param = new SqlParameter[] {

                            new SqlParameter() {
                                ParameterName = "@PageNo",
                                SqlDbType =   SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value =  pageNo
                            },
                            new SqlParameter() {
                                ParameterName = "@PageSize",
                                SqlDbType =  SqlDbType.Int,
                                Direction =  ParameterDirection.Input,

                                Value = pageSize
                            },
                            new SqlParameter() {
                              ParameterName = "@sC_Id",
                              SqlDbType =  SqlDbType.Decimal,
                              Direction =  ParameterDirection.Input,
                              Value = sC_Id
                            },
                            new SqlParameter() {
                                ParameterName = "@sKU_Cod",
                                SqlDbType =  SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,

                                Value = sKU_Cod
                            },
                            new SqlParameter() {
                                ParameterName = "@FromDate",
                                SqlDbType =   SqlDbType.DateTime,
                                Direction =  ParameterDirection.Input,
                                Value =  FromDate
                            },
                            new SqlParameter() {
                                ParameterName = "@ToDate",
                                SqlDbType =  SqlDbType.DateTime,
                                Direction =  ParameterDirection.Input,
                                Value = ToDate
                            },
                            totalDataRows
                        };


                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "RptBooklistSales";
                        cmd.Parameters.AddRange(param);

                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                booklstsale.Add(new RptBooklistSales
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    dAT = sdr["dAT"].ToString(),
                                    vT_No = sdr["vT_No"].ToString(),
                                    sC_Nm = sdr["sC_Nm"].ToString(),
                                    cT_Nm = sdr["cT_Nm"].ToString(),
                                    sET_Qty = Convert.ToDecimal(sdr["sET_Qty"]),
                                    gR_Tot = Convert.ToDecimal(sdr["gR_Tot"]),
                                    bIL_Dis = Convert.ToDecimal(sdr["bIL_Dis"]),
                                    sP_Dis = Convert.ToDecimal(sdr["sP_Dis"]),
                                    tOT_Amt = Convert.ToDecimal(sdr["tOT_Amt"]),
                                    Paid_Amt = Convert.ToDecimal(sdr["Paid_Amt"])
                                });
                            }

                        }
                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();
                    }

                }

                gridlst.Add(new RptBooklistSalesGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = booklstsale });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("BooklistTargetSammary/{sC_Id}/{sKU_Cod}/{FromDate}/{ToDate}")]
        [HttpGet]
        public async Task<ActionResult<List<RptBooklistSales>>> GetBooklistTargetSammary(decimal sC_Id, string sKU_Cod, DateTime FromDate, DateTime ToDate)
        {
            List<RptBooklistSales> lst = await Task.Run(() => new List<RptBooklistSales>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                            new SqlParameter() {
                              ParameterName = "@sC_Id",
                              SqlDbType =  SqlDbType.Decimal,
                              Direction =  ParameterDirection.Input,
                              Value = sC_Id
                            },
                            new SqlParameter() {
                                ParameterName = "@sKU_Cod",
                                SqlDbType =  SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,

                                Value = sKU_Cod
                            },
                            new SqlParameter() {
                                ParameterName = "@FromDate",
                                SqlDbType =   SqlDbType.DateTime,
                                Direction =  ParameterDirection.Input,
                                Value =  FromDate
                            },
                            new SqlParameter() {
                                ParameterName = "@ToDate",
                                SqlDbType =  SqlDbType.DateTime,
                                Direction =  ParameterDirection.Input,
                                Value = ToDate
                            }
                        };


                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BooklistTargetSammary";
                        cmd.Parameters.AddRange(param);

                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lst.Add(new RptBooklistSales
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    sC_Nm = sdr["sC_Nm"].ToString(),
                                    cT_Nm = sdr["cT_Nm"].ToString(),
                                    qTY = Convert.ToDecimal(sdr["qTY"]),
                                    sOLD_Qty = Convert.ToDecimal(sdr["sOLD_Qty"])
                                });
                            }

                        }
                        con.Close();
                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("RptStockRequirments/pn/{pageNo}/ps/{pageSize}/{sKU_Cod}/{FromDate}/{ToDate}")]
        [HttpGet]
        public async Task<ActionResult<List<StockRequirmentsGrid>>> GETStockRequirments(int pageNo, int pageSize, string sKU_Cod, DateTime FromDate, DateTime ToDate)
        {
            decimal totRows = 0.0m;
            List<StockRequirmentsGrid> gridlst = await Task.Run(() => new List<StockRequirmentsGrid>());
            List<StockRequirments> stockRequirments = await Task.Run(() => new List<StockRequirments>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;

                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@PageNo",
                                SqlDbType =   SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value =  pageNo
                            },
                            new SqlParameter() {
                                ParameterName = "@PageSize",
                                SqlDbType =  SqlDbType.Int,
                                Direction =  ParameterDirection.Input,

                                Value = pageSize
                            },
                            new SqlParameter() {
                                ParameterName = "@sKU_Cod",
                                SqlDbType =   SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,
                                Value =  sKU_Cod
                            },

                            new SqlParameter() {
                                ParameterName = "@FromDate",
                                SqlDbType =  SqlDbType.DateTime,
                                Direction =  ParameterDirection.Input,
                                Value = FromDate
                            },
                            new SqlParameter() {
                                ParameterName = "@ToDate",
                                SqlDbType =   SqlDbType.DateTime,
                                Direction =  ParameterDirection.Input,
                                Value =  ToDate
                            },
                           totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "RptStockRequirments";
                        cmd.Parameters.AddRange(param);
                        con.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {

                            while (sdr.Read())
                            {
                                stockRequirments.Add(new StockRequirments
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    ID = Convert.ToDecimal(sdr["ID"]),
                                    gEN_Nm = sdr["gEN_Nm"].ToString(),
                                    mNF_Nm = sdr["mNF_Nm"].ToString(),
                                    cT_Nm = sdr["cT_Nm"].ToString(),
                                    qTY = Convert.ToDecimal(sdr["qTY"]),
                                    sAL_Qty = Convert.ToDecimal(sdr["sAL_Qty"]),
                                    cUR_Stok = Convert.ToDecimal(sdr["cUR_Stok"]),
                                    requir = Convert.ToDecimal(sdr["requir"])
                                });
                            }

                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new StockRequirmentsGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = stockRequirments });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("RptSalesProfit/{FromDate}/{ToDate}/{bR_Id}")]
        [HttpGet]
        public async Task<ActionResult<List<ProfitLosGrid>>> GETProfitLos(DateTime FromDate, DateTime ToDate, int bR_Id)
        {
            decimal totDis = 0.0m;

            List<ProfitLosGrid> gridlst = await Task.Run(() => new List<ProfitLosGrid>());
            List<ProfitLos> profitLos = await Task.Run(() => new List<ProfitLos>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        SqlParameter totalDiscount = new SqlParameter();
                        totalDiscount.ParameterName = "@TotalDiscount";
                        totalDiscount.Direction = ParameterDirection.Output;
                        totalDiscount.DbType = DbType.Decimal;

                        var param = new SqlParameter[] {

                            new SqlParameter() {
                                ParameterName = "@FromDate",
                                SqlDbType =  SqlDbType.DateTime,
                                Direction =  ParameterDirection.Input,
                                Value = FromDate
                            },
                            new SqlParameter() {
                                ParameterName = "@ToDate",
                                SqlDbType =   SqlDbType.DateTime,
                                Direction =  ParameterDirection.Input,
                                Value =  ToDate
                            },
                            new SqlParameter() {
                                ParameterName = "@bR_Id",
                                SqlDbType =   SqlDbType.Int,
                                Direction =  ParameterDirection.Input,
                                Value =  bR_Id
                            },
                             totalDiscount
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "RptSalesProfit";
                        cmd.Parameters.AddRange(param);
                        con.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {

                            while (sdr.Read())
                            {
                                profitLos.Add(new ProfitLos
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    ID = Convert.ToDecimal(sdr["ID"]),
                                    gEN_Nm = sdr["gEN_Nm"].ToString(),
                                    mNF_Nm = sdr["mNF_Nm"].ToString(),
                                    cT_Nm = sdr["cT_Nm"].ToString(),
                                    sKU_Cod = sdr["sKU_Cod"].ToString(),
                                    qTY = Convert.ToDecimal(sdr["qTY"]),
                                    uN_Nm = sdr["uN_Nm"].ToString(),
                                    pUR_Rat = Convert.ToDecimal(sdr["pUR_Rat"]),
                                    sAL_Rat = Convert.ToDecimal(sdr["sAL_Rat"]),
                                    pUR_Amt = Convert.ToDecimal(sdr["pUR_Amt"]),
                                    sAL_Amt = Convert.ToDecimal(sdr["sAL_Amt"])
                                });
                            }

                        }
                        totDis = Convert.ToDecimal(totalDiscount.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new ProfitLosGrid { TotalDiscount = totDis, data = profitLos });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("RptSpecimenCopy/{FromDate}/{ToDate}")]
        [HttpGet]
        public async Task<ActionResult<List<ELG61P03CM>>> RptSpecimenCopy(DateTime FromDate, DateTime ToDate)
        {
            List<ELG61P03CM> lst = await Task.Run(() => new List<ELG61P03CM>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {

                            new SqlParameter() {
                                ParameterName = "@FromDate",
                                SqlDbType =   SqlDbType.DateTime,
                                Direction =  ParameterDirection.Input,
                                Value =  FromDate
                            },
                            new SqlParameter() {
                                ParameterName = "@ToDate",
                                SqlDbType =  SqlDbType.DateTime,
                                Direction =  ParameterDirection.Input,
                                Value = ToDate
                            }
                        };


                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "RptSpecimenCopy";
                        cmd.Parameters.AddRange(param);

                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lst.Add(new ELG61P03CM
                                {
                                    ID = Convert.ToDecimal(sdr["ID"]),
                                    vT_No = sdr["vT_No"].ToString(),
                                    lGR_Nm = (sdr["lGR_Nm"].ToString()),
                                    dAT = (sdr["dAT"].ToString()),
                                    cUS_Nm = (sdr["cUS_Nm"].ToString()),
                                    tOT_Amt = Convert.ToDecimal(sdr["tOT_Amt"])
                                });
                            }

                        }
                        con.Close();
                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("ECR43L72GR/pn/{pageNo}/ps/{pageSize}")]
        [HttpGet]
        public async Task<ActionResult<List<CreditLimitGrid>>> ECR43L72GR(int pageNo = 1, int pageSize = 20)
        {
            decimal totRows = 0.0m;
            List<CreditLimitGrid> gridlst = await Task.Run(() => new List<CreditLimitGrid>());
            List<ECR43L72GR> creditLimit = await Task.Run(() => new List<ECR43L72GR>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlParameter totalDataRows = new SqlParameter();
                        totalDataRows.ParameterName = "@TotalRow";
                        totalDataRows.Direction = ParameterDirection.Output;
                        totalDataRows.DbType = DbType.Decimal;


                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@PageNo",
                            SqlDbType =   SqlDbType.Int,
                            Direction =  ParameterDirection.Input,
                            Value =  pageNo
                        },
                        new SqlParameter() {
                            ParameterName = "@PageSize",
                            SqlDbType =  SqlDbType.Int,
                            Direction =  ParameterDirection.Input,

                            Value = pageSize
                        },
                       totalDataRows
                        };

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ECR43L72GR";
                        cmd.Parameters.AddRange(param);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            {
                                while (sdr.Read())
                                {
                                    creditLimit.Add(new ECR43L72GR { SL = Convert.ToDecimal(sdr["SL"]), Id = Convert.ToDecimal(sdr["Id"]), cR_Tle = sdr["cR_Tle"].ToString(), cR_Lim =Convert.ToDecimal( sdr["cR_Lim"].ToString()), iS_Per = Convert.ToBoolean(sdr["iS_Per"]) == true ? "Percent" : "Amount", iS_Def = Convert.ToBoolean(sdr["iS_Def"]) == true? "Default":"", vDAT = sdr["vDAT"].ToString(),  sTS_Nm = sdr["sTS_Nm"].ToString(), nAR = sdr["nAR"].ToString(), edit = sdr["edit"].ToString() });
                                }
                            }
                        }

                        totRows = Convert.ToDecimal(totalDataRows.Value);
                        con.Close();

                    }
                }

                gridlst.Add(new CreditLimitGrid { PageNo = pageNo, PageSize = pageSize, TotalRow = totRows, data = creditLimit });
                return gridlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [Route("RptAllProducts/{sKU_Cod}/{gEN_Id}/{bR_Id}/{cT_Id}/{mNF_Id}")]
        [HttpGet]
        public async Task<ActionResult<List<ProductList>>> GetRptAllProducts(string sKU_Cod, string gEN_Id, string bR_Id, string cT_Id, string mNF_Id)
        {
            List<ProductList> lst = await Task.Run(() => new List<ProductList>());
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        var param = new SqlParameter[] {
                            new SqlParameter() {
                                ParameterName = "@sKU_Cod",
                                SqlDbType =  SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,

                                Value = sKU_Cod
                            },
                            new SqlParameter() {
                                ParameterName = "@gEN_Id",
                                SqlDbType =  SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,

                                Value = gEN_Id
                            },

                            new SqlParameter() {
                                ParameterName = "@bR_Id",
                                SqlDbType =  SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,

                                Value = bR_Id
                            },
                            new SqlParameter() {
                                ParameterName = "@cT_Id",
                                SqlDbType =  SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,

                                Value = cT_Id
                            },
                            new SqlParameter() {
                                ParameterName = "@mNF_Id",
                                SqlDbType =  SqlDbType.NVarChar,
                                Direction =  ParameterDirection.Input,

                                Value = mNF_Id
                            },
                        };

                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "RptASKU0707";
                        cmd.Parameters.AddRange(param);

                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lst.Add(new ProductList
                                {
                                    SL = Convert.ToDecimal(sdr["SL"]),
                                    mNF_Nm = sdr["mNF_Nm"].ToString(),
                                    gEN_Nm = sdr["gEN_Nm"].ToString(),
                                    cT_Nm = sdr["cT_Nm"].ToString(),
                                    bR_Nm = sdr["bR_Nm"].ToString(),
                                    sKU_Cod = sdr["sKU_Cod"].ToString(),
                                    uN_Nm = sdr["uN_Nm"].ToString(),
                                    sAL_Rat = Convert.ToDecimal(sdr["sAL_Rat"]),
                                    dIS = Convert.ToDecimal(sdr["dIS"]),
                                    cUR_Stok = Convert.ToDecimal(sdr["cUR_Stok"])
                                });
                            }

                        }
                        con.Close();
                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public class ProductCategoryGrid : GridInfo { public List<ACT01001GR> data { get; set; } }
        public class BrandGrid : GridInfo { public List<ABR02002GR> data { get; set; } }
        public class ManufacturerGrid : GridInfo { public List<AMNF0303GR> data { get; set; } }
        public class FilterMasterGrid : GridInfo { public List<AFI04M04GR> data { get; set; } }
        public class FilterValueMasterGrid : GridInfo { public List<AFI05V05GR> data { get; set; } }
        public class GenericGrid : GridInfo { public List<AGE06006GR> data { get; set; } }
        public class ProductSKUGrid : GridInfo { public List<ASKU0707GR> data { get; set; } }
        public class SalesCounterGrid : GridInfo { public List<BSA26C09GR> data { get; set; } }
        public class UnitGrid : GridInfo { public List<AUN10010GR> data { get; set; } }
        public class UnitConversionGrid : GridInfo { public List<AUN11C11GR> data { get; set; } }

        public class GetProductrateGrid : GridInfo { public List<GETASKU0707> data { get; set; } }
        public class SearchFilterGrid : GridInfo { public List<GETASKU0707> data { get; set; } }
        public class StandardRateGrid : GridInfo { public List<AST14R14GR> data { get; set; } }
        public class BarcodeGrid : GridInfo { public List<ABAR1616GR> data { get; set; } }
        public class BatchGrid : GridInfo { public List<ABCH1717GR> data { get; set; } }
        public class BookListGrid : GridInfo { public List<ABK39L22GR> data { get; set; } }


        public class StoreGrid : GridInfo { public List<BST18001GR> data { get; set; } }
        public class StoreRequisitionGrid : GridInfo { public List<BST20R03GR> data { get; set; } }
        public class StockMovmentGrid : GridInfo { public List<BST24M07GR> data { get; set; } }
        public class DemarcationGrid : GridInfo { public List<BDMR2710GR> data { get; set; } }
        public class DeliveryAgentTypeGrid : GridInfo { public List<BDA28T11GR> data { get; set; } }
        public class DeliveryAgentGrid : GridInfo { public List<BDL29A12GR> data { get; set; } }
        public class AgentRateGrid : GridInfo { public List<BAG30R13GR> data { get; set; } }
        public class ClaimGrid : GridInfo { public List<BCLM3114GR> data { get; set; } }
        public class OrderGrid : GridInfo { public List<BOR33015GR> data { get; set; } }
        public class OrderTrackingGrid : GridInfo { public List<BOR35T17GR> data { get; set; } }


        public class CustomerInfoGrid : GridInfo { public List<CCUS3201GR> data { get; set; } }
        public class SchoolGrid : GridInfo { public List<CSCH3807GR> data { get; set; } }
        public class NotificationGrid : GridInfo { public List<CNOT3302GR> data { get; set; } }
        public class NotificationDetailsGrid : GridInfo { public List<CNO34D03GR> data { get; set; } }
        public class OfferTypeGrid : GridInfo { public List<COF35T04GR> data { get; set; } }
        public class OfferMasterGrid : GridInfo { public List<COF36M05GR> data { get; set; } }
        public class OfferDetailsGrid : GridInfo { public List<COF37D06GR> data { get; set; } }


        public class EmployeeTypeGrid : GridInfo { public List<DEM38T01GR> data { get; set; } }
        public class DesignationGrid : GridInfo { public List<DDG39002GR> data { get; set; } }
        public class DepartmentGrid : GridInfo { public List<DDP40003GR> data { get; set; } }
        public class EmployeeInfoGrid : GridInfo { public List<DEM41I04GR> data { get; set; } }
        public class ScheduleGrid : GridInfo { public List<DSC42005GR> data { get; set; } }
        public class EmployeeScheduleGrid : GridInfo { public List<DEM43S06GR> data { get; set; } }
        public class LeaveMasterGrid : GridInfo { public List<DLE44M07GR> data { get; set; } }
        public class EmployeeLeaveGrid : GridInfo { public List<DEM45L08GR> data { get; set; } }
        public class LeaveApprovedGrid : GridInfo { public List<DLE46A09GR> data { get; set; } }
        public class HolidayDeclarationGrid : GridInfo { public List<DHO47D10GR> data { get; set; } }
        public class HolidaySetupGrid : GridInfo { public List<DHO48S11GR> data { get; set; } }
        public class AttendanceGrid : GridInfo { public List<DEM49A12GR> data { get; set; } }
        public class PayHeadGrid : GridInfo { public List<DPA50H13GR> data { get; set; } }
        public class SalaryPackageGrid : GridInfo { public List<DSA51P14GR> data { get; set; } }
        public class SalaryDetailsGrid : GridInfo { public List<DSA53D16GR> data { get; set; } }
        public class BonusDeductionGrid : GridInfo { public List<DBO56D19GR> data { get; set; } }
        public class MonthlySalaryGrid : GridInfo { public List<DMO57S20GR> data { get; set; } }


        public class AccountGroupGrid : GridInfo { public List<EAC59G01GR> data { get; set; } }
        public class AccountLedgerGrid : GridInfo { public List<EAC60L02GR> data { get; set; } }
        public class PartySuplierGrid : GridInfo { public List<EAC60L02GR> data { get; set; } }
        public class AdvanchedPaymentGrid : GridInfo { public List<EAD63P05GR> data { get; set; } }
        public class BankReconcilationGrid : GridInfo { public List<EBN64R06GR> data { get; set; } }
        public class CurrencyGrid : GridInfo { public List<ECUR6911GR> data { get; set; } }
        public class VoucherTypeGrid : GridInfo { public List<EVC26T68GR> data { get; set; } }
        public class FinancialYearGrid : GridInfo { public List<EFN77Y19GR> data { get; set; } }

        public class RptCusSalesAmtGrid : GridInfo { public List<RptCusSalesAmt> data { get; set; } }
        public class RptBooklistSalesGrid : GridInfo { public List<RptBooklistSales> data { get; set; } }
        public class RptSalesReturnGrid : GridInfo { public List<RptCusSalesAmt> data { get; set; } }
        public class RptPurchaseVoucherGrid : GridInfo { public List<RptComPurchaseAmt> data { get; set; } }
        public class RptPurchaseReturnGrid : GridInfo { public List<RptComPurchaseAmt> data { get; set; } }
        public class StockRequirmentsGrid : GridInfo { public List<StockRequirments> data { get; set; } }
        public class ProfitLosGrid : GridInfo { public List<ProfitLos> data { get; set; } public decimal TotalDiscount { get; set; } }


        public class ContraVoucherGrid : GridInfo { public List<ECN65M07GR> data { get; set; } }
        public class JournalVoucherGrid : GridInfo { public List<NESTEJR78M20GR> data { get; set; } }
        public class PaymentMastGrid : GridInfo { public List<EPA83M25NESTGR> data { get; set; } }
        public class ReceiptMasterGrid : GridInfo { public List<ERE98M40NESTGR> data { get; set; } }

        public class CreditLimitGrid : GridInfo { public List<ECR43L72GR> data { get; set; } }

        public class UserInfoGrid : GridInfo { public List<FUS28I01GR> data { get; set; } }
        public class MenuGrid : GridInfo { public List<FMEN2902GR> data { get; set; } }
        public class PermissionGrid : GridInfo { public List<FPER3003GR> data { get; set; } }
        public class UserPermissionGrid : GridInfo { public List<FUS31P04GR> data { get; set; } }

        public class ChalanUpdate { public M34M38M48M57CM_UPDATE masterData { get; set; } public List<D35D39D49D58CM_UPDATE> detailData { get; set; } public UPDCCUS3201CM Customer { get; set; } }
        public class VoucherUpdate { public GETUPDM07M20M25M40 masterData { get; set; } public List<GETUPDD08D21D26D41> detailData { get; set; } }
        public class JournalVoucherUpdate { public GETUPDM07M20M25M40 masterData { get; set; } public List<GETUPDD08D21D26D41> rightData { get; set; } public List<GETUPDD08D21D26D41DR> leftData { get; set; } }

        public class BookListUpdate { public ABK39L22GR masterData { get; set; } public List<ABK40D23GR> detailData { get; set; } }
    }

}

