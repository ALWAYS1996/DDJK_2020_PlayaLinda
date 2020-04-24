using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENTIDAD
{
   public class Itinerario{

        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Código")]
        [Key]
        public int idItinerario { get; set; }


        
        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Desayuno")]
        public string dia { get; set; }
        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Desayuno")]
        public string desayuno { get; set; }

        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Imagen")]
        public string imgUrlDesayuno { get; set; }

        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Almuerzo")]
      
        public string imgUrlAlmuerzo { get; set; }
        public string almuerzo { get; set; }

        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Cena")]
        public string cena { get; set; }
        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Imagen")]
        public string imgUrlCena { get; set; }

    }
}
