using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;

namespace CalculadoraDeJurosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
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
        /// <param name="id">id da entidade xpto.</param>
        [HttpGet("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<string> Get(int id)
        {
            return id.ToString();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
