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

        NEGOCIO.ReservacionCapaNegocios reservacionCapaNegocios = new NEGOCIO.ReservacionCapaNegocios();
        NEGOCIO.HabitacionCapaNegocio HabitacionesCapaNegocio = new NEGOCIO.HabitacionCapaNegocio();
        NEGOCIO.ClienteCapaNegocio clienteCapaNegocio = new NEGOCIO.ClienteCapaNegocio();

        public ActionResult ReservaLinea(Reservacion reservacion) {

            ViewBag.mensaje = "Habitación disponible para ser reservada"+ reservacion.codigoHabitacion;
            return View();
        }
        

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
            }
            else
            {
                ViewData["idHabitacion"] = reservacion.codigoHabitacion;
                ViewData["fechaInicio"] = reservacion.fechaLlegada;
                ViewData["fechaFin"] = reservacion.fechaSalida;
                ViewBag.mensaje = "Habitación disponible para ser reservada";
                return View("ReservaLinea");
            }  
        }

        
        public ActionResult ListaReservaciones()
        {
            return View(reservacionCapaNegocios.listarReservaciones());
        }

        public ActionResult ConsultarReservacion(int codigoReservacion) {

            return View(reservacionCapaNegocios.consultarReservaciones(new Reservacion(codigoReservacion)));
        }

        public ActionResult DatosUsuario (string codigoHabitacion ,string fechaLlegada,string fechaSalida)
        {
            if (reservacionCapaNegocios.verificarReservacion(new Reservacion(codigoHabitacion, fechaLlegada, fechaSalida)) > 0)
            {
                ViewBag.mensaje = "Lo sentimos, el rango de fechas que seleccionaste se encuentran ocupadas. En este calendario podrás ver que fechas se encuentran disponibles:";
                return View("Estado",reservacionCapaNegocios.sugerirReservacion());
            }
            else {
                Reservacion reservacion = new Reservacion();
                ViewData["idHabitacion"] = reservacion.codigoHabitacion;
                ViewData["fechaInicio"] = reservacion.fechaLlegada;
                ViewData["fechaFin"] = reservacion.fechaSalida;
                ViewBag.mensaje = "Habitación disponible para ser reservada";
                return View();
            }
        }

        public ActionResult GenerarReservacion(string idHabitacion, string fechaInicio, string fechaFin, string pasaporte, string nombre, string apellido, string email, string tarjeta)
        {
            Reservacion reservacion = new Reservacion();
            reservacion.codigoHabitacion = Int32.Parse(idHabitacion);
            reservacion.fechaLlegada = Convert.ToDateTime(fechaInicio);
            reservacion.fechaSalida = Convert.ToDateTime(fechaFin);

            Cliente cliente = new Cliente();
            cliente.apellido1 = apellido;
            cliente.nombre = nombre;
            cliente.pasaporte = pasaporte;
            cliente.correo = email;
            clienteCapaNegocio.registrarCliente(cliente);

            if (reservacionCapaNegocios.registrarReservacion(reservacion) == 1)
            {
                return View("Reservado");
            }
            return View("Cancelado");
        }
    }
}