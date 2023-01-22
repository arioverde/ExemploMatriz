using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCliente.Repositories
{
    public class Contexto
    {
        internal readonly MySqlConnection _conn;

        public Contexto()
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
    }
}
