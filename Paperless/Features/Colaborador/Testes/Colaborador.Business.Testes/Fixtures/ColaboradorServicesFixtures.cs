using Colaborador.Business.Models;
using Colaborador.Domain.CasosDeUso.CriarColaborador;
using Colaborador.Domain.Entidades;
using Colaborador.Domain.ValueObjects;
using Colaborador.Fixtures;
using Moq.AutoMock;
using Paperless.Shared.Enums;
using Paperless.Shared.Erros;
using System.Collections.Generic;

namespace Colaborador.Business.Testes.Fixtures
{
    public class ColaboradorServicesFixtures : ColaboradorFixtures
    {
        public AutoMocker Mocker { get; }
        public ColaboradorServicesFixtures()
        {
            Mocker = new AutoMocker();
        }

        public T GerarSUT<T>() where T : class
            => Mocker.CreateInstance<T>();

        public ColaboradorNome GerarColaboradorNome()
            => ColaboradorNome.Criar(COLABORADOR_PRIMEIRO_NOME, COLABORADOR_SOBRENOME);

        public CPF GerarColaboradorCPF()
            => CPF.Criar(COLABORADOR_CPF);

        public ColaboradorFuncao GerarColaboradorFuncao()
            => ColaboradorFuncao.Criar((int)EColaboradorFuncao.PROGRAMADOR);

        public ColaboradorEmpresa GerarColaboradorEmpresa()
         => ColaboradorEmpresa.Criar(COLABORADOR_PRIMEIRO_NOME, COLABORADOR_SOBRENOME, COLABORADOR_CPF, (int)EColaboradorFuncao.PROGRAMADOR);

        public ColaboradorEmpresa GerarColaboradorEmpresaRetorno()
        => ColaboradorEmpresa.Retornar($"{COLABORADOR_PRIMEIRO_NOME} {COLABORADOR_SOBRENOME}", COLABORADOR_CPF, (int)EColaboradorFuncao.PROGRAMADOR);

        public ColaboradorModel GerarColaboradorModel()
        {
            var c = GerarColaboradorEmpresa();
            return new ColaboradorModel()
            {
                ColaboradorCPF = c.ColaboradorCPF,
                Funcao = c.Funcao,
                Nome = c.ColaboradorNome
            };
        }

        public List<ColaboradorEmpresa> GerarListaColaboradorEmpresa()
            => new List<ColaboradorEmpresa>() { GerarColaboradorEmpresaRetorno() };

        public List<ColaboradorModel> GerarListaColaboradorModel()
            => new List<ColaboradorModel>() { GerarColaboradorModel() };

        public CriarColaboradorCommand GerarCriarColaboradorCommand(string primeiroNome, string sobrenome, string colaboradorCpf, int colaboradorFuncaoEmpresa)
            => new CriarColaboradorCommand() { PrimeiroNome = primeiroNome, Sobrenome = sobrenome, CPF = colaboradorCpf, FuncaoEmpresa = colaboradorFuncaoEmpresa };

        public CriarColaboradorCommand GerarCriarColaboradorCommand()
          => new CriarColaboradorCommand() { PrimeiroNome = COLABORADOR_PRIMEIRO_NOME, Sobrenome = COLABORADOR_SOBRENOME, CPF = COLABORADOR_CPF, FuncaoEmpresa = (int)EColaboradorFuncao.PROGRAMADOR };

        public string GerarPatternCPFComCaracteresEspeciais()
            => @"(\d{3}\.){2}(\d{3}\-)(\d{2})";

        public ErroBase GerarErroGenerico() => ErroGenerico();
    }
}
