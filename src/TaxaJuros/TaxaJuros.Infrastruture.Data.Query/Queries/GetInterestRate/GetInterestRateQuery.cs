using MediatR;
using Newtonsoft.Json;

namespace TaxaJuros.Infrastruture.Data.Query.Queries.GetInterestRate
{
    public class GetInterestRateQuery : IRequest<GetInterestRateQueryResponse>
    {
    }
}
