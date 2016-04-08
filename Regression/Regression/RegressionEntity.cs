using System.Collections.Generic;

namespace Regression
{
    public class RegressionEntity
    {
        public List<double> Arguments { get; set; } = new List<double>(); 

        public string Label { get; set; }
    }
}