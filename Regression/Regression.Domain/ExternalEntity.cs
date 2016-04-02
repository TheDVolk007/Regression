using System.Collections.Generic;

namespace Regression.Domain
{
    public class ExternalEntity     // TODO: rename to better name
    {
        public Dictionary<string, double> Data { get; set; } = new Dictionary<string, double>();

        public string Label { get; set; }
    }
}
