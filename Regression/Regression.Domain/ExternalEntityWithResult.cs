using System.Collections.Generic;

namespace Regression.Domain
{
    public class ExternalEntityWithResult : ExternalEntity
    {
        public ExternalEntityWithResult()
        {
            
        }

        public ExternalEntityWithResult(double result, params double[] arguments)
        {
            Result.Add("result", result);
            for(var i = 0; i < arguments.Length; i++)
            {
                var argument = arguments[i];
                Data.Add($"argument{i}", argument);
            }
        }

        public Dictionary<string, double> Result { get; set; } = new Dictionary<string, double>(); 
    }
}