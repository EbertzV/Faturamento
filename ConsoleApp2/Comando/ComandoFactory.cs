namespace Cliente
{
    public interface IComandoFactory
    {
        IComandoHandler Gerar(string comando);
    }
}
