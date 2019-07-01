namespace DevWebModel.SOLID.ISP.Solucao
{
    public interface ICadastroCliente
    {
        void ValidarDados();
        void SalvarBanco();
        void EnviarEmail();
    }

    public interface ICadastroProduto
    {
        void ValidarDados();
        void SalvarBanco();
    }

    public class CadastroCliente : ICadastroCliente
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

    public class CadastroProduto : ICadastroProduto
    {
        public void ValidarDados()
        {
            // Validar valor
        }

        public void SalvarBanco()
        {
            // Insert tabela Produto
        }
    }
}
