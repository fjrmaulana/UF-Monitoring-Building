using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uniflex.GeneralTable
{
    public class Uniflext_ZonaArea
    {
        public int Row_Id { get; set; }
        public string Area_Name { get; set; }
        public string Area_Desc { get; set; }
        public string Area_Id { get; set; }
        public string Area_UserEntry { get; set; }
        public System.DateTime Area_UserEntry_Date { get; set; }
        public System.DateTime Area_UserUpdate_Date { get; set; }
        public bool Area_status_active { get; set; }

        public Uniflext_ZonaArea() { }

        public static List<Uniflext_ZonaArea> GetForDataSource()
        {
            List<Uniflext_ZonaArea> l = new List<Uniflext_ZonaArea>();
            using (I_HUB. DataAccess.SQLServer db = new I_HUB.DataAccess.SQLServer())
            {
                db.CommandText = "select Row_Id, Area_Name,Area_Desc, Area_Id, Area_UserEntry, Area_UserEntry_Date, Area_UserUpdate_Date, Area_status_active from Uniflex_ZonaArea";
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (System.Data.SqlClient.SqlDataReader rdr = db.DbDataReader as System.Data.SqlClient.SqlDataReader)
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Uniflext_ZonaArea i = new Uniflext_ZonaArea
                            {
                                Area_Desc = rdr["Area_Desc"].ToString(),
                                Area_Id = rdr["Area_Id"].ToString(),
                                Area_Name = rdr["Area_Name"].ToString(),
                                Area_status_active =I_HUB.Helper.GeneralHelper.NullToBool(rdr["Area_status_active"],false),
                                Area_UserEntry = rdr["Area_UserEntry"].ToString(),
                                Area_UserEntry_Date =I_HUB.Helper.GeneralHelper.NullToDateTime(rdr["Area_UserEntry_Date"],System.DateTime.Now),
                                Area_UserUpdate_Date = I_HUB.Helper.GeneralHelper.NullToDateTime(rdr["Area_UserUpdate_Date"], System.DateTime.Now),
                                Row_Id = I_HUB.Helper.GeneralHelper.NullToInt(rdr["Row_Id"],1)
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

        public static bool DataExist(string id)
        {
            bool l = false;
            using (I_HUB.DataAccess.SQLServer db = new I_HUB.DataAccess.SQLServer())
            {
                db.CommandText = "select Row_Id, Area_Name,Area_Desc, Area_Id, Area_UserEntry, Area_UserEntry_Date, Area_UserUpdate_Date, Area_status_active from Uniflex_ZonaArea where Area_Id=@id";
                db.AddParameter("@id", System.Data.SqlDbType.VarChar, id);
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (System.Data.SqlClient.SqlDataReader rdr = db.DbDataReader as System.Data.SqlClient.SqlDataReader)
                {
                    if (rdr.HasRows)
                    {
                        l = true;
                    }
                    if (!rdr.IsClosed) rdr.Close();
                }
                db.Close();
            }
            return l;
        }

        public static int SaveData(string Area_Name, string Area_Desc, string Area_Id, string Area_UserEntry,bool Area_status_active)
        {
            int return_ = 0;
            //insert into Uniflex_ZonaArea(Area_Name,Area_Desc,Area_Id,Area_UserEntry)values('zona10','Kantin Belakang. Loker Karyawan, Ruang Genset','10','M.Achdi')
            using (I_HUB.DataAccess.SQLServer db = new I_HUB.DataAccess.SQLServer())
            {
                try
                {
                    db.Open();
                    db.CommandText = "insert into Uniflex_ZonaArea(Area_Name,Area_Desc,Area_Id,Area_UserEntry,Area_status_active)values(@Area_Name,@Area_Desc,@Area_Id,@Area_UserEntry,@Area_status_active)";
                    db.AddParameter("@Area_Name", System.Data.SqlDbType.VarChar, Area_Name);
                    db.AddParameter("@Area_Desc", System.Data.SqlDbType.VarChar, Area_Desc);
                    db.AddParameter("@Area_Id", System.Data.SqlDbType.VarChar, Area_Id);
                    db.AddParameter("@Area_UserEntry", System.Data.SqlDbType.VarChar, Area_UserEntry);
                    db.AddParameter("@Area_status_active", System.Data.SqlDbType.Float, Area_status_active);
                    db.CommandType = System.Data.CommandType.Text;
                    db.BeginTransaction();
                    return_ = db.ExecuteNonQuery();
                    db.CommitTransaction();
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException e)
                {
                    if (db.Transaction != null)
                        db.RollbackTransaction();
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
                catch
                {
                    if (db.Transaction != null)
                        db.RollbackTransaction();
                    throw;
                }
                finally
                {
                    db.Close();
                }
            }

            return return_;
        }

    }
}

/*
 CREATE TABLE Uniflex_ZonaArea (
Row_Id int identity(1,1) NOT NULL PRIMARY KEY,
Area_Name VARCHAR(100)  NULL,
Area_Desc VARCHAR(500)  NULL,
Area_Id VARCHAR(100)  NULL,
Area_UserEntry VARCHAR(100)  NULL,
Area_UserEntry_Date datetime default getdate(),
Area_UserUpdate_Date datetime default getdate(),
Area_status_active bit NOT NULL default 1
);

insert into Uniflex_ZonaArea(Area_Name,Area_Desc,Area_Id,Area_UserEntry)values
('zona10','Kantin Belakang. Loker Karyawan, Ruang Genset','10','M.Achdi')

select Row_Id, Area_Name,Area_Desc, Area_Id, Area_UserEntry, Area_UserEntry_Date, Area_UserUpdate_Date, Area_status_active from Uniflex_ZonaArea
 
 */
