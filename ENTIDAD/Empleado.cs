using System.ComponentModel.DataAnnotations;

namespace ENTIDAD
{

    public class Empleado
    {
        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Identificación")]
        [Key]
        public int idEmpleado { get; set; }

        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "TipoEmpleado")]
        public int tipoUsuario { get; set; }



        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Usuario")]
        public string usuario { get; set; }


        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Contraseña")]
        public string contrasennia { get; set; }

        public Empleado()
        {
        }

        public Empleado(int idEmpleado, int tipoEmpleado, string usuario, string contrasennia)
        {
            this.idEmpleado = idEmpleado;
            this.tipoUsuario = tipoEmpleado;
            this.usuario = usuario;
            this.contrasennia = contrasennia;
        }
        public Empleado(int tipoUsuario, string usuario, string contrasennia) { 
       
            this.tipoUsuario = tipoUsuario;
            this.usuario = usuario;
            this.contrasennia = contrasennia;
        }
    }
}
