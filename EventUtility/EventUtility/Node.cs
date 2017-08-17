using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventUtility
{
	public class Node
	{
		/// <summary>
		/// defines the node class
		/// </summary>
			public Node()
			{
				Children = new List<Node>();
			}

			public string Name { get; set; }
			public List<Node> Children { get; set; }
		}
}
