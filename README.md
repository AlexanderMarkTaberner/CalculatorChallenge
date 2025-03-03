# CalculatorChallenge

CalculatorChallenge is an implementation of a programming interview challenge.
This Branch is specifically for deployment in an AWS Lambda envionment.

## Installation

CalculatorChallenge is built on C# .NET Standard 8 and Visual Studio 2022 Community Edition.
Both can be obtained through: https://visualstudio.microsoft.com/vs/

If you have the AWS lambda dotnet extenisons installed you can package the application with
```Powershell
dotnet lambda package
```
The produced .Zip file can be uploaded to AWS lambdas or used in a pipelie with Terraform to deploy.

You can install the AWS Lambda tool with
```Powershell
dotnet tool install -g Amazon.Lambda.Tools
```

## Usage

The argument must be a syntaxicly correct mathematical formula in a string format.
There is support for:
* Rational numbers (Negitive, Positive, Decimal)
* Addition, Subtraction, Division, Multiplication, Exponents
* Parenthises
