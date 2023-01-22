using ImportacaoCSVclientes.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoCSVclientes.Service
{
    internal class ImportacaoService
    {
        private List<Models.Cliente> clientes = new List<Models.Cliente>();
        private readonly Repositories.ClienteRepository _repositorio;

        public ImportacaoService()
        {
            _repositorio = new Repositories.ClienteRepository();
        }
        public void ImportarClientes()
        {
            LerCsv();
            _repositorio.AbrirConexao();
            GravarClientes();
            //ApagarClientes();
            _repositorio.FecharConexao();
        }
        private void LerCsv()
        {
            var sr = new StreamReader("C:\\DataBasesLocais\\clientes.csv");
            var linha = "";

            while ((linha = sr.ReadLine()) != null)
            {
                if (linha.Contains("CpfCliente,Nome,Nascimento,Telefone"))
                    continue;
                ConverteLinhasParaModel(linha);
            }
            sr.Close();
        }
        private void ConverteLinhasParaModel(string linha)
        {
            var cliente = new Models.Cliente();

            var colunas = linha.Split(',');
            cliente.CpfCliente = colunas[0];
            cliente.Nome = colunas[1];
            cliente.Nascimento = DateTime.ParseExact(colunas[2], "yyyy-MM-dd", null);
            cliente.Telefone = string.IsNullOrWhiteSpace(colunas[3]) ? null : colunas[3];

            clientes.Add(cliente);
        }
        private void GravarClientes()
        {
            foreach (var cliente in clientes)
            {
                if (_repositorio.SeExiste(cliente.CpfCliente))
                    _repositorio.Atualizar(cliente);
                else
                    _repositorio.Inserir(cliente);
            }
        }
        private void ApagarClientes()
        {
            var clientes = _repositorio.ListarClientes();

            foreach (var cliente in clientes)
            {
                _repositorio.Deletar(cliente.CpfCliente);
            }
        }
    }
}
