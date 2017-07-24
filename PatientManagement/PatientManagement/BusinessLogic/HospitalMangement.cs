using PatientManagement.Common;
using PatientManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

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
        public string GetInsuranceDetails(String PatientId)
        {
            var insurance = hospital.GetInsuranceDetails(PatientId);
            StringBuilder sb = new StringBuilder();
            var js = new JavaScriptSerializer();
            js.Serialize(insurance, sb);
            String json = sb.ToString();
            return json;
        }

        public string GetPatientDetails(String PatientId)
        {

            var patient = hospital.GetPatientDetails(PatientId);
            StringBuilder sb = new StringBuilder();
            var js = new JavaScriptSerializer();
            js.Serialize(patient, sb);
            String json = sb.ToString();
            return json;

        }

        public bool UpdateInsuranceDetails(Insurance insurance)
        {
            return hospital.UpdateInsuranceDetails(insurance);
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