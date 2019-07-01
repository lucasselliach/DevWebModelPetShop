using System;

namespace DevWebModel.SOLID.SRP.Violacao
{
    public class ClienteViolacao
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataCadastro { get; set; }

        public string CadastrarCliente()
        {
            // realiza validações ...

            // realiza comunicação com banco de dados e faz o comando INSERT de um novo cliente...

            // realiza envio de email para cliente informando que ele foi cadastrado com sucesso... 

            return "Cliente cadastrado com sucesso!";
        }
    }
}
