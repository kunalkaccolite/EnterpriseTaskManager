using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventUtility
{
	/// <summary>
	/// defines the properties create event transaction will need
	/// </summary>
   public  class EventTransaction
    {
        public String EventTypeDescription { get; set; }

        public String ObjectData { get; set; }

        public String ObjectKey { get; set; }

        public String IsResolved { get; set; }

        public String ResolvedBy { get; set; }
    }
}
