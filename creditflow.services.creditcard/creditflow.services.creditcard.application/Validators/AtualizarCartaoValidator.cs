using creditflow.services.creditcard.application.InputModels;
using FluentValidation;

namespace creditflow.services.creditcard.application.Validators
{
    public class AtualizarCartaoValidator : AbstractValidator<AtualizarCartaoInputModel>
    {
        public AtualizarCartaoValidator()
        {
            RuleFor(c => c.TotalCredito).GreaterThan(0)
                                        .WithMessage("O valor é obrigatório e deve ser maior do que 0!");

            RuleFor(c => c.Id).NotEmpty()
                                     .NotNull()
                                     .WithMessage("É necessário informar qual é o cartão!");
        }
    }
}
