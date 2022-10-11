using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Radar
    {
        public int idRadar { get; set; }
        public string apelido { get; set; }
        public DateTime dataCriacao { get; set; }

        public void Save()
        {
            new Database.Radar().Create(this.apelido);
        }

        public List<Radar> ListAll()
        {
            var listaRadares = new List<Radar>();
            var radaresDb = new Database.Radar();
            foreach (DataRow row in radaresDb.ListAllItens().Rows)
            {
                var radar = new Radar();
                radar.idRadar = Convert.ToInt32(row["idRadar"]);
                radar.apelido = row["apelido"].ToString();
                radar.dataCriacao = Convert.ToDateTime(row["dataCriacao"]);
                listaRadares.Add(radar);
            }
            return listaRadares;
        }

        public object FoundInfoById(int id)
        {
            var radar = new Radar();
            var radarDb = new Database.Radar();
            foreach (DataRow row in radarDb.FoundInfoByIdItem(id).Rows)
            {
                radar.idRadar = Convert.ToInt32(row["idRadar"]);
                radar.apelido = row["apelido"].ToString();
                radar.dataCriacao = Convert.ToDateTime(row["dataCriacao"]);
            }
            return radar;
        }

        public static object FoundLastRadarCreated()
        {
            var radar = new Radar();
            var radarDb = new Database.Radar();
            foreach (DataRow row in radarDb.FoundLastItemCreated().Rows)
            {
                radar.idRadar = Convert.ToInt32(row["idRadar"]);
                radar.apelido = row["apelido"].ToString();
                radar.dataCriacao = Convert.ToDateTime(row["dataCriacao"]);
            }
            return radar;
        }
    }
}
