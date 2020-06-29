using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Management.Interest.Infrastructure.Data.Query.Queries.GetInterestRate
{
    public class GetInterestRateQueryHandler : IRequestHandler<GetInterestRateQuery, GetInterestRateQueryResponse>
    {
        public GetInterestRateQueryHandler()
        {
        }

        public async Task<GetInterestRateQueryResponse> Handle(GetInterestRateQuery query, CancellationToken cancellation)
        {
            decimal interestRate = 0.01M;
            return new GetInterestRateQueryResponse { InterestRate = interestRate, FormattedInterestRate = interestRate.ToString("c")};
        }
    }
}
