using System.ComponentModel.DataAnnotations;

namespace ENTIDAD
{

    public class Habitacion
    {

        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Código")]
        [Key]
        public string codigoHabitacion { get; set; }

        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "tipo Habitacion")]

        public string tipoHabitacion { get; set; }

        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Estado Habitacion")]

        public int vacante { get; set; }


        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Capacidad")]

        public int capacidad { get; set; }

        public Habitacion()
        {
        }

        public Habitacion(string codigoHabitacion, string tipoHabitacion, int vacante, int capacidad)
        {
            this.codigoHabitacion = codigoHabitacion;
            this.tipoHabitacion = tipoHabitacion;
            this.vacante = vacante;
            this.capacidad = capacidad;
        }
    }
}
