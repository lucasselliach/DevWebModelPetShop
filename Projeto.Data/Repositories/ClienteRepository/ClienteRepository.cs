using System;
using System.Collections.Generic;
using System.Linq;
using Projeto.Domain.Administrativo.Clientes;
using Projeto.Domain.Administrativo.Clientes.ClienteInterfaces.Repositories;

namespace Projeto.Data.Repositories.ClienteRepository
{
    public class ClienteRepository : IClienteRepository
    {
        //Somente para não usar nenhum DB
        private readonly IList<Cliente> _clientes;

        public ClienteRepository(IList<Cliente> clientes)
        {
            _clientes = clientes;
        }


        public Cliente ConsultarPorCodigo(Guid codigo)
        {
            return _clientes.First(x => x.Codigo == codigo);
        }

        public IEnumerable<Cliente> ConsultarTodos()
        {
            return _clientes;
        }

        public void Criar(Cliente cliente)
        {
            _clientes.Add(cliente);
        }

        public void Editar(Cliente cliente)
        {
            _clientes.Remove(_clientes.First(x => x.Codigo == cliente.Codigo));
            _clientes.Add(cliente);
        }

        public void Deletar(Cliente cliente)
        {
            _clientes.Remove(cliente);
        }
    }
}
