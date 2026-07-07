using Moq;
using NUnit.Framework;
using CustomerCommLib;

namespace CustomerCommLib.Tests
{
    public class CustomerCommTests
    {
        [Test]
        public void SendMailToCustomer_ReturnsTrue_WhenMailSentSuccessfully()
        {
            // Arrange
            var mockMailSender = new Mock<IMailSender>();
            mockMailSender
                .Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            var customerComm = new CustomerComm(mockMailSender.Object);

            // Act
            bool result = customerComm.SendMailToCustomer();

            // Assert
            Assert.That(result, Is.True);

            mockMailSender.Verify(
                m => m.SendMail("singhroshni3211@gmail.com", "this is a test message"),
                Times.Once);
        }

        [Test]
        public void SendMailToCustomer_ReturnsFalse_WhenMailSendingFails()
        {
            // Arrange
            var mockMailSender = new Mock<IMailSender>();
            mockMailSender
                .Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(false);

            var customerComm = new CustomerComm(mockMailSender.Object);

            // Act
            bool result = customerComm.SendMailToCustomer();

            // Assert
            Assert.That(result, Is.False);

            mockMailSender.Verify(
                m => m.SendMail(It.IsAny<string>(), It.IsAny<string>()),
                Times.Once);
        }
    }
}