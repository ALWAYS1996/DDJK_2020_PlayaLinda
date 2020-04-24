using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DATOS
{
    public class FacilidadesCapaDatos
    {
        public SqlConnection conexion;
        public SqlTransaction transaccion;
        public string error;

        public FacilidadesCapaDatos()
        {
            this.conexion = Conexion.getConexion();
        }

        private List<ENTIDAD.Facilidades> listarFacilidades = new List<ENTIDAD.Facilidades>();
        public IEnumerable<ENTIDAD.Facilidades> ListadoFacilidades()
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.CommandText = "exec PA_ListarFacilidades";

                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ENTIDAD.Facilidades facilidades = null;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        facilidades = new ENTIDAD.Facilidades();
                        facilidades.nombre= (ds.Tables[0].Rows[i][1].ToString());
                        facilidades.reglas= (ds.Tables[0].Rows[i][2].ToString());
                        facilidades.detalles= (ds.Tables[0].Rows[i][4].ToString());
                        facilidades.urlImg = (ds.Tables[0].Rows[i][3].ToString());
                        listarFacilidades.Add(facilidades);
                    }
                }
                int result = comando.ExecuteNonQuery();

                return listarFacilidades;
            }
            catch (Exception) { }
            finally { conexion.Close(); }
            return listarFacilidades;
        }//Fin
    }
}
