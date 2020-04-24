using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayaLinda.Controllers
{
    public class ContenidoController : Controller
    {
        // GET: Contenido
        NEGOCIO.ContenidoCapaNegocio capaNegocios = new NEGOCIO.ContenidoCapaNegocio();
        NEGOCIO.ImagenCapaNegocio img = new NEGOCIO.ImagenCapaNegocio();
        NEGOCIO.PromocionCapaNegocio promocionCapaNegocio = new NEGOCIO.PromocionCapaNegocio();
        public ActionResult Contacto()
        {

            ViewData["contenidoVista"] = capaNegocios.listadoContenido(new ENTIDAD.Contenido(2));
            return View();
        }


        public ActionResult Nosotros()
        {

            ViewData["contenidoVista"] = capaNegocios.listadoContenido(new ENTIDAD.Contenido(1));
            return View(img.listadoImagenes());
        }


        public ActionResult Inicio()
        { 

            ViewData["listadoPromociones"] = promocionCapaNegocio.listadoPromociones();
            ViewData["contenidoVista"] = capaNegocios.listadoContenido(new ENTIDAD.Contenido(4));
            return View();
        }
    }
}