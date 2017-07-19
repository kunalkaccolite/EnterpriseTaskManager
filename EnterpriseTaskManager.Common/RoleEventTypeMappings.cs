using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseTaskManager.Common
{
	[Serializable]
	public class RoleEventTypeMappings
	{
		public int RoleID { get; set; }
		public int EventTypeID { get; set; }
	}
}