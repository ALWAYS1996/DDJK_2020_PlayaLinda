using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DATOS
{
    public class ContenidoCapaDatos
    {

        public SqlConnection conexion;
        public SqlTransaction transaccion;
        public string error;

        public ContenidoCapaDatos()
        {
            this.conexion = Conexion.getConexion();
        }



        public int modificarContenido(ENTIDAD.Contenido contenido)
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = "exec PA_ModificarContenido @contenido,@titulo,@idContenido";
                comando.Parameters.AddWithValue("@contenido", contenido.contenido);
                comando.Parameters.AddWithValue("@titulo", contenido.titulo);
                comando.Parameters.AddWithValue("@idContenido", contenido.idContenido);
                int result = comando.ExecuteNonQuery();
                if (result == -1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception) { }
            finally { conexion.Close(); }
            return 0;
        }//fin


        private List<ENTIDAD.Contenido> listarContenido = new List<ENTIDAD.Contenido>();
        public IEnumerable<ENTIDAD.Contenido> listadoContenido(ENTIDAD.Contenido idContenido)
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.CommandText = "exec PA_ListarContenido @idContenido";
                comando.Parameters.AddWithValue("@idContenido", idContenido.idContenido);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ENTIDAD.Contenido contenido = null;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        contenido = new ENTIDAD.Contenido();
                        contenido.titulo = (ds.Tables[0].Rows[i][0].ToString());
                        contenido.contenido = (ds.Tables[0].Rows[i][1].ToString());
                        listarContenido.Add(contenido);
                    }
                }
                int result = comando.ExecuteNonQuery();

                return listarContenido;
            }
            catch (Exception) { }
            finally { conexion.Close(); }
            return listarContenido;
        }//Fin
    }
}
