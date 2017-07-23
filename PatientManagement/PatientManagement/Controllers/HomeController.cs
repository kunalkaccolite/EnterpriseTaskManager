using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientManagement.Controllers
{
	public class HomeController : Controller
	{
        HospitalMangement hmObj = new HospitalMangement();
		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";

			return View();
		}

		[HttpGet]
		public bool CheckIfInsuranceExists(string PatientID)
		{
           
			return hmObj.CheckInsuranceDetails(PatientID);
		}
	}
}
