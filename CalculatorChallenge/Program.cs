namespace CalculatorChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calculation = Calculator.Calculate(args[0]);
            Console.WriteLine($"The result of \"{args[0]}\" is: {calculation}");
        }
    }
}
