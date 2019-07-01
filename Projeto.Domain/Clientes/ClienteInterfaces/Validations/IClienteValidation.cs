using FluentValidation.Results;
using Projeto.Domain.Core.Interfaces.Validations;

namespace Projeto.Domain.Administrativo.Clientes.ClienteInterfaces.Validations
{
    public interface IClienteValidation : IValidationBase<Cliente>
    {
        ValidationResult IsValid(Cliente cliente);
    }
}
