using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EventUtility
{
	public class CallWebAPI
	{
		public class MethodCallParams
		{
			private string url;
			private string bodyJson;
			private string requestType;

			public string Url { get { return url; } set {url=value; } }

			public string BodyJson { get { return bodyJson; } set {bodyJson=value; } }

			public string RequestType { get {return requestType; } set {requestType=value; } }
		}
		/// <summary>
		/// generic method that takes object data,targetURLFormat,methodType,Parent TransactionID and Body Format and calls webAPI
		/// after generating the URL and body for it. calls the GenerateUrl method from the BuildUrl Class.
		/// </summary>
		/// <param name="ObjectData">string</param>
		/// <param name="targetURLFormat">string</param>
		/// <param name="methodType">string</param>
		/// <param name="parentTransactionId">int</param>
		/// <param name="bodyFormat">string</param>
		public void MethodCall(string ObjectData, string RequestType, string targetURLFormat, int parentTransactionId, string bodyFormat, string methodType)
		{
			BuildURL.GenerateURLResult Url = new BuildURL().GenerateUrl(ObjectData, targetURLFormat);
			string UrlResult = Url.Opt;
			if (UrlResult.Contains("{{") || UrlResult.Contains("}}"))
			{
				//log 
			}
			Node root = Url.Res;
			String bodyJSON="";
			if (bodyFormat != null)
			{
				Dictionary<string, string> body = new Dictionary<string, string>();
				Dictionary<string, string> body1 = new Dictionary<string, string>();
				body = JsonToDictionary.DictionatryBuilder(bodyFormat);
				body.Remove("parentTransactionId");

				foreach (string key in body.Keys)
				{
					body1.Add(key, new KeyValueSearch().KeyNode(key, root).Children.First().Name);
				}
				body1.Add("parentTransactionId", parentTransactionId.ToString());
				bodyJSON = new Event().SerializeObject(body1);
			}

			try
			{
				if (methodType != "API")
				{
					Process.Start(UrlResult);
				}
				else
				{
					MethodCallParams param = new MethodCallParams();
					param.Url = UrlResult;
					param.BodyJson = bodyJSON;
					param.RequestType = RequestType;
					ApiCall(param);
					
				}
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="param"></param>
		public void ApiCall(MethodCallParams param)
		{
			 

			try
			{
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri(param.Url);
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpResponseMessage response = new HttpResponseMessage();
					switch(param.RequestType)
						{
							case  "GET" : response = client.GetAsync(param.Url).Result; break;
							default : response =  client.PostAsJsonAsync("", param.BodyJson).Result; break;
						} 
					
					if (response.IsSuccessStatusCode)
					{
						
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
