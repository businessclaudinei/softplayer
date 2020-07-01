using Accounting.Interest.Domain.Commands.CalculateInterest;
using AutoFixture.Kernel;

namespace Accounting.Interest.Domain.Test.Unit.Commands.v1.CalculateInterest.Mocks.Specimen
{
    public class CalculateInterestCommandSpecimen : ISpecimenBuilder
    {

        public object Create(object request, ISpecimenContext context)
        {
            return new CalculateInterestCommand();
        }
    }
}
