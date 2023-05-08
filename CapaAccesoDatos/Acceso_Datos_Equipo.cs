using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace CapaAccesoDatos
{

    public class Acceso_Datos_Equipo
    {
        MySqlConnection conexionBD = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConexionMYSQL"].ConnectionString);

        void AbrirConexion()
        {
            if (conexionBD.State == ConnectionState.Closed)
            {
                conexionBD.Open();
            }
        }
        void CerrarConexion()
        {
            if (conexionBD.State == ConnectionState.Open)
            {
                conexionBD.Close();
            }
        }

        public DataTable listarEquipo()
        {
            AbrirConexion();
            MySqlCommand commando = new MySqlCommand("sp_ListarEquipos", conexionBD);
            commando.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter adaptador = new MySqlDataAdapter(commando);
            DataTable tabladatosEquipos = new DataTable();
            adaptador.Fill(tabladatosEquipos);
            CerrarConexion();
            return tabladatosEquipos;
        }
        public DataTable BuscarEquipo(CapaEntidad.EntidadEquipo objEntidad)
        {
            AbrirConexion();
            MySqlCommand commando = new MySqlCommand("sp_ListarUnEquipo", conexionBD);
            commando.CommandType = CommandType.StoredProcedure;
            commando.Parameters.AddWithValue("p_codigo", objEntidad.codigo);
            MySqlDataAdapter adaptador = new MySqlDataAdapter(commando);
            DataTable TableBuscarEquipo = new DataTable();
            adaptador.Fill(TableBuscarEquipo);
            CerrarConexion();
            return TableBuscarEquipo;
        }
        public DataTable EliminarEquipo(CapaEntidad.EntidadEquipo objEntidad)
        {
                DataTable TeliminarEquipo = new DataTable();
                AbrirConexion();
                MySqlCommand commando = new MySqlCommand("sp_EliminarEquipo", conexionBD);
                commando.CommandType = CommandType.StoredProcedure;
                commando.Parameters.AddWithValue("p_codigo", objEntidad.codigo);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(commando);
                adaptador.Fill(TeliminarEquipo);
                 CerrarConexion();
                return TeliminarEquipo;
        }
        public DataTable ListarModelo ()
        {
            AbrirConexion();
            MySqlCommand commando = new MySqlCommand("sp_ListarModelo", conexionBD);
            commando.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter adaptador = new MySqlDataAdapter(commando);
            DataTable tablaModelo = new DataTable();
            adaptador.Fill(tablaModelo);
            CerrarConexion();
            return tablaModelo;
        }

        public DataTable ListarEstado()
        {
            AbrirConexion();
            MySqlCommand commando = new MySqlCommand("sp_ListarEstado", conexionBD);
            commando.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter adaptador = new MySqlDataAdapter(commando);
            DataTable tablaEstado = new DataTable();
            adaptador.Fill(tablaEstado);
            CerrarConexion();
            return tablaEstado;
        }
        /*public DataTable InsertarProducto(CapaEntidad.EntidadEquipo objEntidad)
        {
            DataTable TinsertarProducto = new DataTable();
            AbrirConexion();
            MySqlCommand commando = new MySqlCommand("sp_InsertarProducto", conexionBD);
            commando.CommandType = CommandType.StoredProcedure;
            commando.Parameters.AddWithValue("p_codigo", objEntidad.codigoProducto);
            commando.Parameters.AddWithValue("p_nombre", objEntidad.Nombre);
            commando.Parameters.AddWithValue("p_costo", objEntidad.Costo);
            commando.Parameters.AddWithValue("p_existencia", objEntidad.Existencia);
            commando.Parameters.AddWithValue("p_unidadmedida", objEntidad.UnidadMedida);
            MySqlDataAdapter adaptador = new MySqlDataAdapter(commando);
            adaptador.Fill(TinsertarProducto);
            CerrarConexion();
            return TinsertarProducto;
        }
        public DataTable ActualizarProducto(CapaEntidad.EntidadEquipo objEntidad)
        {
            DataTable TActualizarProducto = new DataTable();
            AbrirConexion();
            MySqlCommand commando = new MySqlCommand("sp_ActualizarProducto", conexionBD);
            commando.CommandType = CommandType.StoredProcedure;
            commando.Parameters.AddWithValue("p_codigo", objEntidad.codigoProducto);
            commando.Parameters.AddWithValue("p_nombre", objEntidad.Nombre);
            commando.Parameters.AddWithValue("p_costo", objEntidad.Costo);
            commando.Parameters.AddWithValue("p_existencia", objEntidad.Existencia);
            commando.Parameters.AddWithValue("p_unidadmedida", objEntidad.UnidadMedida);
            MySqlDataAdapter adaptador = new MySqlDataAdapter(commando);
            adaptador.Fill(TActualizarProducto);
            CerrarConexion();
            return TActualizarProducto;
        }*/

    }
}
