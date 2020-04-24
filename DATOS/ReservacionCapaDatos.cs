using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DATOS
{
    public class ReservacionCapaDatos
    {

        public SqlConnection conexion;
        public SqlTransaction transaccion;
        public string error;

        public ReservacionCapaDatos()
        {
            this.conexion = Conexion.getConexion();
        }
        public int registrarReservacion(ENTIDAD.Reservacion reservacion)
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = "exec PA_RegistrarReservacion @idTipoHabitacion,@idCliente,@fechaLlegada,@fechaSalida";
                comando.Parameters.AddWithValue("@idTipoHabitacion", reservacion.codigoHabitacion);
                comando.Parameters.AddWithValue("@idCliente", reservacion.codigoCliente);
                comando.Parameters.AddWithValue("@fechaLlegada", reservacion.fechaLlegada);
                comando.Parameters.AddWithValue("@fechaSalida", reservacion.fechaSalida);
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

        /*Obtener*/
        public int verificarReservacion(ENTIDAD.Reservacion reservacion) {
            int cantidad = 0;// ""; 
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("PA_VerificarReservacion", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechaLlegada", reservacion.fechaL);
                cmd.Parameters.AddWithValue("@fechaSalida", reservacion.fechaS);
                cmd.Parameters.AddWithValue("@tipoHabitacion", reservacion.idHabitacionTemp);
                
                SqlDataReader rdr = cmd.ExecuteReader();
                // while (
                rdr.Read();//)
                           //{

                cantidad = (rdr.GetInt32(rdr.GetOrdinal("rangoFechas")));
                string hola = "Hello word";

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


        private List<ENTIDAD.Reservacion> sugerenciaReservacion = new List<ENTIDAD.Reservacion>();
        public IEnumerable<ENTIDAD.Reservacion> sugerirReservacion()
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.CommandText = "exec PA_SugerenciaReservacion";
            
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ENTIDAD.Reservacion reservacion = null;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        reservacion = new ENTIDAD.Reservacion();
                     //   reservacion.idHabitacionTemp = (ds.Tables[0].Rows[i][0].ToString());
                        reservacion.fechaL = (ds.Tables[0].Rows[i][0].ToString());
                        reservacion.fechaS = (ds.Tables[0].Rows[i][1].ToString());
                        reservacion.idHabitacionTemp = (ds.Tables[0].Rows[i][2].ToString());

                        sugerenciaReservacion.Add(reservacion);
                    }
                }
                int result = comando.ExecuteNonQuery();

                return sugerenciaReservacion;
            }
            catch (Exception) { }
            finally { conexion.Close(); }
            return sugerenciaReservacion;
        }//Fin
        private List<ENTIDAD.Reservacion> listaReservacions = new List<ENTIDAD.Reservacion>();
        public IEnumerable<ENTIDAD.Reservacion> listarReservaciones()
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.CommandText = "exec PA_ListarReservacion";

                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ENTIDAD.Reservacion reservacion = null;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        reservacion = new ENTIDAD.Reservacion();
                        //   reservacion.idHabitacionTemp = (ds.Tables[0].Rows[i][0].ToString());

                        reservacion.codigoReservacion = int.Parse(ds.Tables[0].Rows[i][0].ToString());
                        reservacion.codigoHabitacion = int.Parse(ds.Tables[0].Rows[i][1].ToString());
                        reservacion.codigoCliente = (ds.Tables[0].Rows[i][2].ToString());
                        reservacion.fechaL = (ds.Tables[0].Rows[i][3].ToString());
                        reservacion.fechaS = (ds.Tables[0].Rows[i][4].ToString());

                        listaReservacions.Add(reservacion);
                    }
                }
                int result = comando.ExecuteNonQuery();

                return listaReservacions;
            }
            catch (Exception) { }
            finally { conexion.Close(); }
            return listaReservacions;
        }//Fin
    


private List<ENTIDAD.Reservacion> consultaReservaciones = new List<ENTIDAD.Reservacion>();
        public IEnumerable<ENTIDAD.Reservacion> consultarReservaciones(ENTIDAD.Reservacion reserva)
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.CommandText = "exec PA_FiltrarReservacionById @idReservacion";
                comando.Parameters.AddWithValue("@idReservacion", reserva.codigoReservacion);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ENTIDAD.Reservacion reservacion = null;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        reservacion = new ENTIDAD.Reservacion();
                        //   reservacion.idHabitacionTemp = (ds.Tables[0].Rows[i][0].ToString());

                        reservacion.codigoReservacion = int.Parse(ds.Tables[0].Rows[i][0].ToString());
                        reservacion.codigoHabitacion = int.Parse(ds.Tables[0].Rows[i][1].ToString());
                        reservacion.codigoCliente = (ds.Tables[0].Rows[i][2].ToString());
                        reservacion.fechaL =         (ds.Tables[0].Rows[i][3].ToString());
                        reservacion.fechaS =        (ds.Tables[0].Rows[i][4].ToString());

                        consultaReservaciones.Add(reservacion);
                    }
                }
                int result = comando.ExecuteNonQuery();

                return consultaReservaciones;
            }
            catch (Exception) { }
            finally { conexion.Close(); }
            return consultaReservaciones;
        }//Fin
    }
}
