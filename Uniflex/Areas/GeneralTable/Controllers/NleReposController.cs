using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace I_HUB.Areas.GeneralTable.Controllers
{
    public class NleReposController : Controller
    {

        [Area("GeneralTable")]
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
                List<I_HUB.GeneralTable.itgr_repost_header> SSP =I_HUB.GeneralTable.itgr_repost_header.GetForDataSources();

                totalRecords = SSP.Count;

                // Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    switch (sortColumn.ToLower())
                    {
                        default:
                            SSP = SSP.OrderBy(o => o.APP_REQUEST).ToList();
                            // SSP = SSP.OrderBy(o => o.REF_DOC_NO).ToList();
                            break;
                    }
                }

                if (!string.IsNullOrEmpty(searchValue))
                {
                    string searchValueLower = searchValue.ToLower();
                    SSP = SSP.Where(x => x.APP_REQUEST.ToString().ToLower().Contains(searchValueLower)).ToList();
                    //SSP = SSP.Where(x => x.REF_DOC_NO.ToString().ToLower().Contains(searchValueLower) || x.KD_CABANG.ToString().ToLower().Contains(searchValueLower)).ToList();
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

        public JsonResult GetDetail(string ref_doc_no)
        {
            JsonResult result=null;
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
                List<I_HUB.GeneralTable.itgr_repost_detail> SSP = I_HUB.GeneralTable.itgr_repost_detail.GetDatailFromDocNo(ref_doc_no);

                totalRecords = SSP.Count;

                // Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    switch (sortColumn.ToLower())
                    {
                        default:
                           SSP = SSP.OrderBy(o => o.REF_DOC_NO).ToList();
                            break;
                    }
                }

                if (!string.IsNullOrEmpty(searchValue))
                {
                    string searchValueLower = searchValue.ToLower();
                   SSP = SSP.Where(x => x.REF_DOC_NO.ToString().ToLower().Contains(searchValueLower) || x.DOC_NUMBER_ITGR.ToString().ToLower().Contains(searchValueLower)).ToList();
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

        public JsonResult GetDetailChars(string doc_no)
        {
            JsonResult result = null;
            List<I_HUB.GeneralTable.itgr_repost_detail_chars> SSP = I_HUB.GeneralTable.itgr_repost_detail_chars.GetFromDocNo(doc_no);
            if (SSP!=null)
            {
                object o = new { status = "success", data = SSP };
                return Json(o, new JsonSerializerSettings());
            }
            else
            {
                object o = new { status = "error", data = "null" };
                return Json(o, new JsonSerializerSettings());
            }
            
            //return result;
            //JsonResult result = null;
            //try
            //{
            //    var draw = Request.Form["draw"].FirstOrDefault();
            //    var start = Request.Form["start"].FirstOrDefault();
            //    var length = Request.Form["length"].FirstOrDefault();
            //    var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            //    var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();
            //    var searchValue = Request.Form["search[value]"].FirstOrDefault();

            //    int pageSize = length != null ? Convert.ToInt32(length) : 0;
            //    int skip = start != null ? Convert.ToInt32(start) : 0;
            //    int totalRecords = 0; // Total keseluruhan data
            //    int totalRecordsShowing = 0; // Total data setelah filter / search
            //    List<I_HUB.GeneralTable.itgr_repost_detail_chars> SSP = I_HUB.GeneralTable.itgr_repost_detail_chars.GetFromDocNo(doc_no);

            //    totalRecords = SSP.Count;

            //    // Sorting    
            //    if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //    {
            //        switch (sortColumn.ToLower())
            //        {
            //            default:
            //                SSP = SSP.OrderBy(o => o.REF_DOC_NO).ToList();
            //                break;
            //        }
            //    }

            //    if (!string.IsNullOrEmpty(searchValue))
            //    {
            //        string searchValueLower = searchValue.ToLower();
            //        SSP = SSP.Where(x => x.REF_DOC_NO.ToString().ToLower().Contains(searchValueLower) || x.DOC_NUMBER_ITGR.ToString().ToLower().Contains(searchValueLower)).ToList();
            //    }

            //    totalRecordsShowing = SSP.Count();

            //    // Paging
            //    SSP = SSP.Skip(skip).Take(pageSize).ToList();

            //    // Returning Json Data
            //    result = this.Json(new { recordsFiltered = totalRecordsShowing, recordsTotal = totalRecords, data = SSP }, new Newtonsoft.Json.JsonSerializerSettings());

            //}
            //catch (Exception er)
            //{
            //    System.Diagnostics.Debug.WriteLine(er.Message);
            //}
            //return result;
        }

        public JsonResult GetLog()
        {
            JsonResult result= null;
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
                List<I_HUB.GeneralTable.itgr_repost_log> SSP = I_HUB.GeneralTable.itgr_repost_log.GetForDataSource();

                totalRecords = SSP.Count;

                // Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    switch (sortColumn.ToLower())
                    {
                        default:
                            SSP = SSP.OrderBy(o => o.REF_DOC_NO).ToList();
                            break;
                    }
                }

                if (!string.IsNullOrEmpty(searchValue))
                {
                    string searchValueLower = searchValue.ToLower();
                    SSP = SSP.Where(x => x.REF_DOC_NO.ToString().ToLower().Contains(searchValueLower) || x.DOC_NUMBER_ITGR.ToString().ToLower().Contains(searchValueLower)).ToList();
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
    }
}
