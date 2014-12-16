using DecPlayground.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DecPlayground.Controllers
{
    [ContentHeaderActionFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


      public ActionResult Angular()
        {

            return View();
        }

   
    }
}