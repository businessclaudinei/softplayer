﻿using Accounting.Interest.CrossCutting.Exceptions.Base;
using MediatR;
using System.Net;
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

            throw new System.Exception("Teste");

            throw new ApiHttpCustomException("Teste", HttpStatusCode.BadRequest);

            return new CalculateInterestCommandResponse { };
        }
    }
}
