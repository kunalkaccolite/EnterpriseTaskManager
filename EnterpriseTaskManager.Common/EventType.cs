using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseTaskManager.Common
{
	[Serializable]
	public class EventType
	{
		public int EventTypeID { get; set; }
		public string EventTypeDescription { get; set; }
		public string InputTypeObject { get; set; }
		public string OutputObjectType { get; set; }
	}
}