using Chester_it21;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.IO;

namespace I_HUB.Helper
{
    public class DatabaseFactory
    {
        public static IDbConnection GetConnection(string name = "default")
        {
            Chester chester = new Chester();
            var connectionString = "";
            var connectionStringEncrypted = ConfigurationFactory.GetConfiguration("ConnectionStrings", name);
            connectionString = chester.Decrypt(connectionStringEncrypted);

            var conn = new OracleConnection(connectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            return conn;
        }

      
    }
}
