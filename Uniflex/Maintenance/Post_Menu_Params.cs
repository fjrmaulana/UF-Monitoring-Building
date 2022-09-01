using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I_HUB.Maintenance
{
    public class Post_Menu_Params
    {
        public string Nama { get; set; }
        public string MenuMlm { get; set; }
        public string Kode { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public List<string> Area { get; set; }
        public List<string> Role { get; set; }
        public Post_Menu_Params()
        {

        }
    }
}


