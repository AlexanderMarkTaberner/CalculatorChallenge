using System.Text;

namespace CalculatorChallenge
{
    public static class Calculator
    {
        public static double Calculate(string userInput)
        {
            RemoveWhitespace(userInput);
            var postfixUserInput = ParseToPostfix(userInput);
            var result = ResolvePostfix(postfixUserInput);
            return result;
        }

        private static Queue<string> ParseToPostfix(string userInput)
        {
            //Shunting yard algorithm
            var operations = new Stack<char>();
            var output = new Queue<string>();
            var numberbuffer = new StringBuilder();
            var operatorFlag = false;

            foreach(var character in userInput)
            {
                if (char.IsDigit(character) || character == '.' || (operatorFlag && character=='-'))
                {
                    numberbuffer.Append(character);
                    operatorFlag = false;
                }
                else if ("+-*/^".Contains(character))
                {
                    if (operatorFlag) throw new ArgumentException("Command not valid math. Too many subsequent operators.");
                    if (numberbuffer.Length > 0)
                    {
                        output.Enqueue(numberbuffer.ToString());
                        numberbuffer.Clear();
                    }

                    switch (character)
                    {
                        case '^':
                            operations.Push('^');
                            break;
                        case '*':
                            while(operations.TryPeek(out var topOfStack) && topOfStack == '^')
                            {
                                output.Enqueue(operations.Pop().ToString());
                            }
                            operations.Push('*');
                            break;
                        case '/':
                            while (operations.TryPeek(out var topOfStack) && topOfStack == '^')
                            {
                                output.Enqueue(operations.Pop().ToString());
                            }
                            operations.Push('/');
                            break;
                        case '+':
                            while (operations.TryPeek(out var topOfStack) && "*/^".Contains(topOfStack))
                            {
                                output.Enqueue(operations.Pop().ToString());
                            }
                            operations.Push('+');
                            break;
                        case '-':
                            while (operations.TryPeek(out var topOfStack) && "*/^".Contains(topOfStack))
                            {
                                output.Enqueue(operations.Pop().ToString());
                            }
                            operations.Push('-');
                            break;
                        default:
                            throw new ArgumentException($"Command not valid. Operand {character} not recognised.");
                        }
                    operatorFlag = true;
                }
                else if ("()".Contains(character))
                {
                    if (numberbuffer.Length > 0)
                    {
                        output.Enqueue(numberbuffer.ToString());
                        numberbuffer.Clear();
                    }

                    if (character == '(')
                    {
                        operations.Push('(');
                        operatorFlag = true;
                    }
                    else
                    {
                        while(operations.TryPeek(out var topOfStack) && topOfStack != '(')
                        {
                            output.Enqueue(operations.Pop().ToString());
                        }
                        operations.Pop();
                        if(operations.Count > 0) output.Enqueue(operations.Pop().ToString());
                        operatorFlag = false;
                    }
                    
                } 
                else
                {
                    throw new ArgumentException($"Command not valid.");
                }
            }

            if (numberbuffer.Length > 0)
            {
                output.Enqueue(numberbuffer.ToString());
                numberbuffer.Clear();
            }

            while (operations.Count > 0)
            {
                output.Enqueue(operations.Pop().ToString());
            }
            return output;
        }

        private static double ResolvePostfix(Queue<string> postfix)
        {
            var calculation = new Stack<double>();

            foreach (string operationNumber in postfix)
            {
                // If the token is a number, push it onto the stack
                if (double.TryParse(operationNumber, out double number))
                {
                    calculation.Push(number);
                }
                else
                {
                    var math = new MathFunction(calculation.Pop(), calculation.Pop());

                    switch (operationNumber)
                    {
                        case "^":
                            calculation.Push(math.Exponential());
                            break;
                        case "*":
                            calculation.Push(math.Multiplication());
                            break;
                        case "/":
                            calculation.Push(math.Division());
                            break;
                        case "+":
                            calculation.Push(math.Addition());
                            break;
                        case "-":
                            calculation.Push(math.Subtraction());
                            break;
                    }
                }
            }
            return calculation.Pop();
        }

        private static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
