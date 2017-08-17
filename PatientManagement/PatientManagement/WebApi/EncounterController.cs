using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PatientManagement.WebApi
{
    public class EncounterController : ApiController
    {
        HospitalMangement hmObj = new HospitalMangement();

        /// <summary>
        /// Posts d
        /// </summary>
        /// <param name="Data"></param>
        public void Post([FromBody]String Data) {
            var BodyDictionary = EventUtility.JsonToDictionary.DictionatryBuilder(Data);
            var PatientID = BodyDictionary["PatientId"];
            var parentTransactionId = BodyDictionary["parentTransactionId"];
            hmObj.UpdateEncounterStatus(PatientID, Int32.Parse(parentTransactionId));
            return ;
        }

    }
}
