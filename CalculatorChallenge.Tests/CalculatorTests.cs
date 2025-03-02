using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorChallenge.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void ParseToPostfix_WithValidInput_IsExpected()
        {
            //Arrange
            var input = "5+5-3/(2+4^3)*6^1";

            var expectedResult = new Queue<string>(
                new string[] {
                    "5","5","+","3","2","4","3","^","+","/","6","1","^","*","-"
                }
            );

            //Act
            var result = Calculator.ParseToPostfix(input);

            //Assert
            Assert.That(result.ToString(), Is.EqualTo(expectedResult.ToString()));
        }

        [Test]
        public void ResolvePostfix_WithValidInput_IsExpected()
        {
            //Arrange
            var input = new Queue<string>(
                new string[] {
                    "5","5","+","3","2","4","3","^","+","/","6","1","^","*","-"
                }
            );

            double expectedResult = 9.7272727272d;

            //Act
            var result = Calculator.ResolvePostfix(input);

            //Assert
            Assert.That(Math.Round(result), Is.EqualTo(Math.Round(expectedResult)));
        }
    }
}
