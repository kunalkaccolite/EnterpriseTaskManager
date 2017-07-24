using PatientManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PatientManagement.WebApi
{
    public class InsuranceController : ApiController
    {
        
               HospitalMangement hmObj = new HospitalMangement();
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new List<string> { "value1", "value2" }; 
        }

        // GET api/<controller>/5
        public string Get(string id)
        {
            var json = hmObj.GetInsuranceDetails(id);
            return json;
            
            
        }

  
        public void Post([FromBody]Insurance insurance)
        {

            HospitalMangement hmObj = new HospitalMangement();
            hmObj.InsertInsurance(insurance);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Insurance insurance)
        {
            HospitalMangement hmObj = new HospitalMangement();
            hmObj.UpdateInsuranceDetails(insurance);

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        [HttpPost]
        public void InsertInsurance(String patientid)
        {
            Insurance insurance = new Insurance() { PatientId = patientid, CreatedBy = "payal" };
              hmObj.InsertInsurance(insurance);
        }

        [HttpPost]
        public bool CheckIfInsuranceExists(String PatientId)
        {
            return hmObj.CheckInsuranceDetails(PatientId);
        }
    }
}