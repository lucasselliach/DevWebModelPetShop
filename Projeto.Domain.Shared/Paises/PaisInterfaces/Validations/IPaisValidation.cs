using FluentValidation.Results;
using Projeto.Domain.Core.Interfaces.Validations;

namespace Projeto.Domain.Shared.Paises.PaisInterfaces.Validations
{
    public interface IPaisValidation : IValidationBase<Pais>
    {
        ValidationResult IsValid(Pais pais);
    }
}
