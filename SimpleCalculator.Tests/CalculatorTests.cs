using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace SimpleCalculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Add_EmptyString_ShouldBeZero()
        {
            Calculator.Add("").Should().Be(0);
        }

    }
}