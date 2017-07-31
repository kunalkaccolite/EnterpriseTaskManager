using EnterpriseTaskManager.Common;
using EnterpriseTaskManager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace EnterpriseTaskManager
{
	public class ETMController
	{
		EventDAL eventDAl = new EventDAL();

		public string GetEventActionListForEvent(String EventType="Registration")
		{
			var EventActionList = eventDAl.GetEventActionForEvent(EventType);
			StringBuilder sb = new StringBuilder();
			var jsSerializer = new JavaScriptSerializer();
			jsSerializer.Serialize(EventActionList, sb);
			return sb.ToString();
		}


        public string EventTypeDetails(String EventType)
        {
            var EventActionList = eventDAl.EventTypeDetails(EventType);
            StringBuilder sb = new StringBuilder();
            var jsSerializer = new JavaScriptSerializer();
            jsSerializer.Serialize(EventActionList, sb);
            return sb.ToString();
        }
      



        public string GetEventTransactionList()
        {
            var EventTransactionList = eventDAl.GetEventTransaction();
            StringBuilder sb = new StringBuilder();
            var jsSerializer = new JavaScriptSerializer();
            jsSerializer.Serialize(EventTransactionList, sb);
            return sb.ToString();
        }

        public void InsertEventTransaction(string eventTransactionJSON)
        {
            var jsSerializer = new JavaScriptSerializer();
            var Object = jsSerializer.Deserialize<EventTransaction>(eventTransactionJSON);
             eventDAl.InsertEventTransaction(Object);

            // throw new NotImplementedException();
        }
    }
}