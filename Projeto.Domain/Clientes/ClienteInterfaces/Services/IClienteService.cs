using System;
using System.Collections.Generic;
using Projeto.Domain.Core.Interfaces.Services;

namespace Projeto.Domain.Administrativo.Clientes.ClienteInterfaces.Services
{
    public interface IClienteService : IServiceBase<Cliente>
    {
        Cliente ConsultarPorCodigo(Guid codigo);
        IEnumerable<Cliente> ConsultarTodos();

        void Criar(Cliente cliente);
        void Editar(Cliente cliente);
        void Deletar(Cliente cliente);
    }
}
