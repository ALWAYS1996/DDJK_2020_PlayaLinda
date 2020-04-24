using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENTIDAD
{
    public class Facilidades
    {


        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Código")]
        
        public string id_Facilidades { get; set; }

        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Nombre")]

        public string nombre { get; set; }

        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Reglas")]

        public string reglas { get; set; }


        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Capacidad")]

        public string urlImg { get; set; }
        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Detalles")]

        public string detalles { get; set; }

        public Facilidades() { }

        public Facilidades(string id_Facilidades, string nombre, string reglas, string urlImg, string detalles)
        {
            this.id_Facilidades = id_Facilidades;
            this.nombre = nombre;
            this.reglas = reglas;
            this.urlImg = urlImg;
            this.detalles = detalles;
        }
    }
}
