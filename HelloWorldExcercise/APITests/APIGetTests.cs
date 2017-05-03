using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileAccess;
using Microsoft.Extensions.Options;
using Moq;
using HelloWorldAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using HelloWorldModels;

namespace DALTests
{
    [TestClass]
    public class APIGetTests
    {
        private readonly HelloWorldFile _helloWorldFile;
        private readonly WorldMessageController _messageController;

        public APIGetTests()
        {
            var mock = new Mock<IOptions<FileOptions>>();
            mock.Setup(option => option.Value).Returns(() => new FileOptions() { FileName = @"Data\HelloWorldMessages.csv" });
            _helloWorldFile = new HelloWorldFile(mock.Object);
            _messageController = new WorldMessageController(_helloWorldFile);
        }

        [TestMethod]
        public void GetReturnsNoMessage()
        {
            var message = _messageController.Get("3") as OkObjectResult;

            Assert.IsNotNull(message, "Message is null");
            Assert.IsTrue(message.StatusCode == 200, "StatusCode is not 200");
            Assert.IsNull(message.Value, "Message value is not null");
        }

        [TestMethod]
        public void GetFirstMessage()
        {
            var message = _messageController.Get() as OkObjectResult;

            Assert.IsNotNull(message, "Message is null");
            Assert.IsTrue(message.StatusCode == 200, "StatusCode is not 200");
            Assert.AreEqual("Hello World!", ((HelloWorldMessage)message.Value).Message, true, "Message count is not greater than 0");
        }

        [TestMethod]
        public void GetFirstMessageById()
        {
            var message = _messageController.Get("1") as OkObjectResult;

            Assert.IsNotNull(message, "Message is null");
            Assert.IsTrue(message.StatusCode == 200, "StatusCode is not 200");
            Assert.AreEqual("Hello World!", ((HelloWorldMessage)message.Value).Message, true, "Message count is not greater than 0");
        }
    }
}
