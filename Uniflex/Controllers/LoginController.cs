using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace I_HUB.Controllers
{
    using System.IO;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;

    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            new BaseUrl.Url_().Create_Initial();
            return View();
        }

        [HttpPost]
        public ActionResult index(Model.Users.UserLogin login)
        {
            if (User != null)
            {
                ViewBag.ValidationResult = "";
                bool isValid = false;

                if (string.IsNullOrWhiteSpace(login.UserID) || string.IsNullOrWhiteSpace(login.Password))
                {
                    ViewBag.ValidationResult = "Incorrect user ID or Password";
                    isValid = false;
                }
                else
                {
                    Helper.clsCryptho crypt = new Helper.clsCryptho();
                    string encryptPassword = crypt.Encrypt(login.Password.ToLower(), "@Uniflex");
                    Maintenance.Users user = Maintenance.Users.UserLogin(login.UserID, encryptPassword);
                    if (user != null)
                    {
                        if (!user.USER_ACTIVE)
                        {
                            ViewBag.ValidationResult = "Your account is not active or has been block. Please contact your administrator.";
                            isValid = false;
                            return View(login);
                        }
                        else
                        {
                            isValid = true;
                            HttpContext.Session.SetString(Helper.GlobalVariable.SESSION_USER_ID, user.USER_ID);
                            HttpContext.Session.SetString(Helper.GlobalVariable.SESSION_USER_NAME, user.USER_FULLNAME);
                            HttpContext.Session.SetString(Helper.GlobalVariable.SESSION_USER_ROLE, user.USER_ROLE);
                            return RedirectToAction("index", "Main");
                        }
                    }
                    else
                    {
                        isValid = false;
                        ViewBag.ValidationResult = "Incorrect user ID or Password";
                        return View(login);
                    }
                }
            }
            return View(login);
        }

        public ActionResult Signout()
        {

            HttpContext.Session.Remove(Helper.GlobalVariable.SESSION_USER_ID);
            HttpContext.Session.Remove(Helper.GlobalVariable.SESSION_USER_NAME);
            HttpContext.Session.Remove(Helper.GlobalVariable.SESSION_USER_ROLE);
            return RedirectToAction("Index", "Login", new { area = "" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Model.Error.ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
