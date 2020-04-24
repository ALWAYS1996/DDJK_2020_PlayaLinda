using ENTIDAD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PlayaLinda.Controllers
{
    public class BasicController : Controller
    {

        NEGOCIO.FacilidadesCapaNegocio FacilidadesCapaNegocio = new NEGOCIO.FacilidadesCapaNegocio();
        NEGOCIO.HabitacionCapaNegocio HabitacionesCapaNegocio = new NEGOCIO.HabitacionCapaNegocio();
     

        public ActionResult Facilidades()
        {
            ENTIDAD.Facilidades tipo = new ENTIDAD.Facilidades();
            //ViewData["listaTipoHabitaciones"] = habitacionCapaNegocio.listadoTipoHabitaciones();
            return View(FacilidadesCapaNegocio.listadoFacilidades());
        }

       

        public ActionResult Tarifas()
        {
            return View(HabitacionesCapaNegocio.listadoTipoHabitaciones());
        }


    }
}