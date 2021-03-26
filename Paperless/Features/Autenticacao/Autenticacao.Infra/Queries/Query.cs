using Autenticacao.Business.Models;
using System;
using System.Linq.Expressions;

namespace Autenticacao.Infra.Queries
{
    public class Query
    {
        public static Expression<Func<UsuarioModel, bool>> UsuarioAtivoComEsteIdentificador(int identificador)
        {
            return usuario => usuario.EhUsuarioAtivo == true && usuario.UsuarioIdentificador == identificador;
        }
    }
}
