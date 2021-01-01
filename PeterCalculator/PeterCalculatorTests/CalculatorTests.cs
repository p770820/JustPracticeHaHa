using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeterCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterCalculator.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var calculator = new Calculator();
            int actual = 2;

            // Act
            var expected = calculator.Add(1, 1);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}