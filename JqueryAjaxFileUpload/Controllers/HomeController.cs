using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JqueryAjaxFileUpload.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //Gelen datayı okuyabilmek için (dosya,resim) HttpPostedFileBase den faydalanıyoruz
        [HttpPost]
        public JsonResult FileUpload(HttpPostedFileBase file)
        {
            if(file!=null)
            {
                if(Directory.Exists(Server.MapPath("~/files"))==false)
                {
                    Directory.CreateDirectory(Server.MapPath("~/files"));
                }

                //PathCombine ile dosya adı ve uzantılarını birbirine bağlıyoruz.
                file.SaveAs(Path.Combine(Server.MapPath("~/files"), file.FileName));

                //Dosya geldiği için hasError kısmı False ve Mesajımız Dosya Yüklendi olarak dönücek
                return Json(new { hasError=false, message="Dosya Yüklendi ..."});
            }

            return Json(new { hasError = true, message = "Dosya Null ..." });
        }
    }
}