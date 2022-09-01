using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace I_HUB.Areas.Maintenance.Controllers
{
    public class MenuMasterController : Controller
    {

        [Area("Maintenance")]
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(Helper.GlobalVariable.SESSION_USER_ID)))
                return RedirectToAction("Index", "login");

            ViewBag.UserId = HttpContext.Session.GetString(Helper.GlobalVariable.SESSION_USER_NAME);
            ViewBag.UserMenu = new I_HUB.Maintenance.MenuTreeview().Get_Access_Menu(HttpContext.Session.GetString(Helper.GlobalVariable.SESSION_USER_ROLE));
            return View();
        }

        [HttpPost]
        public JsonResult GetDataChild()
        {
            JsonResult result = null;
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int totalRecords = 0; // Total keseluruhan data
                int totalRecordsShowing = 0; // Total data setelah filter / search
                List<I_HUB.Maintenance.MenuMaster> SSP = I_HUB.Maintenance.MenuMaster.GetMenuMasterForDataSource();

                totalRecords = SSP.Count;

                // Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    switch (sortColumn.ToLower())
                    {
                        default:
                            SSP = SSP.OrderBy(o=>o.MENU_LEVEL).ToList();
                            break;
                    }
                }

                if (!string.IsNullOrEmpty(searchValue))
                {
                    string searchValueLower = searchValue.ToLower();
                    SSP = SSP.Where(x => x.MENU_CODE.ToString().ToLower().Contains(searchValueLower) || x.MENU_NAME.ToString().Contains(searchValueLower)).ToList();
                }

                totalRecordsShowing = SSP.Count();

                // Paging
                SSP = SSP.Skip(skip).Take(pageSize).ToList();

                // Returning Json Data
                result = this.Json(new { recordsFiltered = totalRecordsShowing, recordsTotal = totalRecords, data = SSP }, new Newtonsoft.Json.JsonSerializerSettings());

            }
            catch (Exception er)
            {
                System.Diagnostics.Debug.WriteLine(er.Message);
            }
            return result;
        }

        [HttpPost]
        public JsonResult GetDataMaster()
        {
            JsonResult result = null;
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int totalRecords = 0; // Total keseluruhan data
                int totalRecordsShowing = 0; // Total data setelah filter / search
                List<I_HUB.Maintenance.MenuMaster> SSP = I_HUB.Maintenance.MenuMaster.GetMenuMasterForDataSource();

                totalRecords = SSP.Count;

                // Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    switch (sortColumn.ToLower())
                    {
                        default:
                            SSP = SSP.OrderBy(o=>o.MENU_NAME).ToList();
                            break;
                    }
                }

                if (!string.IsNullOrEmpty(searchValue))
                {
                    string searchValueLower = searchValue.ToLower();
                    SSP = SSP.Where(x => x.MENU_CODE.ToString().ToLower().Contains(searchValueLower) || x.MENU_NAME.ToString().Contains(searchValueLower)).ToList();
                }

                totalRecordsShowing = SSP.Count();

                // Paging
                SSP = SSP.Skip(skip).Take(pageSize).ToList();

                // Returning Json Data
                result = this.Json(new { recordsFiltered = totalRecordsShowing, recordsTotal = totalRecords, data = SSP }, new Newtonsoft.Json.JsonSerializerSettings());

            }
            catch (Exception er)
            {
                System.Diagnostics.Debug.WriteLine(er.Message);
            }
            return result;
        }

        [HttpPost]
        public JsonResult CreateMaster(string MenuName,string MenuKode,string MenuImg,List<string> MenuRole)
        {
            object o = new { status = "error", msg = "Initialized!" };
            List<I_HUB.Maintenance.MenuMaster> m = I_HUB.Maintenance.MenuMaster.GetMenuMasterForDataSource();
            var null__ = m.Where(a => a.MENU_CODE.ToLower() == MenuKode.ToLower()).FirstOrDefault();
            if (null__!=null)
            {
                object error_ = new { status = "error", msg = "Kode " + MenuKode + " Already Exists!" };
                return Json(error_, new Newtonsoft.Json.JsonSerializerSettings());
            }

            string RoleNya = "";
            if (MenuRole.Count>0)
            {
                RoleNya=MenuRole[0].Replace(",", "#");
            }
           
            if (string.IsNullOrEmpty(RoleNya.ToString()))
            {
                object error_ = new { status = "error", msg = "Role is Empty!" };
                return Json(error_, new Newtonsoft.Json.JsonSerializerSettings());
            }

            System.Diagnostics.Debug.WriteLine(RoleNya);

            I_HUB.Maintenance.MenuMaster mMaster = new I_HUB.Maintenance.MenuMaster
            {
                MENU_CODE = MenuKode,
                ID = 0,
                MENU_ACTION_NAME = "XXX",
                MENU_ACTIVE = true,
                MENU_AREA_NAME = "XXX",
                MENU_CONTROLLERNAME = "XXX",
                MENU_CREATED =System.DateTime.Now,
                MENU_IMG = MenuImg,
                MENU_LEVEL = "MASTER",
                MENU_MLM = "#",
                MENU_NAME = MenuName,
                MENU_PARENT = "ZZZZ",
                MENU_ROLE =RoleNya,
                MENU_UPDATE = System.DateTime.Now
            };
            try {
                if (I_HUB.Maintenance.MenuMaster.SaveMenuMaster(mMaster) > 0) {
                    object sukses_ = new { status = "success", msg = "Data Hasbeen Saved!" };
                    return Json(sukses_, new Newtonsoft.Json.JsonSerializerSettings());
                }
                else
                {
                    object error_ = new { status = "error", msg ="Cant Be Save Data" };
                    return Json(error_, new Newtonsoft.Json.JsonSerializerSettings());
                }
              
            }
            catch (Exception e)
            {
                object error_ = new { status = "error", msg = e.Message };
                return Json(error_, new Newtonsoft.Json.JsonSerializerSettings());
            }
            return Json(o, new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]
        public JsonResult CreateChild([FromBody]I_HUB.Maintenance.Post_Menu_Params S)
        {
            object o = new { status = "error", msg = "IniTialized!" };

            List<I_HUB.Maintenance.MenuMaster> m = I_HUB.Maintenance.MenuMaster.GetMenuMasterForDataSource();
            var null__ = m.Where(a => a.MENU_CODE.ToLower() == S.Kode).FirstOrDefault();
            if (null__ != null)
            {
                object error_ = new { status = "error", msg = "Kode " + S.Kode + " Already Exists!" };
                return Json(error_, new Newtonsoft.Json.JsonSerializerSettings());
            }

            var AreaEEEEEE =""+ S.Area[0].ToString().Replace(",","#")+"#";
            if (string.IsNullOrEmpty(AreaEEEEEE))
            {
                object error_ = new { status = "error", msg = "Area Is Null!" };
                return Json(error_, new Newtonsoft.Json.JsonSerializerSettings());
            }

            // Checking Role
            var Role = S.Role[0].ToString().Replace(",", "#");
            if (string.IsNullOrEmpty(Role))
            {
                object error_ = new { status = "error", msg = "Role Is Null!" };
                return Json(error_, new Newtonsoft.Json.JsonSerializerSettings());
            }

            if (!Role.ToString().Contains("#"))
            {
                Role = "#" + Role;
            }


            I_HUB.Maintenance.MenuMaster menuMaster = new I_HUB.Maintenance.MenuMaster
            {
                ID = 0,
                MENU_ACTION_NAME = S.ActionName,
                MENU_ACTIVE = true,
                MENU_AREA_NAME = AreaEEEEEE,
                MENU_CODE = S.Kode,
                MENU_CONTROLLERNAME = S.ControllerName,
                MENU_CREATED = System.DateTime.Now,
                MENU_IMG = "fas fa-circle",
                MENU_LEVEL = "CHILD",
                MENU_MLM = S.MenuMlm,
                MENU_NAME = S.Nama,
                MENU_PARENT = "XX",
                MENU_ROLE = Role,
                MENU_UPDATE =System.DateTime.Now
            };

            int ret = I_HUB.Maintenance.MenuMaster.SaveMenuMaster(menuMaster);
            if (ret > 0)
            {
                o = new { status = "success", msg = "Kode " + S.Kode + " Hasbeen Saved" };
                return Json(o, new Newtonsoft.Json.JsonSerializerSettings());
            }

            return Json(o, new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]
        public JsonResult DeleteMaster(string kode)
        {
            object o = new { status = "error" };
            I_HUB.Maintenance.MenuMaster menuMaster = I_HUB.Maintenance.MenuMaster.GetMenuMasterForDataSource(kode);
            int ret = I_HUB.Maintenance.MenuMaster.DeleteMenuMaster(menuMaster);
            if (ret > 0)
            {
                o = new { status = "success" };
                return Json(o, new Newtonsoft.Json.JsonSerializerSettings());
            }
            return Json(o, new Newtonsoft.Json.JsonSerializerSettings());
        }

        public JsonResult DeleteChild(string kode)
        {
            object o = new { status = "error" };
            if (I_HUB.Maintenance.MenuMaster.DeleteMenuMaster_Item(kode)>0)
            {
                o = new { status = "success" };
                return Json(o, new Newtonsoft.Json.JsonSerializerSettings());
            }
            return Json(o, new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]
        public JsonResult GetList()
        {
            object o = new { status = "error" };
            List<dynamic> kodemaster = new List<dynamic>();
            List<I_HUB.Maintenance.MenuMaster> menuMaster = I_HUB.Maintenance.MenuMaster.GetMenuMasterForDataSource();
            foreach (var x in menuMaster)
            {
                var masteritem = new { Id = x.MENU_CODE, Name = x.MENU_NAME + " - " + x.MENU_CODE };
                kodemaster.Add(masteritem);
            }

            List<dynamic> kodechild = new List<dynamic>();
            List<I_HUB.Maintenance.MenuChild> mc = I_HUB.Maintenance.MenuChild.menuChildrenForDataSource();
            foreach (var x in mc)
            {
                var masteritem = new { mlm = x.mlm, Name = x.Nama + " - " + x.mlm };
                kodechild.Add(masteritem);
            }

            List<dynamic> Rolee = new List<dynamic>();
            List<I_HUB.Maintenance.UsersRoles> roleNya = I_HUB.Maintenance.UsersRoles.RolesForDataSource();
            foreach (var x in roleNya)
            {
                var Roleitem = new { roleName = x.RoleName, roleID = x.RoleId };
                Rolee.Add(Roleitem);
            }

            List<dynamic> ImgIcon = new List<dynamic>();
            List<I_HUB.Maintenance.FaIcons> faNya = I_HUB.Maintenance.FaIcons.GetForDataSource();
            foreach (var x in faNya)
            {
                var ImgIconitem = new { kode = x.kode, nama = x.nama };
                ImgIcon.Add(ImgIconitem);
            }

            o = new { status = "sukses", master = kodemaster, child = kodechild, role = Rolee, icon = ImgIcon };

            return Json(o, new Newtonsoft.Json.JsonSerializerSettings());
        }

        public JsonResult GetListArea()
        {
            JsonResult return_ = null;

            List<dynamic> area_ = new List<dynamic>();
            List<I_HUB.Maintenance.MenuMaster> menuMaster = I_HUB.Maintenance.MenuMaster.GetMenuMasterForDataSource();

            var MS = menuMaster
                    .Select(std => std.MENU_AREA_NAME)
                    .Distinct().ToList();
            
            foreach (var x in MS)
            {
                var Area_item = new { Id = x, Name = x};
                area_.Add(Area_item);
            }

            List<dynamic> ROLE_ = new List<dynamic>();
            List<I_HUB.Maintenance.UsersRoles> rol = I_HUB.Maintenance.UsersRoles.RolesForDataSource();
            foreach (var x in rol)
            {
                var Role_item = new { Idx = x.RoleId, Namex = x.RoleName };
                ROLE_.Add(Role_item);
            }


            object o = new { status = "sukses",area= area_,role=ROLE_ };
            return Json(o, new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}
