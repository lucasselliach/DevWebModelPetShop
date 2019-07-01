using System;
using System.Collections.Generic;
using Projeto.Domain.Core.Interfaces.Repositories;

namespace Projeto.Domain.Operacional.Servicos.ServicoInterfaces.Repositories
{
    public interface IServicoRepository : IRepositoryBase<Servico>
    {
        Servico ConsultarPorCodigo(Guid codigo);
        IEnumerable<Servico> ConsultarTodos();

        void Criar(Servico servico);
        void EditarColaborador(Servico servico);
        void EditarIniciarServico(Servico servico);
        void EditarFinalizarServico(Servico servico);
        void Deletar(Servico servico);
    }
}
