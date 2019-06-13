using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Add_WhenProvidedBlankString_ShouldReturnZero()
        {
            Calculator.Add("").Should().Be(0);
        }

        [TestMethod]
        public void Add_WhenProvidedTheValueOfOne_ReturnsOne()
        {
            Calculator.Add("1").Should().Be(1);
        }

        [TestMethod]
        public void Add_WhenProvidedTheValueOneCommaTwo_ReturnsThree()
        {
            Calculator.Add("1,2").Should().Be(3);
        }

        [TestMethod]
        public void Add_WhenProvidedTheValueTwoCommaTwo_ReturnsFour()
        {
            Calculator.Add("2,2").Should().Be(4);
        }
        
        [TestMethod]
        public void Add_WhenProvidedMoreThanTwoNumbers_ShouldAddAllNumbersTogether()
        {
            Calculator.Add("2,2,3,1").Should().Be(8);
        }
        
        [TestMethod]
        public void Add_WhenProvidedAStringWithLineBreak_ShouldAddAllNumbersTogether()
        {
            Calculator.Add("1\n2,3").Should().Be(6);
        }
        
        [TestMethod]
        public void Add_WhenInputDefinesACustomDelimiter_AllNumbersShouldBeAddedStill()
        {
            Calculator.Add("\\\\;\n2;3").Should().Be(5);
        }
    }
}