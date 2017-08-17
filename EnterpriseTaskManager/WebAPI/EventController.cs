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
    public class EventController : ApiController
    {
        private  ETMController etmControllerObj = new ETMController(new EventDAL());
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // POST api/Event
        public bool Post([FromBody]string EventTransactionJSON)
        {
            try
            {
                etmControllerObj.InsertEventTransaction(EventTransactionJSON);
                return true;
            }
            catch(Exception e)
            {
                logger.Error(e, "Exception occured in Event WebAPI Post Method");
                return false;
            }

        }
    }
}