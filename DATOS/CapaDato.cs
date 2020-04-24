using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DATOS
{
    public class CapaDato
    {
        public SqlConnection conexion;
        public SqlTransaction transaccion;
        public string error;

        public CapaDato()
        {
            this.conexion = Conexion.getConexion();
        }


      
    }
}
