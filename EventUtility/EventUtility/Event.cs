using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace EventUtility
{
    public class Event
    {
        /// <summary>
        /// Serializes an object to JSON and returns its string form 
        /// </summary>
        /// <param name="serializingObject">Object</param>
        /// <returns>String</returns>
        public string SerializeObject(Object serializingObject)
       {
            StringBuilder sb = new StringBuilder();
            var js = new JavaScriptSerializer();
            js.Serialize(serializingObject, sb);
            return sb.ToString();
        }

        private const string baseUri = "http://localhost:64010/";

		/// <summary>
		/// function to create an event and send to task manager
		/// </summary>
		/// <param name="ObjectData">String</param>
		/// <param name="ObjectKey">String</param>
		/// <param name="EventType">String</param>
		/// <returns>System.Threading.Tasks.Task </returns>
		public async System.Threading.Tasks.Task CreateEventTransaction(String ObjectData,  string EventType)
        {
            EventTransaction eventTransaction = new EventTransaction() { EventTypeDescription=EventType,ObjectData=ObjectData, IsResolved="No",ResolvedBy="payal"};

            String eventTransactionJSON = SerializeObject(eventTransaction);
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response =  client.PostAsJsonAsync("api/Event/", eventTransactionJSON).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        //log success message
                        Console.WriteLine("Success");
                    }
                }
            }
            catch (Exception e)
            {
                //log 
            }
        }
		/// <summary>
		/// It is an overload of CreateEventTransaction which takes parent transactions ID
		/// to update the parent transaction status to resolved
		/// </summary>
		/// <param name="ObjectData">string</param>
		/// <param name="EventType">string</param>
		/// <param name="parentTransactionId">int</param>
		/// <returns>System.Threading.Tasks.Task</returns>
		public async System.Threading.Tasks.Task CreateEventTransaction(String ObjectData, string EventType, int parentTransactionId)
		{
			CreateEventTransaction(ObjectData, EventType);
			try
			{
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri(baseUri);
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpResponseMessage response = client.PostAsJsonAsync("api/Transaction/", parentTransactionId).Result;
					if (response.IsSuccessStatusCode)
					{
						//log success message
						Console.WriteLine("Success");
					}
				}
			}
			catch (Exception e)
			{
				//log 
			}

		}

	}
}
