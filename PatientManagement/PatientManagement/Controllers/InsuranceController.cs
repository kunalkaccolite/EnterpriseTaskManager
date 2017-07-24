using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientManagement.Controllers
{
    public class InsuranceController : Controller
    {
        // GET: Insurance
        public ActionResult Insurance()
        {
            ViewBag.Title = "Insurance Page";

            return View();

        }
    }
}