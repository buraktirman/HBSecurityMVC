using HBSecurityMVC.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using System.IO;

namespace HBSecurityMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult MitreInfo()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}