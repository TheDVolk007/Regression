using System.Collections.Generic;

namespace Regression
{
    public class RegressionEntityWithResult : RegressionEntity
    {
        public List<double> Result { get; set; } = new List<double>();
    }
}