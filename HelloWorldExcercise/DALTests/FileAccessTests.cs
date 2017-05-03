using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileAccess;
using Microsoft.Extensions.Options;
using Moq;

namespace DALTests
{
    [TestClass]
    public class FileAccessTests
    {
        private readonly HelloWorldFile _helloWorldFile;

        public FileAccessTests()
        {
            var mock = new Mock<IOptions<FileOptions>>();
            mock.Setup(option => option.Value).Returns(() => new FileOptions() { FileName = @"Data\HelloWorldMessages.csv" });
            _helloWorldFile = new HelloWorldFile(mock.Object);
        }

        [TestMethod]
        public void ReturnNoMessage()
        {
            var result = _helloWorldFile.GetItem("3");
            Assert.IsNull(result.FirstOrDefault(), "Result is not null");
        }

        [TestMethod]
        public void ReturnAllMessages()
        {
            var result = _helloWorldFile.GetAll().ToList();
            Assert.IsTrue(result.Count > 0, "Count is not greater than zero");
        }

        [TestMethod]
        public void ReturnFirstMessage()
        {
            var testMessage = "Hello World!";
            var result = _helloWorldFile.GetItem("1").FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(testMessage, result.Message, $"First message is not {testMessage}, but is {result.Message}");
        }
    }
}
