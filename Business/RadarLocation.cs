using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RadarLocation
    {
        public int idRadarLocal { get; set; }
        public int idRadar { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string uf { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public int cep { get; set; }
        public string viaTipo { get; set; }

        public void Save()
        {
            new Database.RadarLocation().Create(this.idRadar, this.latitude, this.longitude, this.uf, this.cidade, this.bairro, this.cep, this.viaTipo);
        }

        public List<RadarLocation> ListAll()
        {
            var listaLocalDosRadares = new List<RadarLocation>();
            var radaresDb = new Database.RadarLocation();
            foreach (DataRow row in radaresDb.ListAllItens().Rows)
            {
                var radarLocation = new RadarLocation();
                radarLocation.idRadarLocal = Convert.ToInt32(row["idRadarLocal"]);
                radarLocation.idRadar = Convert.ToInt32(row["idRadar"]);
                radarLocation.latitude = row["latitude"].ToString();
                radarLocation.longitude = row["longitude"].ToString();
                radarLocation.uf = row["uf"].ToString();
                radarLocation.cidade = row["cidade"].ToString();
                radarLocation.bairro = row["bairro"].ToString();
                radarLocation.cep = Convert.ToInt32(row["cep"]);
                radarLocation.viaTipo = row["viaTipo"].ToString();
                listaLocalDosRadares.Add(radarLocation);
            }
            return listaLocalDosRadares;
        }

        public object FoundInfoById(int id)
        {
            var radarLocation = new RadarLocation();
            var radarDb = new Database.RadarLocation();
            foreach (DataRow row in radarDb.FoundInfoByIdItem(id).Rows)
            {
                radarLocation.idRadarLocal = Convert.ToInt32(row["idRadarLocal"]);
                radarLocation.idRadar = Convert.ToInt32(row["idRadar"]);
                radarLocation.latitude = row["latitude"].ToString();
                radarLocation.longitude = row["longitude"].ToString();
                radarLocation.uf = row["uf"].ToString();
                radarLocation.cidade = row["cidade"].ToString();
                radarLocation.bairro = row["bairro"].ToString();
                radarLocation.cep = Convert.ToInt32(row["cep"]);
                radarLocation.viaTipo = row["viaTipo"].ToString();
            }
            return radarLocation;
        }
    }
}
