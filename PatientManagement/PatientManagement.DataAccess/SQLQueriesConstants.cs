using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.DataAccess
{
    public static class SQLQueriesConstants
    {
		public static string sp_InsertPatientEncounterDetails = "InsertPatient_EncounterDetails";
		public static string sp_UpdateEncounter = "UpdateEncounter";
		public static string sp_InsertInsurance = "sp_InsertIntoInsurance";
		public static string sp_checkInsuranceDetails = "sp_CheckforInsuranceDetails";
		
    }
}
