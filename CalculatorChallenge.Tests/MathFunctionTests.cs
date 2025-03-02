using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CalculatorChallenge;

namespace CalculatorChallenge.Tests
{
    [TestFixture]
    public class MathFunctionTests
    {
        [Test]
        public void Addition_WithPositiveIntegers_IsExpected() {
            //Arrange
            var mathTest = new MathFunction(5, 5);

            //Act
            var result = mathTest.Addition();

            //Assert
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void Subtraction_WithPositiveIntegers_IsExpected()
        {
            //Arrange
            var mathTest = new MathFunction(5, 5);

            //Act
            var result = mathTest.Subtraction();

            //Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Multiplication_WithPositiveIntegers_IsExpected()
        {
            var mathTest = new MathFunction(5, 5);

            //Act
            var result = mathTest.Multiplication();

            //Assert
            Assert.That(result, Is.EqualTo(25));
        }

        [Test]
        public void Division_WithPositiveIntegers_IsExpected()
        {
            var mathTest = new MathFunction(5, 5);

            //Act
            var result = mathTest.Division();

            //Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Division_WithZero_ThrowsException()
        {
            var mathTest = new MathFunction(5, 0);

            //Act & Assert
            Assert.Throws<DivideByZeroException>(() => mathTest.Division());
        }

        [Test]
        public void Exponent_WithPositiveIntegers_IsExpected()
        {
            var mathTest = new MathFunction(5, 5);

            //Act
            var result = mathTest.Exponential();

            //Assert
            Assert.That(result, Is.EqualTo(3125));
        }

        [Test]
        public void Exponent_WithZeroInteger_IsExpected()
        {
            var mathTest = new MathFunction(0, 5);

            //Act
            var result = mathTest.Exponential();

            //Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Exponent_WithZeroExponent_IsExpected()
        {
            var mathTest = new MathFunction(5, 0);

            //Act
            var result = mathTest.Exponential();

            //Assert
            Assert.That(result, Is.EqualTo(1));
        }
    }
}
