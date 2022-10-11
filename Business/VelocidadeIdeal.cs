using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class VelocidadeIdeal
    {
        public string velocidade { get; set; }
        public int idRadar { get; set; }

        public object FoundInfoById(int idRadar)
        {
            var velIdeal = new VelocidadeIdeal();
            var velIdealDb = new Database.VelocidadeIdeal();
            foreach (DataRow row in velIdealDb.FoundInfoByIdItem(idRadar).Rows)
            {
                velIdeal.velocidade = row["velocidadeSegura"].ToString();
                velIdeal.idRadar = idRadar;
            }
            return velIdeal;
        }
    }
}
