using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DATOS
{
   public class ItinerarioCapaDatos
    {
        public SqlConnection conexion;
        public SqlTransaction transaccion;
        public string error;

        public ItinerarioCapaDatos()
        {
            this.conexion = Conexion.getConexion();
        }




        private List<ENTIDAD.Itinerario> listarItinerario = new List<ENTIDAD.Itinerario>();
        public IEnumerable<ENTIDAD.Itinerario> listadoItinerario()
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.CommandText = "exec PA_ListarItinerario";
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ENTIDAD.Itinerario itinerario = null;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        itinerario = new ENTIDAD.Itinerario();
                        itinerario.dia = (ds.Tables[0].Rows[i][0].ToString());
                        itinerario.desayuno = (ds.Tables[0].Rows[i][1].ToString());
                        itinerario.imgUrlDesayuno = (ds.Tables[0].Rows[i][2].ToString());
                        itinerario.almuerzo = (ds.Tables[0].Rows[i][3].ToString());
                        itinerario.imgUrlAlmuerzo = (ds.Tables[0].Rows[i][4].ToString());
                        itinerario.cena = (ds.Tables[0].Rows[i][5].ToString());
                        itinerario.imgUrlCena = (ds.Tables[0].Rows[i][6].ToString());
                        listarItinerario.Add(itinerario);
                    }
                }
                int result = comando.ExecuteNonQuery();

                return listarItinerario;
            }
            catch (Exception) { }
            finally { conexion.Close(); }
            return listarItinerario;
        }//Fin

    }
}
