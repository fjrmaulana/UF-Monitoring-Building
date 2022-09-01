using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Uniflex.Areas.GeneralTable.Controllers
{
    public class AreahController : Controller
    {
        [Area("GeneralTable")]
        public IActionResult Index()
        {

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(I_HUB. Helper.GlobalVariable.SESSION_USER_ID)))
                return RedirectToAction("Index", "login");

            ViewBag.UserId = HttpContext.Session.GetString(I_HUB.Helper.GlobalVariable.SESSION_USER_NAME);
            ViewBag.UserMenu = new I_HUB.Maintenance.MenuTreeview().Get_Access_Menu(HttpContext.Session.GetString(I_HUB.Helper.GlobalVariable.SESSION_USER_ROLE));
            return View();
        }

        public JsonResult RefreshArea(string tglfrom)
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
                List<Uniflex.GeneralTable.Uniflext_ZonaArea> SSP = Uniflex.GeneralTable.Uniflext_ZonaArea.GetForDataSource();

                totalRecords = SSP.Count;

                // Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    switch (sortColumn.ToLower())
                    {
                        default:
                            SSP = SSP.OrderBy(o => o.Area_Name).ToList();
                            break;
                    }
                }

                if (!string.IsNullOrEmpty(searchValue))
                {
                    string searchValueLower = searchValue.ToLower();
                    SSP = SSP.Where(x => x.Area_Name.ToString().ToLower().Contains(searchValueLower) || x.Area_Desc.ToString().ToLower().Contains(searchValueLower)).ToList();
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

        public JsonResult SaveNewArea(string nama,string id,string desc,bool stat)
        {
            JsonResult result = null;

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(I_HUB.Helper.GlobalVariable.SESSION_USER_ID)))
            {
                object o = new { status = "error", msg = "Time Out!" };
                return Json(o, new JsonSerializerSettings());
            }

           // Uniflex.GeneralTable.Uniflext_ZonaArea l = Uniflex.GeneralTable.Uniflext_ZonaArea.GetFromIdArea(id);
            if (Uniflex.GeneralTable.Uniflext_ZonaArea.DataExist(id))
            {
                object o = new { status = "error", msg = "Data Already Exist!" };
                return Json(o, new JsonSerializerSettings());
            }

            var userName = HttpContext.Session.GetString(I_HUB.Helper.GlobalVariable.SESSION_USER_NAME);
            int success = Uniflex.GeneralTable.Uniflext_ZonaArea.SaveData(nama, desc, id, userName.ToString(), stat);
            if (success > 0)
            {
                object o = new { status = "success", msg = "Data Saved! Success" };
                return Json(o, new JsonSerializerSettings());
            }
            else
            {
                object o = new { status = "error", msg = "Cant Be Saved" };
                return Json(o, new JsonSerializerSettings());
            }

            return result;
        }
    }
}
