using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I_HUB.Maintenance
{
    public class MenuChild
    {
        public int id { get; set; }
        public string Nama { get; set; }
        public string Parent { get; set; }
        public string Img { get; set; }
        public string Kode { get; set; }
        public string mlm { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string AreaName { get; set; }
        public string Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime Update { get; set; }
        public MenuChild() { }

        public static int GetCountChild(string s)
        {
            List<MenuChild> menuChildren = MenuChild.menuChildrenForDataSource();
            int count = (from item in menuChildren
                         where item.mlm.Contains(s)
                         select item).Count();
            return count;
        }

        public static bool IsKodeExist(string Kode)
        {
            List<MenuChild> menuChildren = MenuChild.menuChildrenForDataSource();
            return menuChildren.Find(r => r.Kode == Kode) == null ? false : true;
        }
        public static List<MenuChild> GetManuChildFromMenuMaster(string menumasterkode)
        {
            List<MenuChild> menuChildren = MenuChild.menuChildrenForDataSource();
            var allCorrect = menuChildren.Where(a => a.Parent == menumasterkode).ToList();
            return allCorrect;
        }
        public static List<MenuChild> menuChildrenForDataSource()
        {
            List<MenuChild> menuChildren = new List<MenuChild>();
            string directoryname = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"wwwroot\App_Data\Menu");
            string emat_setting_txt = "menuchild.json";

            string jsontext = System.IO.File.ReadAllText(System.IO.Path.Combine(directoryname, emat_setting_txt));
            menuChildren = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MenuChild>>(jsontext);
            return menuChildren;
        }

        public static MenuChild menuChildrenForDataSource(string m)
        {
            List<MenuChild> menuMasters = MenuChild.menuChildrenForDataSource();
            var b = menuMasters.Where(a => a.Kode == m).FirstOrDefault();
            return b;
        }

        public static int DeleteMenuChild(MenuChild m)
        {
            int result = 1;
            List<MenuChild> menuMasters = MenuChild.menuChildrenForDataSource();
            menuMasters.RemoveAll(x => x.Kode == m.Kode);
            SaveMenuChildFromList(menuMasters);
            return result;
        }
        public static int UpdateMenuChild(MenuChild m)
        {
            int result = 1;
            List<MenuChild> menuMasters = MenuChild.menuChildrenForDataSource();
            menuMasters.RemoveAll(x => x.Kode == m.Kode);
            menuMasters.Insert(0, m);
            SaveMenuChildFromList(menuMasters);
            return result;
        }
        public static int SaveMenuChildFromList(List<MenuChild> m)
        {
            int result = 1;
            List<MenuChild> menuMasters = m;
            string directoryname = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"wwwroot\App_Data\Menu");
            string emat_setting_txt = "menuchild.json";
            string GuarnteedWritePath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            try
            {
                using (System.IO.StreamWriter stream = new System.IO.StreamWriter(System.IO.Path.Combine(GuarnteedWritePath, directoryname, emat_setting_txt), false))
                {
                    stream.Write(Newtonsoft.Json.JsonConvert.SerializeObject(menuMasters));
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return result;
        }
        public static int SaveMenuChild(MenuChild m)
        {
            int result = 1;
            List<MenuChild> menuMasters = MenuChild.menuChildrenForDataSource();
            menuMasters.Insert(0, m);
            string directoryname = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"wwwroot\App_Data\Menu");
            string emat_setting_txt = "menuchild.json";
            string GuarnteedWritePath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            try
            {
                using (System.IO.StreamWriter stream = new System.IO.StreamWriter(System.IO.Path.Combine(GuarnteedWritePath, directoryname, emat_setting_txt), false))
                {
                    stream.Write(Newtonsoft.Json.JsonConvert.SerializeObject(menuMasters));
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return result;
        }

        public void Create_Initial()
        {
            string directoryname =  System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"wwwroot\App_Data\Menu");
            string emat_setting_txt = "menuchild.json";
            string GuarnteedWritePath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!System.IO.Directory.Exists(System.IO.Path.Combine(GuarnteedWritePath, directoryname)))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(GuarnteedWritePath, directoryname));
            }

            string FilePath = System.IO.Path.Combine(GuarnteedWritePath, directoryname, emat_setting_txt);
            if (!System.IO.File.Exists(FilePath))
            {
                List<MenuChild> e = MenuChild.UsersForDataSource_First();
                using (System.IO.FileStream fs = System.IO.File.Create(FilePath))
                {
                    string dataasstring = Newtonsoft.Json.JsonConvert.SerializeObject(e); //your data
                    byte[] info = new System.Text.UTF8Encoding(true).GetBytes(dataasstring);
                    fs.Write(info, 0, info.Length);
                    fs.Close();
                }
            }
        }

        public static List<MenuChild> UsersForDataSource_First()
        {
            List<MenuChild> d = new List<MenuChild>();
            d.Add(new MenuChild {id=0, Nama="Swagger IBS UNICORN", Parent="mDA", Img="fas fa-circle", Kode = "Swg", mlm = "mDA#", ControllerName = "SwaggerUnicorn", ActionName = "Index", AreaName="DocumentApi", Role= "Admin", Created = System.DateTime.Now, Update = System.DateTime.Now });
            d.Add(new MenuChild {  id = 1, Nama = "Company",Parent = "mGT", Img = "fas fa-circle", Kode = "cmpy1", mlm = "mGT#", ControllerName = "Company", ActionName= "Index", AreaName= "GeneralTable", Role = "Admin", Created = System.DateTime.Now, Update = System.DateTime.Now });
            d.Add(new MenuChild { id = 2, Nama = "Employee",Parent = "mGT", Img = "fas fa-circle", Kode = "emp1", mlm = "mGT#", ControllerName = "Employee", ActionName = "Index", AreaName= "GeneralTable", Role = "Admin", Created = System.DateTime.Now, Update = System.DateTime.Now });
            d.Add(new MenuChild { id = 3,Nama = "NLE (save booking h2h)", Parent = "mDA", Img = "fas fa-circle", Kode = "nle1", mlm = "mDA#", ControllerName = "NLE", ActionName = "Index", AreaName= "DocumentApi", Role = "Admin", Created = System.DateTime.Now, Update = System.DateTime.Now });
            d.Add(new MenuChild { id = 4,Nama = "Menu Master", Parent = "mMT", Img = "fas fa-circle", Kode = "mm1", mlm = "mMT#", ControllerName = "MenuMaster", ActionName = "Index", AreaName= "Maintenance", Role = "Admin", Created = System.DateTime.Now, Update= System.DateTime.Now });
            return d;
        }

    }
}
