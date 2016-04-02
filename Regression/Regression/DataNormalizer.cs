using System;
using System.Collections.Generic;
using System.Linq;
using Regression.Domain;

namespace Regression
{
    public class DataNormalizer
    {
        public void PerformFeatureScaling(List<ExternalEntity> data)
        {
            var minmaxArguments = GetMinimalAndMaximumValuesOfArguments(data);
            for(var i = 0; i < data.Count; i++)
            {
                var entity = data[i];
                var arguments = entity.Data.Select(kvp => kvp.Key).ToList();
                for(var j = 0; j < arguments.Count; j++)
                {
                    var argument = arguments[j];
                    var value = entity.Data[argument];
                    var min = minmaxArguments[argument].Item1;
                    var max = minmaxArguments[argument].Item2;
                    var rescaledValue = (value - min) / (max - min);
                    entity.Data[argument] = rescaledValue;
                }
            }
        }

        private Dictionary<string, Tuple<double, double>> GetMinimalAndMaximumValuesOfArguments(List<ExternalEntity> data)
        {
            var arguments = data.SelectMany(e => e.Data.Select(kvp => kvp.Key)).Distinct().ToList();
            var flatennedData = arguments.ToDictionary(argument => argument, argument => new List<double>());

            foreach (var kvp in data.SelectMany(entity => entity.Data))
            {
                flatennedData[kvp.Key].Add(kvp.Value);
            }

            var minmaxArguments = new Dictionary<string, Tuple<double, double>>();
            foreach (var argument in flatennedData.Select(f => f.Key))
            {
                var min = flatennedData[argument].Min();
                var max = flatennedData[argument].Max();

                minmaxArguments.Add(argument, new Tuple<double, double>(min, max));
            }

            return minmaxArguments;
        }

        public bool CheckIfDataIsNormalized(List<ExternalEntity> data)
        {
            var minmaxArguments = GetMinimalAndMaximumValuesOfArguments(data);

            var min = minmaxArguments.Select(a => a.Value.Item1).Min();
            var max = minmaxArguments.Select(a => a.Value.Item2).Max();

            return Math.Abs(min) < 1.0 || Math.Abs(max) < 1.0;
        }
    }
}
