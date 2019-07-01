using System;
using System.Collections.Generic;
using System.Linq;
using Projeto.Domain.Administrativo.Colaboradores;
using Projeto.Domain.Administrativo.Colaboradores.ColaboradorInterfaces.Repositories;

namespace Projeto.Data.Repositories.ColaboradoresRepository
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        //Somente para não usar nenhum DB
        private readonly List<Colaborador> _colaboradores = new List<Colaborador>();


        public Colaborador ConsultarPorCodigo(Guid codigo)
        {
            return _colaboradores.First(x => x.Codigo == codigo);
        }

        public IEnumerable<Colaborador> ConsultarTodos()
        {
            return _colaboradores;
        }

        public void Criar(Colaborador colaborador)
        {
            _colaboradores.Add(colaborador);
        }

        public void Editar(Colaborador colaborador)
        {
            _colaboradores.RemoveAll(x => x.Codigo == colaborador.Codigo);
            _colaboradores.Add(colaborador);
        }

        public void Deletar(Colaborador colaborador)
        {
            _colaboradores.Remove(colaborador);
        }
    }
}
