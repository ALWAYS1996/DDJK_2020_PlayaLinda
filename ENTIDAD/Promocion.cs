using System;
using System.ComponentModel.DataAnnotations;

namespace ENTIDAD
{

    public class Promocion
    {
        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Codigo Promo")]
        [Key]
        public int codigoPromocion { get; set; }


        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Fecha Inicial")]
        public DateTime fechaInicio { get; set; }


        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Fecha Final")]
        public DateTime fechaFinal { get; set; }

        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Información")]
        public string informacion { get; set; }

        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "imgUrl")]
        public string imgUrl { get; set; }

        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Precio")]
        public int precio { get; set; }

        public Promocion()
        {
        }

        public Promocion(int codigoPromocion, DateTime fechaInicio, DateTime fechaFinal, string informacion, int precio)
        {
            this.codigoPromocion = codigoPromocion;
            this.fechaInicio = fechaInicio;
            this.fechaFinal = fechaFinal;
            this.informacion = informacion;
            this.precio = precio;
        }
    }
}
