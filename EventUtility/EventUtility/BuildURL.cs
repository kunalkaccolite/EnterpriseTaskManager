using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using EnterpriseTaskManager.DataAccess;

namespace EventUtility
{
	public class BuildURL
	{
	    public class GenerateURLResult
		{
			private Node res = new Node();
			private string opt = "";
			public Node Res { get { return res; } set { res = value; } }
			public string Opt { get { return opt; } set { opt = value; } }
			
		}
		/// <summary>
		/// The method takes object and BaseURL and returns a targetURL with parameters replaced with its Values
		/// </summary>
		/// <param name="ObjectData">string</param>
		/// <param name="TargetURL">string</param>
		/// <returns>string</returns>
		/// this method uses DictionaryBuilder method from the JsonToDictionary Class to convert the JSON object string 
		/// to key value pair dictionary. It parses the TargetURL Type to get the keys to be replaced with its values.
		/// for every key from the target URl type this function searches for its value in the Object Data dictionary
		/// and replaces the same in the url to generate a final URL
		public GenerateURLResult GenerateUrl(String ObjectData, String TargetURL)
		{
			string modObjectData = String.Format("{{\"root\":{0}}}",ObjectData);
			List <String> parameters = new List<String>();
			parameters = GetParamasToReplace(TargetURL);
			
			Dictionary<string, string> result = new Dictionary<string, string>();
			result = JsonToDictionary.DictionatryBuilder(modObjectData);
			string output=TargetURL ;
            Node ResultantNode = new Node();
			if (result.Keys.Count > 1)
			{
				BuildTree tree = new BuildTree();
				Node root = new Node();
				root = tree.TreeBuild(result);
                ResultantNode = root;

				List<List<string>> valueRes = new List<List<string>>();
				foreach (string str in parameters)
				{
					List<List<Node>> values = new List<List<Node>>();
					KeyValueSearch res = new KeyValueSearch();
					Node x = res.KeyNode(str, root);
					res.Values(x);
					values = res.result;
					valueRes.Add(StringOps.NodetoString(values));
				}
				int i = 0;

				foreach (string replace in parameters)
				{
					string toReplace = "{{" + replace + "}}";
					
						output = TargetURL.Replace(toReplace, valueRes[i][0]);
						TargetURL = output;
					
					i++;
				}
			}
			
			GenerateURLResult URL = new GenerateURLResult();
			if (parameters.Count == 0)
			{

                URL.Res = ResultantNode;
				URL.Opt = TargetURL;
				return URL;
				
			}
			else
			{
                URL.Res = ResultantNode;
                URL.Opt = output ;
				return URL;
				
			}
		}

		/// <summary>
		/// It parses the TargetURL Type to get the keys to be replaced with its values
		/// </summary>
		/// <param name="TargetUrl"></param>
		/// <returns>a list which contains the key parameters to be replaced in the Target URL type to build a final URL</returns>
		public List<string> GetParamasToReplace(string TargetUrl)
		{
			try
			{
				if (TargetUrl == "null") { return new List<string>(); }
				else
				{
					List<string> parameters = new List<string>();
					foreach (string part in TargetUrl.Split(new char[] { '{' }, StringSplitOptions.RemoveEmptyEntries))
					{
						if (StringOps.containsBraces(part)) { parameters.Add(StringOps.TrimBraces(part)); }

					}
					return parameters;
				}
			}
			catch (Exception ex)
			{

				throw;
			}

		}
		
	}
}
