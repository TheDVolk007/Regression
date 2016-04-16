using System;
using System.Collections.Generic;
using System.Data;
using Regression.Domain;

namespace Regression.Logistic.Presentation
{
    public class DataInitializer
    {
        public List<ExternalEntityWithResult> Initialize()
        {
            var rnd = new Random();
            var data = new List<ExternalEntityWithResult>();
            for(var i = 0; i < 200; i++)
            {
                var kidneySize = rnd.NextDouble() * 9;
                if(kidneySize < 2)
                    continue;

                double death;
                if(kidneySize > 5 && kidneySize < 6)
                {
                    death = rnd.Next(0, 2);
                }
                else if(kidneySize < 5)
                {
                    death = 0;
                }
                else
                {
                    death = 1;
                }

                var entry = new ExternalEntityWithResult(death, kidneySize);
                data.Add(entry);
            }

            return data;
        }
    }
}