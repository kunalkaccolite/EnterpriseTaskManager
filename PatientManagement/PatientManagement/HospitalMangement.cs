using PatientManagement.Common;
using PatientManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientManagement
{
    public class HospitalMangement
    {
        HospitalDAL hospital = new HospitalDAL();

        public bool CheckInsuranceDetails(String PatientId)
        {
            bool abc= hospital.CheckInsuranceDetails(PatientId);
            return abc;
        }

        public bool InsertInsurance(Insurance insurance)
        {
            return hospital.InsertInsuranceDetails(insurance);
        }

        public bool InsertPatient(PatientEncounter patient)
        {
            return hospital.InsertPatientEncounterDetails(patient);
        }
    }
}