using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseTaskManager.Common
{
	[Serializable]
	public class UserIDRoleIDMappings
	{
		public int UserId { get; set; }
		public int RoleId { get; set; }
	}
}