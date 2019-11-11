using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.Json;

[assembly: LambdaSerializer(typeof(JsonSerializer))]
namespace HelloWorld
{
    public class Function
    {
        public string FunctionHandler(string input, ILambdaContext context)
        {
            return "Hello " + input;
        }
    }
}
