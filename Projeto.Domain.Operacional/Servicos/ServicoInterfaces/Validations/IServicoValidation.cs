using FluentValidation.Results;
using Projeto.Domain.Core.Interfaces.Validations;

namespace Projeto.Domain.Operacional.Servicos.ServicoInterfaces.Validations
{
    public interface IServicoValidation : IValidationBase<Servico>
    {
        ValidationResult IsValid(Servico servico);
    }
}
