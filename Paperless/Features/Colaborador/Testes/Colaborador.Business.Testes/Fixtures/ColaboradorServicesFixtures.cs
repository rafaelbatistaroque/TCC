﻿using Colaborador.Business.Models;
using Colaborador.Domain.CasosDeUso.AlterarColaborador;
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

        public ColaboradorEmpresa GerarColaboradorEmpresaAlterar()
           => ColaboradorEmpresa.Alterar(COLABORADOR_ID_VALIDO_ALTERAR, COLABORADOR_PRIMEIRO_NOME_ALTERAR, COLABORADOR_SOBRENOME_ALTERAR, (int)EColaboradorFuncao.GERENTE);

        public ColaboradorEmpresa GerarColaboradorEmpresaRetorno()
            => ColaboradorEmpresa.Retornar(COLABORADOR_ID_VALIDO, $"{COLABORADOR_PRIMEIRO_NOME} {COLABORADOR_SOBRENOME}", COLABORADOR_CPF, (int)EColaboradorFuncao.PROGRAMADOR);

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

        public ColaboradorModel GerarColaboradorModelAlterado()
        {
            var c = GerarColaboradorEmpresaAlterar();
            return new ColaboradorModel()
            {
                Id = c.Id,
                ColaboradorCPF = c.ColaboradorCPF,
                Funcao = c.Funcao,
                Nome = c.ColaboradorNome
            };
        }

        public List<ColaboradorEmpresa> GerarListaColaboradorEmpresa()
            => new List<ColaboradorEmpresa>() { GerarColaboradorEmpresaRetorno() };

        public List<ColaboradorModel> GerarListaColaboradorModel()
            => new List<ColaboradorModel>() { GerarColaboradorModel() };

        public CriarColaboradorCommand GerarCriarColaboradorCommandInvalido(string primeiroNome, string sobrenome, string colaboradorCpf, int colaboradorFuncaoEmpresa)
            => new CriarColaboradorCommand() { PrimeiroNome = primeiroNome, Sobrenome = sobrenome, CPF = colaboradorCpf, FuncaoEmpresa = colaboradorFuncaoEmpresa };

        public CriarColaboradorCommand GerarCriarColaboradorCommandValido()
            => new CriarColaboradorCommand() { PrimeiroNome = COLABORADOR_PRIMEIRO_NOME, Sobrenome = COLABORADOR_SOBRENOME, CPF = COLABORADOR_CPF, FuncaoEmpresa = (int)EColaboradorFuncao.PROGRAMADOR };

        public AlterarColaboradorCommand GerarAlterarColaboradorCommandInvalido(int id, string primeiroNome, string sobrenome, int colaboradorFuncaoEmpresa)
            => new AlterarColaboradorCommand() { Id = id, PrimeiroNome = primeiroNome, Sobrenome = sobrenome, FuncaoEmpresa = colaboradorFuncaoEmpresa };

        public AlterarColaboradorCommand GerarAlterarColaboradorCommandValido()
          => new AlterarColaboradorCommand() { Id = COLABORADOR_ID_VALIDO_ALTERAR, PrimeiroNome = COLABORADOR_PRIMEIRO_NOME_ALTERAR, Sobrenome = COLABORADOR_SOBRENOME_ALTERAR, FuncaoEmpresa = (int)EColaboradorFuncao.GERENTE };

        public string GerarPatternCPFComCaracteresEspeciais()
            => @"(\d{3}\.){2}(\d{3}\-)(\d{2})";

        public ErroBase GerarErroGenerico() => ErroGenerico();
    }
}
