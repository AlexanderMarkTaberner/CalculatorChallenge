using Amazon.Lambda.Core;
using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;
using System.Text.Json.Serialization;
using Amazon.Lambda.APIGatewayEvents;
using System.Text.Json;

// Assembly attribute to enable Lambda function logging
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace CalculatorChallenge;

public class CalculationHandler
{
    public class Calculation
    {
        public string Formula { get; set; } = string.Empty;
    }

    public async Task<string> HandleRequest(APIGatewayProxyRequest request, ILambdaContext context)
    {
        try
        {
            var formula = JsonSerializer.Deserialize<Calculation>(request.Body, 
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true}
            );
            context.Logger.LogInformation($"Attempting to calculate {formula.Formula}.");
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