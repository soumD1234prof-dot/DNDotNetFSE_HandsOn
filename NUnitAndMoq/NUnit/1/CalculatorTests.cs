using System;
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
            // Runs before every test — fresh instance each time
            _calculator = new SimpleCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            // Runs after every test — cleanup
            _calculator.AllClear();
            _calculator = null;
        }

        [Test]
        public void Addition_TwoNumbers()
        {
            var result = _calculator.Addition(2, 3);
            Assert.That(result, Is.EqualTo(5));
        }

        [TestCase(2, 3, 5)]
        [TestCase(-1, 1, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(10.5, 4.5, 15)]
        public void Addition_ManyNumbers(double a, double b, double expected)
        {
            var result = _calculator.Addition(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(5, 3, 2)]
        [TestCase(0, 5, -5)]
        [TestCase(-2, -2, 0)]
        public void Subtraction_ManyNumbers(double a, double b, double expected)
        {
            var result = _calculator.Subtraction(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(3, 4, 12)]
        [TestCase(0, 5, 0)]
        [TestCase(-2, 3, -6)]
        public void Multiplication_ManyNumbers(double a, double b, double expected)
        {
            var result = _calculator.Multiplication(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(10, 2, 5)]
        [TestCase(9, 3, 3)]
        [TestCase(-6, 2, -3)]
        public void Division_ManyNumbers(double a, double b, double expected)
        {
            var result = _calculator.Division(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Division_ByZero_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _calculator.Division(5, 0));
        }
    }
}