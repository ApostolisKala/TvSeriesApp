using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TvSeriesApp.Controllers
{
    public class TvController : Controller
    {
        // GET: Tv
        public ActionResult Index()
        {
            return View();
        }

        //public string WelcomeMessage(string message, int ID)
        //{
        //    return "Welcome " + message + " " + ID;
        //}

        public ActionResult Welcome(string message, int ID)
        {
            ViewBag.Message = message;
            ViewBag.Times = ID;

            return View();
        }
    }
}