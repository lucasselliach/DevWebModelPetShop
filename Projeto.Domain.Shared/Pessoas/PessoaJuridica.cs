using Projeto.Domain.Shared.Paises;

namespace Projeto.Domain.Shared.Pessoas
{
    public class PessoaJuridica : Pessoa
    {
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string Cnpj { get; private set; }
        public string InscricaoEstadual { get; private set; }
        public string InscricaoMunicipal { get; private set; }
        public string Responsavel { get; private set; }

        public PessoaJuridica(string razaoSocial, string nomeFantasia, string cnpj, string inscricaoEstadual, string inscricaoMunicipal, string responsavel, string email, string telefone, string celular, string observacao, string logradouro, int numero, string bairro, string complemento, string cep, string cidade, string unidadeFederativa, Pais pais) : base(email, telefone, celular, observacao, logradouro, numero, bairro, complemento, cep, cidade, unidadeFederativa, pais)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            InscricaoEstadual = inscricaoEstadual.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            InscricaoMunicipal = inscricaoMunicipal.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            Responsavel = responsavel;
        }

        public void AlterarDadosPessoaJuridica(string razaoSocial, string nomeFantasia, string cnpj, string inscricaoEstadual, string inscricaoMunicipal, string responsavel, string email, string telefone, string celular, string observacao, string logradouro, int numero, string bairro, string complemento, string cep, string cidade, string unidadeFederativa, Pais pais)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            InscricaoEstadual = inscricaoEstadual;
            InscricaoMunicipal = inscricaoMunicipal;
            Responsavel = responsavel;

            AlterarDadosPessoa(email, telefone, celular, observacao, logradouro, numero, bairro, complemento, cep, cidade, unidadeFederativa, pais);
        }
    }
}
