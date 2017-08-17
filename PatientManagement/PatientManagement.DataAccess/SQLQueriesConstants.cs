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
        public static string sp_GetInsuranceDetails = "sp_GetInsuranceDetails";
        public static string sp_UpdateInsuranceDetails = "sp_UpdateInsuranceDetails";
        public static string sp_GetPatientDetails = "sp_GetPatientDetails";
        public static string sp_GetEncounterDetails = "sp_GetEncounterDetails";
        public static string sp_GetPatientEncounterDetails = "sp_GetPatientEncounterDetails";

    }
}
