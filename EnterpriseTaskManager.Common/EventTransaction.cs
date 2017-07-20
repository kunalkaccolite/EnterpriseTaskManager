using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseTaskManager.Common
{
	[Serializable]
	public class EventTransaction
	{
		public int EventTransactionID { get; set; }
		public int EventTypeID { get; set; }
		public string ObjectData { get; set; }
		public string ObjectKey { get; set; }
		public string IsResolved { get; set; }
		public string ResolvedBy { get; set; }
        public String EventTypeDescription { get; set; }
	}
}