using System;
using System.Collections.Generic;
using System.Linq;
using Projeto.Domain.Shared.Pessoas;
using Projeto.Domain.Shared.Pessoas.PessoaInterfaces.Repositories;

namespace Projeto.Data.Repositories.PessoaRepository
{
    public class PessoaRepository : IPessoaRepository
    {
        //Somente para não usar nenhum DB
        private readonly IList<Pessoa> _pessoas;

        public PessoaRepository(IList<Pessoa> pessoas)
        {
            _pessoas = pessoas;
        }


        public Pessoa ConsultarPorCodigo(Guid codigo)
        {
            return _pessoas.First(x => x.Codigo == codigo);
        }

        public IEnumerable<Pessoa> ConsultarTodos()
        {
            return _pessoas;
        }

        public void Criar(Pessoa pessoa)
        {
            _pessoas.Add(pessoa);
        }

        public void Editar(Pessoa pessoa)
        {
            _pessoas.Remove(_pessoas.First(x => x.Codigo == pessoa.Codigo));
            _pessoas.Add(pessoa);
        }

        public void Deletar(Pessoa pessoa)
        {
            _pessoas.Remove(pessoa);
        }
    }
}
