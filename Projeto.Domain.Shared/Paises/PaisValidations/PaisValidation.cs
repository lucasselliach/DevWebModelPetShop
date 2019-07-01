using FluentValidation;
using FluentValidation.Results;
using Projeto.Domain.Shared.Paises.PaisInterfaces.Validations;

namespace Projeto.Domain.Shared.Paises.PaisValidations
{
    public class PaisValidation : AbstractValidator<Pais>, IPaisValidation
    {
        private void NomeIsValid()
        {
            RuleFor(c => c.Nome)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Nome do país não pode ser nulo.")
                .NotEmpty().WithMessage("Nome do país não pode ser vazio.")
                .MaximumLength(30).WithMessage("Nome do país não pode ter mais que 30 caracteres.");
        }

        private void IdiomaIsValid()
        {
            RuleFor(c => c.Idioma)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Idioma do país não pode ser nulo.")
                .NotEmpty().WithMessage("Idioma do país não pode ser vazio.")
                .MaximumLength(30).WithMessage("Idioma do país não pode ter mais que 30 caracteres.");
        }

        public ValidationResult IsValid(Pais pais)
        {
            NomeIsValid();
            IdiomaIsValid();
            
            return Validate(pais);
        }
    }
}
