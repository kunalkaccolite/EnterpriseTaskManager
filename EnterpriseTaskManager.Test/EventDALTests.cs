using EnterpriseTaskManager.Common;
using EnterpriseTaskManager.DataAccess;
using EnterpriseTaskManager;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseTaskManager.Test
{
    public class EventDALTests
    {
        /// <summary>
        /// Testing the InsertEventTransaction method
        /// </summary>
        [Test]
        public void TestforCreatingEvents()
        {
            EventDAL eventDALObj = new EventDAL();
            EventTransaction eventTransactionTestObject = new EventTransaction() { EventTypeDescription="Procedure", IsResolved="Yes", ObjectData= "{\"BillId\":\"1\",\"Amount\":\"230\",\"Status\":\"Paid\",\"PatientId\":\"61\"}" , ResolvedBy="Kunal"};

            //Action
            var result = eventDALObj.InsertEventTransaction(eventTransactionTestObject);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);

        }
    }
}
