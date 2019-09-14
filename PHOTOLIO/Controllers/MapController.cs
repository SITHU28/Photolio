using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PHOTOLIO.Service;
using PHOTOLIO.ViewModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using PHOTOLIO.Model;

namespace PHOTOLIO.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Locations()
        {
            return View();
        }
    }
}