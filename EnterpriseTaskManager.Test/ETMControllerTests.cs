using EnterpriseTaskManager.Common;
using EnterpriseTaskManager.DataAccess;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace EnterpriseTaskManager.Test
{
    class ETMControllerTests
    {

        /// <summary>
        /// Check if proper JSONstring is generated when data is  proper
        /// </summary>
        [Test]
        public void EventTypeDetails_ValidEventType_JsonString ()
        {
            //Arrange
            var eventDAL = new Moq.Mock<IEventDAL>();
            var eventTypeDetails = new EventType() { EventTypeID = 1, EventTypeDescription = null, DisplayParameters = "ABC:Value" };

            eventDAL.Setup(x => x.EventTypeDetails(It.IsAny<string>())).Returns(eventTypeDetails);


            String JSONString = "{\"EventTypeID\":1,\"EventTypeDescription\":null,\"DisplayParameters\":\"ABC:Value\"}";
            IEtmController etmControllerObject = new ETMController(eventDAL.Object);
          
            //Action
            var result = etmControllerObject.EventTypeDetails(JSONString);

            //Assert
             Assert.That(result, Is.EqualTo(JSONString));
            
        }


        /// <summary>
        /// Check for getting event details when null object is sent
        /// </summary>
        [Test]
        public void EventTypeDetails_NullEventType_JsonString()
        {
            //Arrange
            var eventDAL = new Moq.Mock<IEventDAL>();
            var eventTypeDetails = new EventType() { EventTypeID = 1, EventTypeDescription = null, DisplayParameters = "ABC:Value" };

            eventDAL.Setup(x => x.EventTypeDetails(It.IsAny<string>()));


            String JSONString = "{\"EventTypeID\":1,\"EventTypeDescription\":null,\"DisplayParameters\":\"ABC:Value\"}";
            IEtmController etmControllerObject = new ETMController(eventDAL.Object);

            //Action
            var result = etmControllerObject.EventTypeDetails(null);

            //Assert
            Assert.That(result, Is.EqualTo("null"));
        }


        [Test]
        public void ValidateLogin_ValidUser_true()
        {
            var eventDAL = new Moq.Mock<IEventDAL>();
            Users validUser = new Users() { UserName = "payal", Password = "1234" };
            eventDAL.Setup(x => x.ValidateLogin(It.IsAny<Users>())).Returns(true);
            IEtmController etmControllerObject = new ETMController(eventDAL.Object);


            //Act
            var result=etmControllerObject.ValidateLogin("payal", "1234");

            //Assert
            Assert.That(result, Is.EqualTo(true));
        }


    }
}
