using System;

namespace DevWebModel.SOLID.SRP.Solucao
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataCadastro { get; set; }
    }

    public class ClienteEmailService
    {
        public void EnviarEmail(Cliente cliente)
        {
            // realiza envio de email para cliente informando que ele foi cadastrado com sucesso... 
        }
    }

    public class ClienteRepository
    {
        public void CadastrarCliente(Cliente cliente)
        {
            // realiza comunicação com banco de dados e faz o comando INSERT de um novo cliente...
        }
    }

    public class ClienteValidation
    {
        public bool ValidarCliente(Cliente cliente)
        {
            // realiza validações...

            return true;
        }
    }

    public class ClienteService
    {
        public string CadastrarCliente(Cliente cliente)
        {
            var clienteValidation = new ClienteValidation();
            clienteValidation.ValidarCliente(cliente);

            var clienteRepository = new ClienteRepository();
            clienteRepository.CadastrarCliente(cliente);

            var clienteEmailService = new ClienteEmailService();
            clienteEmailService.EnviarEmail(cliente);

            return "Cliente cadastrado com sucesso!";
        }
    }
}
