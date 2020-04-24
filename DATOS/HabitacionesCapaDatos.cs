using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DATOS
{
    public class HabitacionesCapaDatos
    {

        public SqlConnection conexion;
        public SqlTransaction transaccion;
        public string error;

        public HabitacionesCapaDatos()
        {
            this.conexion = Conexion.getConexion();
        }

        private List<ENTIDAD.TipoHabitacion> listarTipoHabitacion = new List<ENTIDAD.TipoHabitacion>();
        public IEnumerable<ENTIDAD.TipoHabitacion> listadoTipoHabitaciones()
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.CommandText = "exec PA_ListarTipoHabitacion";

                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ENTIDAD.TipoHabitacion tipoHabitacion = null;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        tipoHabitacion = new ENTIDAD.TipoHabitacion();
                        tipoHabitacion.codigoTipoHabitacion = int.Parse(ds.Tables[0].Rows[i][0].ToString());
                        tipoHabitacion.nombre = (ds.Tables[0].Rows[i][1].ToString());
                        tipoHabitacion.precio = int.Parse(ds.Tables[0].Rows[i][2].ToString());
                        tipoHabitacion.urlImg =(ds.Tables[0].Rows[i][3].ToString());
                        tipoHabitacion.descripcion = (ds.Tables[0].Rows[i][4].ToString());

                        listarTipoHabitacion.Add(tipoHabitacion);
                    }
                }
                int result = comando.ExecuteNonQuery();

                return listarTipoHabitacion;
            }
            catch (Exception) { }
            finally { conexion.Close(); }
            return listarTipoHabitacion;
        }//Fin
    }
}
