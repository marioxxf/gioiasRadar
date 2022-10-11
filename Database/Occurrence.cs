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
    public class Occurrence
    {
        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["sqlConn"];
        }

        public void Create(string apelido)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "insert into radars (apelido, dataCriacao) values ('" + apelido + "', getdate())";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
        
        public void Create(int idRadar, string dataOcorrencia, double temperatura, string veiculoTipo, string veiculoPlaca, double veiculoVelocidade, int veiculoPassageiroQtd, int chuva, int acidente)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "insert into occurrences" +
                    " (idRadar, dataOcorrencia, dataCriacao, temperatura, veiculoTipo, veiculoPlaca, veiculoVelocidade, veiculoPassageiroQtd, chuva, acidente)" +
                    " values (" + idRadar + ", '" + dataOcorrencia + "', getdate(), '" + temperatura + "', '" + veiculoTipo + "', '" + veiculoPlaca + "'," +
                    "'" + veiculoVelocidade + "', " + veiculoPassageiroQtd + ", " + chuva + ", " + acidente + ")";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public DataTable ListOccurrencesByRadar(int idRadar)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from occurrences where idRadar = " + idRadar;
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
