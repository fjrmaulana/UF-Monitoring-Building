using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace I_HUB.Areas.DocumentApi.Controllers
{
    public class SwaggerUnicornController : Controller
    {
        [Area("DocumentApi")]
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(Helper.GlobalVariable.SESSION_USER_ID)))
                return RedirectToAction("Index", "login");

            ViewBag.UserId = HttpContext.Session.GetString(Helper.GlobalVariable.SESSION_USER_NAME);
            ViewBag.UserMenu = new I_HUB.Maintenance.MenuTreeview().Get_Access_Menu(HttpContext.Session.GetString(Helper.GlobalVariable.SESSION_USER_ROLE));
            return View();
        }

        public JsonResult GetData()
        {
            JsonResult rst = null;//swagger/ibs-unicorn/swagger.json
            var swagerPath ="https://"+ Request.Host.ToString()+ "/swagger/v1/swagger.json";
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                var HtmlResult = wc.DownloadString(swagerPath);
                return Json(HtmlResult, new JsonSerializerSettings());
            }

            string u = Request.Host.ToString();
            string basePhats = "/Api";// Sesuaikan di Api Loacation Url
            Model.Swagger.SwaggerParams sw = Model.Swagger.SwaggerParams.GetForDataSource(u,basePhats);
            return Json(sw, new JsonSerializerSettings());
        }
    }
}