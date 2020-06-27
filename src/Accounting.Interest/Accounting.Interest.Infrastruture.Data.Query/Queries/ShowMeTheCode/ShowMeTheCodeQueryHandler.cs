using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Interest.Insfrastruture.Data.Query.Queries.ShowMeTheCode
{
    public class ShowMeTheCodeQueryHandler : IRequestHandler<ShowMeTheCodeQuery, ShowMeTheCodeQueryResponse>
    {
        public ShowMeTheCodeQueryHandler()
        {
        }

        public async Task<ShowMeTheCodeQueryResponse> Handle(ShowMeTheCodeQuery query, CancellationToken cancellation)
        {
            return new ShowMeTheCodeQueryResponse { GitHubRepositoryUrl = "https://github.com/businessclaudinei/softplayer" };
        }
    }
}
