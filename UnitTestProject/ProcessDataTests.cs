using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolverChallengue.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject
{
    [TestClass]
    public class ProcessDataTests
    {
        [TestMethod]
        public void MaxTravels_ShouldCalcMaxTravels()
        {
            //Arrange
            List<int> inputData = new List<int> {  50, 5, 50, 4 };
            inputData.Sort();
            int expected = 2;

            //Act
            int maxTravels = DataProcessingService.maxTravels(inputData);

            //Assert
            Assert.AreEqual(expected, maxTravels);
        }

        [TestMethod]
        public void MaxTravels_ShouldCalcCornerCase()
        {
            //Arrange
            List<int> inputData = new List<int> { 50, 50, 1 };
            inputData.Sort();
            int expected = 2;

            //Act
            int maxTravels = DataProcessingService.maxTravels(inputData);

            //Assert
            Assert.AreEqual(expected, maxTravels);
        }

        [TestMethod]
        public void MaxTravels_ShouldCalcSpecialCase()
        {
            //Arrange
            List<int> inputData = new List<int> { 50, 24, 1 };
            inputData.Sort();
            int expected = 1;

            //Act
            int maxTravels = DataProcessingService.maxTravels(inputData);

            //Assert
            Assert.AreEqual(expected, maxTravels);
        }
    }
}
