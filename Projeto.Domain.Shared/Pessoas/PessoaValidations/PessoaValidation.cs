using FluentValidation;

namespace Projeto.Domain.Shared.Pessoas.PessoaValidations
{
    public abstract class PessoaValidation<T> : AbstractValidator<T> where T : Pessoa
    {
        protected void EmailIsValid()
        {
            RuleFor(c => c.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .EmailAddress().WithMessage("Email da pessoa é inválido.")
                .NotEmpty().WithMessage("Email da pessoa é inválido.")
                .Length(6, 100).WithMessage("Email da pessoa deve conter no mínimo 6 e no maximo 100 caracteres.");
        }

        protected void TelefoneIsValid()
        {
            RuleFor(c => c.Telefone)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .MaximumLength(20).WithMessage("Telefone da pessoa deve conter no maximo 20 caracteres.");
        }

        protected void CelularIsValid()
        {
            RuleFor(c => c.Celular)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .MaximumLength(20).WithMessage("Celular da pessoa deve conter no maximo 20 caracteres.");
        }

        protected void ObservacaoIsValid()
        {
            RuleFor(c => c.Observacao)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .MaximumLength(100).WithMessage("Observacao da pessoa deve conter no maximo 100 caracteres.");
        }

        protected void LogradouroIsValid()
        {
            RuleFor(c => c.Logradouro)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .MaximumLength(45).WithMessage("Logradouro do endereço deve conter no maximo 45 caracteres.");
        }

        protected void NumeroIsValid()
        {
            RuleFor(c => c.Numero)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Numero do endereço é inválido.")
                .GreaterThanOrEqualTo(0).WithMessage("Numero do endereço não pode ser menor que zero.");
        }

        protected void BairroIsValid()
        {
            RuleFor(c => c.Bairro)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .MaximumLength(30).WithMessage("Bairro do endereço deve conter no maximo 30 caracteres.");
        }

        protected void ComplementoIsValid()
        {
            RuleFor(c => c.Complemento)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .MaximumLength(30).WithMessage("Complemento do endereço deve conter no maximo 30 caracteres.");
        }

        protected void CepIsValid()
        {
            RuleFor(c => c.Cep)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .MaximumLength(10).WithMessage("Cep do endereço deve conter no maximo 10 caracteres.");
        }

        protected void CidadeIsValid()
        {
            RuleFor(c => c.Cidade)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .MaximumLength(30).WithMessage("Cidade do endereço deve conter no maximo 30 caracteres.");
        }

        protected void UfIsValid()
        {
            RuleFor(c => c.UnidadeFederativa)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .MaximumLength(2).WithMessage("Uf do endereço deve conter no maximo 2 caracteres.");
        }
    }
}
