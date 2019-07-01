using System;
using System.Collections.Generic;
using Projeto.Domain.Administrativo.Clientes;
using Projeto.Domain.Administrativo.Clientes.ClienteInterfaces.Repositories;
using Projeto.Domain.Administrativo.Clientes.ClienteInterfaces.Services;
using Projeto.Domain.Administrativo.Clientes.ClienteInterfaces.Validations;
using Projeto.Domain.Shared.Pessoas.PessoaInterfaces.Repositories;

namespace Projeto.Application.ClientesService
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteValidation _clienteValidation;
        private readonly IPessoaRepository _pessoaRepository;
        
        public ClienteService(IClienteRepository clienteRepository, IClienteValidation clienteValidation, IPessoaRepository pessoaRepository)
        {
            _clienteRepository = clienteRepository;
            _clienteValidation = clienteValidation;
            _pessoaRepository = pessoaRepository;
        }

        public Cliente ConsultarPorCodigo(Guid codigo)
        {
            return _clienteRepository.ConsultarPorCodigo(codigo);
        }

        public IEnumerable<Cliente> ConsultarTodos()
        {
            return _clienteRepository.ConsultarTodos();
        }

        public void Criar(Cliente cliente)
        {
            var clienteResults = _clienteValidation.IsValid(cliente);
            if (clienteResults.IsValid)
            {
                _pessoaRepository.Criar(cliente.Pessoa);
                _clienteRepository.Criar(cliente);
            }
            else
            {
                throw new Exception(clienteResults.ToString("~"));
            }
        }

        public void Editar(Cliente cliente)
        {
            var clienteResults = _clienteValidation.IsValid(cliente);
            if (clienteResults.IsValid)
            {
                _pessoaRepository.Editar(cliente.Pessoa);
                _clienteRepository.Editar(cliente);
            }
            else
            {
                throw new Exception(clienteResults.ToString("~"));
            }
        }

        public void Deletar(Cliente cliente)
        {
            var clienteResults = _clienteValidation.IsValid(cliente);
            if (clienteResults.IsValid)
            {
                _pessoaRepository.Deletar(cliente.Pessoa);
                _clienteRepository.Deletar(cliente);
            }
            else
            {
                throw new Exception(clienteResults.ToString("~"));
            }
        }
    }
}
