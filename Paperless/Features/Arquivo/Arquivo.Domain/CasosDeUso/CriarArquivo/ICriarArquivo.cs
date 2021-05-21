using Paperless.Shared.Utils;

namespace Arquivo.Domain.CasosDeUso.CriarArquivo
{
  public interface ICriarArquivo : IHandler<CriarArquivoCommand, bool>
  {
  }
}
