using Accounting.Interest.Domain.Commands.CalculateInterest;
using Accounting.Interest.Insfrastruture.Data.Query.Queries.ShowMeTheCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;
using FluentValidation;

namespace Accounting.Interest.Api.Controllers
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
        /// Calcula Juros Compostos v1.
        /// </summary>
        /// <remarks>
        /// <p>
        /// <b>Descricao: </b><br />
        /// Este método calcula os juros compostos a partir de uma taxa de juros. A resposta do metodo contém o calculo dos juros compostos.<br />
        /// Nota, o parametro taxa de juros e obrigatório. <br />
        /// </p>
        /// <br />
        /// <p>
        /// <b>Requerimentos: </b><br />
        /// Nenhum.
        /// </p>
        /// </remarks>
        /// <returns>CalculateInterestCommandResponse</returns>
        [HttpPost("/calcula-juros")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CalculateInterestCommandResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CalculateInterestCommandResponse>> CalculateCompoundInterest([FromBody] CalculateInterestCommand command)
        {
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Mostra Código Fonte v1.
        /// </summary>
        /// <remarks>
        /// <p>
        /// <b>Descricao: </b><br />
        /// Este método é responsável por apresentar o código fonte no GitHub. A resposta do método é a url do repositório Github.<br />
        /// </p>
        /// <br />
        /// <p>
        /// <b>Requerimentos: </b><br />
        /// Nenhum.
        /// </p>
        /// </remarks>
        /// <returns>ShowMeTheCodeQueryResponse</returns>
        [HttpGet("/show-me-the-code")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ShowMeTheCodeQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ShowMeTheCodeQueryResponse>> ShowMeTheCode()
        {
            return await _mediator.Send(new ShowMeTheCodeQuery());
        }
    }
}
