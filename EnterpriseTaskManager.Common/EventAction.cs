using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseTaskManager.Common
{
	[Serializable]
	public class EventAction
	{
		public int EventTypeID { get; set; }
		public string ActionType { get; set; }
		public string TargetURL { get; set; }
		public string RequestType { get; set; }
        public string BodyFormat { get; set; }
        public string MethodType { get; set; }

	}
}