using System;
using Projeto.Domain.Shared.Paises;

namespace Projeto.Domain.Shared.Pessoas
{
    public class PessoaFisica : Pessoa
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Rg { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public PessoaFisica(string nome, string cpf, string rg, DateTime dataNascimento, string email, string telefone, string celular, string observacao, string logradouro, int numero, string bairro, string complemento, string cep, string cidade, string unidadeFederativa, Pais pais) : base(email, telefone, celular, observacao, logradouro, numero, bairro, complemento, cep, cidade, unidadeFederativa, pais)
        {
            Nome = nome;
            Cpf = cpf.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            Rg = rg.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            DataNascimento = dataNascimento;
        }

        public void AlterarDadosPessoaFisica(string nome, string cpf, string rg, DateTime dataNascimento, string email, string telefone, string celular, string observacao, string razaoSocial, string nomeFantasia, string cnpj, string inscricaoEstadual, string inscricaoMunicipal, string responsavel, string logradouro, int numero, string bairro, string complemento, string cep, string cidade, string unidadeFederativa, Pais pais)
        {
            Nome = nome;
            Cpf = cpf;
            Rg = rg;
            DataNascimento = dataNascimento;

            AlterarDadosPessoa(email, telefone, celular, observacao, logradouro, numero, bairro, complemento, cep, cidade, unidadeFederativa, pais);
        }
    }
}
