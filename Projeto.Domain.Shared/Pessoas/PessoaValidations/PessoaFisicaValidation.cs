using System;
using FluentValidation;
using Projeto.Domain.Shared.Pessoas.PessoaInterfaces.Validations;

namespace Projeto.Domain.Shared.Pessoas.PessoaValidations
{
    public class PessoaFisicaValidation : PessoaValidation<PessoaFisica>, IPessoaFisicaValidation
    {
        public PessoaFisicaValidation()
        {
            NomeIsValid();
            CpfIsValid();
            RgIsValid();
            DataNascimentoIsValid();
            EmailIsValid();
            TelefoneIsValid();
            CelularIsValid();
            ObservacaoIsValid();
            LogradouroIsValid();
            NumeroIsValid();
            BairroIsValid();
            ComplementoIsValid();
            CepIsValid();
            CidadeIsValid();
            UfIsValid();
        }

        private void NomeIsValid()
        {
            RuleFor(c => c.Nome)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Nome da pessoa não pode ser nulo.")
                .NotEmpty().WithMessage("Nome da pessoa não pode ser vazio.")
                .MaximumLength(100).WithMessage("Nome da pessoa não pode ter mais que 100 caracteres.");
        }

        private void CpfIsValid()
        {
            RuleFor(c => c.Cpf)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("CPF da pessoa não pode ser nulo.")
                .NotEmpty().WithMessage("CPF da pessoa não pode ser vazio.")
                .MaximumLength(11).WithMessage("CPF da pessoa não pode ter mais que 11 caracteres.")
                .MinimumLength(11).WithMessage("CPF da pessoa não pode ter menos que 11 caracteres.")
                .Must(IsCpf).WithMessage("CPF da pessoa está em um formato incorreto. Ele não é valido.");
        }

        private void RgIsValid()
        {
            RuleFor(c => c.Rg)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("RG da pessoa não pode ser nulo.")
                .NotEmpty().WithMessage("RG da pessoa não pode ser vazio.")
                .MaximumLength(10).WithMessage("RG da pessoa não pode ter mais que 10 caracteres.");
        }

        private void DataNascimentoIsValid()
        {
            RuleFor(c => c.DataNascimento)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Data de nascimento de pessoa é inválido.")
                .Must(x => x.Date > DateTime.Parse("1900-01-01")).WithMessage("Data de nascimento tem que ser maior que 01/01/1900");
        }
        

        private static bool IsCpf(string cpf)
        {
            //Reference: https://gist.github.com/rdakar/dba890b5e2cbdeb7c62c0dee9f627a7f

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11) return false;

            for (int j = 0; j < 10; j++) if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf) return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
