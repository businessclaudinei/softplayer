using Management.Interest.Infrastructure.Data.Query.Queries.v1.GetInterestRate;
using System;
using System.IO;

namespace Management.Interest.Infrastructure.Data.Query.Tests.Unit.Queries.v1.GetInterestRate.Mocks.Specimen
{
    public sealed class GetInterestRateResponseSpecimen : SpecimenBase<GetInterestRateQueryResponse>
    {
        private static string path = string.Concat(Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName,
           @"/Unit/Queries/v1/GetInterestRate/Mocks/Specimen/GetInterestRateQueryResponse/");

        private static string pathForValidRequest = string.Concat(path, "ForValidRequest.json");

        private static readonly GetInterestRateResponseSpecimen _instance = new GetInterestRateResponseSpecimen();
        private static GetInterestRateQueryResponse _validRequest;

        static GetInterestRateResponseSpecimen()
        {
            _validRequest = Create(pathForValidRequest);
        }

        public static GetInterestRateResponseSpecimen For
        {
            get
            {
                return _instance ?? new GetInterestRateResponseSpecimen();
            }
        }

        public GetInterestRateQueryResponse ValidRequest => _validRequest;
    }
}
