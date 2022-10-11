using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }

        public List<Cliente> ListarTodosClientes()
        {
            var lista = new List<Cliente>();
            var clienteDb = new Database.Cliente();
            foreach (DataRow row in clienteDb.BuscaTodosClientes().Rows)
            {
                var cliente = new Cliente();
                cliente.id = Convert.ToInt32(row["id"]);
                cliente.nome = row["fullname"].ToString();
                lista.Add(cliente);
            }
            return lista;
        }
    }
}
