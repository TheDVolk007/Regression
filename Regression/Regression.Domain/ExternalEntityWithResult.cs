using System.Collections.Generic;

namespace Regression.Domain
{
    public class ExternalEntityWithResult : ExternalEntity
    {
        public Dictionary<string, double> Result { get; set; } = new Dictionary<string, double>(); 
    }
}