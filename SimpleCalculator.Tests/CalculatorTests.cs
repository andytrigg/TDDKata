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

        [TestMethod]
        public void Add_1_ShouldBe1()
        {
            Calculator.Add("1").Should().Be(1);
        }
        
        [TestMethod]
        public void Add_1Comma2_ShouldBe3()
        {
            Calculator.Add("1,2").Should().Be(3);
        }
    }
}