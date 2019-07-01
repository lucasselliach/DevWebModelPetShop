using System;
using System.Collections.Generic;
using Projeto.Domain.Core.Interfaces.Services;

namespace Projeto.Domain.Administrativo.Colaboradores.ColaboradorInterfaces.Services
{
    public interface IColaboradorService : IServiceBase<Colaborador>
    {
        Colaborador ConsultarPorCodigo(Guid codigo);
        IEnumerable<Colaborador> ConsultarTodos();

        void Criar(Colaborador colaborador);
        void Editar(Colaborador colaborador);
        void Deletar(Colaborador colaborador);
    }
}
