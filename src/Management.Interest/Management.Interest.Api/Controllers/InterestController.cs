﻿using AutoMapper;
using Management.Interest.CrossCutting.Configuration.ExceptionModels;
using Management.Interest.Infrastructure.Data.Query.Queries.v1.GetInterestRate;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Management.Interest.Controllers
{
    [Route("api/interest/v1")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InterestController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obter Taxa de Juros v1.
        /// </summary>
        /// <remarks>
        /// <p>
        /// <b>Descricao: </b><br />
        /// Este método é responsável por obter a taxa de juros. A resposta deste método contém a taxa de juros.<br />
        /// </p>
        /// <br />
        /// <p>
        /// <b>Requerimentos: </b><br />
        /// Nenhum.
        /// </p>
        /// </remarks>
        [HttpGet("taxa-juros")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(GetInterestRateQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DefaultExceptionResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(DefaultExceptionResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetInterestRateQueryResponse>> GetInterestRate()
        {
            return await _mediator.Send(new GetInterestRateQuery());

        }
    }
}
