using Amazon.Lambda.Core;

// Assembly attribute to enable Lambda function logging
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace CalculatorChallenge;

public class CalculationRequest
{
    public string Formula { get; set; }
}

public class CalculationHandler
{
    public async Task<string> HandleRequest(CalculationRequest formula, ILambdaContext context)
    {
        try
        {
            var result = await Calculator.CalculateAsync(formula.Formula);

            context.Logger.LogInformation($"Successfully processed calculation \"{formula.Formula}\" with result \"{result}\".");
            return result.ToString();
        }
        catch (Exception ex)
        {
            context.Logger.LogError($"Failed to process formula: {ex.Message}");
            throw;
        }
    }
}