using EnterpriseTaskManager.DataAccess;
using NLog;
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
        
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private  ETMController etmControllerObj = new ETMController(new EventDAL());

        
		public ActionResult Index()
		{
			return View();
		}

        public ActionResult Test()
        {
            return View();
        }


        /// <summary>
        /// Returns a  serialized list of Action List for Event Type
        /// </summary>
        /// <param name="EventType">String </param>
        /// <returns>Serialized JSON STring </returns>
        [System.Web.Mvc.HttpGet]
		public string GetEventActionList(String EventType)
		{
            try
            {
                var json = etmControllerObj.GetEventActionListForEvent(EventType);
                return json;
            }
            catch (Exception e)
            {
                logger.Error(e, "Exception occured in Home Controller's GetEventActionList Action");
                return null;
                
            }
		}

        /// <summary>
        /// Returns List of All Transctions 
        /// </summary>
        /// <returns>Serialized string odf all transactions</returns>
        [System.Web.Http.HttpGet]
        public string GetEventTransactionList(String EventType, bool ShowAllTasks)
       {
            try
            {
                var json = etmControllerObj.GetEventTransactionList(EventType, ShowAllTasks);
                return json;
            }
            catch (Exception e)
            {
                logger.Error(e, "Exception occured in Home Controller's GetEventTransactionList Action");
                return null;
            }
        }


        /// <summary>
        /// Returns all the details of Particular Event Type
        /// </summary>
        /// <param name="EventType">String Descriptiob of Event Type</param>
        /// <returns>Serialized String</returns>
        [System.Web.Http.HttpGet]
        public string GetEventTypeDetails(String EventType)
        {
            try
            {
                var json = etmControllerObj.EventTypeDetails(EventType);
                return json;
            }
            catch (Exception e)
            {
                logger.Error(e, "Exception occured in Home Controller's GetEventTypeDetails Action");
                return null;
            }
        }

        /// <summary>
        /// Post Transaction Details of any new event
        /// </summary>
        /// <param name="EventTransactionJSON">String of Transaction details</param>
        [System.Web.Mvc.HttpPost]
        public bool PostEventTransaction([FromBody]String EventTransactionJSON)
        {
            try
            {
                etmControllerObj.InsertEventTransaction(EventTransactionJSON);
                return true;
            }
            catch (Exception e)
            {
                logger.Error(e, "Exception occured in Home Controller's PostEventTransaction Action");
                return false;
            }
        }


        /// <summary>
        /// Calls the WebApi or opens the Url in a new window.
        /// </summary>
        /// <param name="ObjectData"></param>
        /// <param name="BodyFormat"></param>
        /// <param name="TargetURL">Target Adress of WebAPI</param>
        /// <param name="MethodType">UI or API call</param>
        /// <param name="parentTransactionId"></param>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        public bool GoToUrl(string ObjectData, string BodyFormat, string TargetURL, string MethodType, int parentTransactionId)
        {
            try
            {
                BodyFormat = BodyFormat == "null" ? null : BodyFormat;
                etmControllerObj.GoToURL(ObjectData, BodyFormat, TargetURL, MethodType, parentTransactionId);
                return true;
            }
            catch(Exception e)
            {
                logger.Error(e, "Exception occured in Home Controller's GoToUrl Action");
                return false;
            }
        }



        /// <summary>
        /// Returns list of all events for which a user has permisssion
        /// </summary>
        /// <returns></returns>
        [System.Web.Mvc.HttpGet]
        public string GetEventTypeForUser()
        {
            try
            {
                string UserName = (string)Session["userName"];
                var json = etmControllerObj.GetEventTypeForUser(UserName);
                return json;
            }
            catch (Exception e)
            {
                logger.Error(e, "Exception occured in Home Controller's GetEventTypeForUser Action");
                return null;
            }

        }
    }
}