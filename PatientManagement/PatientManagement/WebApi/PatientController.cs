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
        public void Post([FromBody]PatientEncounter patient)
        {

            HospitalMangement hmObj = new HospitalMangement();
            hmObj.InsertPatient(patient);
        }
    }
}
