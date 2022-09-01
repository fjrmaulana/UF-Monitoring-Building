using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace I_HUB.Helper
{
    public class ConfigurationFactory
    {
        public static string GetConfiguration(string parent,string key)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");

            IConfiguration Configuration = builder.Build();

            var conf = Configuration.GetSection(parent).GetSection(key).Value;

            return conf;
        }
    }
}
