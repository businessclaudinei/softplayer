using System;
using Accounting.Interest.Infrastructure.Service.Services.Management;
using AutoFixture.Kernel;

namespace Accounting.Interest.Domain.Test.Unit.Commands.v1.CalculateInterest.Mocks.Specimen
{
    public class InterestRateServiceResponseSpecimen : ISpecimenBuilder
    {

        public object Create(object request, ISpecimenContext context)
        {
            var type = request as Type;

            if (type == null)
                return new NoSpecimen();

            if (type != typeof(InterestRateServiceResponse))
                return new NoSpecimen();

            return new InterestRateServiceResponse{InterestRate = 0.01};
        }
    }
}
