using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uniflex.GeneralTable
{
    public class Uniflext_Report_Checker
    {
     public int rpt_ID { get; set; }
	 public System.DateTime rpt_Datetime { get; set; }
	 public string rpt_UserId { get; set; }
	 public string rpt_UserName { get; set; }
	 public string rpt_Zonano { get; set; }
	 public string rpt_Zonacode { get; set; }
	 public string rpt_Objname { get; set; }
	 public string rpt_Objstatus { get; set; }
	 public string rpt_Checkerdesc { get; set; }
	 public string rpt_Updateowner { get; set; }
	 public System.DateTime rpt_Updateownerdate { get; set; }
	 public string rpt_Updateownerdesc { get; set; }
		 
		public Uniflext_Report_Checker(){}

		public static List<Uniflext_Report_Checker> GetForDataSource(string status, string d_from,string d_to)
        {
			List<Uniflext_Report_Checker> l = new List<Uniflext_Report_Checker>();
            using (I_HUB.DataAccess.SQLServer db = new I_HUB.DataAccess.SQLServer())
            {
                //select * from uniflex_report where rpt_objstatus='Not Ok' and rpt_Datetime BETWEEN '2022-06-01' AND '2022-09-01'
                if (status.ToString().ToLower().Contains("all"))
                {
                    db.CommandText = "SELECT rpt_ID,rpt_Datetime,rpt_UserId,rpt_UserName,rpt_Zonano,rpt_Zonacode,rpt_Objname,rpt_Objstatus,rpt_Checkerdesc,rpt_Updateowner,rpt_Updateownerdate,rpt_Updateownerdesc  FROM Uniflex_Report where rpt_Datetime BETWEEN @d_from AND @d_to";
                }
                else
                {
                    db.CommandText = "SELECT rpt_ID,rpt_Datetime,rpt_UserId,rpt_UserName,rpt_Zonano,rpt_Zonacode,rpt_Objname,rpt_Objstatus,rpt_Checkerdesc,rpt_Updateowner,rpt_Updateownerdate,rpt_Updateownerdesc  FROM Uniflex_Report where rpt_objstatus='"+status+"' and rpt_Datetime BETWEEN @d_from AND @d_to";
                }
                db.AddParameter("@d_from", System.Data.SqlDbType.VarChar, d_from);
                db.AddParameter("@d_to", System.Data.SqlDbType.VarChar, d_to);
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (System.Data.SqlClient.SqlDataReader rdr = db.DbDataReader as System.Data.SqlClient.SqlDataReader)
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Uniflext_Report_Checker i = new Uniflext_Report_Checker
                            {
                                rpt_Checkerdesc = rdr["rpt_Checkerdesc"].ToString(),
                                rpt_Datetime = I_HUB.Helper.GeneralHelper.NullToDateTime(rdr["rpt_Datetime"], System.DateTime.Now),
                                rpt_ID =I_HUB. Helper.GeneralHelper.NullToInt(rdr["rpt_ID"], 0),
                                rpt_Objname = rdr["rpt_Objname"].ToString(),
                                rpt_Objstatus = rdr["rpt_Objstatus"].ToString(),
                                rpt_Updateowner = rdr["rpt_Updateowner"].ToString(),
                                rpt_Updateownerdate =I_HUB.Helper.GeneralHelper.NullToDateTime(rdr["rpt_Updateownerdate"], System.DateTime.Now),
                                rpt_Updateownerdesc = rdr["rpt_Updateownerdesc"].ToString(),
                                rpt_UserId = rdr["rpt_UserId"].ToString(),
                                rpt_UserName = rdr["rpt_UserName"].ToString(),
                                rpt_Zonacode = rdr["rpt_Zonacode"].ToString(),
                                rpt_Zonano = rdr["rpt_Zonano"].ToString()
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

        public static Uniflext_Report_Checker GetFromId(int id)
        {
            Uniflext_Report_Checker uniflext_Report_Checker = new Uniflext_Report_Checker();
            using (I_HUB.DataAccess.SQLServer db = new I_HUB.DataAccess.SQLServer())
            {
                //select * from uniflex_report where rpt_objstatus='Not Ok' and rpt_Datetime BETWEEN '2022-06-01' AND '2022-09-01'
                db.CommandText = "SELECT rpt_ID,rpt_Datetime,rpt_UserId,rpt_UserName,rpt_Zonano,rpt_Zonacode,rpt_Objname,rpt_Objstatus,rpt_Checkerdesc,rpt_Updateowner,rpt_Updateownerdate,rpt_Updateownerdesc  FROM Uniflex_Report where rpt_ID=@id";
                db.AddParameter("@id", System.Data.SqlDbType.Int,id);
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (System.Data.SqlClient.SqlDataReader rdr = db.DbDataReader as System.Data.SqlClient.SqlDataReader)
                {
                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        uniflext_Report_Checker = new Uniflext_Report_Checker
                        {
                            rpt_Checkerdesc = rdr["rpt_Checkerdesc"].ToString(),
                            rpt_Datetime = I_HUB.Helper.GeneralHelper.NullToDateTime(rdr["rpt_Datetime"], System.DateTime.Now),
                            rpt_ID = I_HUB.Helper.GeneralHelper.NullToInt(rdr["rpt_ID"], 0),
                            rpt_Objname = rdr["rpt_Objname"].ToString(),
                            rpt_Objstatus = rdr["rpt_Objstatus"].ToString(),
                            rpt_Updateowner = rdr["rpt_Updateowner"].ToString(),
                            rpt_Updateownerdate = I_HUB.Helper.GeneralHelper.NullToDateTime(rdr["rpt_Updateownerdate"], System.DateTime.Now),
                            rpt_Updateownerdesc = rdr["rpt_Updateownerdesc"].ToString(),
                            rpt_UserId = rdr["rpt_UserId"].ToString(),
                            rpt_UserName = rdr["rpt_UserName"].ToString(),
                            rpt_Zonacode = rdr["rpt_Zonacode"].ToString(),
                            rpt_Zonano = rdr["rpt_Zonano"].ToString()
                        };
                    }
                    if (!rdr.IsClosed) rdr.Close();
                }
                db.Close();
            }
            return uniflext_Report_Checker;
        }

        public static int UpdateReportDesc(int id,string txt)
        {
            int return_ = 0;
            using (I_HUB.DataAccess.SQLServer db = new I_HUB.DataAccess.SQLServer())
            {
                try
                {
                    db.Open();
                    db.CommandText = "update uniflex_report set rpt_Updateownerdesc=@txt where rpt_ID=@rpt_ID";
                    db.AddParameter("@txt", System.Data.SqlDbType.VarChar, txt);
                    db.AddParameter("@rpt_ID", System.Data.SqlDbType.Int, id);
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
 
 CREATE TABLE [dbo].[Uniflex_Report](
	[rpt_ID] [int] IDENTITY(1,1) NOT NULL primary key,
	[rpt_Datetime] [Datetime] not NULL default getdate(),
	[rpt_UserId] [varchar](200) NULL,
	[rpt_UserName] [varchar](200) NULL,
	[rpt_Zonano] [datetime] not NULL default getdate(),
	[rpt_Zonacode][varchar](200) NULL,
	[rpt_Objname][varchar](200) NULL,
	[rpt_Objstatus] [varchar](200) NULL,
	[rpt_Checkerdesc] [varchar](200) NULL,
	[rpt_Updateowner] [varchar](200) NULL,
	[rpt_Updateownerdate] datetime not NULL default getdate(),
	[rpt_Updateownerdesc] [varchar](200) NULL
)

--------------------- Insert data ---------------------------------------


insert into Uniflex_Report(rpt_UserId,rpt_UserName,rpt_Zonano,rpt_Zonacode,rpt_Objname,rpt_Objstatus,rpt_Checkerdesc,rpt_Updateowner,rpt_Updateownerdesc)values
('LH','Lundy Hasym','8','zona8','Lantai','OK','Aman terkandali','M.Achdi','Ok Good Job');
insert into Uniflex_Report(rpt_UserId,rpt_UserName,rpt_Zonano,rpt_Zonacode,rpt_Objname,rpt_Objstatus,rpt_Checkerdesc,rpt_Updateowner,rpt_Updateownerdesc)values
('LH','Lundy Hasym','8','zona8','Tembok','OK','Aman terkandali','M.Achdi','Ok Good Job');
insert into Uniflex_Report(rpt_UserId,rpt_UserName,rpt_Zonano,rpt_Zonacode,rpt_Objname,rpt_Objstatus,rpt_Checkerdesc,rpt_Updateowner,rpt_Updateownerdesc)values
('LH','Lundy Hasym','8','zona8','Plafon','OK','Aman terkandali','M.Achdi','Ok Good Job');
insert into Uniflex_Report(rpt_UserId,rpt_UserName,rpt_Zonano,rpt_Zonacode,rpt_Objname,rpt_Objstatus,rpt_Checkerdesc,rpt_Updateowner,rpt_Updateownerdesc)values
('LH','Lundy Hasym','8','zona8','Pintu','Not OK','Handle Patah','M.Achdi','Tunggu Maintenance');
insert into Uniflex_Report(rpt_UserId,rpt_UserName,rpt_Zonano,rpt_Zonacode,rpt_Objname,rpt_Objstatus,rpt_Checkerdesc,rpt_Updateowner,rpt_Updateownerdesc)values
('LH','Lundy Hasym','8','zona8','Meja','Not OK','Cat Luntur','M.Achdi','Tunggu Maintenance');
insert into Uniflex_Report(rpt_UserId,rpt_UserName,rpt_Zonano,rpt_Zonacode,rpt_Objname,rpt_Objstatus,rpt_Checkerdesc,rpt_Updateowner,rpt_Updateownerdesc)values
('LH','Lundy Hasym','8','zona8','Kursi','Not OK','Patah','M.Achdi','Tunggu Maintenance');
insert into Uniflex_Report(rpt_UserId,rpt_UserName,rpt_Zonano,rpt_Zonacode,rpt_Objname,rpt_Objstatus,rpt_Checkerdesc,rpt_Updateowner,rpt_Updateownerdesc)values
('LH','Lundy Hasym','8','zona8','Dinding Kaca','Not OK','Retak','M.Achdi','Tunggu Maintenance');
insert into Uniflex_Report(rpt_UserId,rpt_UserName,rpt_Zonano,rpt_Zonacode,rpt_Objname,rpt_Objstatus,rpt_Checkerdesc,rpt_Updateowner,rpt_Updateownerdesc)values
('LH','Lundy Hasym','8','zona8','Kipas Angin','OK','Aman terkandali','M.Achdi','Ok Good Job');
insert into Uniflex_Report(rpt_UserId,rpt_UserName,rpt_Zonano,rpt_Zonacode,rpt_Objname,rpt_Objstatus,rpt_Checkerdesc,rpt_Updateowner,rpt_Updateownerdesc)values
('LH','Lundy Hasym','8','zona8','Exhaust','OK','Aman terkandali','M.Achdi','Ok Good Job');
insert into Uniflex_Report(rpt_UserId,rpt_UserName,rpt_Zonano,rpt_Zonacode,rpt_Objname,rpt_Objstatus,rpt_Checkerdesc,rpt_Updateowner,rpt_Updateownerdesc)values
('LH','Lundy Hasym','8','zona8','Jam Dinding','OK','Aman terkandali','M.Achdi','Ok Good Job');
insert into Uniflex_Report(rpt_UserId,rpt_UserName,rpt_Zonano,rpt_Zonacode,rpt_Objname,rpt_Objstatus,rpt_Checkerdesc,rpt_Updateowner,rpt_Updateownerdesc)values
('LH','Lundy Hasym','8','zona8','Lampu','OK','Aman terkandali','M.Achdi','Ok Good Job');
insert into Uniflex_Report(rpt_UserId,rpt_UserName,rpt_Zonano,rpt_Zonacode,rpt_Objname,rpt_Objstatus,rpt_Checkerdesc,rpt_Updateowner,rpt_Updateownerdesc)values
('LH','Lundy Hasym','8','zona8','Jendela','OK','Aman terkandali','M.Achdi','Ok Good Job');
insert into Uniflex_Report(rpt_UserId,rpt_UserName,rpt_Zonano,rpt_Zonacode,rpt_Objname,rpt_Objstatus,rpt_Checkerdesc,rpt_Updateowner,rpt_Updateownerdesc)values
('LH','Lundy Hasym','8','zona8','SCREEN ANTI SERANGGA','OK','Aman terkandali','M.Achdi','Ok Good Job');
insert into Uniflex_Report(rpt_UserId,rpt_UserName,rpt_Zonano,rpt_Zonacode,rpt_Objname,rpt_Objstatus,rpt_Checkerdesc,rpt_Updateowner,rpt_Updateownerdesc)values
('LH','Lundy Hasym','8','zona8','Pagar Pembatas','Not OK','Pentok terbentur forklift','M.Achdi','Tunggu Bagian GA');
insert into Uniflex_Report(rpt_UserId,rpt_UserName,rpt_Zonano,rpt_Zonacode,rpt_Objname,rpt_Objstatus,rpt_Checkerdesc,rpt_Updateowner,rpt_Updateownerdesc)values
('LH','Lundy Hasym','8','zona8','Apar','Not OK','Gas Habis','M.Achdi','Tunggu Approval Bos');

 */