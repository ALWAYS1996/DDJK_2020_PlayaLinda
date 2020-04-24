using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIO
{
    public class ClienteCapaNegocio
    {
        DATOS.ClienteCapaDatos capaDatos = new DATOS.ClienteCapaDatos();
        public IEnumerable<ENTIDAD.Cliente> listadoClientes()
        {
            return capaDatos.listadoClientes();
        }
    }
}
