using System;
using System.Collections.Generic;
using System.Linq;

namespace Regression.Logistic
{
    public class GaussianNormalization
    {
        /// <summary>
        /// Performs standartization of data
        /// </summary>
        /// <param name="data"></param>
        public void NormalizeData(List<List<double>> data)
        {
            var gaussianNormalizationData = GetColumnMeansAndStandartDeviations(data);
            foreach(var entry in data)
            {
                for(var index = 0; index < entry.Count; index++)
                {
                    entry[index] = (entry[index] - gaussianNormalizationData[index].Item1)
                        / gaussianNormalizationData[index].Item2;
                }
            }
        }

        private List<Tuple<double, double>> GetColumnMeansAndStandartDeviations(List<List<double>> data)
        {
            var columnsCount = data[0].Count;
            var gaussianNormalizationData = new List<Tuple<double, double>>();
            for (var i = 0; i < columnsCount; i++)
            {
                var columnMean = data.Select(e => e[i]).Average();
                var standartDeviation = Math.Sqrt(data.Select(e => e[i]).Select(e => Math.Pow(e - columnMean, 2)).Average());
                gaussianNormalizationData.Add(new Tuple<double, double>(columnMean, standartDeviation));
            }

            return gaussianNormalizationData;
        }
    }
}