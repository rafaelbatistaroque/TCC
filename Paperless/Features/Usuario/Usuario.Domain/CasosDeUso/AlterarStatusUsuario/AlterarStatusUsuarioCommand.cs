using Paperless.Shared.Utils;
using Paperless.Shared.Validacoes;

namespace Usuario.Domain.CasosDeUso.AlterarStatusUsuario
{
    public class AlterarStatusUsuarioCommand : UsuarioCommandQueryValidacoes, ICommandQueryBase
    {
        public string UsuarioCodigo { get; set; }

        public void Validar()
        {
            ValidarUsuarioCodigo(UsuarioCodigo);
        }
    }
}
