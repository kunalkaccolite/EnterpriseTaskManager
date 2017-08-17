using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventUtility
{
	public class JsonToDictionary
	{	/// <summary>
	/// takes a json string as input and returns a dictionary of key value paiar
	/// </summary>
	/// <param name="theJsonString">string</param>
	/// <returns>Dictionary<string,string></returns>
		public static Dictionary<string, string> DictionatryBuilder(string theJsonString)
		{
			try
			{
				JObject jsonObject = JObject.Parse(theJsonString);
				IEnumerable<JToken> jTokens = jsonObject.Descendants().Where(p => p.Count() == 0);
				Dictionary<string, string> results = jTokens.Aggregate(new Dictionary<string, string>(), (properties, jToken) =>
				{
					properties.Add(jToken.Path, jToken.ToString());
					return properties;
				});

				return results;
			}
			catch (Exception e)
			{
				//log
				
				return new Dictionary<string, string>();
			}
		}
	}

	
}
