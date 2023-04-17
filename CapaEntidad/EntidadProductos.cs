using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntidadProductos
    {
        public String codigoProducto { get; set; }
        public String Nombre { get; set; }
        public int Costo { get; set; }
        public int Existencia { get; set; }
        public String UnidadMedida { get; set; }
    }
}
