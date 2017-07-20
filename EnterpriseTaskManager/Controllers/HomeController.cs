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

        public ActionResult BasicWebPage()
        {
            return View();
        }


        [HttpGet]
		public string GetEventActionList(String EventType)
		{
			var json = etmControllerObj.GetEventActionListForEvent(EventType);
			return json;
		}

        [HttpGet]
        public string GetEventTransactionList()
        {
            var json = etmControllerObj.GetEventTransactionList();
            return json;
        }
    }
}