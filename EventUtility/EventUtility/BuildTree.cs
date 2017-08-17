using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventUtility
{
	public class BuildTree
	{

		/// <summary>
		/// Takes dictionary of key value pairs which contains keys as a hierarichal data
		/// and builds a tree which contains leaves as values
		/// </summary>
		/// <param name="json">Dictionary<String, String></param>
		/// <returns>Node</returns>
		public Node TreeBuild(Dictionary<String, String> json)
		{
			Node root = new Node();
			foreach (KeyValuePair<string, string> kvp in json)
			{
				Node parent = root;
				if (!string.IsNullOrEmpty(kvp.Key))
				{
					Node child = null;
					foreach (string part in kvp.Key.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries))
					{
						string name = part.Trim();
						name = StringOps.CheckBrackets(name) ? StringOps.TrimString(name) : name;
						child = parent.Children.Find(n => n.Name == name);
						if (child == null)
						{
							child = new Node { Name = name };
							parent.Children.Add(child);
						}
						parent = child;
					}
				}
				parent.Children.Add(new Node { Name = kvp.Value });
			}
			return root;
		}
	}
}
