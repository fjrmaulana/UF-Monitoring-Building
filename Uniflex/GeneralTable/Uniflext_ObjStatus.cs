using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uniflex.GeneralTable
{
    public class Uniflext_ObjStatus
    {
        public int ID { get; set; }
        public string Kode { get; set; }
        public string Name { get; set; }
        public System.DateTime Created_date { get; set; }
        public System.DateTime Update_date { get; set; }
        public string user_entry { get; set; }
        public Uniflext_ObjStatus(){}

        public static List<Uniflext_ObjStatus> GetForDataSources()
        {
            List<Uniflext_ObjStatus> l = new List<Uniflext_ObjStatus>();
            using (I_HUB.DataAccess.SQLServer db = new I_HUB.DataAccess.SQLServer())
            {
                db.CommandText = "select id,kode,name,created_date,update_date,user_entry from [Uniflex_ObjStatus]";
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (System.Data.SqlClient.SqlDataReader rdr = db.DbDataReader as System.Data.SqlClient.SqlDataReader)
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Uniflext_ObjStatus i = new Uniflext_ObjStatus
                            {
                                Created_date = I_HUB.Helper.GeneralHelper.NullToDateTime(rdr["Created_date"], System.DateTime.Now),
                                ID = I_HUB.Helper.GeneralHelper.NullToInt(rdr["ID"], 0),
                                Kode = rdr["Kode"].ToString(),
                                Name = rdr["Name"].ToString(),
                                Update_date = I_HUB.Helper.GeneralHelper.NullToDateTime(rdr["Update_date"], System.DateTime.Now),
                                user_entry = rdr["user_entry"].ToString()
                            };
                            l.Add(i);
                        }
                    }
                    if (!rdr.IsClosed) rdr.Close();
                }
                db.Close();
            }
            return l;
        }

        public static Uniflext_ObjStatus GetFromCode(string code)
        {
            Uniflext_ObjStatus uniflext_ObjStatus = new Uniflext_ObjStatus();
            using (I_HUB.DataAccess.SQLServer db = new I_HUB.DataAccess.SQLServer())
            {
                db.CommandText = "select id,kode,name,created_date,update_date,user_entry from [Uniflex_ObjStatus] where Kode=@kode";
                db.AddParameter("@kode", System.Data.SqlDbType.VarChar, code);
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (System.Data.SqlClient.SqlDataReader rdr = db.DbDataReader as System.Data.SqlClient.SqlDataReader)
                {
                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        uniflext_ObjStatus = new Uniflext_ObjStatus
                        {
                            Created_date = I_HUB.Helper.GeneralHelper.NullToDateTime(rdr["Created_date"], System.DateTime.Now),
                            ID = I_HUB.Helper.GeneralHelper.NullToInt(rdr["ID"], 0),
                            Kode = rdr["Kode"].ToString(),
                            Name = rdr["Name"].ToString(),
                            Update_date = I_HUB.Helper.GeneralHelper.NullToDateTime(rdr["Update_date"], System.DateTime.Now),
                            user_entry = rdr["user_entry"].ToString()
                        };
                    }
                    if (!rdr.IsClosed) rdr.Close();
                }
                db.Close();
            }
            return uniflext_ObjStatus;
        }

        public static List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> ForList()
        {
            List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> groups = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            List<Uniflext_ObjStatus> baseUrls = Uniflext_ObjStatus.GetForDataSources();
            foreach (var x in baseUrls)
            {
                Microsoft.AspNetCore.Mvc.Rendering.SelectListItem item = new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem();
                item.Value =x.Kode;
                item.Text = x.Name;
                groups.Add(item);
            }
            return groups;
        }


    }
}

/*
 CREATE TABLE [dbo].[Uniflex_ObjStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL primary key,
	[Kode] [varchar](200) NULL,
	[Name] [varchar](200) NULL,
	[Created_date] datetime not NULL default getdate(),
	[Update_date]datetime not NULL default getdate(),
	[user_entry][varchar](200) NULL
)
-------------------------------------------------------------------


insert into Uniflex_ObjStatus(kode,name,user_entry)values('0','Not Ok','M.Achdi');
insert into Uniflex_ObjStatus(kode,name,user_entry)values('1','Ok','M.Achdi');
insert into Uniflex_ObjStatus(kode,name,user_entry)values('2','ALL','M.Achdi');
 
 */