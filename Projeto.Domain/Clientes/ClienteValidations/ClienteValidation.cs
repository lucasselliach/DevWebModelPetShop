using FluentValidation;
using FluentValidation.Results;
using Projeto.Domain.Administrativo.Clientes.ClienteInterfaces.Validations;
using Projeto.Domain.Shared.Pessoas;
using Projeto.Domain.Shared.Pessoas.PessoaValidations;

namespace Projeto.Domain.Administrativo.Clientes.ClienteValidations
{
    public class ClienteValidation : AbstractValidator<Cliente>, IClienteValidation
    {
        private void PessoaFisicaIsValid()
        {
            RuleFor(c => (PessoaFisica) c.Pessoa)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Pessoa fisica do colaborador não pode ser nulo.")
                .SetValidator(new PessoaFisicaValidation());
        }

        private void PessoaJuridicaIsValid()
        {
            RuleFor(c => (PessoaJuridica) c.Pessoa)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Pessoa jurídica do colaborador não pode ser nulo.")
                .SetValidator(new PessoaJuridicaValidation());
        }

        public ValidationResult IsValid(Cliente cliente)
        {
            if (cliente.Pessoa.GetType() == typeof(PessoaFisica)) PessoaFisicaIsValid();
            if (cliente.Pessoa.GetType() == typeof(PessoaJuridica)) PessoaJuridicaIsValid();

            return Validate(cliente);
        }
    }
}
