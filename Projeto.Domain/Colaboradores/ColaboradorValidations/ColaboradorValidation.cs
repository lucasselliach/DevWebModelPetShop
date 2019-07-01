using FluentValidation;
using FluentValidation.Results;
using Projeto.Domain.Administrativo.Colaboradores.ColaboradorInterfaces.Validations;
using Projeto.Domain.Shared.Pessoas.PessoaValidations;

namespace Projeto.Domain.Administrativo.Colaboradores.ColaboradorValidations
{
    public class ColaboradorValidation : AbstractValidator<Colaborador>, IColaboradorValidation
    {
        private void PessoaFisicaIsValid()
        {
            RuleFor(c => c.PessoaFisica)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Pessoa fisica do colaborador não pode ser nulo.")
                .SetValidator(new PessoaFisicaValidation());
        }

        private void CargoIsValid()
        {
            RuleFor(c => c.Cargo)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Cargo do colaborador não pode ser nulo.")
                .NotEmpty().WithMessage("Cargo do colaborador não pode ser vazio.")
                .MaximumLength(60).WithMessage("Cargo do colaborador não pode ter mais que 60 caracteres.");
        }

        public ValidationResult IsValid(Colaborador colaborador)
        {
            PessoaFisicaIsValid();
            CargoIsValid();

            return Validate(colaborador);
        }
    }
}
