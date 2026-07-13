using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerCommLib.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mockMailSender;
        private CustomerComm _customerComm;

        [SetUp]
        public void Setup()
        {
            // Create the fake IMailSender
            _mockMailSender = new Mock<IMailSender>();

            // Inject the fake into CustomerComm via constructor
            _customerComm = new CustomerComm(_mockMailSender.Object);
        }

        [Test]
        public void SendMailToCustomer_ValidCall_ReturnsTrue()
        {
            // Arrange: tell the mock what to return when SendMail is called
            _mockMailSender
                .Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            var result = _customerComm.SendMailToCustomer();

            Assert.That(result, Is.True);
        }
    }
}