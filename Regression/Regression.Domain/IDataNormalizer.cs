using System.Collections.Generic;

namespace Regression.Domain
{
    public interface IDataNormalizer
    {
        bool CheckIfDataIsNormalized(List<ExternalEntity> data);

        void PerformFeatureScaling(List<ExternalEntity> data);
    }
}