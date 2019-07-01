using System;
using System.Collections.Generic;
using Projeto.Domain.Shared.Paises;
using Projeto.Domain.Shared.Paises.PaisInterfaces.Repositories;
using Projeto.Domain.Shared.Paises.PaisInterfaces.Services;
using Projeto.Domain.Shared.Paises.PaisInterfaces.Validations;

namespace Projeto.Application.PaisesService
{
    public class PaisService : IPaisService
    {
        private readonly IPaisRepository _paisRepository;
        private readonly IPaisValidation _paisValidation;

        public PaisService(IPaisRepository paisRepository, IPaisValidation paisValidation)
        {
            _paisRepository = paisRepository;
            _paisValidation = paisValidation;
        }

        public Pais ConsultarPorCodigo(Guid codigo)
        {
            return _paisRepository.ConsultarPorCodigo(codigo);
        }

        public IEnumerable<Pais> ConsultarTodos()
        {
            return _paisRepository.ConsultarTodos();
        }

        public void Criar(Pais pais)
        {
            var results = _paisValidation.IsValid(pais);

            if (results.IsValid)
            {
                _paisRepository.Criar(pais);
            }
            else
            {
                throw new Exception(results.ToString("~"));
            }
        }

        public void Editar(Pais pais)
        {
            var results = _paisValidation.IsValid(pais);

            if (results.IsValid)
            {
                _paisRepository.Editar(pais);
            }
            else
            {
                throw new Exception(results.ToString("~"));
            }
        }

        public void Deletar(Pais pais)
        {
            var results = _paisValidation.IsValid(pais);

            if (results.IsValid)
            {
                _paisRepository.Deletar(pais);
            }
            else
            {
                throw new Exception(results.ToString("~"));
            }
        }
    }
}
