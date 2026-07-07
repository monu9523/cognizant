using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new SimpleCalculator();
        }

        [TearDown]
        public void Cleanup()
        {
            _calculator = null;
        }

        [TestCase(2, 3, 5)]
        [TestCase(-1, 1, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(-5, -5, -10)]
        public void Addition_VariousInputs_ReturnsExpectedSum(double a, double b, double expected)
        {
            double result = _calculator.Addition(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Subtract_TwoNumbers_ReturnsDifference()
        {
            double result = _calculator.Subtraction(5, 3);
            Assert.That(result, Is.EqualTo(2));
        }
    }
}