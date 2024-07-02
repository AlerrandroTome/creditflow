using creditflow.services.client.application.InputModels;
using FluentValidation;

namespace creditflow.services.client.application.Validators
{
    public class CriarClienteValidator : AbstractValidator<CriarClienteComPropostaInputModel>
    {
        public CriarClienteValidator()
        {
            RuleFor(c => c.Email).EmailAddress()
                                 .WithMessage("E-mail não válido!");

            RuleFor(c => c.Nome).NotEmpty()
                                .NotNull()
                                .WithMessage("Nome é obrigatório!");

            RuleFor(c => c.Telefone).NotEmpty()
                                    .NotNull()
                                    .WithMessage("Telefone é obrigatório!");
            RuleFor(c => c.Telefone).Matches(@"^\d{10,15}$")
                                    .WithMessage("Telefone deve conter apenas números e ter entre 10 e 15 caracteres!");
        }
    }
}
