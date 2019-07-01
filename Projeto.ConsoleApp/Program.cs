using System;
using Projeto.Application.ClientesService;
using Projeto.Application.ColaboradoresService;
using Projeto.Application.PaisesService;
using Projeto.Application.PetsService;
using Projeto.Application.ServicosServices;
using Projeto.Data.Repositories.ClienteRepository;
using Projeto.Data.Repositories.ColaboradoresRepository;
using Projeto.Data.Repositories.PaisRepository;
using Projeto.Data.Repositories.PessoaRepository;
using Projeto.Data.Repositories.PetRepository;
using Projeto.Data.Repositories.ServicoRepository;
using Projeto.Domain.Administrativo.Clientes;
using Projeto.Domain.Administrativo.Clientes.ClienteInterfaces.Repositories;
using Projeto.Domain.Administrativo.Clientes.ClienteInterfaces.Services;
using Projeto.Domain.Administrativo.Clientes.ClienteInterfaces.Validations;
using Projeto.Domain.Administrativo.Clientes.ClienteValidations;
using Projeto.Domain.Administrativo.Colaboradores;
using Projeto.Domain.Administrativo.Colaboradores.ColaboradorInterfaces.Repositories;
using Projeto.Domain.Administrativo.Colaboradores.ColaboradorInterfaces.Services;
using Projeto.Domain.Administrativo.Colaboradores.ColaboradorInterfaces.Validations;
using Projeto.Domain.Administrativo.Colaboradores.ColaboradorValidations;
using Projeto.Domain.Administrativo.Pets;
using Projeto.Domain.Administrativo.Pets.PetInterfaces.Repositories;
using Projeto.Domain.Administrativo.Pets.PetInterfaces.Services;
using Projeto.Domain.Administrativo.Pets.PetInterfaces.Validations;
using Projeto.Domain.Administrativo.Pets.PetValidations;
using Projeto.Domain.Operacional.Servicos;
using Projeto.Domain.Operacional.Servicos.ServicoInterfaces.Repositories;
using Projeto.Domain.Operacional.Servicos.ServicoInterfaces.Services;
using Projeto.Domain.Operacional.Servicos.ServicoInterfaces.Validations;
using Projeto.Domain.Operacional.Servicos.ServicoValidations;
using Projeto.Domain.Shared.Paises;
using Projeto.Domain.Shared.Paises.PaisInterfaces.Repositories;
using Projeto.Domain.Shared.Paises.PaisInterfaces.Services;
using Projeto.Domain.Shared.Paises.PaisInterfaces.Validations;
using Projeto.Domain.Shared.Paises.PaisValidations;
using Projeto.Domain.Shared.Pessoas;
using Projeto.Domain.Shared.Pessoas.PessoaInterfaces.Repositories;

