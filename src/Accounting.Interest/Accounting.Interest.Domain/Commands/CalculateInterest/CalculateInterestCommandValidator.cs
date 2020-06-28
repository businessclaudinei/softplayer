using FluentValidation;

namespace Accounting.Interest.Domain.Commands.CalculateInterest
{
    public class CalculateInterestCommandValidator : AbstractValidator<CalculateInterestCommand>
    {
        public CalculateInterestCommandValidator()
        {
            RuleFor(command => command.Principal).Custom((principal, context) =>{
                if (principal < 1)
                    context.AddFailure("Este campo precisa ser igual ou maior que 1.");
            });

            RuleFor(command => command.TimeInMonths)
                .NotNull().WithMessage("nulo")
                .GreaterThan(0).WithMessage("Este campo precisa ser maior que 0.");
        }
    }
}
