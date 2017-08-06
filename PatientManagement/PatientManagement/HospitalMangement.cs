using PatientManagement.Common;
using PatientManagement.DataAccess;
using EventUtility;
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
        private Event eventObj = new Event();


        String SerializeIntoJSON(object SerializerObject)
        {
            StringBuilder sb = new StringBuilder();
            var js = new JavaScriptSerializer();
            js.Serialize(SerializerObject, sb);
            return sb.ToString();
        }


        public bool CheckInsuranceDetails(String PatientId)
        {
            bool abc= hospital.CheckInsuranceDetails(PatientId);
            return abc;
        }
        public string GetInsuranceDetails(String PatientId)
        {
            var insurance = hospital.GetInsuranceDetails(PatientId);
            string json = SerializeIntoJSON(PatientId);
            return json;
        }

        public string GetPatientDetails(String PatientId)
        {

            var patient = hospital.GetPatientDetails(PatientId);
            String json = SerializeIntoJSON(patient);
            return json;

        }

        public bool UpdateEncounterStatus(String PatientId, int parentTransactionId)
        {
            var Encounter = hospital.GetEncounterDetails(PatientId);
            Encounter.Status = "Procedure";
            var result=hospital.UpdateEncounter(Encounter);
            if (result)
            {
                try
                {

                    var patient = hospital.GetPatientDetails(PatientId);
                    patient.Status = Encounter.Status;
                    var patientJSON = SerializeIntoJSON(patient);
                    eventObj.CreateEventTransaction(patientJSON, "Procedure", parentTransactionId);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
                return false;
            
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
            var IsPatientInserted= hospital.InsertPatientEncounterDetails(patient);
            if (IsPatientInserted)
            {
                try
                {
                    String patientJSON = SerializeIntoJSON(patient);
                    
                    eventObj.CreateEventTransaction(patientJSON,  "Registration");
                    return true;
                }
                catch(Exception e)
                {
                    //log exception 
                    return false;
                }
                             
            }
            return false;
            
        }
    }
}