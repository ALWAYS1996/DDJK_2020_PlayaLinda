using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENTIDAD
{
   public class Contenido
    {



        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Id Contenido")]
        [Key]
        public int idContenido { get; set; }

        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Contenido")]
        public string contenido { get; set; }

 
        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Titulo")]
        public string titulo { get; set; }

        public Contenido(int idContenido, string contenido, string titulo)
        {
            this.idContenido = idContenido;
            this.contenido = contenido;
            this.titulo = titulo;
        }
        public Contenido(int idContenido)
        {
            this.idContenido = idContenido;
    
          
        }
        public Contenido()
        {
         

        }

    }
}
