using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntidadEquipo
    {
        public String codigo { get; set; }
        public String Descripcion { get; set; }
        public int Serial { get; set; }
        public DateTime fechafabricacion { get; set; }
        public DateTime fechacompra { get; set; }
        public String Modelo { get; set; }

        public String Estado { get; set; }
    }
}
