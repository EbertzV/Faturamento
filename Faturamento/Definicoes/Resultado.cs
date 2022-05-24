namespace Faturamento.Definicoes
{

    public class Resultado<T>
    {
        public Resultado(bool ehSucesso, bool ehFalha, T valor, Falha falha)
        {
            EhSucesso = ehSucesso;
            EhFalha = ehFalha;
            Valor = valor;
            Falha = falha;
        }

        public static Resultado<T> NovoSucesso(T valor)
            => new Resultado<T>(true, false, valor, null);

        public static Resultado<T> NovaFalha(Falha falha)
            => new Resultado<T>(false, true, default, falha);

        public bool EhSucesso { get; }
        public bool EhFalha { get; }
        public Falha Falha { get; }
        public T Valor { get; }

        public static implicit operator Resultado<T>(T objeto)
            => NovoSucesso(objeto);

        public static implicit operator Resultado<T>(Falha falha)
            => NovaFalha(falha);
    }
}
