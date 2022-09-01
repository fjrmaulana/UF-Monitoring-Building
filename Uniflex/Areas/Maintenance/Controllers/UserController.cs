using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace I_HUB.Areas.Maintenance.Controllers
{
    public class UserController : Controller
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

        public JsonResult GetUser()
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
                List<I_HUB.Maintenance.Users> SSP = I_HUB.Maintenance.Users.UsersForDataSource();

                totalRecords = SSP.Count;

                // Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    switch (sortColumn.ToLower())
                    {
                        default:
                            SSP = SSP.OrderBy(o => o.USER_FULLNAME).ToList();
                            break;
                    }
                }

                if (!string.IsNullOrEmpty(searchValue))
                {
                    string searchValueLower = searchValue.ToLower();
                    SSP = SSP.Where(x => x.USER_FULLNAME.ToString().ToLower().Contains(searchValueLower) || x.USER_ID.ToString().Contains(searchValueLower)).ToList();
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
        public JsonResult GetDetailData(string userid)
        {
            JsonResult resulta = null;
            I_HUB.Maintenance.Users users = I_HUB.Maintenance.Users.GetUserItemFrom_id(userid);
            if (users != null)
            {
                var dec1 = new Helper.clsCryptho().Decrypt(users.USER_PASS, "@Pelindo");
                var dec2 = new Helper.clsCryptho().Decrypt(dec1, "@Pelindo");
                I_HUB.Maintenance.Users users1 = new I_HUB.Maintenance.Users
                {
                    USER_PASS = dec2,
                    USER_ID = users.USER_ID,
                    USER_TOKEN_TRX = users.USER_TOKEN_TRX,
                    USER_UPDATE = users.USER_UPDATE,
                    USER_TOKEN_EMAIL_KONFIRM = users.USER_TOKEN_EMAIL_KONFIRM,
                    USER_TOKEN_EMAIL = users.USER_TOKEN_EMAIL,
                    USER_ROLE = users.USER_ROLE,
                    USER_ORG = users.USER_ORG,
                    ENTRY_DATE = users.ENTRY_DATE,
                    ID = users.ID,
                    TRX_COUNT = users.TRX_COUNT,
                    USER_ACTIVE =users.USER_ACTIVE,
                    USER_EMAIL = users.USER_EMAIL,
                    USER_ENTRY = users.USER_ENTRY,
                    USER_EXP = users.USER_EXP,
                    USER_FULLNAME = users.USER_FULLNAME,
                    USER_JOINT = users.USER_JOINT
                };

                System.Collections.Specialized.ListDictionary list = new System.Collections.Specialized.ListDictionary();
                List<I_HUB.Maintenance.UsersRoles> u = I_HUB.Maintenance.UsersRoles.RolesForDataSource();
                foreach (var i in u)
                {
                    list.Add(i.RoleId, i.RoleName);
                }

                object o = new { status = "success", data = users1,role=u };
                return Json(o, new Newtonsoft.Json.JsonSerializerSettings());
            }
            else
            {
                object o = new { status = "error", data = ""};
                return Json(o, new Newtonsoft.Json.JsonSerializerSettings());
            }
            return resulta;
        }

        public JsonResult UpdateUser([FromBody]I_HUB.Maintenance.Users u) {

            I_HUB.Maintenance.Users users1 = new I_HUB.Maintenance.Users
            {
                USER_ID = u.USER_ID,
                USER_TOKEN_TRX = u.USER_TOKEN_TRX,
                USER_UPDATE = u.USER_UPDATE,
                USER_TOKEN_EMAIL_KONFIRM = u.USER_TOKEN_EMAIL_KONFIRM,
                USER_TOKEN_EMAIL = u.USER_TOKEN_EMAIL,
                USER_ROLE = u.USER_ROLE,
                USER_ORG = u.USER_ORG,
                ENTRY_DATE = u.ENTRY_DATE,
                TRX_COUNT = u.TRX_COUNT,
                ID = u.ID,
                USER_ACTIVE = u.USER_ACTIVE,
                USER_EMAIL = u.USER_EMAIL,
                USER_ENTRY = u.USER_ENTRY,
                USER_EXP = u.USER_EXP,
                USER_FULLNAME = u.USER_FULLNAME,
                USER_JOINT = u.USER_JOINT,
                USER_PASS = new Helper.clsCryptho().Encrypt(new Helper.clsCryptho().Encrypt(u.USER_PASS, "@Pelindo"), "@Pelindo")
            };

            object o = new { status = "error", data = "" };
            try {
                List<I_HUB.Maintenance.Users> users = I_HUB.Maintenance.Users.UsersForDataSource();
                users.RemoveAll(x => x.USER_ID == users1.USER_ID);
                users.Insert(0, users1);
                I_HUB.Maintenance.Users.SaveAllUsers(users);
                o = new { status = "success", data =""};
                return Json(o, new JsonSerializerSettings());
            }
            catch (Exception ex)
            {
                o = new { status = "error", data = ex.Message};
                return Json(o, new JsonSerializerSettings());
            }
            return Json(o, new JsonSerializerSettings());
        }

        [HttpPost]
        public JsonResult GetRoleList()
        {
            JsonResult return_= null;
            try
            {
                System.Collections.Specialized.ListDictionary list = new System.Collections.Specialized.ListDictionary();
                List<I_HUB.Maintenance.UsersRoles> u = I_HUB.Maintenance.UsersRoles.RolesForDataSource();
                foreach (var i in u)
                {
                    list.Add(i.RoleId, i.RoleName);
                }

                var token_ = "PLD" + "-" + System.DateTime.Now.ToString("yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture)+"-"+Helper.GeneralHelper.RandomString(8).ToUpper();

                object o = new { status = "success",  role = u,token=token_ };
                return Json(o, new Newtonsoft.Json.JsonSerializerSettings());
            }
            catch (Exception ex)
            {
                object o = new { status = "error", data = "" };
                return Json(o, new Newtonsoft.Json.JsonSerializerSettings());
            }
            return return_;
        }

       
        //public JsonResult AddlUser([FromBody] I_HUB.Maintenance.Post_User_Params u)
        //{
        //    I_HUB.Maintenance.Users NewUser = new I_HUB.Maintenance.Users
        //    {
        //        USER_ACTIVE = u.Active,
        //        USER_ENTRY = HttpContext.Session.GetString(Helper.GlobalVariable.SESSION_USER_NAME).ToString(),
        //        TRX_COUNT =0,
        //        USER_ORG = u.org,
        //        USER_ROLE = u.UserRolesId[0].ToString().Replace("#",""),
        //        USER_TOKEN_EMAIL_KONFIRM = 1,
        //        USER_TOKEN_EMAIL ="xxxtokenMail",
        //        USER_TOKEN_TRX = u.Token,
        //        ENTRY_DATE = System.DateTime.Now,
        //        ID = 0,
        //        USER_EMAIL ="u.USER_EMAIL@gmail.com",
        //        USER_EXP = System.DateTime.Now,
        //        USER_FULLNAME = u.UserName,
        //        USER_ID = u.UserId,
        //        USER_JOINT = System.DateTime.Now,
        //        USER_PASS =new Helper.clsCryptho().Encrypt(new Helper.clsCryptho().Encrypt(u.UserPass,"@Pelindo"),"@Pelindo"),
        //        USER_UPDATE = System.DateTime.Now
        //    };

        //    List<I_HUB.Maintenance.Users> users = I_HUB.Maintenance.Users.UsersForDataSource();
        //    var b = users.Where(a => a.USER_ID.ToLower() == u.UserId.ToLower()).FirstOrDefault();
        //    if (b != null)
        //    {
        //        object erb = new { status = "error", msg = "User Already Exist!" };
        //        return Json(erb, new JsonSerializerSettings());
        //    }

        //    try
        //    {
        //        users.Insert(0, NewUser);
        //        I_HUB.Maintenance.Users.SaveAllUsers(users);
        //        object o  = new { status = "success", msg = "New User Hasbeen Added" };
        //        return Json(o, new JsonSerializerSettings());
        //    }
        //    catch (Exception ex)
        //    {
        //      object   o1 = new { status = "error", msg = ex.Message };
        //        return Json(o1, new JsonSerializerSettings());
        //    }
        //   object  o2 = new { status = "error", msg = "" };
        //    return Json(o2, new JsonSerializerSettings());
        //}

        public JsonResult DeleteUser(string uid) {
            JsonResult return_ = null;
            if (I_HUB.Maintenance.Users.DeleteCompany(uid)>0)
            {
                object o = new { status = "success", data = "" };
                return Json(o, new JsonSerializerSettings());
            }
            else {
                object o = new { status = "error", data = "" };
                return Json(o, new JsonSerializerSettings());
            }
            return return_;
        }

        public JsonResult tst()
        {
            JsonResult result = null;

            return result;
        }

    }
}
