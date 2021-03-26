namespace Colaborador.Domain.Entidades
{
    public class Colaborador : Usuario
    {
        public string ColaboradorNome { get; set; }
        public string ColaboradorCPF { get; set; }
        public string ColaboradorFuncaoEmpresa { get; set; }
        public bool EhUsuarioSistema { get; set; }
    }
}
