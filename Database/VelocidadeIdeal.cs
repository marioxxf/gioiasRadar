using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class VelocidadeIdeal
    {
        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["sqlConn"];
        }

        public DataTable FoundInfoByIdItem(int idRadar)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select sum(veiculoVelocidade) as 'somaVelocidadesSeguras', count(veiculoVelocidade) as 'qtdOccorenciaSegura', cast(sum(veiculoVelocidade)/count(veiculoVelocidade) as NUMERIC(10,1)) as 'velocidadeSegura' from (SELECT * from occurrences where acidente = 0 and idRadar = " + idRadar + ") as myTable";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
    }
}
