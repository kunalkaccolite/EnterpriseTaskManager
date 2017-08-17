using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Common
{
	public class PatientEncounter
	{
		public string PatientId { get; set; }
		public string Name { get; set; }
		public string Sex { get; set; }
		public string Address { get; set; }
		public string PhoneNo { get; set; }
        public int EncounterId { get; set; }
		public string DoctorId { get; set; }
		public string Status { get; set; }
		public string CreatedBy { get; set; }
		public DateTime DOB { get; set; }
		public int ProcedureCode { get; set; }
	}
}
