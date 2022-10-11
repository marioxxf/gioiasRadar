using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace radarGioiligente.Controllers
{
    public class RadarController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Perfil(int id)
        {
            ViewBag.Radar = new Radar().FoundInfoById(id);
            ViewBag.RadarLocation = new RadarLocation().FoundInfoById(id);
            ViewBag.VelocidadeIdeal = new VelocidadeIdeal().FoundInfoById(id);
            ViewBag.Occurrences = new Business.Occurrence().ListAll(id);
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public void Criar()
        {
            try
            {
                var radar = new Radar();
                radar.apelido           = Request["txtApelido"];
                radar.Save();

                var lastRadarCreated = Radar.FoundLastRadarCreated();
                Business.Radar lastDefinitiveRadarCreated = (Radar)lastRadarCreated;

                var radarLocation = new RadarLocation();
                radarLocation.idRadar   = lastDefinitiveRadarCreated.idRadar;
                radarLocation.latitude  = Request["txtLatitude"];
                radarLocation.longitude = Request["txtLongitude"];
                radarLocation.uf        = Request["txtUf"];
                radarLocation.cidade    = Request["txtCidade"];
                radarLocation.bairro    = Request["txtBairro"];
                radarLocation.cep       = int.Parse(Request["txtCep"]);
                radarLocation.viaTipo   = Request["txtTipoEst"];
                radarLocation.Save();

                Response.Redirect("/");
                TempData["radarCriado"] = "O radar foi cadastrado com sucesso!";
            }
            catch (Exception erro)
            {
                TempData["radarNaoCriado"] = "O radar não pôde ser cadastrado (" + erro.Message + ")!";
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public void Ocorrer()
        {
            try
            {
                var occurrence = new Occurrence();
                occurrence.idRadar              = int.Parse(Request["txtIdRadar"]);
                occurrence.dataOcorrencia       = Request["txtDateTimeOcc"];
                occurrence.temperatura          = float.Parse(Request["txtTemp"]);
                occurrence.veiculoTipo          = Request["txtTipoVei"];
                occurrence.veiculoPlaca         = Request["txtPlacaVei"];
                occurrence.veiculoVelocidade    = float.Parse(Request["txtVeiVel"]);
                occurrence.veiculoPassageiroQtd = int.Parse(Request["txtQtdPassag"]);
                occurrence.chuva                = int.Parse(Request["txtSelChuva"]);
                occurrence.acidente             = int.Parse(Request["txtSelAcid"]);
                occurrence.Save();

                Response.Redirect("/");
                TempData["ocorrenciaCriada"] = "A ocorrência foi registrada com sucesso!";
                TempData["idPerfilDaOccCriada"] = occurrence.idRadar;
            }
            catch (Exception erro)
            {
                TempData["ocorrenciaNaoCriada"] = "A ocorrência não pôde ser criada (" + erro.Message + ")!";
            }
        }

        public ActionResult Radares()
        {
            return View();
        }
    }
}