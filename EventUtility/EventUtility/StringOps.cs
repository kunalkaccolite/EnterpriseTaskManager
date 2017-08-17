using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventUtility
{
	public class StringOps
	{
		/// <summary>
		/// trims the string till the first occurence of "}"
		/// </summary>
		/// <param name="str">string</param>
		/// <returns>string</returns>
		public static string TrimBraces(String str)
		{

			try
			{
				if (str.Contains("}"))
					return str.Substring(0, str.IndexOf("}"));
				else
					return str;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		/// <summary>
		/// checks if the string contains "}}"
		/// </summary>
		/// <param name="str">string</param>
		/// <returns>bool</returns>
		public static bool containsBraces(String str)
		{
			
			return str.Contains("}}");
		}
		/// <summary>
		/// checks if the string contains "]"
		/// </summary>
		/// <param name="node">string</param>
		/// <returns>bool</returns>
		public static bool CheckBrackets(String node)
		{
			if (node.EndsWith("]")) { return true; }
			else return false;
		}
		/// <summary>
		/// trims the string till the first occurence of "["
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		public static string TrimString(String node)
		{
			try
			{
				if (node.Contains("["))
					return node.Substring(0, node.IndexOf("["));
				else return node;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		/// <summary>
		/// add the property Names of Node form list of nodes to list of strings
		/// </summary>
		/// <param name="res">List<List<Node>></param>
		/// <returns>List<String></returns>
		public static List<String> NodetoString(List<List<Node>> res)
		{
			try
			{
				List<String> nodeStr = new List<String>();
				foreach (List<Node> x in res)
				{
					nodeStr.Add(x[0].Name);
				}
				return nodeStr;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
	}
}
