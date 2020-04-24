using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayaLinda.Controllers
{
    public class ImagenController : Controller
    {
        // GET: Imagen
        NEGOCIO.ImagenCapaNegocio img = new NEGOCIO.ImagenCapaNegocio();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegistrarImagenes(HttpPostedFileBase fileUpload)
        {
            try
            {
                string path = Server.MapPath("~/Content/img/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                fileUpload.SaveAs(path + Path.GetFileName(fileUpload.FileName));
                ENTIDAD.Imagen galeria = new ENTIDAD.Imagen();
                galeria.imgPath = "\\Content\\img\\" + fileUpload.FileName;
            
                img.modificarImagenes(galeria);
            }
            catch (Exception e)
            {
                return Json(new { Value = false, Message = "Error" + e.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Value = false, Message = "Subido con exito" }, JsonRequestBehavior.AllowGet);
        }

    }
}