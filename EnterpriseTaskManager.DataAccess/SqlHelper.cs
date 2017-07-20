
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
	public class SqlHelper
	{
		//public const string ConnStrWinAuth= "Data Source=KUKI-DEL-19;Initial Catalog=StockMarket;User ID=testLogin;Password=testPassword";
		public static string ConnStrWinAuth = ConfigurationManager.ConnectionStrings["EventDB_ConnectionString"].ConnectionString;
		public  bool TestConnection()
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(ConnStrWinAuth))
				{
					conn.Open();
					Console.WriteLine(conn.ConnectionTimeout);
					Console.WriteLine(conn.DataSource);
					Console.WriteLine(conn.Database);
					Console.WriteLine(conn.ConnectionString);
					return true;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return false;
			}
		}


		public List<EventAction> GetEventActionForEvent(String EventType)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(ConnStrWinAuth))
				{
					conn.Open();
					SqlCommand command = new SqlCommand("sp_GetActionListForEventType", conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter param = command.Parameters.AddWithValue("@EventTypeDescription", EventType);
                    List<EventAction> eventActionList = new List<EventAction>();
					using (SqlDataReader rdr = command.ExecuteReader())
					{
						while (rdr.Read())
						{
							EventAction x = new EventAction();
							//int index = rdr.GetOrdinal("EventTypeID");
							//x.EventTypeID = !rdr.IsDBNull(index) ? rdr.GetInt32(index) : 0;
							int index = rdr.GetOrdinal("ActionType");
							x.ActionType = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
							index = rdr.GetOrdinal("TargetURL");
							x.TargetURL = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
							//index = rdr.GetOrdinal("TargetInputObjectType");
							//x.TargetInputObjectType = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;


							eventActionList.Add(x);
						}
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
                using (SqlConnection conn = new SqlConnection(ConnStrWinAuth))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("sp_GetTransactionDetails", conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    List<EventTransaction> EventTransactionList = new List<EventTransaction>();
                    using (SqlDataReader rdr = command.ExecuteReader())
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


                            EventTransactionList.Add(x);
                        }
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


       
    }
}

