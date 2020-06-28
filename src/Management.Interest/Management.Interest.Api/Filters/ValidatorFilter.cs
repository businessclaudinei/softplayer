using Management.Interest.CrossCutting.Exception.Base;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace Management.Interest.Api.Filters
{
    public class ValidatorFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInState = context.ModelState.Where(v => v.Value.Errors.Any())
                .SelectMany(e => e.Value.Errors.Select(m => new ErrorModel
                {
                    FieldName = e.Key,
                    Message = m.ErrorMessage
                }));
                throw new BadRequestCustomException(errorsInState, "A entrada de dados da requisição está incorreta.");
            }
            await next();
        }
    }
}

