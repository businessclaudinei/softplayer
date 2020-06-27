using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;
using Management.Interest.Infrastruture.Data.Query.Queries.GetInterestRate;

namespace Management.Interest.Controllers
{
    [Route("api/interest/v1")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InterestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Busca valores v1.
        /// </summary>
        /// <remarks>
        /// <p>
        /// <b>Descricao: </b><br />
        /// Este metodo busca os valores xpto filtrados por parametros.<br />
        /// Nota, o parametro id e obrigatorio. <br />
        /// </p>
        /// <br />
        /// <p>
        /// <b>Requerimentos: </b><br />
        /// Nenhum.
        /// </p>
        /// </remarks>
        [HttpGet("/taxa-juros")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(GetInterestRateQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetInterestRateQueryResponse>> GetInterestRate()
        {
            return await _mediator.Send(new GetInterestRateQuery());

        }
    }
}
