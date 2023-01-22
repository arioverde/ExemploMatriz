namespace ImportacaoCSVclientes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var importacaoClientes = new Service.ImportacaoService();
            importacaoClientes.ImportarClientes();
        }
    }
}