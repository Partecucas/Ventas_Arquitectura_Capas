using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaNegocio
{
    public class NegocioProductos
    {

        CapaAccesoDatos.Acceso_Datos_Productos AccesoDatosProductos = new CapaAccesoDatos.Acceso_Datos_Productos();


        public readonly StringBuilder stringBuilder = new StringBuilder();


        public DataTable listarProductos()
        {
            return AccesoDatosProductos.listarProductos();
        }
        public DataTable BuscarProducto(CapaEntidad.EntidadProductos objEntidadProductos)
        {
            return AccesoDatosProductos.BuscarProducto(objEntidadProductos);
        }
        public DataTable EliminarProducto(CapaEntidad.EntidadProductos objEntidadProductos)
        {
            return AccesoDatosProductos.EliminarProducto(objEntidadProductos);
        }
        public DataTable listarUnidadesMedida()
        {
            return AccesoDatosProductos.ListarunidadMedida();

        }
        public DataTable InsertarProducto(CapaEntidad.EntidadProductos objEntidadProductos)
        {
            return AccesoDatosProductos.InsertarProducto(objEntidadProductos);
        }

        public bool ValidarProducto(CapaEntidad.EntidadProductos objEntidad)
        {
            stringBuilder.Clear();
            if (string.IsNullOrEmpty(objEntidad.codigoProducto)) stringBuilder.Append("El Campo Codigo esta vacio");
            if (string.IsNullOrEmpty(objEntidad.Nombre)) stringBuilder.Append(Environment.NewLine + "El Campo Nombre esta vacio");
            if (string.IsNullOrEmpty(objEntidad.Costo.ToString())) stringBuilder.Append(Environment.NewLine + "El Campo Nombre esta vacio");
            if (string.IsNullOrEmpty(objEntidad.Existencia.ToString())) stringBuilder.Append(Environment.NewLine + "El Campo Existencia esta vacio");
            if (string.IsNullOrEmpty(objEntidad.Nombre)) stringBuilder.Append(Environment.NewLine + "El Campo UnidadMediad esta vacio");

            return stringBuilder.Length == 0;

        }
    }
    }
