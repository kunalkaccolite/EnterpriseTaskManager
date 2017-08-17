using EnterpriseTaskManager.Common;
using EnterpriseTaskManager.Controllers;
using EnterpriseTaskManager.DataAccess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace EnterpriseTaskManager.Test
{
    class HomeControllerMVCTests
    {
        /// <summary>
        /// Testing for Post method with null values for certain fields
        /// </summary>
        [Test]
        public void PostEventTransactionTest()
        {
            HomeController homeControllerObject = new HomeController();

            EventTransaction eventTransactionTestObject = new EventTransaction() { EventTypeDescription = "Procedure", IsResolved = "Yes" };
            JavaScriptSerializer js = new JavaScriptSerializer();
            String EventTransctionJSON = js.Serialize(eventTransactionTestObject).ToString();

            //Action
            var result = homeControllerObject.PostEventTransaction(EventTransctionJSON);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }


        [Test]
        public void PostEventTransactionWithAllDetailsTest()
        {
            HomeController homeControllerObject = new HomeController();

            var mockSqlHelper = new Moq.Mock<IEventDAL>();
            mockSqlHelper.Setup(client => client.InsertEventTransaction(new EventTransaction())).Returns(true); 
            EventTransaction eventTransactionTestObject = new EventTransaction() { EventTypeDescription = "Procedure", IsResolved = "Yes" };
            JavaScriptSerializer js = new JavaScriptSerializer();
            String EventTransctionJSON = js.Serialize(eventTransactionTestObject).ToString();

            //Action
            var result = homeControllerObject.PostEventTransaction(EventTransctionJSON);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }
    }
}
