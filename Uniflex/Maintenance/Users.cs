using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I_HUB.Maintenance
{
    public class Users
    {
        public Users()
        {
            
        }
        public int ID { get; set; }
        public string USER_ID { get; set; }
        public string USER_FULLNAME { get; set; }
        public string USER_EMAIL { get; set; }
        public string USER_PASS { get; set; }
        public string USER_TOKEN_TRX { get; set; }
        public string USER_TOKEN_EMAIL { get; set; }
        public bool USER_TOKEN_EMAIL_KONFIRM { get; set; }
        public string USER_ROLE { get; set; }
        public string USER_ORG { get; set; }
        public int TRX_COUNT { get; set; }
        public System.DateTime USER_JOINT { get; set; }
        public System.DateTime ENTRY_DATE { get; set; }
        public System.DateTime USER_UPDATE { get; set; }
        public string USER_ENTRY { get; set; }
        public bool USER_ACTIVE { get; set; }
        public System.DateTime USER_EXP { get; set; }

        public static List<Users> UsersForDataSource()
        {
            List<Users> L = new List<Users>();
            using (DataAccess.SQLServer db = new DataAccess.SQLServer())
            {
                db.CommandText = "SELECT ID, USER_ID, USER_FULLNAME, USER_EMAIL, USER_PASS, USER_TOKEN_TRX, USER_TOKEN_EMAIL, USER_TOKEN_EMAIL_CONFIRM, USER_ROLE, USER_ORG, USER_TRX_COUNT, USER_JOINT, ENTRY_DATE, USER_UPDATE, USER_ENTRY, USER_ACTIVE, USER_EXP FROM Uniflex_Users";
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (System.Data.SqlClient.SqlDataReader rdr = db.DbDataReader as System.Data.SqlClient.SqlDataReader)
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Users i = new Users
                            {
                                ENTRY_DATE = Helper.GeneralHelper.NullToDateTime(rdr["ENTRY_DATE"], System.DateTime.Now),
                                ID = Helper.GeneralHelper.NullToInt(rdr["ID"], 0),
                                TRX_COUNT = Helper.GeneralHelper.NullToInt(rdr["USER_TRX_COUNT"], 0),
                                USER_ACTIVE = Helper.GeneralHelper.NullToBool(rdr["USER_ACTIVE"],false),
                                USER_EMAIL = rdr["USER_EMAIL"].ToString(),
                                USER_ENTRY =rdr["USER_ENTRY"].ToString(),
                                USER_EXP = Helper.GeneralHelper.NullToDateTime(rdr["USER_EXP"], System.DateTime.Now),
                                USER_FULLNAME = rdr["USER_FULLNAME"].ToString(),
                                USER_ID =rdr["USER_ID"].ToString(),
                                USER_JOINT = Helper.GeneralHelper.NullToDateTime(rdr["USER_JOINT"], System.DateTime.Now),
                                USER_ORG =rdr["USER_ORG"].ToString(),
                                USER_PASS =  rdr["USER_PASS"].ToString(),
                                USER_ROLE = rdr["USER_ROLE"].ToString(),
                                USER_TOKEN_EMAIL = rdr["USER_TOKEN_EMAIL"].ToString(),
                                USER_TOKEN_EMAIL_KONFIRM =Helper.GeneralHelper.NullToBool(rdr["USER_TOKEN_EMAIL_CONFIRM"],false),
                                USER_TOKEN_TRX =  rdr["USER_TOKEN_TRX"].ToString(),
                                USER_UPDATE = Helper.GeneralHelper.NullToDateTime(rdr["USER_UPDATE"], System.DateTime.Now)
                            };
                            L.Add(i);
                        }
                    }
                    if (!rdr.IsClosed) rdr.Close();
                }
                db.Close();
            }
            return L;
        }

        public static int DeleteAllUser()
        {
            int return_ = 0;
            using (DataAccess.Oracle db = new DataAccess.Oracle())
            {
                try
                {
                    db.Open();
                    db.CommandText = "DELETE FROM IHUB_USER";
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

        public static void SaveAllUsers(List<Users> s)
        {
            DeleteAllUser();

            foreach (var x in s)
            {
                int success_save = SaveUser(x);
            }
        }

        public static int DeleteCompany(string user_id)
        {
            int return_ = 0;
            using (DataAccess.Oracle db = new DataAccess.Oracle())
            {
                try
                {
                    db.Open();
                    db.CommandText = "DELETE FROM IHUB_USER WHERE USER_ID='"+user_id+"'";
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

        public static int SaveUser(Users u)
        {
            int return_ = 0;
            using (DataAccess.Oracle db = new DataAccess.Oracle())
            {
                try
                {
                    db.Open();
                    db.CommandText = "INSERT INTO IHUB_USER (USER_ID, USER_FULLNAME, USER_EMAIL, USER_PASS, USER_TOKEN_TRX, USER_TOKEN_EMAIL, USER_TOKEN_EMAIL_CONFIRM, USER_ROLE, USER_ORG, USER_TRX_COUNT, USER_ENTRY, USER_ACTIVE)VALUES(:USER_ID, :USER_FULLNAME, :USER_EMAIL, :USER_PASS, :USER_TOKEN_TRX, :USER_TOKEN_EMAIL, :USER_TOKEN_EMAIL_CONFIRM, :USER_ROLE, :USER_ORG, :USER_TRX_COUNT, :USER_ENTRY, :USER_ACTIVE)";
                    db.AddParameter(":USER_ID", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, u.USER_ID);
                    db.AddParameter(":USER_FULLNAME", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, u.USER_FULLNAME);
                    db.AddParameter(":USER_EMAIL", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2,u.USER_EMAIL);
                    db.AddParameter(":USER_PASS", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2,u.USER_PASS);
                    db.AddParameter(":USER_TOKEN_TRX", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, u.USER_TOKEN_TRX);
                    db.AddParameter(":USER_TOKEN_EMAIL", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, u.USER_TOKEN_EMAIL);
                    db.AddParameter(":USER_TOKEN_EMAIL_CONFIRM", Oracle.ManagedDataAccess.Client.OracleDbType.Int16,u.USER_TOKEN_EMAIL_KONFIRM);
                    db.AddParameter(":USER_ROLE", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2,u.USER_ROLE);
                    db.AddParameter(":USER_ORG", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, u.USER_ORG);
                    db.AddParameter(":USER_TRX_COUNT", Oracle.ManagedDataAccess.Client.OracleDbType.Int16, u.TRX_COUNT);
                    db.AddParameter(":USER_ENTRY", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, u.USER_ENTRY);
                    db.AddParameter(":USER_ACTIVE", Oracle.ManagedDataAccess.Client.OracleDbType.Int16,u.USER_ACTIVE);
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

        public static Users UserLogin(string userID, string password)
        {
            Helper.clsCryptho crypt = new Helper.clsCryptho();
            string passwd = crypt.Encrypt(password, "@Uniflex");
            List<Users> users = Users.UsersForDataSource();
            var b = users.Where(a => a.USER_PASS == passwd && a.USER_ID.ToLower() == userID.ToLower()).FirstOrDefault();
            return b;
        }

        public static Users GetUserItemFrom_id(string u)
        {
            List<Users> users = Users.UsersForDataSource();
            var b = users.Where(a => a.USER_ID.ToLower() == u.ToLower()).FirstOrDefault();
            return b;
        }
        public static Users GetFromToken(string token)
        {
            List<Users> users = Users.UsersForDataSource();
            var b = users.Where(a => a.USER_TOKEN_TRX.ToLower() == token.ToLower()).FirstOrDefault();
            return b;
        }
    }
}

/*
 
CREATE TABLE Uniflex_Users (
ID INT PRIMARY KEY,
[USER_ID] VARCHAR(100) NULL,
USER_FULLNAME VARCHAR(100) NULL,
USER_EMAIL VARCHAR(100) NULL,
USER_PASS VARCHAR(500) NULL,
USER_TOKEN_TRX VARCHAR(200) NULL,
USER_TOKEN_EMAIL_KONFIRM  INT NOT NULL DEFAULT 0,
USER_ROLE VARCHAR(100) NULL,
USER_ORG VARCHAR(100) NULL,
TRX_COUNT INT NOT NULL DEFAULT 0,
USER_JOINT  DATETIME not NULL default getdate(),
ENTRY_DATE  DATETIME not NULL default getdate(),
USER_UPDATE VARCHAR(8) NOT NULL,
USER_ENTRY VARCHAR(100) NULL,
USER_ACTIVE BIT NULL,
USER_EXP DATETIME not NULL default getdate()
);
 */
