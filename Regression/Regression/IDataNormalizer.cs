using System.Collections.Generic;
using Regression.Domain;

namespace Regression
{
    public interface IDataNormalizer
    {
        bool CheckIfDataIsNormalized(List<ExternalEntity> data);

        void PerformFeatureScaling(List<ExternalEntity> data);
    }
}