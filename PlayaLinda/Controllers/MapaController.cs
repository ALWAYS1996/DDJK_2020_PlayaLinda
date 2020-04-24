using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayaLinda.Controllers
{
    public class MapaController : Controller
    {
        // GET: Mapa

        NEGOCIO.MapaCapaNegocio capaNegocios = new NEGOCIO.MapaCapaNegocio();
        NEGOCIO.ContenidoCapaNegocio contenido = new NEGOCIO.ContenidoCapaNegocio();
        public ViewResult Mapa(string lat, string lng)
        {
            ENTIDAD.Mapa mapa = new ENTIDAD.Mapa(); mapa.latitudOrigen = lat; mapa.longitudOrigen = lng;
            ViewData["contenidoVista"] = contenido.listadoContenido(new ENTIDAD.Contenido(3));
            capaNegocios.modificarCoordenadasOrigen(mapa);
            return View(capaNegocios.listadoCoordenadasOrigen());

        }

        public ActionResult Llegar()
        {
            return View();
        }
    }
}