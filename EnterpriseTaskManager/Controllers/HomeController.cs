using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
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


        [System.Web.Mvc.HttpGet]
		public string GetEventActionList(String EventType)
		{
			var json = etmControllerObj.GetEventActionListForEvent(EventType);
			return json;
		}

        [System.Web.Http.HttpGet]
        public string GetEventTransactionList()
        {
            var json = etmControllerObj.GetEventTransactionList();
            return json;
        }


        [System.Web.Http.HttpGet]
        public string GetEventTypeDetails(String EventType)
        {
            var json = etmControllerObj.EventTypeDetails(EventType);
            return json;
        }

        [System.Web.Mvc.HttpPost]
        public void PostEventTransaction([FromBody]String EventTransactionJSON)
        {
            etmControllerObj.InsertEventTransaction(EventTransactionJSON);
        }
    }
}