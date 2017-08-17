using EventUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApp
{
	class Program
	{
		static void Main(string[] args)
		{
			//string targetURL = "http://localhost:8080/xyz/?={{neat}}&Name";
			//string theJsonString = "{ \"sample\": {\"someitem\": {\"thesearecool\": [{\"neat\": \"wow\"},{\"neat\": \"tubular\"}]}}}";
			//string theJsonString1 = "{ \"sample\": {\"someitem\": {\"thesearecool\": [{\"neat\": \"\"},{\"neat\": \"\"}]}}}";
			//string theJsonString2 = "{\"PatientId\":\"\",\"Name\":\"\",\"Sex\":\"\"}";
			String validJsonString = "{ \"name\":, \"age\":31,\"city\":\"New York\" }";
			//EventUtility.EventGeneric y = new EventUtility.EventGeneric();
			//List<List<string>> x = new List<List<string>>();
			//x = y.GenerateUrl(theJsonString, targetURL);
			//EventUtility.KeyValueSearch test = new EventUtility.KeyValueSearch();
			//EventUtility.BuildTree tree = new EventUtility.BuildTree();
			//Dictionary<string, string> k = new Dictionary<string, string>();
			//k = EventUtility.JSONToDictionary.DictionatryBuilder(theJsonString);
			//Node w = new Node();
			//w=tree.TreeBuild(k);
			//Node q = new Node();
			//q = test.KeyNode("neat", w);
			//List<Node> e = new List<Node>();
			//test.Values(q, e);
			Dictionary<string,string> res=JsonToDictionary.DictionatryBuilder(validJsonString);
			//Dictionary<string, string> res1= JSONToDictionary.DictionatryBuilder(theJsonString1);
			foreach (KeyValuePair<string, string> k in res) { Console.WriteLine("{0}:{1}",k.Key,k.Value); }
			//foreach (KeyValuePair<string, string> k in res1) { Console.WriteLine("{0}:{1}", k.Key, k.Value); }
			//List<string> key = res1.Keys.ToList();
			//KeyValueSearch ser = new KeyValueSearch();
			
			//Console.WriteLine(ser.ReturnValue(key[1], res));
			//Console.WriteLine(y.GenerateUrl(theJsonString, targetURL).opt);
			Console.ReadKey();
			//foreach (string x in EventUtility.JSONToDictionary.DictionatryBuilder(theJsonString).Keys)
			//{ Console.WriteLine(x); }
			//Console.ReadKey();
		}
	}
}
