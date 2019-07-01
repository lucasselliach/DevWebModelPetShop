using System;
using System.Collections.Generic;
using Projeto.Domain.Core.Interfaces.Services;

namespace Projeto.Domain.Shared.Paises.PaisInterfaces.Services
{
    public interface IPaisService : IServiceBase<Pais>
    {
        Pais ConsultarPorCodigo(Guid codigo);
        IEnumerable<Pais> ConsultarTodos();

        void Criar(Pais pais);
        void Editar(Pais pais);
        void Deletar(Pais pais);
    }
}
