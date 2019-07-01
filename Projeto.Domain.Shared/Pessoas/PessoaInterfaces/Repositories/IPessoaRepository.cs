using System;
using Projeto.Domain.Core.Interfaces.Repositories;

namespace Projeto.Domain.Shared.Pessoas.PessoaInterfaces.Repositories
{
    public interface IPessoaRepository : IRepositoryBase<Pessoa>
    {
        Pessoa ConsultarPorCodigo(Guid codigo);

        void Criar(Pessoa pessoa);
        void Editar(Pessoa pessoa);
        void Deletar(Pessoa pessoa);
    }
}
