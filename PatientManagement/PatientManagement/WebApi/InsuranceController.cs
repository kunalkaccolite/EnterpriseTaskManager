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
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new List<string> { "value1", "value2" }; 
        }

        // GET api/<controller>/5
        public bool Get(string id)
        {

            Insurance insurance = new Insurance() { PlanType="liftime", InsuranceCompanyId="12345", InsuranceCompanyName="nationalInsurance", InsuredSGroupEmpId="123123", InsurancePlanId="MEdilife jivan bima", InsuredSGroupEmpName="Kunal", PatientId = id, CreatedBy = "payal" , PlanEffectiveDate=DateTime.Now, PlanExpirationDate=DateTime.Parse("12-2-2019")};
            HospitalMangement hmObj = new HospitalMangement();
            return hmObj.InsertInsurance(insurance);
            
            //HospitalMangement hmObj = new HospitalMangement();
            //return hmObj.CheckInsuranceDetails(id); ;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }


        public void Post([FromBody]Insurance insurance)
        {

            HospitalMangement hmObj = new HospitalMangement();
            hmObj.InsertInsurance(insurance);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        [HttpPost]
        public void InsertInsurance(String patientid)
        {
            Insurance insurance = new Insurance() { PatientId = patientid, CreatedBy = "payal" };
            HospitalMangement hmObj = new HospitalMangement();
            hmObj.InsertInsurance(insurance);
        }
    }
}