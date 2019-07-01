using System;
using System.Collections.Generic;
using System.Linq;
using Projeto.Domain.Operacional.Servicos;
using Projeto.Domain.Operacional.Servicos.ServicoInterfaces.Repositories;

namespace Projeto.Data.Repositories.ServicoRepository
{
    public class ServicoRepository : IServicoRepository
    {
        //Somente para não usar nenhum DB
        private readonly List<Servico> _servicos = new List<Servico>();


        public Servico ConsultarPorCodigo(Guid codigo)
        {
            return _servicos.First(x => x.Codigo == codigo);
        }

        public IEnumerable<Servico> ConsultarTodos()
        {
            return _servicos;
        }

        public void Criar(Servico servico)
        {
            _servicos.Add(servico);
        }

        public void EditarColaborador(Servico servico)
        {
            _servicos.RemoveAll(x => x.Codigo == servico.Codigo);
            _servicos.Add(servico);
        }

        public void EditarIniciarServico(Servico servico)
        {
            _servicos.RemoveAll(x => x.Codigo == servico.Codigo);
            _servicos.Add(servico);
        }

        public void EditarFinalizarServico(Servico servico)
        {
            _servicos.RemoveAll(x => x.Codigo == servico.Codigo);
            _servicos.Add(servico);
        }

        public void Deletar(Servico servico)
        {
            _servicos.Remove(servico);
        }
    }
}
