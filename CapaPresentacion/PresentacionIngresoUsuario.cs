using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace CapaPresentacion
{
    public partial class PresentacionIngresoUsuario : Form
    {
        CapaEntidad.EntidadIngresoUsuario objEntidad =new CapaEntidad.EntidadIngresoUsuario();
        CapaNegocio.NegocioIngresousuario objNegocio=new CapaNegocio.NegocioIngresousuario();

        public PresentacionIngresoUsuario()
        {
            InitializeComponent();
        }

        private void PresentacionIngresoUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try {
                objEntidad.EntidadUsuario = txtUsuario.Text;
                objEntidad.EntidadClave = txtClave.Text;

                objNegocio.ValidarUsuario(objEntidad);

                if (objNegocio.stringBuilder.Length != 0)
                {
                    MessageBox.Show(objNegocio.stringBuilder.ToString());
                }
                else
                {
                    DataTable tablaDatosUsuario = new DataTable();
                    tablaDatosUsuario = objNegocio.DatosUsuario(objEntidad);

                    if (tablaDatosUsuario.Rows.Count > 0)
                    {
                        MessageBox.Show("Bienvenido");
                        this.Hide();
                        PresentacionEquipo frmproductos = new PresentacionEquipo();
                        frmproductos.Show();
                    }
                    else
                    {
                        MessageBox.Show("Datos Incorrectos , favor verificar");
                        txtClave.Clear();
                        txtUsuario.Clear();
                        txtUsuario.Focus();


                    }
                }
            }
            catch(MySqlException Err)
            {
                if (Err.Number == 1042)
                {
                    MessageBox.Show("Error de Conexion a la base de datos");
                }
            }
           

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult Salir = MessageBox.Show("Desea Salir?", "Control Acceso", MessageBoxButtons.YesNo);
            if (Salir == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
