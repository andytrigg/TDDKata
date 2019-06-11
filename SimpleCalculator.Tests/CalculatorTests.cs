using System;
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
        
        [TestMethod]
        public void Add_1Comma2Comma3_ShouldBe6()
        {
            Calculator.Add("1,2,3").Should().Be(6);
        }

        [TestMethod]
        public void Add_1Comma2Comma3Comma4_ShouldBe6()
        {
            Calculator.Add("1,2,3,4").Should().Be(10);
        }
        
        [TestMethod]
        public void Add_1NewLine2Comma3_ShouldBe6()
        {
            Calculator.Add("1\n2,3").Should().Be(6);
        }
        
                
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Add_InvalidInput_ShouldThrowException()
        {
            Calculator.Add("1,\n");
        }

        [TestMethod]
        public void Add_CustomerDelimiter_ShouldChangeExpectedDelimiter()
        {
            Calculator.Add("//;\n1;2").Should().Be(3);
        }
        
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Add_OneNegativeNumber_ShouldThrowException()
        {
            Calculator.Add("-1");
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Add_OneNegativeNumberOnePositiveNumber_ShouldThrowException()
        {
            Calculator.Add("1,-1");
        }
        
        [TestMethod]
        public void Add_MultipleNegativeNumbers_ShouldThrowExceptionWithMessageContainingAllNegativeNumbers()
        {
            try
            {
                Calculator.Add("-1,1,-3");
                Assert.Fail("Expected exception");
            }
            catch (ArgumentException e)
            {
                e.Message.Should().Be("-1,-3");
            }
        }

        [TestMethod]
        public void Add_NumbersLessThanOrEqualTo1000_ShouldBeIncludedInResult()
        {
            
            Calculator.Add("2,1000").Should().Be(1002);
        }
        
        [TestMethod]
        public void Add_NumbersGreaterThan1000_ShouldBeIgnoredInResult()
        {
            Calculator.Add("2,1001").Should().Be(2);
        }
        
        [TestMethod]
        public void Add_CustomerStringDelimiter_ShouldChangeExpectedDelimiter()
        {
            Calculator.Add("//[****]\n1****2****3").Should().Be(6);
        }
    }
}