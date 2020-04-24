using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIO
{
    public class EmpleadoCapaNegocio
    {

        public int loginEmpleado(ENTIDAD.Empleado empleado)
        {

            DATOS.EmpleadoCapaDatos empleadoDatos = new DATOS.EmpleadoCapaDatos();
            return empleadoDatos.loginEmpleado(empleado);


        }
    }
}
