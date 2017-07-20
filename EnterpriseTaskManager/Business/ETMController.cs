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
		SqlHelper sqlHelper = new SqlHelper();

		public string GetEventActionListForEvent(String EventType="Registration")
		{
			var EventActionList = sqlHelper.GetEventActionForEvent(EventType);
			StringBuilder sb = new StringBuilder();
			var jsSerializer = new JavaScriptSerializer();
			jsSerializer.Serialize(EventActionList, sb);
			return sb.ToString();
		}


        public string GetEventTransactionList()
        {
            var EventTransactionList = sqlHelper.GetEventTransaction();
            StringBuilder sb = new StringBuilder();
            var jsSerializer = new JavaScriptSerializer();
            jsSerializer.Serialize(EventTransactionList, sb);
            return sb.ToString();
        }
    }
}