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
    public class TollFeeServiceTests
    {
        [DataRow(new string[] { "2021-01-15T06:10:33" }, 9)]
        [DataRow(new string[] { "2021-01-15T06:20:33", "2021-01-15T08:10:33" }, 25)]
        [DataRow(new string[] { "2021-01-15T08:13:33", "2021-01-16T07:32:54", "2021-01-16T17:04:07" }, 16)]
        [DataTestMethod]
        public void get_toll_fee_for_the_day_test(string[] passage, int fee)
        {
            var dateArray= new DateTime[passage.Length];
            // Arrange
            for (int i = 0; i < passage.Length; i++)
            {
                dateArray[i] = DateTime.Parse(passage[i]);
            }
            // Act
            var tollFreeRes = TollFeeService.GetTollFeeForTheDay(dateArray);
            Console.WriteLine(tollFreeRes);

            // Assert
            Assert.IsTrue(tollFreeRes == fee);
        }

        [DataRow(new string[] { "2021-01-15T06:10:33" }, 9)]
        [DataRow(new string[] { "2021-01-15T06:20:33", "2021-01-15T07:10:33" }, 22)]
        [DataRow(new string[] { "2021-01-15T08:13:33", "2021-01-15T07:32:54", "2021-01-15T09:04:07" }, 22)]
        [DataTestMethod]
        public void get_highest_fee_for_the_hour(string[] passage, int fee)
        {
            var dateArray = new DateTime[passage.Length];
            // Arrange
            for (int i = 0; i < passage.Length; i++)
            {
                dateArray[i] = DateTime.Parse(passage[i]);
            }
            // Act
            var tollFreeRes = TollFeeService.GetTollFeeForTheDay(dateArray);
            Console.WriteLine(tollFreeRes);

            // Assert
            Assert.IsTrue(tollFreeRes == fee);
        }


        [DataRow( "2021-01-15T08:10:33", 16)]
        [DataRow( "2021-01-15T07:15:33", 22)]
        [DataRow( "2021-01-15T15:40:33", 22)]
        [DataTestMethod]
        public void get_fee_for_the_time_test(string passage, int fee)
        {
            // Arrange
            var passed = DateTime.Parse(passage);

            // Act
            var tollFreeRes = TollFeeService.GetFeeForTheTime(passed);
            Console.WriteLine(tollFreeRes);

            // Assert
            Assert.IsTrue(tollFreeRes == fee);
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
