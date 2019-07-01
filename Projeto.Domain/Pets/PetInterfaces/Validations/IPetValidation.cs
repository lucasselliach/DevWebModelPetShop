using FluentValidation.Results;
using Projeto.Domain.Core.Interfaces.Validations;

namespace Projeto.Domain.Administrativo.Pets.PetInterfaces.Validations
{
    public interface IPetValidation : IValidationBase<Pet>
    {
        ValidationResult IsValid(Pet pet);
    }
}
