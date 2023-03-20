using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using TollFee.Api.Services;
using Moq;
using TollFee.Api.Controllers;
using TollFee.Api.Models;
using System.Reflection;

namespace TollFeeTest
{
    [TestClass]
    public class TollFreeServiceTests
    {
        [DataRow("2021-01-15T08:13:33", false)]
        [DataTestMethod]
        public void is_toll_free_test(string passage, bool isfree)
        {
            // Arrange
            var passaged = DateTime.Parse(passage);
            // Act
            var tollFreeRes = TollFreeService.IsTollFree(passaged);

            // Assert
            Assert.IsTrue(tollFreeRes == isfree);
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
