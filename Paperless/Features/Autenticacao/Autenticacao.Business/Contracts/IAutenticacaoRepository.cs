﻿using Autenticacao.Business.Contracts.Extensoes;

namespace Autenticacao.Business.Contracts
{
    public interface IAutenticacaoRepository : IObterUsuarioRepository, IUsuarioExisteRepository
    {
    }
}
