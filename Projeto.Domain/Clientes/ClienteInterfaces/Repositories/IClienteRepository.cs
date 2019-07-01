using System;
using System.Collections.Generic;
using Projeto.Domain.Core.Interfaces.Repositories;

namespace Projeto.Domain.Administrativo.Clientes.ClienteInterfaces.Repositories
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        Cliente ConsultarPorCodigo(Guid codigo);
        IEnumerable<Cliente> ConsultarTodos();

        void Criar(Cliente cliente);
        void Editar(Cliente cliente);
        void Deletar(Cliente cliente);
    }
}
