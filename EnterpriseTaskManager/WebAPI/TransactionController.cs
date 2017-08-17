using EnterpriseTaskManager.DataAccess;
using NLog;
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

        private ETMController etmControllerObj = new ETMController(new EventDAL());

        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Updating the Event Transction as Resolved
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        // POST api/Transaction

        public bool Post([FromBody]int transactionId)
        {
            try
            {
                etmControllerObj.UpdateEventTransaction(transactionId);
                return true;
            }
            catch (Exception e)
            {
                logger.Error(e, "Exception occured in Transaction Controller's UpdateEventTransaction Action");
                return false;
            }
        }

     
    }
}