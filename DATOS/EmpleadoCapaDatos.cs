using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DATOS
{
   public class EmpleadoCapaDatos
    {
        public SqlConnection conexion;
        public SqlTransaction transaccion;
        public string error;

        public EmpleadoCapaDatos()
        {
            this.conexion = Conexion.getConexion();
        }

        public int loginEmpleado(ENTIDAD.Empleado empleado)
        {
            int cantidad = 0;// ""; 
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("PA_Login", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", empleado.usuario);
                cmd.Parameters.AddWithValue("@Contra", empleado.contrasennia);
                cmd.Parameters.AddWithValue("@TipoUsuario", empleado.tipoUsuario);

                SqlDataReader rdr = cmd.ExecuteReader();
                // while (
                rdr.Read();//)
                           //{

                cantidad = (rdr.GetInt32(rdr.GetOrdinal("cantidad")));

                //}
            }
            catch (Exception)
            {

            }
            finally
            {
                conexion.Close();
            }
            return cantidad;


        }//fin

    }
}
