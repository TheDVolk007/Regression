using System.Collections.Generic;
using System.Linq;
using Regression.Domain;

namespace Regression.Logistic
{
    /// <summary>
    /// Transforms data to List of Lists of doubles form,
    /// where List of doubles is entry, and last double is the result,
    /// which needs to be predicted
    /// </summary>
    public class DataMapper
    {
        public List<List<double>> Map(List<ExternalEntityWithResult> data)
        {
            var result = new List<List<double>>();

            foreach(var entityWithResult in data)
            {
                var entry = new List<double>();
                entry.AddRange(entityWithResult.Data.Select(a => a.Value));
                entry.Add(entityWithResult.Result.Values.First());

                result.Add(entry);
            }

            return result;
        } 
    }
}