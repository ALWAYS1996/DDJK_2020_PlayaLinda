using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIO
{
    public class ContenidoCapaNegocio
    {
        DATOS.ContenidoCapaDatos capaDatos = new DATOS.ContenidoCapaDatos();


        public int modificarContenido(ENTIDAD.Contenido contenido)
        {
            return capaDatos.modificarContenido(contenido);
        }

        public IEnumerable<ENTIDAD.Contenido> listadoContenido(ENTIDAD.Contenido contenido)
        {
            return capaDatos.listadoContenido(contenido);
        }
    }
}
