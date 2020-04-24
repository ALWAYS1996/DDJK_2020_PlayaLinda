using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayaLinda.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult RegistrarCliente()
        {
            return View();
        }
    }
}