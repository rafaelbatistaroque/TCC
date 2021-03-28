using Paperless.Shared.Erros;
using Paperless.Shared.Utils;
using System;
using Usuario.Business.Contracts;
using Usuario.Business.Models;
using Usuario.Infra.EF;
using Usuario.Infra.Erros;

namespace Usuario.Infra.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _context;
        public UsuarioRepository(UsuarioContext context)
        {
            _context = context;
        }

        public Either<ErroBase, bool> CriarUsuario(UsuarioDoSistemaModel usuario)
        {
            try
            {
                _context.Add(usuario);
                var resposta = _context.SaveChanges();

                return resposta > 0;
            }
            catch(Exception e)
            {
                return new ErroComunicacaoBancoDeDados(e.Message);
            }
        }
    }
}
