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
    public class AccesoDatosIngresoUsuario
    {
        MySqlConnection conexionBD = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConexionMYSQL"].ConnectionString);
        public DataTable ConectarUsuario(CapaEntidad.EntidadIngresoUsuario objEntidad){
            conexionBD.Open();
            MySqlCommand commando = new MySqlCommand("sp_AccesoUsuarios",conexionBD);
            commando.CommandType = CommandType.StoredProcedure;
            commando.Parameters.AddWithValue("E_usuario", objEntidad.EntidadUsuario);
            commando.Parameters.AddWithValue("E_clave", objEntidad.EntidadClave);
            MySqlDataAdapter adaptador = new MySqlDataAdapter(commando);
            DataTable tablaDatosUsuario = new DataTable();
            adaptador.Fill(tablaDatosUsuario);
            conexionBD.Close();
            return tablaDatosUsuario;
           }
      }
    }


