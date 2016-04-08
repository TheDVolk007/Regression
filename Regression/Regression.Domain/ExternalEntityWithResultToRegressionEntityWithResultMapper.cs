using System.Collections.Generic;
using System.Linq;

namespace Regression.Domain
{
    public class ExternalEntityWithResultToRegressionEntityWithResultMapper
    {
        public List<RegressionEntityWithResult> Map(List<ExternalEntityWithResult> sourse)
        {
            var result = new List<RegressionEntityWithResult>();
            var arguments = sourse.SelectMany(e => e.Data.Select(kvp => kvp.Key)).Distinct().ToList();
            var resultArg = sourse.SelectMany(e => e.Result.Select(kvp => kvp.Key)).Distinct().ToList();

            foreach (var entity in sourse)
            {
                var resultEntity = new RegressionEntityWithResult
                {
                    Label = entity.Label
                };

                foreach(var argument in arguments)
                {
                    double value;
                    resultEntity.Arguments.Add(entity.Data.TryGetValue(argument, out value) ? value : 0);
                }

                foreach (var argument in resultArg)
                {
                    double value;
                    resultEntity.Result.Add(entity.Result.TryGetValue(argument, out value) ? value / 1000 : 0);     //dividing by 1000 to roughly normalize data
                }

                result.Add(resultEntity);
            }

            return result;
        } 
    }
}