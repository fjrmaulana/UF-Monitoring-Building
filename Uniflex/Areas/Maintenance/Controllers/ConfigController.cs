using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace I_HUB.Areas.Maintenance.Controllers
{

    [Area("Maintenance")]
    public class ConfigController : Controller
    {
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(Helper.GlobalVariable.SESSION_USER_ID)))
                return RedirectToAction("Index", "login");

            ViewBag.UserId = HttpContext.Session.GetString(Helper.GlobalVariable.SESSION_USER_NAME);
            ViewBag.UserMenu = new I_HUB.Maintenance.MenuTreeview().Get_Access_Menu(HttpContext.Session.GetString(Helper.GlobalVariable.SESSION_USER_ROLE));
            return View();
        }
    }
}
