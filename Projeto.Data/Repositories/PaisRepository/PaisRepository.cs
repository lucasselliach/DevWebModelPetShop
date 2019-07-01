using System;
using System.Collections.Generic;
using System.Linq;
using Projeto.Domain.Shared.Paises;
using Projeto.Domain.Shared.Paises.PaisInterfaces.Repositories;

namespace Projeto.Data.Repositories.PaisRepository
{
    public class PaisRepository : IPaisRepository
    {
        //Somente para não usar nenhum DB
        private readonly List<Pais> _paises = new List<Pais>();


        public Pais ConsultarPorCodigo(Guid codigo)
        {
            return _paises.First(x => x.Codigo == codigo);
        }

        public IEnumerable<Pais> ConsultarTodos()
        {
            return _paises;
        }

        public void Criar(Pais pais)
        {
            _paises.Add(pais);
        }

        public void Editar(Pais pais)
        {
            _paises.RemoveAll(x => x.Codigo == pais.Codigo);
            _paises.Add(pais);
        }

        public void Deletar(Pais pais)
        {
            _paises.Remove(pais);
        }
    }
}