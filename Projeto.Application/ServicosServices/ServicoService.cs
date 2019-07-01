using System;
using System.Collections.Generic;
using Projeto.Domain.Operacional.Servicos;
using Projeto.Domain.Operacional.Servicos.ServicoInterfaces.Repositories;
using Projeto.Domain.Operacional.Servicos.ServicoInterfaces.Services;
using Projeto.Domain.Operacional.Servicos.ServicoInterfaces.Validations;

namespace Projeto.Application.ServicosServices
{
    public class ServicoService : IServicoService
    {
        private readonly IServicoRepository _servicoRepository;
        private readonly IServicoValidation _servicoValidation;

        public ServicoService(IServicoRepository servicoRepository, IServicoValidation servicoValidation)
        {
            _servicoRepository = servicoRepository;
            _servicoValidation = servicoValidation;
        }

        public Servico ConsultarPorCodigo(Guid codigo)
        {
            return _servicoRepository.ConsultarPorCodigo(codigo);
        }

        public IEnumerable<Servico> ConsultarTodos()
        {
            return _servicoRepository.ConsultarTodos();
        }

        public void Criar(Servico servico)
        {
            var results = _servicoValidation.IsValid(servico);

            if (results.IsValid)
            {
                _servicoRepository.Criar(servico);
            }
            else
            {
                throw new Exception(results.ToString("~"));
            }
        }

        public void EditarColaborador(Servico servico)
        {
            var results = _servicoValidation.IsValid(servico);

            if (results.IsValid)
            {
                _servicoRepository.EditarColaborador(servico);
            }
            else
            {
                throw new Exception(results.ToString("~"));
            }
        }

        public void EditarIniciarServico(Servico servico)
        {
            var results = _servicoValidation.IsValid(servico);

            if (results.IsValid)
            {
                _servicoRepository.EditarIniciarServico(servico);
            }
            else
            {
                throw new Exception(results.ToString("~"));
            }
        }

        public void EditarFinalizarServico(Servico servico)
        {
            var results = _servicoValidation.IsValid(servico);

            if (results.IsValid)
            {
                _servicoRepository.EditarFinalizarServico(servico);
            }
            else
            {
                throw new Exception(results.ToString("~"));
            }
        }

        public void Deletar(Servico servico)
        {
            var results = _servicoValidation.IsValid(servico);

            if (results.IsValid)
            {
                _servicoRepository.Deletar(servico);
            }
            else
            {
                throw new Exception(results.ToString("~"));
            }
        }
    }
}
