using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaNegocio
{
    public class NegocioIngresousuario
    {
        CapaAccesoDatos.AccesoDatosIngresoUsuario objAccesoDatosUsuario =new CapaAccesoDatos.AccesoDatosIngresoUsuario();
 


        public DataTable DatosUsuario(CapaEntidad.EntidadIngresoUsuario objEntidad)
        {
            return objAccesoDatosUsuario.ConectarUsuario(objEntidad);
        }
         public readonly StringBuilder stringBuilder = new StringBuilder();

        public bool ValidarUsuario(CapaEntidad.EntidadIngresoUsuario objEntidad)
        {
            stringBuilder.Clear();
            if (string.IsNullOrEmpty(objEntidad.EntidadUsuario)) stringBuilder.Append("El Campo Usuario esta vacio");
            if (string.IsNullOrEmpty(objEntidad.EntidadClave)) stringBuilder.Append("El Campo Clave esta vacio");

            return stringBuilder.Length==0;
           
        }

    }
}
