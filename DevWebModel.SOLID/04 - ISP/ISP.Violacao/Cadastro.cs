using System;

namespace DevWebModel.SOLID.ISP.Violacao
{
    public interface ICadastro
    {
        void ValidarDados();
        void SalvarBanco();
        void EnviarEmail();
    }

    public class CadastroCliente : ICadastro
    {
        public void ValidarDados()
        {
            // Validar Cpf, Email
        }

        public void SalvarBanco()
        {
            // Insert na tabela Cliente
        }

        public void EnviarEmail()
        {
            // Enviar e-mail para o cliente
        }
    }

    public class CadastroProduto : ICadastro
    {
        public void ValidarDados()
        {
            // Validar valor
        }

        public void SalvarBanco()
        {
            // Insert tabela Produto
        }

        public void EnviarEmail()
        {
            // Produto não tem e-mail, o que eu faço agora???
            throw new NotImplementedException("Esse metodo não serve pra nada");
        }
    }
}