namespace Projeto.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inicio da aplicação...                               LUCAS ALVES SELLIACH");
            Console.WriteLine("=========================================================================");
            Console.WriteLine("Criando as depedencias tipo scoped, simulando a injeção de dependência.  ");

            IPaisRepository paisRepository = new PaisRepository();
            IPessoaRepository pessoaRepository = new PessoaRepository();
            IColaboradorRepository colaboradorRepository = new ColaboradorRepository();
            IClienteRepository clienteRepository = new ClienteRepository();
            IPetRepository petRepository = new PetRepository();
            IServicoRepository servicoRepository = new ServicoRepository();

            Console.WriteLine("=========================================================================");
            Console.WriteLine("Criação do PAÍS pelo operador do sistema, para simples teste...          ");

            //Depedencia tipo Singleton
            IPaisValidation paisValidation = new PaisValidation();
            IPaisService paisService = new PaisService(paisRepository, paisValidation);
            var pais = new Pais("teste", "teste");
            paisService.Criar(pais);
            Console.WriteLine("Pais Criado!");
            Console.WriteLine("======================");

            Console.WriteLine("Paises cadastrados: ");

            foreach (var paisConsultado in paisService.ConsultarTodos())
            {
                Console.WriteLine("Codigo: " + paisConsultado.Codigo);
                Console.WriteLine("Nome:   " + paisConsultado.Nome);
                Console.WriteLine("Idioma: " + paisConsultado.Idioma);
                Console.WriteLine("-----------------------");
            }

            Console.WriteLine("=========================================================================");
            Console.WriteLine("=========================================================================");
            Console.WriteLine("Criação do Colaborador pelo operador do sistema, para simples teste...   ");
            
            //Depedencia tipo Singleton
            IColaboradorValidation colaboradorValidation1 = new ColaboradorValidation();
            IColaboradorService colaboradorService1 = new ColaboradorService(colaboradorRepository, colaboradorValidation1, pessoaRepository);
            var pessoaFisicaColaborador = new PessoaFisica("Colaboradorzinho", "688.404.530-24", "99999999", DateTime.Now, "teste@teste.com", "99 9999-9999", "99 99999-9999", "Teste de sistema", "teste", 0, "teste", "teste", "teste", "teste", "SC", pais);
            var colaborador1 = new Colaborador(pessoaFisicaColaborador, "Veterinário");
            colaboradorService1.Criar(colaborador1);
            Console.WriteLine("Colaborador 1 pessoa fisica Criada!");

            //Depedencia tipo Singleton
            IColaboradorValidation colaboradorValidation2 = new ColaboradorValidation();
            IColaboradorService colaboradorService2 = new ColaboradorService(colaboradorRepository, colaboradorValidation2, pessoaRepository);
            var pessoaFisicaColaborador2 = new PessoaFisica("Colaboradorzinho 2", "688.404.530-24", "99999999", DateTime.Now, "teste@teste.com", "99 9999-9999", "99 99999-9999", "Teste de sistema", "teste", 0, "teste", "teste", "teste", "teste", "SC", pais);
            var colaborador2 = new Colaborador(pessoaFisicaColaborador2, "Auxiliar Veterinário");
            colaboradorService2.Criar(colaborador2);
            Console.WriteLine("Colaborador 2 pessoa fisica Criada!");
            Console.WriteLine("======================");

            Console.WriteLine("Colaboradores cadastrados: ");

            //Depedencia tipo Singleton
            IColaboradorValidation colaboradorValidation3 = new ColaboradorValidation();
            IColaboradorService colaboradorService3 = new ColaboradorService(colaboradorRepository, colaboradorValidation3, pessoaRepository);
            foreach (var colaboradorConsultado in colaboradorService3.ConsultarTodos())
            {
                Console.WriteLine("Codigo:        " + colaboradorConsultado.Codigo);
                Console.WriteLine("Cargo:         " + colaboradorConsultado.Cargo);
                Console.WriteLine("Data Admissão: " + colaboradorConsultado.DataAdmissao);
                Console.WriteLine("PF Nome:       " + colaboradorConsultado.PessoaFisica.Nome);
                Console.WriteLine("PF CPF:        " + colaboradorConsultado.PessoaFisica.Cpf);
                Console.WriteLine("PF RG:         " + colaboradorConsultado.PessoaFisica.Rg);
                Console.WriteLine("PF Data Nasc.: " + colaboradorConsultado.PessoaFisica.DataNascimento);
                Console.WriteLine("P Codigo:      " + colaboradorConsultado.PessoaFisica.Codigo);
                Console.WriteLine("P Email:       " + colaboradorConsultado.PessoaFisica.Email);
                Console.WriteLine("P Telefone:    " + colaboradorConsultado.PessoaFisica.Telefone);
                Console.WriteLine("P Celular:     " + colaboradorConsultado.PessoaFisica.Celular);
                Console.WriteLine("P Observação:  " + colaboradorConsultado.PessoaFisica.Observacao);
                Console.WriteLine("P Data Cad.:   " + colaboradorConsultado.PessoaFisica.DataCadastro);
                Console.WriteLine("P Logradouro:  " + colaboradorConsultado.PessoaFisica.Logradouro);
                Console.WriteLine("P Numero:      " + colaboradorConsultado.PessoaFisica.Numero);
                Console.WriteLine("P Bairro:      " + colaboradorConsultado.PessoaFisica.Bairro);
                Console.WriteLine("P Complemento: " + colaboradorConsultado.PessoaFisica.Complemento);
                Console.WriteLine("P Cep:         " + colaboradorConsultado.PessoaFisica.Cep);
                Console.WriteLine("P Cidade:      " + colaboradorConsultado.PessoaFisica.Cidade);
                Console.WriteLine("P UF:          " + colaboradorConsultado.PessoaFisica.UnidadeFederativa);
                Console.WriteLine("Pais Codigo:   " + colaboradorConsultado.PessoaFisica.Pais.Codigo);
                Console.WriteLine("Pais Nome:     " + colaboradorConsultado.PessoaFisica.Pais.Nome);
                Console.WriteLine("Pais Idioma:   " + colaboradorConsultado.PessoaFisica.Pais.Idioma);
                Console.WriteLine("-----------------------");
            }

            Console.WriteLine("=========================================================================");
            Console.WriteLine("=========================================================================");
            Console.WriteLine("Criação do CLIENTE pelo operador do sistema, para simples teste...       ");
            
            //Depedencia tipo Singleton
            IClienteValidation clienteValidation1 = new ClienteValidation();
            IClienteService clienteService1 = new ClienteService(clienteRepository, clienteValidation1, pessoaRepository);
            var pessoaFisicaCliente = new PessoaFisica("fulaninho", "688.404.530-24", "99999999", DateTime.Now, "teste@teste.com", "99 9999-9999", "99 99999-9999", "Teste de sistema", "teste", 0, "teste", "teste", "teste", "teste", "SC", pais);
            var clientePessoaFisica = new Cliente(pessoaFisicaCliente);
            clienteService1.Criar(clientePessoaFisica);
            Console.WriteLine("Cliente pessoa fisica Criada!");

            //Depedencia tipo Singleton
            IClienteValidation clienteValidation2 = new ClienteValidation();
            IClienteService clienteService2 = new ClienteService(clienteRepository, clienteValidation2, pessoaRepository);
            var pessoaJuridica1 = new PessoaJuridica("Empresinha", "Empresinha Teste", "56.310.237/0001-23", "614.912.493.506", "123.123.123", "Fulaninho", "teste@teste.com", "99 9999-9999", "99 99999-9999", "Teste de sistema", "teste", 0, "teste", "teste", "teste", "teste", "SC", pais);
            var clientePessoaJuridica = new Cliente(pessoaJuridica1);
            clienteService2.Criar(clientePessoaJuridica);
            Console.WriteLine("Cliente 2 pessoa juridica Criada!");
            Console.WriteLine("======================");

            Console.WriteLine("Clientes cadastrados: ");

            //Depedencia tipo Singleton
            IClienteValidation clienteValidation3 = new ClienteValidation();
            IClienteService clienteService3 = new ClienteService(clienteRepository, clienteValidation3, pessoaRepository);
            
            foreach (var clienteConsultado in clienteService3.ConsultarTodos())
            {
                if (clienteConsultado.Pessoa.GetType() == typeof(PessoaFisica))
                {
                    var pessoaFisica = (PessoaFisica) clienteConsultado.Pessoa;

                    Console.WriteLine("Codigo:        " + clienteConsultado.Codigo);
                    Console.WriteLine("PF Nome:       " + pessoaFisica.Nome);
                    Console.WriteLine("PF CPF:        " + pessoaFisica.Cpf);
                    Console.WriteLine("PF RG:         " + pessoaFisica.Rg);
                    Console.WriteLine("PF Data Nasc.: " + pessoaFisica.DataNascimento);
                    Console.WriteLine("P Codigo:      " + pessoaFisica.Codigo);
                    Console.WriteLine("P Email:       " + pessoaFisica.Email);
                    Console.WriteLine("P Telefone:    " + pessoaFisica.Telefone);
                    Console.WriteLine("P Celular:     " + pessoaFisica.Celular);
                    Console.WriteLine("P Observação:  " + pessoaFisica.Observacao);
                    Console.WriteLine("P Data Cad.:   " + pessoaFisica.DataCadastro);
                    Console.WriteLine("P Logradouro:  " + pessoaFisica.Logradouro);
                    Console.WriteLine("P Numero:      " + pessoaFisica.Numero);
                    Console.WriteLine("P Bairro:      " + pessoaFisica.Bairro);
                    Console.WriteLine("P Complemento: " + pessoaFisica.Complemento);
                    Console.WriteLine("P Cep:         " + pessoaFisica.Cep);
                    Console.WriteLine("P Cidade:      " + pessoaFisica.Cidade);
                    Console.WriteLine("P UF:          " + pessoaFisica.UnidadeFederativa);
                    Console.WriteLine("Pais Codigo:   " + pessoaFisica.Pais.Codigo);
                    Console.WriteLine("Pais Nome:     " + pessoaFisica.Pais.Nome);
                    Console.WriteLine("Pais Idioma:   " + pessoaFisica.Pais.Idioma);
                }

                if (clienteConsultado.Pessoa.GetType() == typeof(PessoaJuridica))
                {
                    var pessoaJuridica = (PessoaJuridica)clienteConsultado.Pessoa;

                    Console.WriteLine("Codigo:        " + clienteConsultado.Codigo);
                    Console.WriteLine("PJ Razão Soci.:" + pessoaJuridica.RazaoSocial);
                    Console.WriteLine("PJ Nome Fant.: " + pessoaJuridica.NomeFantasia);
                    Console.WriteLine("PJ CNPJ:       " + pessoaJuridica.Cnpj);
                    Console.WriteLine("PJ IE:         " + pessoaJuridica.InscricaoEstadual);
                    Console.WriteLine("PJ IM:         " + pessoaJuridica.InscricaoMunicipal);
                    Console.WriteLine("PJ Resp:       " + pessoaJuridica.Responsavel);
                    Console.WriteLine("P Codigo:      " + pessoaJuridica.Codigo);
                    Console.WriteLine("P Email:       " + pessoaJuridica.Email);
                    Console.WriteLine("P Telefone:    " + pessoaJuridica.Telefone);
                    Console.WriteLine("P Celular:     " + pessoaJuridica.Celular);
                    Console.WriteLine("P Observação:  " + pessoaJuridica.Observacao);
                    Console.WriteLine("P Data Cad.:   " + pessoaJuridica.DataCadastro);
                    Console.WriteLine("P Logradouro:  " + pessoaJuridica.Logradouro);
                    Console.WriteLine("P Numero:      " + pessoaJuridica.Numero);
                    Console.WriteLine("P Bairro:      " + pessoaJuridica.Bairro);
                    Console.WriteLine("P Complemento: " + pessoaJuridica.Complemento);
                    Console.WriteLine("P Cep:         " + pessoaJuridica.Cep);
                    Console.WriteLine("P Cidade:      " + pessoaJuridica.Cidade);
                    Console.WriteLine("P UF:          " + pessoaJuridica.UnidadeFederativa);
                    Console.WriteLine("Pais Codigo:   " + pessoaJuridica.Pais.Codigo);
                    Console.WriteLine("Pais Nome:     " + pessoaJuridica.Pais.Nome);
                    Console.WriteLine("Pais Idioma:   " + pessoaJuridica.Pais.Idioma);
                }
                
                Console.WriteLine("-----------------------");
            }


            Console.WriteLine("=========================================================================");
            Console.WriteLine("=========================================================================");
            Console.WriteLine("Criação do PET pelo operador do sistema, para simples teste...           ");

            //Depedencia tipo Singleton
            IPetValidation petValidation1 = new PetValidation();
            IPetService petService1 = new PetService(petRepository, petValidation1);
            var petPessoaFisica = new Pet("Fufuzinho", "Cachorro", DateTime.Now, "PET TESTE 1", clientePessoaFisica);
            petService1.Criar(petPessoaFisica);

            //Depedencia tipo Singleton
            IPetValidation petValidation2 = new PetValidation();
            IPetService petService2 = new PetService(petRepository, petValidation2);
            var petPessoaJuridica1 = new Pet("Zizizinho", "Gato", DateTime.Now, "PET TESTE 2", clientePessoaJuridica);
            petService2.Criar(petPessoaJuridica1);

            //Depedencia tipo Singleton
            IPetValidation petValidation3 = new PetValidation();
            IPetService petService3 = new PetService(petRepository, petValidation3);
            var petPessoaJuridica2 = new Pet("Nanazinho", "Passaro", DateTime.Now, "PET TESTE 3", clientePessoaJuridica);
            petService3.Criar(petPessoaJuridica2);
            
            Console.WriteLine("Pets cadastrados: ");

            IPetValidation petValidation4 = new PetValidation();
            IPetService petService4 = new PetService(petRepository, petValidation4);

            foreach (var petConsultado in petService4.ConsultarTodos())
            {
                Console.WriteLine("Codigo:        " + petConsultado.Codigo);
                Console.WriteLine("Nome:          " + petConsultado.Nome);
                Console.WriteLine("Bio:           " + petConsultado.Bio);
                Console.WriteLine("Data Nasc.:    " + petConsultado.DataNascimento);
                Console.WriteLine("Observação:    " + petConsultado.Observacao);
                Console.WriteLine("Data Cadastro: " + petConsultado.DataCadastro);
                Console.WriteLine("Cli. Dono COD.:" + petConsultado.ClienteDono.Codigo);
                Console.WriteLine("-----------------------");
            }

            Console.WriteLine("=========================================================================");
            Console.WriteLine("=========================================================================");
            Console.WriteLine("Criação do SERVIÇOS pelo operador do sistema, para simples teste...      ");

            //Depedencia tipo Singleton
            IServicoValidation servicoValidation1 = new ServicoValidation();
            IServicoService servicoService1 = new ServicoService(servicoRepository, servicoValidation1);
            var servico1 = new Servico(clientePessoaFisica, petPessoaFisica, colaborador1, "Vacinação");
            servicoService1.Criar(servico1);

            //Depedencia tipo Singleton
            IServicoValidation servicoValidation2 = new ServicoValidation();
            IServicoService servicoService2 = new ServicoService(servicoRepository, servicoValidation2);
            var servico2 = new Servico(clientePessoaJuridica, petPessoaJuridica1, colaborador2, "Banho");
            servicoService2.Criar(servico2);

            //Depedencia tipo Singleton
            IServicoValidation servicoValidation3 = new ServicoValidation();
            IServicoService servicoService3 = new ServicoService(servicoRepository, servicoValidation3);
            var servico3 = new Servico(clientePessoaJuridica, petPessoaJuridica2, colaborador1, "Enfaixar");
            servicoService3.Criar(servico3);
            
            Console.WriteLine("Serviços cadastrados: ");

            //Depedencia tipo Singleton
            IServicoValidation servicoValidation4 = new ServicoValidation();
            IServicoService servicoService4 = new ServicoService(servicoRepository, servicoValidation4);

            foreach (var servicoConsultado in servicoService4.ConsultarTodos())
            {
                Console.WriteLine("Serv. Codigo:  " + servicoConsultado.Codigo);
                Console.WriteLine("Serv. Tipo:    " + servicoConsultado.Tipo);
                Console.WriteLine("Serv. Status:  " + servicoConsultado.Status);
                Console.WriteLine("Serv. DataIni: " + servicoConsultado.DataInicio);
                Console.WriteLine("Serv. DataFim: " + servicoConsultado.DataFim);
                Console.WriteLine("Cliente Codigo:" + servicoConsultado.Cliente.Codigo);
                Console.WriteLine("Pet Codigo:    " + servicoConsultado.Pet.Codigo);
                Console.WriteLine("Colab. Codigo: " + servicoConsultado.ColaboradorResponsavel.Codigo);
                Console.WriteLine("-----------------------");
            }

            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");

            servico1.IniciarServico();
            servicoService4.EditarIniciarServico(servico1);
            Console.WriteLine("Serviço 1:");
            var servicoConsultado1 = servicoService4.ConsultarPorCodigo(servico1.Codigo);
            Console.WriteLine("Serv. Codigo:  " + servicoConsultado1.Codigo);
            Console.WriteLine("Serv. Tipo:    " + servicoConsultado1.Tipo);
            Console.WriteLine("Serv. Status:  " + servicoConsultado1.Status);
            Console.WriteLine("Serv. DataIni: " + servicoConsultado1.DataInicio);
            Console.WriteLine("Serv. DataFim: " + servicoConsultado1.DataFim);
            Console.WriteLine("Cliente Codigo:" + servicoConsultado1.Cliente.Codigo);
            Console.WriteLine("Pet Codigo:    " + servicoConsultado1.Pet.Codigo);
            Console.WriteLine("Colab. Codigo: " + servicoConsultado1.ColaboradorResponsavel.Codigo);
            Console.WriteLine("-----------------------");
            
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");

            servico2.IniciarServico();
            servicoService4.EditarIniciarServico(servico2);
            Console.WriteLine("Serviço 2:");
            var servicoConsultado2 = servicoService4.ConsultarPorCodigo(servico2.Codigo);
            Console.WriteLine("Serv. Codigo:  " + servicoConsultado2.Codigo);
            Console.WriteLine("Serv. Tipo:    " + servicoConsultado2.Tipo);
            Console.WriteLine("Serv. Status:  " + servicoConsultado2.Status);
            Console.WriteLine("Serv. DataIni: " + servicoConsultado2.DataInicio);
            Console.WriteLine("Serv. DataFim: " + servicoConsultado2.DataFim);
            Console.WriteLine("Cliente Codigo:" + servicoConsultado2.Cliente.Codigo);
            Console.WriteLine("Pet Codigo:    " + servicoConsultado2.Pet.Codigo);
            Console.WriteLine("Colab. Codigo: " + servicoConsultado2.ColaboradorResponsavel.Codigo);
            Console.WriteLine("-----------------------");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");

            servico1.FinalizarServico();
            servicoService4.EditarIniciarServico(servico1);
            Console.WriteLine("Serviço 1:");
            servicoConsultado1 = servicoService4.ConsultarPorCodigo(servico1.Codigo);
            Console.WriteLine("Serv. Codigo:  " + servicoConsultado1.Codigo);
            Console.WriteLine("Serv. Tipo:    " + servicoConsultado1.Tipo);
            Console.WriteLine("Serv. Status:  " + servicoConsultado1.Status);
            Console.WriteLine("Serv. DataIni: " + servicoConsultado1.DataInicio);
            Console.WriteLine("Serv. DataFim: " + servicoConsultado1.DataFim);
            Console.WriteLine("Cliente Codigo:" + servicoConsultado1.Cliente.Codigo);
            Console.WriteLine("Pet Codigo:    " + servicoConsultado1.Pet.Codigo);
            Console.WriteLine("Colab. Codigo: " + servicoConsultado1.ColaboradorResponsavel.Codigo);
            Console.WriteLine("-----------------------");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");

            servicoService4.Deletar(servico1);
            Console.WriteLine("Serviço 1 deletado");

            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");
            Console.WriteLine("                                                                         ");

            Console.WriteLine("Serviços que ainda estão ativos: ");
            foreach (var servicoConsultado in servicoService4.ConsultarTodos())
            {
                Console.WriteLine("Serv. Codigo:  " + servicoConsultado.Codigo);
                Console.WriteLine("Serv. Tipo:    " + servicoConsultado.Tipo);
                Console.WriteLine("Serv. Status:  " + servicoConsultado.Status);
                Console.WriteLine("Serv. DataIni: " + servicoConsultado.DataInicio);
                Console.WriteLine("Serv. DataFim: " + servicoConsultado.DataFim);
                Console.WriteLine("Cliente Codigo:" + servicoConsultado.Cliente.Codigo);
                Console.WriteLine("Pet Codigo:    " + servicoConsultado.Pet.Codigo);
                Console.WriteLine("Colab. Codigo: " + servicoConsultado.ColaboradorResponsavel.Codigo);
                Console.WriteLine("-----------------------");
            }
            Console.WriteLine("=========================================================================");
            
            Console.ReadLine();
        }
    }
}
