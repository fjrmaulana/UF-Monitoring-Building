using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace I_HUB.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            if ( string.IsNullOrEmpty(HttpContext.Session.GetString(Helper.GlobalVariable.SESSION_USER_ID)))
                return RedirectToAction("Index", "login");

            var menu_ = new Maintenance.MenuTreeview().Get_Access_Menu(HttpContext.Session.GetString(Helper.GlobalVariable.SESSION_USER_ROLE));

            ViewBag.UserId = HttpContext.Session.GetString(Helper.GlobalVariable.SESSION_USER_NAME);
            ViewBag.UserMenu = menu_;
            return View();
        }

        [HttpPost]
        public JsonResult GetTotalStatus([FromForm] string dat, [FromForm] string status_send)
        {
            object o = new { status = "error", count = "0" };
            System.DateTime d = System.DateTime.Now;
            int Month_ = GetMonthNumber_From_MonthName(d.ToString("MMM"));
            int year_ = int.Parse(d.ToString("yyyy"));
            if (!string.IsNullOrEmpty(dat))
            {
                System.DateTime oDate = DateTime.ParseExact(dat, "MMM yyyy", null);
                Month_ = GetMonthNumber_From_MonthName(oDate.ToString("MMM"));
                year_ = int.Parse(oDate.ToString("yyyy"));
                o = new { status = "success", count = GeneralTable.nle_sp2_itgr_HEADER.GetCount(Month_, year_, status_send) };
                return Json(o, new Newtonsoft.Json.JsonSerializerSettings());
            }
            return Json(o, new Newtonsoft.Json.JsonSerializerSettings());
        }

        public static int GetMonthNumber_From_MonthName(string monthname)
        {
            int monthNumber = 0;
            monthNumber = DateTime.ParseExact(monthname, "MMM", System.Globalization.CultureInfo.CurrentCulture).Month;
            return monthNumber;
        }


    }
}
