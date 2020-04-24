using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIO
{
    public class PromocionCapaNegocio
    {
        DATOS.PromocionCapaDatos promocionCapaDatos = new DATOS.PromocionCapaDatos();

        public IEnumerable<ENTIDAD.Promocion> listadoPromociones()
        { return promocionCapaDatos.listadoPromociones(); }
    }

}

