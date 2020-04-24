using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayaLinda.Controllers
{
    public class ItinerarioController : Controller
    {
        // GET: Itineracio
        NEGOCIO.ItinerarioCapaNegocio itinerario = new NEGOCIO.ItinerarioCapaNegocio();
        public ActionResult Itinerario() {
        return View(itinerario.listadoItinerario());
        }
    }
}