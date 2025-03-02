# CalculatorChallenge

CalculatorChallenge is an implementation of a programming interview challenge.

## Installation

CalculatorChallenge is built on C# .NET Standard 8 and Visual Studio 2022 Community Edition.
Both can be obtained through: https://visualstudio.microsoft.com/vs/

Open the solution file in the root of the project called "CalculatorChallenge.sln"
And follow the steps inside visual studio to build and run the console application.

Alternatively you can user powershell to build the project:

```Powershell
dotnet build .\CalculatorChallenge.sln
```

And run the applicaiton:

```Powershell
.\CalculatorChallenge\bin\Debug\net8.0\CalculatorChallenge.exe "2.5+2*(4-3/2)^2"
```

## Usage

The commandline argument must be a syntaxicly correct mathematical formula in a string format.
There is support for:
    * Rational numbers. (Negitive, positive, decimal)
    * Addition, Subtraction, Division, Multiplication, Exponents.
    * Parenthises.