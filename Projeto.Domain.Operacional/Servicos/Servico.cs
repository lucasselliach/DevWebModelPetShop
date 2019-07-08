using System;
using Projeto.Domain.Administrativo.Clientes;
using Projeto.Domain.Administrativo.Colaboradores;
using Projeto.Domain.Administrativo.Pets;

namespace Projeto.Domain.Operacional.Servicos
{
    public class Servico
    {
        public Guid Codigo { get; }
        public Cliente Cliente { get; }
        public Pet Pet { get; }
        public Colaborador ColaboradorResponsavel { get; private set; }
        public string Tipo { get; }
        public string Status { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public Colaborador GerenteQueAprovouServico { get; private set; }

        public Servico(Cliente cliente, Pet pet, Colaborador colaboradorResponsavel, string tipo)
        {
            Codigo = Guid.NewGuid();
            Cliente = cliente;
            Pet = pet;
            ColaboradorResponsavel = colaboradorResponsavel;
            Tipo = tipo;
            Status = "ABERTO";
            DataInicio = DateTime.Parse("1900-01-01 00:00:00");
            DataFim = DateTime.Parse("1900-01-01 00:00:00");
        }

        public void AlterarColaboradorResponsavel(Colaborador colaboradorResponsavel)
        {
            ColaboradorResponsavel = colaboradorResponsavel;
        }

        public void IniciarServico()
        {
            Status = "INICIADO";
            DataInicio = DateTime.Now;
        }

        public void FinalizarServico(Colaborador gerenteQueAprovouServico)
        {
            GerenteQueAprovouServico = gerenteQueAprovouServico;
            Status = "FINALIZADO";
            DataFim = DateTime.Now;
        }
    }
}
