﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ImportacaoCSVclientes.Repositories
{
    internal class ClienteRepository
    {
        private readonly MySqlConnection _conn;

        public ClienteRepository()
        {
            _conn = new MySqlConnection("Server=sql10.freemysqlhosting.net;Database=sql10591856;Uid=sql10591856;Pwd=yHr7GRRHqn;");
        }
        public void AbrirConexao()
        {
            _conn.Open();
        }
        public void FecharConexao()
        {
            _conn.Close();
        }
        public void Inserir(Models.Cliente model)
        {
            string comandoSql = @"INSERT INTO Cliente (CpfCliente, Nome, Nascimento, Telefone) 
                                VALUES 
                                (@CpfCliente, @Nome, @Nascimento, @Telefone);";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@CpfCliente", model.CpfCliente);
                cmd.Parameters.AddWithValue("@Nome", model.Nome);
                cmd.Parameters.AddWithValue("@Nascimento", model.Nascimento);
                cmd.Parameters.AddWithValue("@Telefone", model.Telefone);
                cmd.ExecuteNonQuery();
            }
        }
        public void Atualizar(Models.Cliente model)
        {
            string comandoSql = @"UPDATE Cliente 
                                SET Nome = @Nome, Nascimento = @Nascimento, Telefone = @Telefone 
                                WHERE CpfCliente = @CpfCliente;";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@CpfCliente", model.CpfCliente);
                cmd.Parameters.AddWithValue("@Nome", model.Nome);
                cmd.Parameters.AddWithValue("@Nascimento", model.Nascimento);
                cmd.Parameters.AddWithValue("@Telefone", model.Telefone);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o Cpf {model.CpfCliente}");
            }
        }
        public bool SeExiste(string CpfCliente)
        {
            string comandoSql = @"SELECT COUNT(CpfCliente) AS Total FROM Cliente WHERE CpfCliente = @CpfCliente;";
            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@CpfCliente", CpfCliente);
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }
        public List<Models.Cliente> ListarClientes()
        {
            string comandoSql = @"SELECT CpfCliente, Nome, Nascimento, Telefone FROM Cliente;";
            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                using (var rdr = cmd.ExecuteReader())
                {
                    var clientes = new List<Models.Cliente>();
                    while (rdr.Read())
                    {
                        var cliente = new Models.Cliente();
                        cliente.CpfCliente = Convert.ToString(rdr["CpfCliente"]);
                        cliente.Nome = Convert.ToString(rdr["Nome"]);
                        cliente.Nascimento = Convert.ToDateTime(rdr["Nascimento"]);
                        cliente.Telefone = rdr["Telefone"] == DBNull.Value ? null : Convert.ToString(rdr["Telefone"]);
                        clientes.Add(cliente);
                    }
                    return clientes;
                }
            }
        }
        public void Deletar(string CpfCliente)
        {
            string comandoSql = "DELETE FROM Cliente WHERE CpfCliente = @CpfCliente;";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@CpfCliente", CpfCliente);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o Cpf {CpfCliente}");
            }
        }
    }
}
