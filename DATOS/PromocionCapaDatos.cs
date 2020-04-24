using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DATOS
{
    public class PromocionCapaDatos
    {
        public SqlConnection conexion;
        public SqlTransaction transaccion;
        public string error;

        public PromocionCapaDatos()
        {
            this.conexion = Conexion.getConexion();
        }
        private List<ENTIDAD.Promocion> listarPromociones = new List<ENTIDAD.Promocion>();
        public IEnumerable<ENTIDAD.Promocion> listadoPromociones()
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.CommandText = "exec PA_ListarPromocion";

                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ENTIDAD.Promocion promocion= null;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        promocion = new ENTIDAD.Promocion();
                        promocion.codigoPromocion= int.Parse(ds.Tables[0].Rows[i][0].ToString());
                        promocion.fechaInicio = DateTime.Parse(ds.Tables[0].Rows[i][1].ToString());
                        promocion.fechaFinal = DateTime.Parse(ds.Tables[0].Rows[i][2].ToString());
                        promocion.informacion = (ds.Tables[0].Rows[i][3].ToString());
                        promocion.precio = int.Parse(ds.Tables[0].Rows[i][4].ToString());
                        promocion.imgUrl =(ds.Tables[0].Rows[i][5].ToString());

                        listarPromociones.Add(promocion);
                    }
                }
                int result = comando.ExecuteNonQuery();

                return listarPromociones;
            }
            catch (Exception) { }
            finally { conexion.Close(); }
            return listarPromociones;
        }//Fin

    }
}
