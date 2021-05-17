﻿using Autenticacao.Business.Facades;
using Autenticacao.Business.Models;
using Moq.AutoMock;
using Autenticacao.Fixtures;
using Paperless.Shared.Erros;

namespace Autenticacao.Business.Testes.Fixtures
{
    public class AutenticacaoFacadesFixtures : AutenticacaoFixtures
    {
        public AutoMocker Mocker { get; }
        public AutenticacaoFacadesFixtures()
        {
            Mocker = new AutoMocker();
        }

        public AutenticacaoFacades GerarSUT()
            => Mocker.CreateInstance<AutenticacaoFacades>();

        public UsuarioDoSistemaModel GerarUsuarioModel()
           => new UsuarioDoSistemaModel()
           {
               UsuarioNome = USUARIO_NOME_VALIDO,
               UsuarioSenha = SENHA_BASE64_VALIDA,
               UsuarioIdentificacao = USUARIO_IDENTIFICADOR_VALIDO,
               EhUsuarioAtivo = USUARIO_ATIVO_VALIDO
           };

        public ErroBase GerarErroGenerico() => ErroGenerico();
    }
}
