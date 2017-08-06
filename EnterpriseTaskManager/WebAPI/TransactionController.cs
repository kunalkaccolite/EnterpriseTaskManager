using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EnterpriseTaskManager.WebAPI
{
    public class TransactionController : ApiController
    {

        ETMController etmControllerObj = new ETMController();

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public bool Post([FromBody]int transactionId)
        {
            try
            {
                etmControllerObj.UpdateEventTransaction(transactionId);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}