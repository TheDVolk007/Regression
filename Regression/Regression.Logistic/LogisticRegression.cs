using System;
using System.Collections.Generic;
using System.Linq;

namespace Regression.Logistic
{
    public class LogisticRegression
    {
        private int numFeatures;    // TODO: get rid of this fiel, initialize weights at the begining of train
        private List<double> weights = new List<double>();
        private Random rnd;

        public LogisticRegression(int numFeatures)
        {
            this.numFeatures = numFeatures;
            weights.Add(0);
            for(var i = 0; i < numFeatures; i++)
            {
                weights.Add(0);
            }
        }

        public double ComputeRawHypothesis(List<double> entry)
        {
            var z = 0d;
            z += weights[0];
            for(var i = 0; i < entry.Count - 1; i++)
            {
                z += weights[i + 1] * entry[i];
            }

            return 1.0 / (1.0 + Math.Exp(-z));
        }

        public double ComputeHypothesis(List<double> entry, double threshold = 0.5)
        {
            var rawHypothesis = ComputeRawHypothesis(entry);
            return rawHypothesis <= threshold ? 0 : 1;
        }

        public double ComputeAccuracy(List<List<double>> data)
        {
            var correctCount = 0;
            var wrongCount = 0;
            foreach(var entry in data)
            {
                var predicted = ComputeHypothesis(entry);
                var granted = entry.Last();

                if(Math.Abs(predicted - granted) < double.Epsilon)
                {
                    correctCount++;
                }
                else
                {
                    wrongCount++;
                }
            }

            return correctCount * 1.0 / (correctCount + wrongCount);
        }

        public double ComputeMeanSquaredError(List<List<double>> data)
        {
            var sumSquaredError = 0d;
            foreach(var entry in data)
            {
                var predicted = ComputeHypothesis(entry);
                var granted = entry.Last();

                sumSquaredError += (predicted - granted) * (predicted - granted);
            }

            return sumSquaredError / data.Count;
        }

        public void Train(List<List<double>> trainDataList)
        {
            foreach(var trainEntry in trainDataList)
            {
                trainEntry.Insert(0, 1);        // bias signal
            }


        }

        private Tuple<double, List<double>> ComputeCostFunction(List<List<double>> dataList)
        {
            var entriesAmount = dataList.Count;
            var grad = new List<double>();
            grad.AddRange(weights.Select(w => 0d));

            var hypothesises = dataList.Select(ComputeRawHypothesis).ToList();
            var realValues = dataList.Select(entry => entry.Last()).ToList();

            var positiveHalf = hypothesises.Select((h, i) => Math.Log(h) * (-realValues[i])).ToList();
            var negativeHalf = hypothesises.Select((h, i) => Math.Log(1 - h) * (1 - realValues[i])).ToList();
            var cost = 1.0 / entriesAmount * positiveHalf.Select((v, i) => v - negativeHalf[i]).Sum();

            for(var i = 0; i < weights.Count; i++)
            {
                var k = i; //escaping closure
                var xs = dataList.Select(entry => entry[k]).ToList();

                grad[i] = hypothesises.Select((h,j) => h - realValues[j]).Select((v, j) => v * xs[j]).Sum() / entriesAmount;
            }

            return new Tuple<double, List<double>>(cost, grad);
        }
    }
}