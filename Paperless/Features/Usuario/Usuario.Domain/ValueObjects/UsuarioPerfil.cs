using Paperless.Shared.Utils;

namespace Usuario.Domain.ValueObjects
{
    public sealed class UsuarioPerfil
    {
        public int PerfilId { get; }
        public string PerfilNome { get; }

        private UsuarioPerfil(int perfilId)
        {
            PerfilId = perfilId;
        }

        private UsuarioPerfil(int perfilId, string perfilNome) : this(perfilId)
        {
            PerfilNome = perfilNome;
        }

        public static UsuarioPerfil Criar(int perfilId)
        {
            var perfilIdValidado = Padronizacoes.ValidarPerfilId(perfilId);

            return new UsuarioPerfil(perfilIdValidado);
        }

        public static UsuarioPerfil Retornar(int perfilId)
        {
            var perfilIdValidado = Padronizacoes.ValidarPerfilId(perfilId);
            var nomePerfil = Padronizacoes.ObterNomePerfil(perfilIdValidado);

            return new UsuarioPerfil(perfilIdValidado, nomePerfil);
        }
    }
}
