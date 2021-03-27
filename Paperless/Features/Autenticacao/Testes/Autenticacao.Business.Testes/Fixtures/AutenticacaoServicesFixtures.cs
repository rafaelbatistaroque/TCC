﻿using Autenticacao.Business.Models;
using Autenticacao.Business.Services;
using Autenticacao.Domain.CasosDeUso.AutenticarUsuario;
using Autenticacao.Domain.Entidades;
using Moq.AutoMock;
using Paperless.Init.Fixtures;
using Paperless.Shared.Erros;

namespace Autenticacao.Business.Testes.Fixtures
{
    public class AutenticacaoServicesFixtures : AutenticacaoFixtures
    {
        public AutoMocker Mocker { get; }
        public AutenticacaoServicesFixtures()
        {
            Mocker = new AutoMocker();
        }

        public AutenticarUsuarioHandler GerarSUT()
            => Mocker.CreateInstance<AutenticarUsuarioHandler>();

        public AutenticarUsuarioCommand GerarAutenticarUsuarioCommand(string usuarioIdentificador, string senha)
            => new AutenticarUsuarioCommand() { UsuarioIdentificador = usuarioIdentificador, Senha = senha };

        public AutenticarUsuarioCommand GerarAutenticarUsuarioCommandValido()
            => new AutenticarUsuarioCommand() { UsuarioIdentificador = USUARIO_IDENTIFICADOR_VALIDO, Senha = SENHA_VALIDA };

        public UsuarioDoSistemaModel GerarUsuarioModel()
            => new UsuarioDoSistemaModel()
            {
                NomeUsuario = USUARIO_NOME_VALIDO,
                Senha = SENHA_VALIDA,
                UsuarioIdentificador = USUARIO_IDENTIFICADOR_VALIDO,
                EhUsuarioAtivo = USUARIO_ATIVO_VALIDO,
                Perfil = USUARIO_PERFIL_VALIDO
            };

        public UsuarioAutenticado GerarUsuarioAutenticado()
            => UsuarioAutenticado.Criar(USUARIO_NOME_VALIDO,FAKE_TOKEN);

        public string GerarTokeFake() => FAKE_TOKEN;

        public ErroBase GerarErrogenerico() => ErroGenerico();
    }
}
