using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I_HUB.Maintenance
{
    public class UsersRoles
    {
        public UsersRoles()
        {

        }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool RoleStatus { get; set; }
     

        public static List<UsersRoles> RolesForDataSource()
        {
            List<UsersRoles> L = new List<UsersRoles>();
            using (DataAccess.Oracle db = new DataAccess.Oracle())
            {
                db.CommandText = "SELECT RoleId,RoleName,RoleStatus FROM IHUB_USER_ROLE";
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (Oracle.ManagedDataAccess.Client.OracleDataReader rdr = db.DbDataReader as Oracle.ManagedDataAccess.Client.OracleDataReader)
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            UsersRoles i = new UsersRoles
                            {
                                 RoleId= rdr["RoleId"].ToString(),
                                RoleName = rdr["RoleName"].ToString(),
                                RoleStatus = rdr["RoleStatus"].ToString().Equals("1") ? true : false
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
    }
}

/*
 CREATE TABLE Uniflex_Role (
RoleId VARCHAR(500) NOT NULL PRIMARY KEY,
RoleName VARCHAR(100) NOT NULL,
RoleStatus bit NOT NULL default 1
);
 
 */
