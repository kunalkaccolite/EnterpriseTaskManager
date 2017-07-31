
using EnterpriseTaskManager.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseTaskManager.DataAccess
{
	public class EventDAL
	{
		


		public List<EventAction> GetEventActionForEvent(String EventType)
		{
			try
			{
			    SqlParameter[] SqlParamArray = new SqlParameter[1];
                SqlParamArray[0] = new SqlParameter("@EventTypeDescription", EventType);
                List<EventAction> eventActionList = new List<EventAction>();

                SqlHelper sqlHelper = new SqlHelper();
                using (SqlDataReader rdr = sqlHelper.ExecuteDataReader(DataAccess.SQLQueriesConstants.sp_GetActionListForEventType, SqlParamArray))
                {
                    while (rdr.Read())
                    {
                        EventAction x = new EventAction();
                        int index = rdr.GetOrdinal("ActionType");
                        x.ActionType = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                        index = rdr.GetOrdinal("TargetURL");
                        x.TargetURL = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                        eventActionList.Add(x);
                    }
                    return eventActionList;
                }
            }
         
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}


        public List<EventTransaction> GetEventTransaction()
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper();
                List<EventTransaction> EventTransactionList = new List<EventTransaction>();
                using (SqlDataReader rdr = sqlHelper.ExecuteDataReader(SQLQueriesConstants.sp_GetTransactionDetails))
                {
                        while (rdr.Read())
                        {
                            EventTransaction x = new EventTransaction();
                            int index = rdr.GetOrdinal("EventTransactionID");
                            x.EventTransactionID = !rdr.IsDBNull(index) ? rdr.GetInt32(index) : 0;
                            index = rdr.GetOrdinal("EventTypeDescription");
                            x.EventTypeDescription = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                            index = rdr.GetOrdinal("IsResolved");
                            x.IsResolved = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                            index = rdr.GetOrdinal("ResolvedBy");
                            x.ResolvedBy = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                        index = rdr.GetOrdinal("ObjectData");
                        x.ObjectData= !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                        EventTransactionList.Add(x);
                        }
                    
                    return EventTransactionList;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool InsertEventTransaction(EventTransaction eventTransaction)
        {
            try
            {
                SqlParameter[] SqlParamArray = new SqlParameter[4];
                SqlParamArray[0] = new SqlParameter("@EventTypeDescription", eventTransaction.EventTypeDescription);
                SqlParamArray[1] = new SqlParameter("@ObjectData", eventTransaction.ObjectData);
               
                SqlParamArray[2] = new SqlParameter("@IsResolved", eventTransaction.IsResolved);
                SqlParamArray[3] = new SqlParameter("@ResolvedBy", eventTransaction.ResolvedBy);
                SqlHelper sqlHelper = new SqlHelper();

                sqlHelper.ExecuteNonQuery(DataAccess.SQLQueriesConstants.sp_InsertIntoEventTransaction,SqlParamArray);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }


        /// <summary>
        /// Get EventType
        /// </summary>
        /// <param name="eventTypeDescription"></param>
        /// <returns></returns>
        public EventType EventTypeDetails(string eventTypeDescription)
        {
            try
            {
                SqlParameter[] SqlParamArray = new SqlParameter[1];
                SqlParamArray[0] = new SqlParameter("@EventTypeDescription", eventTypeDescription);
                var eventType = new EventType();
                SqlHelper sqlHelper = new SqlHelper();
                SqlDataReader rdr = sqlHelper.ExecuteDataReader(SQLQueriesConstants.sp_EventTypeDetails, SqlParamArray);
                while (rdr.Read())
                {
                    int index = rdr.GetOrdinal("EventTypeID");
                    eventType.EventTypeID = !rdr.IsDBNull(index) ? rdr.GetInt32(index) : 0;
                    index = rdr.GetOrdinal("InputTypeObject");
                    eventType.InputTypeObject = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;

                }
                return eventType;
            }
            catch (Exception e)
            {

                return null;
            }


        }



    }
}

