using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManagement.Common;
using System.Configuration;

namespace PatientManagement.DataAccess
{
	public class SqlHelper : ISqlHelper
	{
		public static string ConnStrWinAuth = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
		public bool CheckInsuranceDetails(string patientId)
		{
			throw new NotImplementedException();
		}

		public bool InsertInsuranceDetails(Insurance insurance)
		{
			throw new NotImplementedException();
		}

		public bool InsertPatientEncounterDetails(PatientEncounter patient)
		{
			throw new NotImplementedException();
		}

		public bool UpdateEncounter(UpdateEncounter encounter)
		{
			throw new NotImplementedException();
		}
	}
}
