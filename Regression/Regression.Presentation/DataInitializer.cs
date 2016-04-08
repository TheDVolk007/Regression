using System;
using System.Collections.Generic;
using Regression.Domain;

namespace Regression.Presentation
{
    public class DataInitializer
    {
        private readonly Random rnd;

        public DataInitializer()
        {
            rnd = new Random();
        }

        public List<ExternalEntityWithResult> Initialize()
        {
            var data = new List<ExternalEntityWithResult>();
            AddData(data, 1000);

            return data;
        }

        private void AddData(List<ExternalEntityWithResult> dataList, int dataAmount)
        {
            double size = 30; //sqared meters
            for(var i = 0; i < dataAmount; i++)
            {
                var houseData = new ExternalEntityWithResult();
                houseData.Data.Add("size", size);
                houseData.Result.Add("price", LinearFunction(size));
                houseData.Label = $"house#{i}";
                dataList.Add(houseData);

                var step = rnd.NextDouble();
                size += step;
            }
        }

        private double LinearFunction(double x)
        {
            var bias = rnd.Next(80000, 150000);
            var coefficient = rnd.Next(50, 70);
            return x * coefficient + bias;
        }

        private double NonLinearFunctionWithSqrtDependency(double x)
        {
            var bias = rnd.Next(80000, 150000);
            var coefficient = rnd.Next(50, 70);
            return x * Math.Sqrt(x) * coefficient + bias;
        }
    }
}