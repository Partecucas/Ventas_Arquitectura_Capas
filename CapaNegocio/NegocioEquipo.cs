using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaNegocio
{
    public class NegocioEquipo
    {

        CapaAccesoDatos.Acceso_Datos_Equipo AccesoDatosProductos = new CapaAccesoDatos.Acceso_Datos_Equipo();


        public readonly StringBuilder stringBuilder = new StringBuilder();


        public DataTable listarProductos()
        {
            return AccesoDatosProductos.listarEquipo();
        }
        public DataTable BuscarProducto(CapaEntidad.EntidadEquipo objEntidadProductos)
        {
            return AccesoDatosProductos.BuscarEquipo(objEntidadProductos);
        }
        public DataTable EliminarProducto(CapaEntidad.EntidadEquipo objEntidadProductos)
        {
            return AccesoDatosProductos.EliminarEquipo(objEntidadProductos);
        }
        public DataTable listarModelo()
        {
            return AccesoDatosProductos.ListarModelo();

        }
        public DataTable listarEstado()
        {
            return AccesoDatosProductos.ListarEstado();

        }
        // public DataTable InsertarProducto(CapaEntidad.EntidadEquipo objEntidadProductos)
        //{
        //  return AccesoDatosProductos.InsertarProducto(objEntidadProductos);
        // }

        //public bool ValidarProducto(CapaEntidad.EntidadEquipo objEntidad)
        //{
        //stringBuilder.Clear();
        //if (string.IsNullOrEmpty(objEntidad.codigo)) stringBuilder.Append("El Campo Codigo esta vacio");
        //if (string.IsNullOrEmpty(objEntidad.Descripcion)) stringBuilder.Append(Environment.NewLine + "El Campo Descripcion esta vacio");
        //if (string.IsNullOrEmpty(objEntidad.Serial.ToString())) stringBuilder.Append(Environment.NewLine + "El Campo d esta vacio");
        //if (string.IsNullOrEmpty(objEntidad.Existencia.ToString())) stringBuilder.Append(Environment.NewLine + "El Campo Existencia esta vacio");
        //if (string.IsNullOrEmpty(objEntidad.Nombre)) stringBuilder.Append(Environment.NewLine + "El Campo UnidadMediad esta vacio");

        //return stringBuilder.Length == 0;

        //}
        //public DataTable ActualizarProducto(CapaEntidad.EntidadEquipo objEntidadProductos)
        //{
        //  return AccesoDatosProductos.ActualizarProducto(objEntidadProductos);
        //}

    }
}
