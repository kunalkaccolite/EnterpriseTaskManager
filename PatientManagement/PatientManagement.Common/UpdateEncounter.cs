﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Common
{
	public class UpdateEncounter
	{
		public int EncounterId { get; set; }
        public string patientId { get; set; }
        public string DoctorId { get; set; }

		public string Status { get; set; }
		public String UpdatedBy { get; set; }
	}
}
