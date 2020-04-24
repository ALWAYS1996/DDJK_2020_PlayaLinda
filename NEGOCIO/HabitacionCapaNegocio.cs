using System;
using System.Collections.Generic;
using DATOS;
using System.Text;

namespace NEGOCIO
{
    public class HabitacionCapaNegocio
    {
        DATOS.HabitacionesCapaDatos habitacionCapaDatos = new DATOS.HabitacionesCapaDatos();

        public IEnumerable<ENTIDAD.TipoHabitacion> listadoTipoHabitaciones()
        {
            return habitacionCapaDatos.listadoTipoHabitaciones();
        }
    }
}
