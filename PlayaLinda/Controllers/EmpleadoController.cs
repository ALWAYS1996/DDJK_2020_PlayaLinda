using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayaLinda.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        NEGOCIO.EmpleadoCapaNegocio businness = new NEGOCIO.EmpleadoCapaNegocio();
        public ActionResult LoginEmpleado()
        {
            return View();
        }

        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult LoginOut()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(int idTipoUsuario, string idUsuario, string contrasenna)
        {
            if (businness.loginEmpleado(new ENTIDAD.Empleado(idTipoUsuario, idUsuario, contrasenna)) > 0)
            {
                ViewBag.mensaje = "Login Correcto";
                return View("Inicio");
            }
            else
            {
                ViewBag.mensaje = "Login Incorrecto";
                return View("LoginEmpleado");
            }

        }



    }
}