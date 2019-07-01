using FluentValidation;
using Projeto.Domain.Shared.Pessoas.PessoaInterfaces.Validations;

namespace Projeto.Domain.Shared.Pessoas.PessoaValidations
{
    public class PessoaJuridicaValidation : PessoaValidation<PessoaJuridica>, IPessoaJuridicaValidation
    {
        public PessoaJuridicaValidation()
        {
            RazaoSocialIsValid();
            NomeFantasiaIsValid();
            CnpjIsValid();
            InscricaoEstadualIsValid();
            InscricaoMunicipalIsValid();
            ResponsavelIsValid();
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

        private void RazaoSocialIsValid()
        {
            RuleFor(c => c.RazaoSocial)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Razão social da empresa não pode ser nulo.")
                .NotEmpty().WithMessage("Razão social da empresa não pode ser vazio.")
                .MaximumLength(60).WithMessage("Razão social da empresa não pode ter mais que 60 caracteres.");
        }

        private void NomeFantasiaIsValid()
        {
            RuleFor(c => c.NomeFantasia)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Nome fantasia da empresa não pode ser nulo.")
                .NotEmpty().WithMessage("Nome fantasia da empresa não pode ser vazio.")
                .MaximumLength(60).WithMessage("Nome fantasia da empresa não pode ter mais que 60 caracteres.");
        }

        private void CnpjIsValid()
        {
            RuleFor(c => c.Cnpj)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("CNPJ da empresa não pode ser nulo.")
                .NotEmpty().WithMessage("CNPJ da empresa não pode ser vazio.")
                .MaximumLength(14).WithMessage("CNPJ da empresa não pode ter mais que 14 caracteres.")
                .MinimumLength(14).WithMessage("CNPJ da empresa não pode ter menos que 14 caracteres.")
                .Must(IsCnpj).WithMessage("CNPJ da empresa está em um formato incorreto.");
        }

        private void InscricaoEstadualIsValid()
        {
            RuleFor(c => c.InscricaoEstadual)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Inscricao estadual da empresa não pode ser nulo.")
                .NotEmpty().WithMessage("Inscricao estadual da empresa não pode ser vazio.")
                .MinimumLength(2).WithMessage("Inscricao estadual da empresa não pode ter menos que 2 caracteres.")
                .MaximumLength(14).WithMessage("Inscricao estadual da empresa não pode ter mais que 14 caracteres.");
        }

        private void InscricaoMunicipalIsValid()
        {
            RuleFor(c => c.InscricaoMunicipal)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Inscricao municipal da empresa não pode ser nulo.")
                .NotEmpty().WithMessage("Inscricao municipal da empresa não pode ser vazio.")
                .MinimumLength(2).WithMessage("Inscricao municipal da empresa não pode ter menos que 2 caracteres.")
                .MaximumLength(14).WithMessage("Inscricao municipal da empresa não pode ter mais que 14 caracteres.");
        }

        private void ResponsavelIsValid()
        {
            RuleFor(c => c.Responsavel)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .MaximumLength(100).WithMessage("Responsavel da empresa não pode ter mais que 100 caracteres.");
        }


        private static bool IsCnpj(string cnpj)
        {
            //reference: https://gist.github.com/rdakar/dba890b5e2cbdeb7c62c0dee9f627a7f

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }
    }
}
