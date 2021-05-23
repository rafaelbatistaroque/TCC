using Paperless.Shared.Erros;
using Paperless.Shared.Utils;
using System.Collections.Generic;
using System.Linq;
using Usuario.Business.Contracts;
using Usuario.Domain.CasosDeUso.ObterUsuarios;
using Usuario.Domain.Entidades;

namespace Usuario.Business.Services
{
    public class ObterUsuariosHandler : IObterUsuarios
    {
        private readonly IUsuarioRepository _repositorio;
        private readonly IUsuarioAdapters _adapter;

        public ObterUsuariosHandler(IUsuarioRepository repositorio, IUsuarioAdapters adapter)
        {
            _repositorio = repositorio;
            _adapter = adapter;
        }

        public Either<ErroBase, IReadOnlyCollection<UsuarioDoSistema>> Handler()
        {
            var usuarioModel = _repositorio.ObterUsuarios();
            var usuarioDoSitema = _adapter.DeListaUsuarioDoSistemaModelParaListaUsuarioDoSistema(usuarioModel);

            return usuarioDoSitema.ToList();
        }
    }
}
