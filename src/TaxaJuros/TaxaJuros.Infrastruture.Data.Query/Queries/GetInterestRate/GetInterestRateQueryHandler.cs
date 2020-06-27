using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace TaxaJuros.Infrastruture.Data.Query.Queries.GetInterestRate
{
    public class GetInterestRateQueryHandler : IRequestHandler<GetInterestRateQuery, GetInterestRateQueryResponse>
    {
        public GetInterestRateQueryHandler()
        {
        }

        public async Task<GetInterestRateQueryResponse> Handle(GetInterestRateQuery query, CancellationToken cancellation)
        {
            decimal interestRate = 0.01M;
            return new GetInterestRateQueryResponse { InterestRate = interestRate, InterestRateStr = interestRate.ToString("c")};
        }
    }
}
