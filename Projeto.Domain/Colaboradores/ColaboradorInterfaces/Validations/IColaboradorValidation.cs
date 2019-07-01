using FluentValidation.Results;
using Projeto.Domain.Core.Interfaces.Validations;

namespace Projeto.Domain.Administrativo.Colaboradores.ColaboradorInterfaces.Validations
{
    public interface IColaboradorValidation : IValidationBase<Colaborador>
    {
        ValidationResult IsValid(Colaborador colaborador);
    }
}
