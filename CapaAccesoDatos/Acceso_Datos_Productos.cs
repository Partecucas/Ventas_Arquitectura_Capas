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

    public class Acceso_Datos_Productos
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

        public DataTable listarProductos()
        {
            AbrirConexion();
            MySqlCommand commando = new MySqlCommand("sp_ListarProductos", conexionBD);
            commando.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter adaptador = new MySqlDataAdapter(commando);
            DataTable tabladatosproductos = new DataTable();
            adaptador.Fill(tabladatosproductos);
            CerrarConexion();
            return tabladatosproductos;
        }
        public DataTable BuscarProducto(CapaEntidad.EntidadProductos objEntidad)
        {
            AbrirConexion();
            MySqlCommand commando = new MySqlCommand("sp_ListarUnProducto", conexionBD);
            commando.CommandType = CommandType.StoredProcedure;
            commando.Parameters.AddWithValue("p_codigo", objEntidad.codigoProducto);
            MySqlDataAdapter adaptador = new MySqlDataAdapter(commando);
            DataTable TdatoProducto = new DataTable();
            adaptador.Fill(TdatoProducto);
            CerrarConexion();
            return TdatoProducto;
        }
        public DataTable EliminarProducto(CapaEntidad.EntidadProductos objEntidad)
        {
                DataTable TeliminarProducto = new DataTable();
                AbrirConexion();
                MySqlCommand commando = new MySqlCommand("sp_EliminarProducto", conexionBD);
                commando.CommandType = CommandType.StoredProcedure;
                commando.Parameters.AddWithValue("p_codigo", objEntidad.codigoProducto);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(commando);
                adaptador.Fill(TeliminarProducto);
                 CerrarConexion();
                return TeliminarProducto;
        }
        public DataTable ListarunidadMedida ()
        {
            AbrirConexion();
            MySqlCommand commando = new MySqlCommand("sp_ListarUnidadMedida", conexionBD);
            commando.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter adaptador = new MySqlDataAdapter(commando);
            DataTable tablaunidadmedida = new DataTable();
            adaptador.Fill(tablaunidadmedida);
            CerrarConexion();
            return tablaunidadmedida;
        }
        public DataTable InsertarProducto(CapaEntidad.EntidadProductos objEntidad)
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
    }
}
