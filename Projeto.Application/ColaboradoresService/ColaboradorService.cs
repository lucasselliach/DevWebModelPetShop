using System;
using System.Collections.Generic;
using Projeto.Domain.Administrativo.Colaboradores;
using Projeto.Domain.Administrativo.Colaboradores.ColaboradorInterfaces.Repositories;
using Projeto.Domain.Administrativo.Colaboradores.ColaboradorInterfaces.Services;
using Projeto.Domain.Administrativo.Colaboradores.ColaboradorInterfaces.Validations;
using Projeto.Domain.Shared.Pessoas.PessoaInterfaces.Repositories;

namespace Projeto.Application.ColaboradoresService
{
    public class ColaboradorService : IColaboradorService
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IColaboradorValidation _colaboradorValidation;
        private readonly IPessoaRepository _pessoaRepository;

        public ColaboradorService(IColaboradorRepository colaboradorRepository, IColaboradorValidation colaboradorValidation, IPessoaRepository pessoaRepository)
        {
            _colaboradorRepository = colaboradorRepository;
            _colaboradorValidation = colaboradorValidation;
            _pessoaRepository = pessoaRepository;
        }

        public Colaborador ConsultarPorCodigo(Guid codigo)
        {
            return _colaboradorRepository.ConsultarPorCodigo(codigo);
        }

        public IEnumerable<Colaborador> ConsultarTodos()
        {
            return _colaboradorRepository.ConsultarTodos();
        }

        public void Criar(Colaborador colaborador)
        {
            var results = _colaboradorValidation.IsValid(colaborador);

            if (results.IsValid)
            {
                _pessoaRepository.Criar(colaborador.PessoaFisica);
                _colaboradorRepository.Criar(colaborador);
            }
            else
            {
                throw new Exception(results.ToString("~"));
            }
        }

        public void Editar(Colaborador colaborador)
        {
            var results = _colaboradorValidation.IsValid(colaborador);

            if (results.IsValid)
            {
                _pessoaRepository.Editar(colaborador.PessoaFisica);
                _colaboradorRepository.Editar(colaborador);
            }
            else
            {
                throw new Exception(results.ToString("~"));
            }
        }

        public void Deletar(Colaborador colaborador)
        {
            var results = _colaboradorValidation.IsValid(colaborador);

            if (results.IsValid)
            {
                _pessoaRepository.Deletar(colaborador.PessoaFisica);
                _colaboradorRepository.Deletar(colaborador);
            }
            else
            {
                throw new Exception(results.ToString("~"));
            }
        }
    }
}
