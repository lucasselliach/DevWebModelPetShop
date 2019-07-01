using System;
using FluentValidation;
using FluentValidation.Results;
using Projeto.Domain.Administrativo.Clientes.ClienteValidations;
using Projeto.Domain.Administrativo.Pets.PetInterfaces.Validations;

namespace Projeto.Domain.Administrativo.Pets.PetValidations
{
    public class PetValidation : AbstractValidator<Pet>, IPetValidation
    {
        private void NomeIsValid()
        {
            RuleFor(c => c.Nome)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Nome do pet não pode ser nulo.")
                .NotEmpty().WithMessage("Nome do pet não pode ser vazio.")
                .MaximumLength(30).WithMessage("Nome do pet não pode ter mais que 30 caracteres.");
        }

        private void BioIsValid()
        {
            RuleFor(c => c.Bio)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Bio do pet não pode ser nulo.")
                .NotEmpty().WithMessage("Bio do pet não pode ser vazio.")
                .MaximumLength(30).WithMessage("Bio do pet não pode ter mais que 30 caracteres.");
        }
        
        private void DataNascimentoIsValid()
        {
            RuleFor(c => c.DataNascimento)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Data de nascimento do pet é inválido.")
                .Must(x => x.Date > DateTime.Parse("1900-01-01")).WithMessage("Data de nascimento tem que ser maior que 01/01/1900");
        }
        
        private void ObservacaoIsValid()
        {
            RuleFor(c => c.Observacao)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .MaximumLength(200).WithMessage("Observação do pet não pode ter mais que 200 caracteres.");
        }

        private void ClienteDonoIsValid()
        {
            RuleFor(c => c.ClienteDono)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("O cliente dono do pet não pode ser nulo.")
                .SetValidator(new ClienteValidation());
        }


        public ValidationResult IsValid(Pet pet)
        {
            NomeIsValid();
            BioIsValid();
            DataNascimentoIsValid();
            ObservacaoIsValid();
            ClienteDonoIsValid();

            return Validate(pet);
        }
    }
}
