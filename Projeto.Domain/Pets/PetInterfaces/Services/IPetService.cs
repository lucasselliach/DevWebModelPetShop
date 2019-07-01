using System;
using System.Collections.Generic;
using Projeto.Domain.Core.Interfaces.Services;

namespace Projeto.Domain.Administrativo.Pets.PetInterfaces.Services
{
    public interface IPetService : IServiceBase<Pet>
    {
        Pet ConsultarPorCodigo(Guid codigo);
        IEnumerable<Pet> ConsultarTodos();

        void Criar(Pet pet);
        void Editar(Pet pet);
        void Deletar(Pet pet);
    }
}
