using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseTaskManager.Controllers
{
	public class HomeController : Controller
	{

		ETMController etmControllerObj = new ETMController();
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public string GetEventActionList()
		{
			var json = etmControllerObj.GetEventActionList();
			return json;
		}
	}
}