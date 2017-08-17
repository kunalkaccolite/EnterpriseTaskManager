using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventUtility
{
	public class KeyValueSearch
	{

		public List<List<Node>> result = new List<List<Node>>();
		List<Node> path = new List<Node>();
		/// <summary>
		/// takes a key to search for in the tree
		/// </summary>
		/// <param name="key">string</param>
		/// <param name="root">Node</param>
		/// <returns>Node</returns>
		public Node KeyNode(string key, Node root)
		{
			if (root.Name != key && root.Children.Count == 0) { return null; }
			foreach (Node x in root.Children)
			{
				Node y = x.Children.Find(n => n.Name == key);
				if (y == null) { return KeyNode(key, x); }
				else { return y; }
			}
			return null;
		}
		/// <summary>
		/// Takes the root and stores all the root to leaf path in a list
		/// </summary>
		/// <param name="root">Node</param>
		public void Values(Node root)
		{
			//path.Add(root);
			//List<Node> path = new List<Node>();
			if (root.Children.Count == 0) { result.Add(new List<Node>(path)); return; }
			
			
			foreach (Node val in root.Children)
			{

				 path.Add(val);
				 Values(val);
				path.Remove(path.Last());
								



			}

			//path.Remove(path.Last());
		}

		//public Node ValueNode(Node root, string key)
		//{
		//	if (root.Name != key && root.Children.Count == 0) { return null; }
		//	foreach (Node x in root.Children)
		//	{
		//		Node y = x.Children.Find(n => n.Name == key);
		//		if (y == null) { return KeyNode(key, x); }
		//		else { return y; }
		//	}
		//	return null;
		//}


		public string ReturnValue(string key,Dictionary<string, string> objectData)
		{
			List<string> keys = objectData.Keys.ToList();
			string keyToSearch;
			keyToSearch = keys.Find(x => x.Contains(key));
			return objectData[keyToSearch];

		}
	}
}
