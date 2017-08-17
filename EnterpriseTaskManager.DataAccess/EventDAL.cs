
using EnterpriseTaskManager.Common;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseTaskManager.DataAccess
{
	public class EventDAL :IEventDAL
	{
       private static Logger logger = LogManager.GetCurrentClassLogger();


        /// <summary>
        /// Returns a list of action for a particular Event Type
        /// </summary>
        /// <param name="EventType">String</param>
        /// <returns>list<paramref name="EventType"/></returns>
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
                        index = rdr.GetOrdinal("BodyFormat");
                        x.BodyFormat = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                        index = rdr.GetOrdinal("RequestType");
                        x.RequestType = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                        index = rdr.GetOrdinal("MethodType");
                        x.MethodType = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                        eventActionList.Add(x);
                    }
                    return eventActionList;
                }
            }
         
			catch (Exception e)
			{
                logger.Error(e, "Error occured in Event DAL GetEventActionForEvent Action");
                return null;
			}
		}


        public List<EventTransaction> GetEventTransaction(String EventType , bool ShowAllTasks)
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper();

                SqlParameter[] SqlParamArray = new SqlParameter[2];
                SqlParamArray[0] = new SqlParameter("@EventTypeDescription", EventType);
                SqlParamArray[1] = new SqlParameter("@ShowAllTasks", ShowAllTasks);

                List<EventTransaction> EventTransactionList = new List<EventTransaction>();
                using (SqlDataReader rdr = sqlHelper.ExecuteDataReader(SQLQueriesConstants.sp_GetTransactionDetails, SqlParamArray))
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
                        x.ObjectData = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                        EventTransactionList.Add(x);
                        index = rdr.GetOrdinal("CreatedDate");
                        x.CreatedDate = !rdr.IsDBNull(index) ? rdr.GetDateTime(index) : DateTime.MinValue;
                        x.CreatedDateString = x.CreatedDate.ToShortDateString();
                        index = rdr.GetOrdinal("LastModifiedDate");
                        x.LastModifiedDate = !rdr.IsDBNull(index) ? rdr.GetDateTime(index) : DateTime.MinValue;
                        x.LastModifiedDateString = x.LastModifiedDate.ToShortDateString();
                    }
                    
                    return EventTransactionList;
                }
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in Event DAL GetEventTransaction Action");               
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
                logger.Error(e, "Error occured in Event DAL GetEventTransaction Action");
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
                    index = rdr.GetOrdinal("DisplayParameters");
                    eventType.DisplayParameters = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;

                }
                return eventType;
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in Event DAL GetEventTransaction Action");
                throw;
            }


        }


        public bool UpdateTransactionStatus(int transactionId)
        {
            try
            {
                SqlParameter[] SqlParamArray = new SqlParameter[1];
                SqlParamArray[0] = new SqlParameter("@EventTransactionId", transactionId);

                SqlHelper sqlHelper = new SqlHelper();

                sqlHelper.ExecuteNonQuery(DataAccess.SQLQueriesConstants.sp_UpdateTransactionStatus, SqlParamArray);
                return true;
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in Event DAL GetEventTransaction Action"); 
                return false;
            }
        }


        /// <summary>
        /// Returns a list of Event types for the given user permissions
        /// </summary>
        /// <param name="userName">String </param>
        /// <returns>List of EventType objects</returns>
        public List<EventType> GetEventTypeForUser(String userName)
        {
            try
            {
                SqlParameter[] SqlParamArray = new SqlParameter[1];
                SqlParamArray[0] = new SqlParameter("@Username", userName);
                List<EventType> eventTypeList = new List<EventType>();

                SqlHelper sqlHelper = new SqlHelper();
                using (SqlDataReader rdr = sqlHelper.ExecuteDataReader(DataAccess.SQLQueriesConstants.sp_GetEventTypeForUser, SqlParamArray))
                {
                    while (rdr.Read())
                    {
                        EventType x = new EventType();
                        int index = rdr.GetOrdinal("EventTypeDescription");
                        x.EventTypeDescription = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                        eventTypeList.Add(x);
                    }
                    return eventTypeList;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }


        /// <summary>
        /// Authorizes a user for Login
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ValidateLogin(Users user)
        {
            try
            {
                SqlParameter[] SqlParamArray = new SqlParameter[3];
                SqlParamArray[0] = new SqlParameter("@username", user.UserName);
                SqlParamArray[1] = new SqlParameter("@password", user.Password);

                SqlParamArray[2] = new SqlParameter("@ret", System.Data.SqlDbType.Int);
                SqlParamArray[2].Direction = System.Data.ParameterDirection.Output;
                SqlHelper sqlHelper = new SqlHelper();

                sqlHelper.ExecuteNonQuery(DataAccess.SQLQueriesConstants.users_login, SqlParamArray);
                if (SqlParamArray[2].Value.Equals(1)) { return true; }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }





    }
}

