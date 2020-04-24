using System;
using System.ComponentModel.DataAnnotations;

namespace ENTIDAD
{
    public class Reservacion
    {
        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Id Reserva")]
        [Key]
        public int codigoReservacion { get; set; }


        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Id Habitacion")]

        public int codigoHabitacion { get; set; }

        public string idHabitacionTemp { get; set; }


        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Id Cliente")]

        public string codigoCliente { get; set; }


        [Display(Name = "Fecha Llegada")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime fechaLlegada { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public string fechaL { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public string fechaS { get; set; }



        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Fecha Salida")]

        public DateTime fechaSalida { get; set; }

        public Reservacion()
        {
        }

        public Reservacion(int codigoReservacion, int codigoHabitacion, string codigoCliente, DateTime fechaLlegada, DateTime fechaSalida)
        {
            this.codigoReservacion = codigoReservacion;
            this.codigoHabitacion = codigoHabitacion;
            this.codigoCliente = codigoCliente;
            this.fechaLlegada = fechaLlegada;
            this.fechaSalida = fechaSalida;
        }
        public Reservacion(string idHabitacio, string fechaLlegada, string fechaSalida)
        {
            this.idHabitacionTemp = idHabitacio;
            this.codigoHabitacion = codigoHabitacion;
            this.fechaL = fechaLlegada;
            this.fechaS = fechaSalida;
        }
        public Reservacion(int idReserva)
        {
            this.codigoReservacion = idReserva;

        }
    }
}
