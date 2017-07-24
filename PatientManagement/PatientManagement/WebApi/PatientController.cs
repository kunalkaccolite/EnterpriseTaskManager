using PatientManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PatientManagement.WebApi
{
    public class PatientController : ApiController
    {
        HospitalMangement hmObj = new HospitalMangement();

        public void Post([FromBody]PatientEncounter patient)
        {
            hmObj.InsertPatient(patient);
            return;
        }

        public Object Get([FromBody]string PatientId)
        {
            var patientDetatil = hmObj.GetPatientDetails(PatientId);
            return patientDetatil;
        }

    }
}
