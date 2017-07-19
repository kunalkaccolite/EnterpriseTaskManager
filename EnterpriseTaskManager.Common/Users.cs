using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseTaskManager.Common
{
	[Serializable]
	public class Users
	{
		public int UserId { get; set; }
		public string RoleDescription { get; set; }
		public string Password { get; set; }
	}
}