using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Uniflex.Areas.Report.Controllers
{
    public class CheckerReportController : Controller
    {
        [Area("Report")]
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(I_HUB. Helper.GlobalVariable.SESSION_USER_ID)))
                return RedirectToAction("Index", "login");

            ViewData["statuslist"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(Uniflex.GeneralTable.Uniflext_ObjStatus.ForList(), "Value", "Text",2);

            ViewBag.UserId = HttpContext.Session.GetString(I_HUB.Helper.GlobalVariable.SESSION_USER_NAME);
            ViewBag.UserMenu = new I_HUB.Maintenance.MenuTreeview().Get_Access_Menu(HttpContext.Session.GetString(I_HUB.Helper.GlobalVariable.SESSION_USER_ROLE));
            return View();
        }

        public JsonResult GetData(string tglfrom,string tglto, string status)
        {
            System.DateTime d_from =I_HUB. Helper.GeneralHelper.StringToDate(tglfrom, "MMM yyyy");
            System.DateTime d_to = I_HUB.Helper.GeneralHelper.StringToDate(tglto, "MMM yyyy");

            var total_hari_from = System.DateTime.DaysInMonth(d_from.Year, d_from.Month);
            var total_hari_to = System.DateTime.DaysInMonth(d_to.Year, d_to.Month);

            var post_from_date =d_from.ToString("yyyy-MM") + "-01";
            var post_to_date = d_to.ToString("yyyy-MM") +"-"+ total_hari_to;

            // System.Diagnostics.Debug.WriteLine("from->" + total_hari_from + "\n" + "to->" + total_hari_to);
            Uniflex. GeneralTable.Uniflext_ObjStatus sts = Uniflex.GeneralTable.Uniflext_ObjStatus.GetFromCode(status);

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
                List<Uniflex.GeneralTable.Uniflext_Report_Checker> SSP = Uniflex.GeneralTable.Uniflext_Report_Checker.GetForDataSource(sts.Name,post_from_date,post_to_date);

                totalRecords = SSP.Count;

                // Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    switch (sortColumn.ToLower())
                    {
                        default:
                            SSP = SSP.OrderBy(o => o.rpt_Objname).ToList();
                            break;
                    }
                }

                if (!string.IsNullOrEmpty(searchValue))
                {
                    string searchValueLower = searchValue.ToLower();
                    SSP = SSP.Where(x => x.rpt_Objstatus.ToString().ToLower().Contains(searchValueLower) || x.rpt_Zonacode.ToString().Contains(searchValueLower)).ToList();
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

        public JsonResult GetDetailReport(string id)
        {
            JsonResult result = null;

            Uniflex.GeneralTable.Uniflext_Report_Checker l = Uniflex.GeneralTable.Uniflext_Report_Checker.GetFromId(int.Parse(id.Replace("x","")));
            if (l==null)
            {
                object o = new {status="error",data="" };
                return Json(o, new JsonSerializerSettings());
            }
            else
            {
                object o = new { status = "success", data = l };
                return Json(o, new JsonSerializerSettings());
            }

            return result;
        }

        [HttpPost]
        public JsonResult UpdateData(string id,string txt)
        {
            JsonResult result = null;
            int succezz = Uniflex.GeneralTable.Uniflext_Report_Checker.UpdateReportDesc(int.Parse(id), txt);
            if (succezz > 0)
            {
                object o = new { status="success",data=""};
                return Json(o, new JsonSerializerSettings());
            }
            else {
                object o = new { status = "error", data = "" };
                return Json(o, new JsonSerializerSettings());
            }
            return result;
        }

        // camera
        //ttps://www.c-sharpcorner.com/article/capturing-image-from-web-cam-in-asp-net-core-mvc/
    }
}
