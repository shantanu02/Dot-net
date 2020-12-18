using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstApplication.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        //public string Index()
        //{
        //    return "Hello <b>World</b>";
        //}


        //passind id 
        public ActionResult First(int id=0)
        { 
            ViewBag.Id = id;
            return View();
        }

        //passing parameters using query string 
        //http://localhost:52202/Default/Second/1000?a=100&b=200&c="Shantanu"
        public ActionResult Second(int id = 0,int a=0, int b = 0 , string c ="")
        {
            ViewBag.Id = id;
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.c = c;
            return View();
        }

    }
}