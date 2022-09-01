using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I_HUB.GeneralTable
{
    public class nle_sp2_itgr_HEADER
    {
        public string BL_NO { get; set; }
        public string NM_CARGOOWNER { get; set; }
        public decimal PRICE { get; set; }
        public string TERMINAL { get; set; }
        public string STATUS_SENT { get; set; }
        public string MESSAGE_SENT { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public System.DateTime SEND_DATE { get; set; }
        public nle_sp2_itgr_HEADER() { }

        public static List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> getTerminalForDatasource()
        {
            List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> groups = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();

            using (DataAccess.Oracle db = new DataAccess.Oracle())
            {
                db.CommandText = "SELECT DISTINCT KD_TERMINAL,TERMINAL FROM nle_sp2_itgr ORDER BY KD_TERMINAL";
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (Oracle.ManagedDataAccess.Client.OracleDataReader dr = db.DbDataReader as Oracle.ManagedDataAccess.Client.OracleDataReader)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Microsoft.AspNetCore.Mvc.Rendering.SelectListItem item = new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem();
                            var valnya = Helper.GeneralHelper.NullToString(dr["KD_TERMINAL"]);
                            var textNya = Helper.GeneralHelper.NullToString(dr["TERMINAL"]);
                            item.Value = valnya;
                            item.Text = textNya + " - " + valnya;
                            groups.Add(item);
                        }
                    }
                    if (!dr.IsClosed)
                        dr.Close();
                }
                db.Close();
            }
            groups.Insert(0, new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = "ALL", Value = "ALL" });
            return groups;
        }

        public static List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> GetSelectDropDownLimit()
        {
            List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> groups = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            groups.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = "20", Value = "20" });
            groups.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = "50", Value = "50" });
            groups.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = "100", Value = "100" });
            groups.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = "500", Value = "500" });
            groups.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = "1000", Value = "1000" });
            groups.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = "1000", Value = "5000" });
            groups.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = "1000", Value = "10000" });
            return groups;
        }

        public static List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> getBlistForDatasource()
        {
            List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> groups = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();

            using (DataAccess.Oracle db = new DataAccess.Oracle())
            {
                db.CommandText = "SELECT DISTINCT BL_NO,NM_CARGOOWNER FROM nle_sp2_itgr ORDER BY BL_NO FETCH FIRST 100 ROWS ONLY";
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (Oracle.ManagedDataAccess.Client.OracleDataReader dr = db.DbDataReader as Oracle.ManagedDataAccess.Client.OracleDataReader)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Microsoft.AspNetCore.Mvc.Rendering.SelectListItem item = new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem();
                            var v_ = Helper.GeneralHelper.NullToString(dr["BL_NO"]);
                            var t_ = Helper.GeneralHelper.NullToString(dr["NM_CARGOOWNER"]);
                            item.Value = v_;
                            item.Text = v_ + " - " + t_;
                            groups.Add(item);
                        }
                    }
                    if (!dr.IsClosed)
                        dr.Close();
                }
                db.Close();
            }
            groups.Insert(0, new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = "ALL", Value = "ALL" });
            return groups;
        }

        public static List<dynamic> Get_List_BlNo(string query)
        {
            List<dynamic> l = new List<dynamic>();
            using (DataAccess.Oracle db = new DataAccess.Oracle())
            {
                db.CommandText = query;
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (Oracle.ManagedDataAccess.Client.OracleDataReader dr = db.DbDataReader as Oracle.ManagedDataAccess.Client.OracleDataReader)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var v_ = Helper.GeneralHelper.NullToString(dr["BL_NO"]);
                            var t_ = Helper.GeneralHelper.NullToString(dr["NM_CARGOOWNER"]);
                            var blno_item = new { blno = v_, nm_cargoowner = v_ + " - " + t_ };
                            l.Add(blno_item);
                        }
                    }
                    if (!dr.IsClosed)
                        dr.Close();
                }
                db.Close();
            }
            l.Insert(0, new { blno = "ALL", nm_cargoowner = "ALL" });
            return l;
        }
        public static List<nle_sp2_itgr_HEADER> Get_nle_sp2_itgr_HeaderforDatasource(string query)
        {
            List<nle_sp2_itgr_HEADER> l = new List<nle_sp2_itgr_HEADER>();
            using (DataAccess.Oracle db = new DataAccess.Oracle())
            {
                db.CommandText = query;
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (Oracle.ManagedDataAccess.Client.OracleDataReader rdr = db.DbDataReader as Oracle.ManagedDataAccess.Client.OracleDataReader)
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            nle_sp2_itgr_HEADER sp2 = new nle_sp2_itgr_HEADER
                            {
                                CREATED_DATE = Helper.GeneralHelper.NullToDateTime(rdr["CREATED_DATE_"], System.DateTime.Now),
                                BL_NO = Helper.GeneralHelper.NullToString(rdr["BL_NO"]),
                                MESSAGE_SENT = Helper.GeneralHelper.NullToString(rdr["MESSAGE_SENT"]),
                                NM_CARGOOWNER = Helper.GeneralHelper.NullToString(rdr["NM_CARGOOWNER"]),
                                PRICE = Helper.GeneralHelper.NullToDecimal(rdr["PRICE"], 0),
                                SEND_DATE = Helper.GeneralHelper.NullToDateTime(rdr["SEND_DATE_"], System.DateTime.Now),
                                STATUS_SENT = Helper.GeneralHelper.NullToString(rdr["STATUS_SENT"]),
                                TERMINAL = Helper.GeneralHelper.NullToString(rdr["TERMINAL"])
                            };
                            l.Add(sp2);
                        }
                    }
                    if (!rdr.IsClosed) rdr.Close();
                }
                db.Close();
            }
            return l;
        }

        public static string Get_Detail_Json(string bl_no)
        {
            string l = "";
            using (DataAccess.Oracle db = new DataAccess.Oracle())
            {
                db.CommandText = "SELECT JSON_TEXT FROM nle_sp2_itgr WHERE BL_NO LIKE '%" + bl_no.Trim() + "%' ORDER BY BL_NO FETCH FIRST 1 ROWS ONLY";
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (Oracle.ManagedDataAccess.Client.OracleDataReader dr = db.DbDataReader as Oracle.ManagedDataAccess.Client.OracleDataReader)
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        l = dr["JSON_TEXT"].ToString();// Helper.GeneralHelper.NullToString(dr["BL_NO"]);
                    }
                    if (!dr.IsClosed)
                        dr.Close();
                }
                db.Close();
            }
            return l;
        }//

        public static int GetCount(int mont, int yer, string status_sent)
        {
            int return_ = 0;
            string sql = "SELECT COUNT(CREATED_DATE) as COUNT FROM NLE_SP2_ITGR WHERE EXTRACT(MONTH from CREATED_DATE) =" + mont + " and EXTRACT(YEAR from CREATED_DATE) =" + yer + " AND STATUS_SENT ='" + status_sent + "' ORDER BY CREATED_DATE";
            //System.Diagnostics.Debug.WriteLine(sql);
            using (DataAccess.Oracle db = new DataAccess.Oracle())
            {
                db.CommandText = sql;
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (Oracle.ManagedDataAccess.Client.OracleDataReader rdr = db.DbDataReader as Oracle.ManagedDataAccess.Client.OracleDataReader)
                {
                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        return_ = Helper.GeneralHelper.NullToInt(rdr["COUNT"], 0);
                    }
                    if (!rdr.IsClosed) rdr.Close();
                }
                db.Close();
            }
            return return_;
        }
    }

    public class Lessee
    {
        public string bl_no { get; set; }
    }

    public class Lessee_Root
    {
        public List<Lessee> Lessee { get; set; }
    }
}
