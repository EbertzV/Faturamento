namespace Faturamento.Definicoes
{
    public class Falha
    {
        public Falha(int codigo, string mensagem, Falha falhaInterna)
        {
            Codigo = codigo;
            Mensagem = mensagem;
            FalhaInterna = falhaInterna;
        }

        public static Falha Nova(int codigo, string mensagem)
            => new Falha(codigo, mensagem, null);

        public static Falha Nova(int codigo, string mensagem, Falha falhaInterna)
            => new Falha(codigo, mensagem, falhaInterna);

        public int Codigo { get; }
        public string Mensagem { get; }
        public Falha FalhaInterna { get; }
    }
}
