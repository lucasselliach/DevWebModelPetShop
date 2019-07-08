using System;
using System.Collections.Generic;
using System.Linq;
using Projeto.Domain.Administrativo.Pets;
using Projeto.Domain.Administrativo.Pets.PetInterfaces.Repositories;

namespace Projeto.Data.Repositories.PetRepository
{
    public class PetRepository : IPetRepository
    {
        //Somente para não usar nenhum DB
        private readonly IList<Pet> _pets;

        public PetRepository(IList<Pet> pets)
        {
            _pets = pets;
        }


        public Pet ConsultarPorCodigo(Guid codigo)
        {
            return _pets.First(x => x.Codigo == codigo);
        }

        public IEnumerable<Pet> ConsultarTodos()
        {
            return _pets;
        }

        public void Criar(Pet pet)
        {
            _pets.Add(pet);
        }

        public void Editar(Pet pet)
        {
            _pets.Remove(_pets.First(x => x.Codigo == pet.Codigo));
            _pets.Add(pet);
        }

        public void Deletar(Pet pet)
        {
            _pets.Remove(pet);
        }
    }
}
