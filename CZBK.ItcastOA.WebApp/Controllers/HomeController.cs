using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZBK.ItcastOA.WebApp.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            //ViewData["name"]= LoginUser.UNAME;
            return View();
        }
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult Getmenus()
        {
            return View(); 
        }
    }
}