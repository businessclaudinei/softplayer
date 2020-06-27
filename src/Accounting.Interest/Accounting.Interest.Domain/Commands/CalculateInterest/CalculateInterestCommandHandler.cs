using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Interest.Domain.Commands.CalculateInterest
{
    public class CalculateInterestCommandHandler : IRequestHandler<CalculateInterestCommand, CalculateInterestCommandResponse>
    {
        public CalculateInterestCommandHandler()
        {
        }

        public async Task<CalculateInterestCommandResponse> Handle(CalculateInterestCommand command, CancellationToken cancellation)
        {
            return new CalculateInterestCommandResponse { };
        }
    }
}
