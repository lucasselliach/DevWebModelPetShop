using System;
using Projeto.Domain.Administrativo.Clientes;

namespace Projeto.Domain.Administrativo.Pets
{
    public class Pet
    {
        public Guid Codigo { get; }
        public string Nome { get; private set; }
        public string Bio { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Observacao { get; private set; }
        public DateTime DataCadastro { get; }
        public Cliente ClienteDono { get; set; }

        public Pet(string nome, string bio, DateTime dataNascimento, string observacao, Cliente clienteDono)
        {
            Codigo = Guid.NewGuid();
            Nome = nome;
            Bio = bio;
            DataNascimento = dataNascimento;
            Observacao = observacao;
            DataCadastro = DateTime.Now;
            ClienteDono = clienteDono;
        }

        public void AlterarDadosPet(string nome, string bio, DateTime dataNascimento, string observacao)
        {
            Nome = nome;
            Bio = bio;
            DataNascimento = dataNascimento;
            Observacao = observacao;
        }
    }
}
