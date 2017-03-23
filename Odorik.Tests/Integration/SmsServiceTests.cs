using System;
using System.Linq;

using NUnit.Framework;
using Odorik.Infrastructure;
using Odorik.Models.Sms;
using Odorik.Services;

namespace Odorik.Tests.Integration
{
    /// <summary>
    /// Odorik integration tests.<see cref="FakeOdorikCredentials"/> must be set.
    /// </summary>
    [TestFixture]
    public class SmsServiceTests
    {
        [Ignore("Too expensive :-) - only manual test run")]
        [TestCase]
        public void SendSms_SendSuccessfully_Test()
        {
            var smsService = new SmsService(new FakeOdorikCredentials());

            var result = smsService.SendSms("5517", "00420774123456", "Testing message from unit test.");

            Assert.IsTrue(result > 0);
        }


        [TestCase]
        public void SendSms_InvalidSender_Test()
        {
            var exception = Assert.Throws<OdorikException>(() =>
            {
                var smsService = new SmsService(new FakeOdorikCredentials());
                smsService.SendSms("xxx", "00420774123456", "Testing message from unit test.");
            });

            Assert.AreEqual("error forbidden_sender", exception.MessageCode);
        }


        [TestCase]
        public void SendSms_InvalidRecipient_Test()
        {
            var exception = Assert.Throws<OdorikException>(() =>
            {
                var smsService = new SmsService(new FakeOdorikCredentials());
                smsService.SendSms("5517", "xxx", "Testing message from unit test.");
            });

            Assert.AreEqual("error unsupported_recipient", exception.MessageCode);
        }


        [TestCase]
        public void GetAllowedSenders_ReturnCorrectSenders_Test()
        {
            var smsService = new SmsService(new FakeOdorikCredentials());

            var result = smsService.GetAllowedSenders();

            Assert.IsTrue(result.Any());
        }


        [TestCase]
        public void GetSmsList_ReturnsSomeRecords_Test()
        {
            var smsService = new SmsService(new FakeOdorikCredentials());

            var result = smsService.GetSentSMSs(new SMSFilter { From = DateTime.Now.AddYears(-1), To = DateTime.Now });

            Assert.IsTrue(result.Any());
        }
    }
}
