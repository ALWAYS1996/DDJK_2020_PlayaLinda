using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIO
{
    public class MapaCapaNegocio
    {
        DATOS.MapaCapaDatos capaDatos = new DATOS.MapaCapaDatos();
        public IEnumerable<ENTIDAD.Mapa> listadoCoordenadasOrigen()
        {
            return capaDatos.listadoCoordenadasOrigen();
        }
        public int modificarCoordenadasOrigen(ENTIDAD.Mapa mapa)
        {
            return capaDatos.modificarCoordenadasOrigen(mapa);
        }
    }
}
