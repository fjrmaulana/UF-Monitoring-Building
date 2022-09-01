using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I_HUB.Maintenance
{
    public class FaIcons
    {
        public string kode { get; set; }
        public string nama { get; set; }
        //public string fas_fa_circle { get; set; }
        //public string far_fa_circle { get; set; }
        //public string fas_fa_box { get; set; }
        public FaIcons()
        {

        }

        public static List<FaIcons> GetForDataSource()
        {
            List<FaIcons> l = new List<FaIcons>();
            l.Add(new FaIcons { kode = "fas fa-circle", nama = "fas fa-circle" });
            l.Add(new FaIcons { kode = "far fa-circle", nama = "far fa-circle" });
            l.Add(new FaIcons { kode = "fas fa-box", nama = "fas fa-box" });
            l.Add(new FaIcons { kode = "fas fa-th", nama = "fas fa-th" });
            l.Add(new FaIcons { kode = "fas fa-copy", nama = "fas fa-copy" });
            l.Add(new FaIcons { kode = "fas fa-chart_pie", nama = "fas fa-chart-pie" });
            l.Add(new FaIcons { kode = "fas fa-tree", nama = "fas fa-tree" });
            l.Add(new FaIcons { kode = "fas fa-edit", nama = "fas fa-edit" });
            l.Add(new FaIcons { kode = "fas fa-table", nama = "fas fa-table" });
            l.Add(new FaIcons { kode = "far fa-calendar_alt", nama = "far fa-calendar-alt" });
            l.Add(new FaIcons { kode = "far fa-image", nama = "far fa-image" });
            l.Add(new FaIcons { kode = "fas fa-columns", nama = "fas fa-columns" });
            l.Add(new FaIcons { kode = "far fa-envelope", nama = "far fa-envelope" });
            l.Add(new FaIcons { kode = "fas fa-book", nama = "fas fa-book" });
            l.Add(new FaIcons { kode = "far fa-plus-square", nama = "far fa-plus-square" });
            l.Add(new FaIcons { kode = "fas fa-search", nama = "fas fa-search" });
            return l;
        }

        //public static List<Dictionary<string, string>> GetForDataSource()
        //{
        //    List<Dictionary<string, string>> l = new List<Dictionary<string, string>>();
        //    Dictionary<string, string> dicNumber = new Dictionary<string, string>();
        //    dicNumber.Add("fas_fa_circle", "fas fa-circle");
        //    dicNumber.Add("far_fa_circle", "far fa-circle");
        //    dicNumber.Add("fas_fa_box", "fas fa-box");
        //    l.Add(dicNumber);
        //    return l;
        //}
        /*
         using Newtonsoft.Json;
List<Dictionary<string, string>> testDictionary = new List<Dictionary<string, string>()>();
string json = JsonConvert.SerializeObject(testDictionary);
         */
    }
}
