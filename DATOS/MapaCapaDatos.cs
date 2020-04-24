using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DATOS
{
   public class MapaCapaDatos {

        public SqlConnection conexion;
        public SqlTransaction transaccion;
        public string error;

        public MapaCapaDatos()
        {
            this.conexion = Conexion.getConexion();
        }



        public int modificarCoordenadasOrigen(ENTIDAD.Mapa mapa)
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = "exec PA_ModificarCoordenadasOrigen @latitudOrigen,@longitudOrigen";
                comando.Parameters.AddWithValue("@latitudOrigen", mapa.latitudOrigen);
                comando.Parameters.AddWithValue("@longitudOrigen", mapa.longitudOrigen);
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
        private List<ENTIDAD.Mapa> listarCoordenadasOrigen = new List<ENTIDAD.Mapa>();
        public IEnumerable<ENTIDAD.Mapa> listadoCoordenadasOrigen()
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.CommandText = "exec PA_ListarCoordenadasOrigen";

                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ENTIDAD.Mapa mapa = null;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        mapa = new ENTIDAD.Mapa();
                        mapa.latitudOrigen = (ds.Tables[0].Rows[i][0].ToString());
                        mapa.longitudOrigen = (ds.Tables[0].Rows[i][1].ToString());

                        listarCoordenadasOrigen.Add(mapa);
                    }
                }
                int result = comando.ExecuteNonQuery();

                return listarCoordenadasOrigen;
            }
            catch (Exception) { }
            finally { conexion.Close(); }
            return listarCoordenadasOrigen;
        }//Fin

    }
}
