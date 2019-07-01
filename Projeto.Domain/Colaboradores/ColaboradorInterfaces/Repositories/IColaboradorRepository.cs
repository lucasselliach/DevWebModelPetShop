using System;
using System.Collections.Generic;
using Projeto.Domain.Core.Interfaces.Repositories;

namespace Projeto.Domain.Administrativo.Colaboradores.ColaboradorInterfaces.Repositories
{
    public interface IColaboradorRepository : IRepositoryBase<Colaborador>
    {
        Colaborador ConsultarPorCodigo(Guid codigo);
        IEnumerable<Colaborador> ConsultarTodos();

        void Criar(Colaborador colaborador);
        void Editar(Colaborador colaborador);
        void Deletar(Colaborador colaborador);
    }
}
