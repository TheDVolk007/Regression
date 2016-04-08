using System;
using System.Collections.Generic;
using System.Linq;

namespace Regression
{
    public class LinearRegression
    {
        private readonly int numFeatures;
        private Random rnd;
        private List<double> weights;

        public double LearningRate { get; set; } = 0.0000001d;

        public LinearRegression(int numFeatures)
        {
            rnd = new Random();
            if(numFeatures <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numFeatures));
            }

            this.numFeatures = numFeatures;

            weights = new List<double>(numFeatures + 1);
            for(var i = 0; i < numFeatures + 1; i++)
            {
                weights.Add(0);
            }
        }

        public void Train(List<RegressionEntityWithResult> data)
        {
            const int numIterations = 1500; // TODO: replace it with more graceful solution, perhaps when the changes become too low, break the iteration

            for (var i = 0; i < numIterations; i++)
            {
                foreach (var entry in data)
                {
                    SingleDataTraining(entry);
                }
            }
        }

        public void SingleDataTraining(RegressionEntityWithResult data)
        {
            // TODO: fix bug with bias weight
            var tempWeights = new List<double>(weights.Count);
            var hypothesis = ComputeHypothesis(data);
            var predictionError = hypothesis - data.Result.First();
            tempWeights.AddRange(weights.Select(w => w - LearningRate / 1.0d * data.Arguments.Select(a => a * predictionError).Sum()));

            weights = tempWeights;
        }

        public double ComputeHypothesis(RegressionEntity data)
        {
            var h = 0.0;
            h += weights[0];    //bias
            for(var i = 0; i < weights.Count - 1; i++)
            {
                h += weights[i + 1] * data.Arguments[i];
            }

            return h;
        }
    }
}