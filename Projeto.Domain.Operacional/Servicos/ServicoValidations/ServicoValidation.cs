using FluentValidation;
using FluentValidation.Results;
using Projeto.Domain.Administrativo.Clientes.ClienteValidations;
using Projeto.Domain.Administrativo.Colaboradores.ColaboradorValidations;
using Projeto.Domain.Administrativo.Pets.PetValidations;
using Projeto.Domain.Operacional.Servicos.ServicoInterfaces.Validations;

namespace Projeto.Domain.Operacional.Servicos.ServicoValidations
{
    public class ServicoValidation : AbstractValidator<Servico>, IServicoValidation
    {
        private void ClienteIsValid()
        {
            RuleFor(c => c.Cliente)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Cliente do serviço não pode ser nulo.")
                .SetValidator(new ClienteValidation());
        }

        private void PetIsValid()
        {
            RuleFor(c => c.Pet)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Pet do serviço não pode ser nulo.")
                .SetValidator(new PetValidation());
        }

        private void ColaboradorResponsavelIsValid()
        {
            RuleFor(c => c.ColaboradorResponsavel)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Colaborador responsável do serviço não pode ser nulo.")
                .SetValidator(new ColaboradorValidation());
        }

        private void TipoIsValid()
        {
            RuleFor(c => c.Tipo)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Tipo do serviço não pode ser nulo.")
                .NotEmpty().WithMessage("Tipo do serviço não pode ser vazio.")
                .MaximumLength(60).WithMessage("Tipo do serviço não pode ter mais que 60 caracteres.");
        }

        public ValidationResult IsValid(Servico servico)
        {
            ClienteIsValid();
            PetIsValid();
            ColaboradorResponsavelIsValid();
            TipoIsValid();

            return Validate(servico);
        }
    }
}
