using System;
using Projeto.Domain.Shared.Paises;

namespace Projeto.Domain.Shared.Pessoas
{
    public abstract class Pessoa
    {
        public Guid Codigo { get; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Celular { get; private set; }
        public string Observacao { get; private set; }
        public DateTime DataCadastro { get; }
        public string Logradouro { get; private set; }
        public int Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Complemento { get; private set; }
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string UnidadeFederativa { get; private set; }
        public Pais Pais { get; private set; }

        protected Pessoa(string email, string telefone, string celular, string observacao, string logradouro, int numero, string bairro, string complemento, string cep, string cidade, string unidadeFederativa, Pais pais)
        {
            Codigo = Guid.NewGuid();
            Email = email;
            Telefone = telefone;
            Celular = celular;
            Observacao = observacao;
            DataCadastro = DateTime.Now;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Complemento = complemento;
            Cep = cep;
            Cidade = cidade;
            UnidadeFederativa = unidadeFederativa;
            Pais = pais;
        }

        protected void AlterarDadosPessoa(string email, string telefone, string celular, string observacao, string logradouro, int numero, string bairro, string complemento, string cep, string cidade, string unidadeFederativa, Pais pais)
        {
            Email = email;
            Telefone = telefone;
            Celular = celular;
            Observacao = observacao;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Complemento = complemento;
            Cep = cep;
            Cidade = cidade;
            UnidadeFederativa = unidadeFederativa;
            Pais = pais;
        }
    }
}
