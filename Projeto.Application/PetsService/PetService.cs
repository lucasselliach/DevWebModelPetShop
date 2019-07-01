using System;
using System.Collections.Generic;
using Projeto.Domain.Administrativo.Pets;
using Projeto.Domain.Administrativo.Pets.PetInterfaces.Repositories;
using Projeto.Domain.Administrativo.Pets.PetInterfaces.Services;
using Projeto.Domain.Administrativo.Pets.PetInterfaces.Validations;

namespace Projeto.Application.PetsService
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IPetValidation _petValidation;
        
        public PetService(IPetRepository petRepository, IPetValidation petValidation)
        {
            _petRepository = petRepository;
            _petValidation = petValidation;
        }

        public Pet ConsultarPorCodigo(Guid codigo)
        {
            return _petRepository.ConsultarPorCodigo(codigo);
        }

        public IEnumerable<Pet> ConsultarTodos()
        {
            return _petRepository.ConsultarTodos();
        }

        public void Criar(Pet pet)
        {
            var petResults = _petValidation.IsValid(pet);
            if (petResults.IsValid)
            {
                _petRepository.Criar(pet);
            }
            else
            {
                throw new Exception(petResults.ToString("~"));
            }
        }

        public void Editar(Pet pet)
        {
            var petResults = _petValidation.IsValid(pet);
            if (petResults.IsValid)
            {
                _petRepository.Editar(pet);
            }
            else
            {
                throw new Exception(petResults.ToString("~"));
            }
        }

        public void Deletar(Pet pet)
        {
            var petResults = _petValidation.IsValid(pet);
            if (petResults.IsValid)
            {
                _petRepository.Deletar(pet);
            }
            else
            {
                throw new Exception(petResults.ToString("~"));
            }
        }
    }
}
