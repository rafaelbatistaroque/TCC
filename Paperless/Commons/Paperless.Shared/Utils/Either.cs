using System;

namespace Paperless.Shared.Utils
{
    public class Either<L, R>
    {
        private readonly bool _sucesso;

        public L Falha { get; }
        public R Sucesso { get; }
        public bool EhSucesso => _sucesso;
        public bool EhFalha => !_sucesso;

        private Either(L falha)
        {
            Falha = falha;
            _sucesso = false;
        }

        private Either(R sucesso)
        {
            Sucesso = sucesso;
            _sucesso = true;
        }

        public T RetornarCaso<T>(Func<L, T> falha, Func<R, T> sucesso)
            => _sucesso == false ? falha(Falha) : sucesso(Sucesso);

        public static implicit operator Either<L, R>(L falha) => new Either<L, R>(falha);
        public static implicit operator Either<L, R>(R sucesso) => new Either<L, R>(sucesso);
    }
}
