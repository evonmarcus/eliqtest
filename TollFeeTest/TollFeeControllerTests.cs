using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using TollFee.Api.Services;
using Moq;
using TollFee.Api.Controllers;
using TollFee.Api.Models;

namespace TollFeeTest
{
    [TestClass]
    public class TollFeeControllerTests
    {
        [TestMethod]
        public void get_the_fee_test()
        {
            var request = new List<DateTime>()
            {
                new DateTime(2021, 12, 1, 7, 30, 1),
                new DateTime(2021, 12, 1, 9, 30, 1),
                new DateTime(2021, 1, 1),
                new DateTime(2021, 1, 2)
            }.ToArray();

            // Arrange
            var mockRepository = new Mock<ITollService>();
            var controller = new TollFeeController(mockRepository.Object);

            // Act
            CalculateFeeResponse actionResult = controller.CalculateFee(request);

            // Assert
            Assert.IsTrue(actionResult.TotalFee == 31);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "The passed year is not yet configured!")]
        public void check_if_the_year_is_not_configured_test()
        {
            var request = new List<DateTime>()
            {
                new DateTime(2023, 12, 1, 7, 30, 1)
            }.ToArray();

            var mockRepository = new Mock<ITollService>();
            var controller = new TollFeeController(mockRepository.Object);

            CalculateFeeResponse actionResult = controller.CalculateFee(request);

        }
    }
}
