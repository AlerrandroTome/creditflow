using creditflow.services.creditproposal.application.InputModels;
using FluentValidation;

namespace creditflow.services.creditproposal.application.Validators
{
    public class AtualizarPropostaValidator : AbstractValidator<AtualizarValorDePropostaInputModel>
    {
        public AtualizarPropostaValidator()
        {
            RuleFor(c => c.ValorCredito).GreaterThan(0)
                                        .WithMessage("O valor é obrigatório e deve ser maior do que 0!");

            RuleFor(c => c.Id).NotEmpty()
                                .NotNull()
                                .WithMessage("É necessário informar qual é a proposta!");
        }
    }
}