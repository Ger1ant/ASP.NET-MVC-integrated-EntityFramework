using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _24_MVC_JQueryAjax.Controllers
{
    public class HomeController : Controller
    {
        private List<string> liste = new List<string>()
        {
            "Ferrari","RBR","Mercedes"
        };
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult VerileriGetir(string veri="")
        {
            if(string.IsNullOrEmpty(veri)==false)
            {
                liste.Add(veri);
            }
            System.Threading.Thread.Sleep(300);
            return PartialView("_DataPartialPage",liste);
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Index3()
        {
            return View();
        }

        public ActionResult Index4()
        {
            return View();
        }


        //Js ile httpPost oluşturmadan actiona parametetre vererek textbox üzerinden ekleme yapılabilir
        public JsonResult VerileriGetir2(string veri="")
        {
            if (string.IsNullOrEmpty(veri) == false)
            {
                liste.Add(veri);
            }
            System.Threading.Thread.Sleep(300);
            return Json(liste,JsonRequestBehavior.AllowGet);
        }

    }
}