using System;
using System.Collections.Generic;
using Projeto.Domain.Core.Interfaces.Repositories;

namespace Projeto.Domain.Shared.Paises.PaisInterfaces.Repositories
{
    public interface IPaisRepository : IRepositoryBase<Pais>
    {
        Pais ConsultarPorCodigo(Guid codigo);
        IEnumerable<Pais> ConsultarTodos();

        void Criar(Pais pais);
        void Editar(Pais pais);
        void Deletar(Pais pais);
    }
}
