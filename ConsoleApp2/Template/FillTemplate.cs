namespace Cliente.Template
{
    public interface IFillTemplate
    {
        string Fill(string section);
    }

    public sealed class FillTemplate : IFillTemplate
    {
        private readonly string _path;

        public FillTemplate(string path)
        {
            _path = path;
        }

        public string Fill(string section)
        {
            var text = System.IO.File.ReadAllText(_path);
            var indiceInicial = text.IndexOf($"<{section}>") + section.Length + 2;
            var indiceFinal = text.IndexOf($"</{section}>") - indiceInicial;
            var value = text.Substring(indiceInicial, indiceFinal);
            return value;
        }
    }
}
