using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I_HUB.Maintenance
{
    public class MenuMaster
    {
        public int ID { get; set; }
        public string MENU_NAME { get; set; }
        public string MENU_PARENT { get; set; }
        public string MENU_IMG { get; set; }
        public string MENU_CODE { get; set; }
        public string MENU_LEVEL { get; set; }
        public string MENU_MLM { get; set; }
        public string MENU_CONTROLLERNAME { get; set; }
        public string MENU_ACTION_NAME { get; set; }
        public string MENU_AREA_NAME { get; set; }
        public string MENU_ROLE { get; set; }
        public bool MENU_ACTIVE { get; set; }
        public System.DateTime MENU_CREATED { get; set; }
        public System.DateTime MENU_UPDATE { get; set; }
        public MenuMaster() { }

        public static int DeleteMenuMaster(MenuMaster m)
        {
            int result = 1;
            List<MenuMaster> menuMasters = MenuMaster.GetMenuMasterForDataSource();
            menuMasters.RemoveAll(x => x.MENU_CODE == m.MENU_CODE);
            SaveMenuMasterFromList(menuMasters);
            return result;
        }

        public static int UpdateMenuMaster(MenuMaster m)
        {
            int result = 1;
            List<MenuMaster> m_ = MenuMaster.GetMenuMasterForDataSource();
            m_.RemoveAll(x => x.MENU_CODE == m.MENU_CODE);
            m_.Insert(0, m);
            SaveMenuMasterFromList(m_);
            return result;
        }

        public static int SaveMenuMasterFromList(List<MenuMaster> m)
        {
            int result = 1;
            //List<MenuMaster> menuMasters = m;
            //string directoryname = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"wwwroot\App_Data\Menu");
            //string emat_setting_txt = "menumaster.json";
            //string GuarnteedWritePath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            //try
            //{
            //    using (System.IO.StreamWriter stream = new System.IO.StreamWriter(System.IO.Path.Combine(GuarnteedWritePath, directoryname, emat_setting_txt), false))
            //    {
            //        stream.Write(Newtonsoft.Json.JsonConvert.SerializeObject(menuMasters));
            //        stream.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine(ex.Message);
            //}
            return result;
        }

        public static int DeleteMenuMaster()
        {
            int return_ = 0;
            using (DataAccess.Oracle db = new DataAccess.Oracle())
            {
                try
                {
                    db.Open();
                    db.CommandText = "DELETE FROM IHUB_MENUMASTER";
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

        public static int DeleteMenuMaster_Item(string menu_code)
        {
            int return_ = 0;
            using (DataAccess.Oracle db = new DataAccess.Oracle())
            {
                try
                {
                    db.Open();
                    db.CommandText = "DELETE FROM IHUB_MENUMASTER WHERE MENU_CODE=:CODE";
                    db.AddParameter(":CODE", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2,menu_code);
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

        public static int SaveMenuMaster(MenuMaster m)
        {
            int return_ = 0;
            using (DataAccess.Oracle db = new DataAccess.Oracle())
            {
                try
                {
                    db.Open();
                    db.CommandText = "INSERT INTO IHUB_MENUMASTER (MENU_NAME, MENU_PARENT, MENU_IMG, MENU_CODE, MENU_LEVEL, MENU_MLM, MENU_CONTROLLERNAME, MENU_ACTION_NAME, MENU_AREA_NAME, MENU_ROLE, MENU_ACTIVE)VALUES(:MENU_NAME, :MENU_PARENT, :MENU_IMG, :MENU_CODE, :MENU_LEVEL, :MENU_MLM, :MENU_CONTROLLERNAME, :MENU_ACTION_NAME, :MENU_AREA_NAME, :MENU_ROLE, :MENU_ACTIVE)";
                    // db.CommandText = "INSERT INTO IHUB_MENUMASTER ('NLE ITGR REPOST', 'XX', 'fas fa-table', 'NleRepost', 'CHILD', 'gTbl#', 'NleRepos', 'Index', 'GeneralTable', '#rDev', 1)";
                    db.AddParameter(":MENU_NAME", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2,m.MENU_NAME);
                    db.AddParameter(":MENU_PARENT", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2,m.MENU_PARENT);
                    db.AddParameter(":MENU_IMG", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2,m.MENU_IMG);
                    db.AddParameter(":MENU_CODE", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2,m.MENU_CODE);
                    db.AddParameter(":MENU_LEVEL", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, m.MENU_LEVEL);
                    db.AddParameter(":MENU_MLM", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2,m.MENU_MLM);
                    db.AddParameter(":MENU_CONTROLLERNAME", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, m.MENU_CONTROLLERNAME);
                    db.AddParameter(":MENU_ACTION_NAME", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, m.MENU_ACTION_NAME);
                    db.AddParameter(":MENU_AREA_NAME", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2,m.MENU_AREA_NAME);
                    db.AddParameter(":MENU_ROLE", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, m.MENU_ROLE);
                    db.AddParameter(":MENU_ACTIVE", Oracle.ManagedDataAccess.Client.OracleDbType.Int16,m.MENU_ACTIVE?1:0);
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

        public static bool IsKodeExist(string Kode)
        {
            bool return_ = false;
            List<MenuMaster> menuMasters = MenuMaster.GetMenuMasterForDataSource();
            return_ = menuMasters.Find(r => r.MENU_CODE == Kode) == null ? false : true;
            return return_;
        }

        public static List<MenuMaster> GetMenuMasterForDataSource()
        {
            List<MenuMaster> L = new List<MenuMaster>();
            using (DataAccess.SQLServer db = new DataAccess.SQLServer())
            {
                db.CommandText = "SELECT ID, MENU_NAME, MENU_PARENT, MENU_IMG, MENU_CODE, MENU_LEVEL, MENU_MLM, MENU_CONTROLLERNAME, MENU_ACTION_NAME, MENU_AREA_NAME, MENU_ROLE, MENU_ACTIVE, MENU_CREATED, MENU_UPDATE FROM Uniflex_Menu";
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (System.Data.SqlClient.SqlDataReader rdr = db.DbDataReader as System.Data.SqlClient.SqlDataReader)
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            MenuMaster i = new MenuMaster
                            {
                                ID = Helper.GeneralHelper.NullToInt(rdr["ID"], 0),
                                MENU_ACTION_NAME = rdr["MENU_ACTION_NAME"].ToString(),
                                MENU_ACTIVE = Helper.GeneralHelper.NullToBool(rdr["MENU_ACTIVE"],false),
                                MENU_AREA_NAME = rdr["MENU_AREA_NAME"].ToString(),
                                MENU_CODE = rdr["MENU_CODE"].ToString(),
                                MENU_CONTROLLERNAME = rdr["MENU_CONTROLLERNAME"].ToString(),
                                MENU_CREATED = Helper.GeneralHelper.NullToDateTime(rdr["MENU_CREATED"], System.DateTime.Now),
                                MENU_IMG = rdr["MENU_IMG"].ToString(),
                                MENU_LEVEL = rdr["MENU_LEVEL"].ToString(),
                                MENU_MLM = rdr["MENU_MLM"].ToString(),
                                MENU_NAME = rdr["MENU_NAME"].ToString(),
                                MENU_PARENT = rdr["MENU_PARENT"].ToString(),
                                MENU_ROLE = rdr["MENU_ROLE"].ToString(),
                                MENU_UPDATE = Helper.GeneralHelper.NullToDateTime(rdr["MENU_UPDATE"], System.DateTime.Now)
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

        public static string Chil_Count(string mlmKode) {
            string return_ = "";
            using (DataAccess.SQLServer db = new DataAccess.SQLServer())
            {
                db.CommandText = "SELECT Count(*) AS c FROM Uniflex_Menu WHERE MENU_MLM LIKE '%"+mlmKode.Trim().ToLower()+"%'";
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (System.Data.SqlClient.SqlDataReader rdr = db.DbDataReader as System.Data.SqlClient.SqlDataReader)
                {
                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        return_ = rdr["c"].ToString();
                    }
                    if (!rdr.IsClosed) rdr.Close();
                }
                db.Close();
            }
            return return_;       
        }

        public static List<MenuMaster> GetMenuMasterForRealView()
        {
            List<MenuMaster> menuMasters = MenuMaster.GetMenuMasterForDataSource();
            var allCorrect = menuMasters.Where(a => a.MENU_ACTIVE == bool.Parse("true")).ToList();
            return allCorrect;
        }

        public static MenuMaster GetMenuMasterForDataSource(string m)
        {
            List<MenuMaster> menuMasters = MenuMaster.GetMenuMasterForDataSource();
            MenuMaster l = new MenuMaster();
            var b = menuMasters.Where(a => a.MENU_CODE == m).FirstOrDefault();
            return b;
        }

        //public void Create_Initial()
        //{
        //    string directoryname = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"wwwroot\App_Data\Menu");
        //    string emat_setting_txt = "menumaster.json";
        //    string GuarnteedWritePath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        //    if (!System.IO.Directory.Exists(System.IO.Path.Combine(GuarnteedWritePath, directoryname)))
        //    {
        //        System.IO.Directory.CreateDirectory(System.IO.Path.Combine(GuarnteedWritePath, directoryname));
        //    }

        //    string FilePath = System.IO.Path.Combine(GuarnteedWritePath, directoryname, emat_setting_txt);
        //    if (!System.IO.File.Exists(FilePath))
        //    {
        //        List<MenuMaster> e = MenuMaster.UsersForDataSource_First();
        //        using (System.IO.FileStream fs = System.IO.File.Create(FilePath))
        //        {
        //            string dataasstring = Newtonsoft.Json.JsonConvert.SerializeObject(e); //your data
        //            byte[] info = new System.Text.UTF8Encoding(true).GetBytes(dataasstring);
        //            fs.Write(info, 0, info.Length);
        //            fs.Close();
        //        }
        //    }
        //}

        //public static List<MenuMaster> UsersForDataSource_First()
        //{
        //    List<MenuMaster> d = new List<MenuMaster>();
        //    d.Add(new MenuMaster { id = 0, Nama = "General Table", Kode = "mGT", Img = "nav-icon fas fa-table", Created = System.DateTime.Now, Update = System.DateTime.Now, Role = "rDev", Active = true });
        //    d.Add(new MenuMaster { id = 1, Nama = "Document Api", Kode = "mDA", Img = "nav-icon fas fa-globe", Created = System.DateTime.Now, Update = System.DateTime.Now, Role = "rDev#rAdmin#rUser",Active = true });
        //    d.Add(new MenuMaster { id = 2, Nama = "Maintenance", Kode = "mMT", Img = "nav-icon fas fa-columns", Created = System.DateTime.Now, Update = System.DateTime.Now, Role = "rDev",Active = true });
        //    return d;
        //}
    }
}
