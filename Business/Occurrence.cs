using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Occurrence
    {
        public int idOcorrencia { get; set; }
        public int idRadar { get; set; }
        public string dataOcorrencia { get; set; }
        public DateTime dataCriacao { get; set; }
        public double temperatura { get; set; }
        public string veiculoTipo { get; set; }
        public string veiculoPlaca { get; set; }
        public double veiculoVelocidade{ get; set; }
        public int veiculoPassageiroQtd { get; set; }
        public int chuva { get; set; }
        public int acidente { get; set; }

        public void Save()
        {
            new Database.Occurrence().Create(this.idRadar, this.dataOcorrencia, this.temperatura, this.veiculoTipo, this.veiculoPlaca, this.veiculoVelocidade, this.veiculoPassageiroQtd, this.chuva, this.acidente);
        }

        public List<Occurrence> ListAll(int idRadar)
        {
            var occurrenceList = new List<Occurrence>();
            var occurrenceListDb = new Database.Occurrence();
            foreach (DataRow row in occurrenceListDb.ListOccurrencesByRadar(idRadar).Rows)
            {
                var occurrence = new Occurrence();
                occurrence.idOcorrencia = Convert.ToInt32(row["idOcorrencia"]);
                occurrence.idRadar = Convert.ToInt32(row["idRadar"]);
                occurrence.dataOcorrencia = row["dataOcorrencia"].ToString();
                occurrence.temperatura = Convert.ToDouble(row["temperatura"]);
                occurrence.veiculoTipo = row["veiculoTipo"].ToString();
                occurrence.veiculoPlaca = row["veiculoPlaca"].ToString();
                occurrence.veiculoVelocidade = Convert.ToDouble(row["veiculoVelocidade"]);
                occurrence.veiculoPassageiroQtd = Convert.ToInt32(row["veiculoPassageiroQtd"]);
                occurrence.chuva = Convert.ToInt32(row["chuva"]);
                occurrence.acidente = Convert.ToInt32(row["acidente"]);
                occurrence.dataCriacao = Convert.ToDateTime(row["dataCriacao"]);
                occurrenceList.Add(occurrence);
            }
            return occurrenceList;
        }
    }
}
