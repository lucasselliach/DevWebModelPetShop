using System;
using Projeto.Domain.Shared.Pessoas;

namespace Projeto.Domain.Administrativo.Colaboradores
{
    public class Colaborador
    {
        public Guid Codigo { get; }
        public PessoaFisica PessoaFisica { get; }
        public string Cargo { get; private set; }
        public DateTime DataAdmissao { get; set; }

        public Colaborador(PessoaFisica pessoaFisica, string cargo)
        {
            Codigo = Guid.NewGuid();
            PessoaFisica = pessoaFisica;
            Cargo = cargo;
            DataAdmissao = DateTime.Now;
        }

        public void AlterarCargo(string cargo)
        {
            Cargo = cargo;
        }
    }
}
