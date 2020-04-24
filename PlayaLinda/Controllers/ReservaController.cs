using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayaLinda.Controllers
{
    public class ReservaController : Controller
    {
        // GET: Reserva
        public ActionResult ReservaLinea(Reservacion reservacion) {

            ViewBag.mensaje = "Habitación disponible para ser reservada"+ reservacion.codigoHabitacion;
            return View();
        }
        NEGOCIO.ReservacionCapaNegocios reservacionCapaNegocios = new NEGOCIO.ReservacionCapaNegocios();
        NEGOCIO.HabitacionCapaNegocio HabitacionesCapaNegocio = new NEGOCIO.HabitacionCapaNegocio();

        public ActionResult Reservar()
        {
            return View(HabitacionesCapaNegocio.listadoTipoHabitaciones());
        }
      
        public ActionResult Estado(Reservacion reservacion)
        {

            if (reservacionCapaNegocios.verificarReservacion(reservacion) > 0)
            {
                ViewBag.mensaje = "Lo sentimos, el rango de fechas que seleccionaste se encuentran ocupadas. En este calendario podrás ver que fechas se encuentran disponibles";
                return View(reservacionCapaNegocios.sugerirReservacion());
            } else {
                ViewData["idHabitacion"] = reservacion.codigoHabitacion;
                ViewData["fechaInicio"] = reservacion.fechaLlegada;
                ViewData["fechaFin"] = reservacion.fechaSalida;
                ViewBag.mensaje = "Habitación disponible para ser reservada";
                return View("ReservaLinea");
            }  
        }


            }



        }
        public ActionResult ListaReservaciones()
        {
            return View(reservacionCapaNegocios.listarReservaciones());
        }

        public ActionResult ConsultarReservacion(int codigoReservacion) {

            return View(reservacionCapaNegocios.consultarReservaciones(new Reservacion(codigoReservacion)));
        }
            
        public ActionResult CrearReservacion(Reservacion reservacion)  {
            string mensaje;
            if (this.reservacionCapaNegocios.registrarReservacion(reservacion) == 0)
            {
                //mensaje de error
                mensaje = "<script language='javascript' type='text/javascript'>" +
                     "alert('No agregado');window.location.href=" +
                     "'Reservar';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                    "alert('agregado');window.location.href=" +
                    "'Reservar';</script>";
            }
            //reservacionCapaNegocios.registrarReservacion(reservacion);

            return Content(mensaje);
        }

        public ActionResult DatosUsuario (Reservacion reservacion)
        {
            if (reservacionCapaNegocios.verificarReservacion(reservacion) > 0)
            {
                ViewBag.mensaje = "Lo sentimos, el rango de fechas que seleccionaste se encuentran ocupadas. En este calendario podrás ver que fechas se encuentran disponibles:";
                return View(reservacionCapaNegocios.sugerirReservacion());
            }
            else
            {
                ViewData["idHabitacion"] = reservacion.codigoHabitacion;
                ViewData["fechaInicio"] = reservacion.fechaLlegada;
                ViewData["fechaFin"] = reservacion.fechaSalida;
                ViewBag.mensaje = "Habitación disponible para ser reservada";
                return View();
            }
        }
    }
}