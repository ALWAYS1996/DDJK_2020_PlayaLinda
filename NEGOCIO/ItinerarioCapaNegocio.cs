using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIO
{
    public class ItinerarioCapaNegocio {


        DATOS.ItinerarioCapaDatos itinerario = new DATOS.ItinerarioCapaDatos();

        public IEnumerable<ENTIDAD.Itinerario> listadoItinerario() {
            return itinerario.listadoItinerario();
        }


    }
}
