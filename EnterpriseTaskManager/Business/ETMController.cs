using EnterpriseTaskManager.Common;
using EnterpriseTaskManager.DataAccess;
using EventUtility;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace EnterpriseTaskManager
{
    public class ETMController : IEtmController
    {
        private readonly IEventDAL eventDAl;

        public ETMController(IEventDAL EventDAL)
        {
            eventDAl = EventDAL;
        }

        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Serializes an object into JSON string
        /// </summary>
        /// <param name="SerializerObject"></param>
        /// <returns></returns>
        String SerializeIntoJSON(object SerializerObject)
        {
            StringBuilder sb = new StringBuilder();
            var js = new JavaScriptSerializer();
            js.Serialize(SerializerObject, sb);
            return sb.ToString();
        }


        /// <summary>
        /// Returns action list for a particular event type
        /// </summary>
        /// <param name="EventType">STring</param>
        /// <returns>String</returns>
		public string GetEventActionListForEvent(String EventType = "Registration")
        {
            try
            {
                var EventActionList = eventDAl.GetEventActionForEvent(EventType);
                var JsonString = SerializeIntoJSON(EventActionList);
                return JsonString;
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in ETM controller GetEventActionListForEvent Action");
                return null;
            }
        }


        /// <summary>
        /// returns Event Details for a particular type of event
        /// </summary>
        /// <param name="EventType">Give the description of event</param>
        /// <returns>String in JSON format</returns>
        public string EventTypeDetails(String EventType)
        {
            try
            {
                var EventDetails = eventDAl.EventTypeDetails(EventType);
                var JsonString = SerializeIntoJSON(EventDetails);
                return JsonString;
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in ETM controller GetEventActionListForEvent Action");
                return null;
            }
        }


        /// <summary>
        /// Takes the URL and Data and hits the WEbApi Or opens a new UI as per Method Type
        /// </summary>
        /// <param name="ObjectData">TJSON string from whch parametrs are to be extracted</param>
        /// <param name="BodyFormat">Key value dictionary with empty value.</param>
        /// <param name="TargetURL"></param>
        /// <param name="MethodType"></param>
        /// <param name="parentTransactionId"></param>
        /// <returns></returns>
        public bool GoToURL(string ObjectData, string BodyFormat, string TargetURL, string MethodType, int parentTransactionId)
        {
            CallWebAPI eventUtilityObject = new CallWebAPI();
            try
            {
                eventUtilityObject.MethodCall(ObjectData, "POST", TargetURL, parentTransactionId, BodyFormat, MethodType);
                return true;
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in ETM controller GoToURL Action");
                return false;
            }
        }



        /// <summary>
        /// Returns a List of Transactions serialized into JSON
        /// </summary>
        /// <returns>JSON string of List of Transactions</returns>
        public string GetEventTransactionList(String EventType, bool ShowAllTasks)
        {
            var EventTransactionList = eventDAl.GetEventTransaction(EventType, ShowAllTasks);
            var JsonString = SerializeIntoJSON(EventTransactionList);
            return JsonString;
        }


        /// <summary>
        /// USed to create new Event and Insert Details in DB
        /// </summary>
        /// <param name="eventTransactionJSON">Send the EventTransction serilialized object </param>
        public bool InsertEventTransaction(string eventTransactionJSON)
        {
            var jsSerializer = new JavaScriptSerializer();
            var Object = jsSerializer.Deserialize<Common.EventTransaction>(eventTransactionJSON);
            try
            {
                eventDAl.InsertEventTransaction(Object);
                return true;
            }
            catch (Exception e)
            {

                logger.Error(e, "Error occured in ETM controller InsertEventTransaction Action");
                return false;
            }
        }

        /// <summary>
        /// Updates the event Transaction for resolved
        /// </summary>
        /// <param name="transactionId">int</param>
        /// <returns>bool</returns>
        public bool UpdateEventTransaction(int transactionId)
        {
            try
            {
                eventDAl.UpdateTransactionStatus(transactionId);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error occured in ETM controller UpdateEventTransaction Action");
                return false;

            }
        }


        /// <summary>
        /// returns a list of Event for given user
        ///  </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string GetEventTypeForUser(String userName)
        {
            try
            {
                var EventTypeList = eventDAl.GetEventTypeForUser(userName);
                var JsonString = SerializeIntoJSON(EventTypeList);
                return JsonString;
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in ETM controller GetEventActionListForEvent Action");
                return null;
            }
        }


        public  bool ValidateLogin(String userName, String password)
        {
            try
            {
                var IsValidUser =eventDAl.ValidateLogin(new Users() { UserName=userName, Password=password});
                return IsValidUser;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error occured in ETM controller ValidateLogin Action");
                return false;

            }
        }
    }
    }
