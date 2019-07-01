using System;

namespace DevWebModel.SOLID.DIP.Solucao
{
    public interface IClienteEmailService
    {
        void EnviarEmail(Cliente cliente);
    }
    
    public interface IClienteServices
    {
        string CadastrarCliente(Cliente cliente);
    }

    public interface IClienteRepository
    {
        void CadastrarCliente(Cliente cliente);
    }

    public interface IClienteValidation
    {
        bool ValidarCliente(Cliente cliente);
    }
    
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataCadastro { get; set; }
    }

    public class ClienteEmailService : IClienteEmailService
    {
        public void EnviarEmail(Cliente cliente)
        {
            // realiza envio de email para cliente informando que ele foi cadastrado com sucesso... 
        }
    }

    public class ClienteRepository : IClienteRepository
    {
        public void CadastrarCliente(Cliente cliente)
        {
            // realiza comunicação com banco de dados e faz o comando INSERT de um novo cliente...
        }
    }

    public class ClienteValidation : IClienteValidation
    {
        public bool ValidarCliente(Cliente cliente)
        {
            // realiza validações...

            return true;
        }
    }

    public class ClienteService : IClienteServices
    {
        private readonly IClienteEmailService _clienteEmailService;
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteValidation _clienteValidation;

        public ClienteService(IClienteEmailService clienteEmailService, IClienteRepository clienteRepository, IClienteValidation clienteValidation)
        {
            _clienteEmailService = clienteEmailService;
            _clienteRepository = clienteRepository;
            _clienteValidation = clienteValidation;
        }

        public string CadastrarCliente(Cliente cliente)
        {
            _clienteValidation.ValidarCliente(cliente);
            _clienteRepository.CadastrarCliente(cliente);
            _clienteEmailService.EnviarEmail(cliente);

            return "Cliente cadastrado com sucesso!";
        }
    }
}
