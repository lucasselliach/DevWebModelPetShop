using System;
using Projeto.Domain.Shared.Pessoas;

namespace Projeto.Domain.Administrativo.Clientes
{
    public class Cliente
    {
        public Guid Codigo { get; }
        public Pessoa Pessoa { get; }

        public Cliente(Pessoa pessoa)
        {
            Codigo = Guid.NewGuid();
            Pessoa = pessoa;
        }
    }
}
