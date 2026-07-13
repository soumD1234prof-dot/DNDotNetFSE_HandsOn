using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests2
    {
        private SimpleCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new SimpleCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            _calculator.AllClear();
        }

        // Subtraction tests
        [TestCase(10, 4, 6)]
        [TestCase(0, 5, -5)]
        [TestCase(-3, -3, 0)]
        [TestCase(7.5, 2.5, 5)]
        public void Subtraction_VariousInputs(double a, double b, double expected)
        {
            var result = _calculator.Subtraction(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        // Multiplication tests
        [TestCase(3, 4, 12)]
        [TestCase(0, 9, 0)]
        [TestCase(-2, 5, -10)]
        [TestCase(1.5, 2, 3)]
        public void Multiplication_VariousInputs(double a, double b, double expected)
        {
            var result = _calculator.Multiplication(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        // Division tests
        [TestCase(10, 2, 5)]
        [TestCase(9, 3, 3)]
        [TestCase(-6, 2, -3)]
        [TestCase(5, 0, 0)]
        public void Division_VariousInputs(double a, double b, double expected)
        {
            try
            {
                var result = _calculator.Division(a, b);
                Assert.That(result, Is.EqualTo(expected));
            }
            catch (ArgumentException)
            {
                Assert.Fail("Division by zero");
            }
        }

        // ---- Void method test ----
        [Test]
        public void TestAddAndClear()
        {
            var currentRes = _calculator.Addition(5, 3);
            Assert.That(currentRes, Is.EqualTo(8));

            _calculator.AllClear();

            Assert.That(_calculator.GetResult, Is.EqualTo(0));
        }
    }
}