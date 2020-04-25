using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ENTIDAD;

namespace DATOS
{
   public class ClienteCapaDatos
    {

        public SqlConnection conexion;
        public SqlTransaction transaccion;
        public string error;

        public ClienteCapaDatos()
        {
            this.conexion = Conexion.getConexion();
        }


        private List<ENTIDAD.Cliente> listarCliente = new List<ENTIDAD.Cliente>();
        public IEnumerable<ENTIDAD.Cliente> listadoClientes()
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.CommandText = "exec PA_ListarClientes";

                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ENTIDAD.Cliente cliente = null;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        cliente = new ENTIDAD.Cliente();
                        cliente.codigoCliente = int.Parse(ds.Tables[0].Rows[i][0].ToString());
                        cliente.pasaporte = (ds.Tables[0].Rows[i][1].ToString());
                        cliente.nombre = (ds.Tables[0].Rows[i][2].ToString());
                        cliente.apellido1 = (ds.Tables[0].Rows[i][3].ToString());
                        cliente.apellido2 = (ds.Tables[0].Rows[i][4].ToString());
                        cliente.edad = int.Parse(ds.Tables[0].Rows[i][5].ToString());
                        cliente.correo = (ds.Tables[0].Rows[i][6].ToString());
                        cliente.nacionalidad = (ds.Tables[0].Rows[i][7].ToString());
                        listarCliente.Add(cliente);
                    }
                }
                int result = comando.ExecuteNonQuery();

                return listarCliente;
            }
            catch (Exception) { }
            finally { conexion.Close(); }
            return listarCliente;
        }//Fin

        public int registrarCliente(Cliente cliente)
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = "exec PA_RegistrarReservacion @idTipoHabitacion,@idCliente,@fechaLlegada,@fechaSalida";
                comando.Parameters.AddWithValue("@pasaporte", cliente.pasaporte);
                comando.Parameters.AddWithValue("@nombre", cliente.nombre);
                comando.Parameters.AddWithValue("@apellido", cliente.apellido1);
                comando.Parameters.AddWithValue("@correo", cliente.correo);
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
        }
    }
}
