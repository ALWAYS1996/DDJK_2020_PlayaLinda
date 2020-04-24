using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIO
{
    public class FacilidadesCapaNegocio
    {
        DATOS.FacilidadesCapaDatos facilidadesCapaDatos = new DATOS.FacilidadesCapaDatos();
        public IEnumerable<ENTIDAD.Facilidades> listadoFacilidades()
        { return facilidadesCapaDatos.ListadoFacilidades(); }
    }
}

