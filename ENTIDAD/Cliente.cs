using System.ComponentModel.DataAnnotations;

namespace ENTIDAD
{

    public class Cliente
    {
        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Código")]
        [Key]
        public int codigoCliente { get; set; }




        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Pasaporte")]
        public string pasaporte { get; set; }

        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }



        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Apellido 1")]
        public string apellido1 { get; set; }


        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Apellido 2")]
        public string apellido2 { get; set; }



        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Correo")]
        public string correo { get; set; }



        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Nacionalidad")]
        public string nacionalidad { get; set; }


        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Edad")]
        public int edad { get; set; }

        public Cliente()
        {
        }

        public Cliente(int codigoCliente, string pasaporte, string nombre, string apellido1, string apellido2, string correo, string nacionalidad, int edad)
        {
            this.codigoCliente = codigoCliente;
            this.pasaporte = pasaporte;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.correo = correo;
            this.nacionalidad = nacionalidad;
            this.edad = edad;
        }
    }
}
