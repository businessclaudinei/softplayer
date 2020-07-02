using AutoMapper;
using Management.Interest.CrossCutting.Exception.Base;
using Management.Interest.Infrastructure.Data.Query.Queries.v1.GetInterestRate;
using Management.Interest.Infrastructure.Data.Query.Tests.Unit.Queries.v1.GetInterestRate.Mocks.Specimen;
using NSubstitute;

namespace Management.Interest.Infrastructure.Data.Query.Tests.Unit.Queries.v1.GetInterestRate.Mocks.Mappers
{
    public sealed class MapperMock
    {
        public IMapper GetMock()
        {
            IMapper mock = Substitute.For<IMapper>();

            mock.Map<double?, GetInterestRateQueryResponse>(Arg.Is<double?>(interestRate => interestRate.HasValue)).Returns(GetInterestRateResponseSpecimen.For.ValidRequest);

            mock.When(x => x.Map<double?, GetInterestRateQueryResponse>(Arg.Is<double?>(interestRate => !interestRate.HasValue))).Do(response => { throw new NotFoundCustomException(); });

            return mock;
        }
    }
}
