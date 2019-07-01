using System;
using System.Collections.Generic;
using Projeto.Domain.Core.Interfaces.Repositories;

namespace Projeto.Domain.Administrativo.Pets.PetInterfaces.Repositories
{
    public interface IPetRepository : IRepositoryBase<Pet>
    {
        Pet ConsultarPorCodigo(Guid codigo);
        IEnumerable<Pet> ConsultarTodos();

        void Criar(Pet pet);
        void Editar(Pet pet);
        void Deletar(Pet pet);
    }
}
