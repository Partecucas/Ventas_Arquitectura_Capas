using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

namespace CapaPresentacion
{
    public partial class PresentacionEquipo : Form
    {
        CapaNegocio.NegocioEquipo objNegocioProductos = new CapaNegocio.NegocioEquipo();
        CapaEntidad.EntidadEquipo objEntidadProductos = new CapaEntidad.EntidadEquipo();
        Boolean sw,swunidadmedidad;
        string CodigoUnidadMedida;


        public PresentacionEquipo()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void Salir_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void PresentacionProductos_Load(object sender, EventArgs e)
        {
            ListarProductos();
            ListarModelo();
            ListarEstado();
        }
        //funciones
        private void ListarProductos()
        {
            DataTable TablaDatosProductos = new DataTable();
            TablaDatosProductos = objNegocioProductos.listarProductos();
            dgvEquipo.DataSource = TablaDatosProductos;
            dgvEquipo.Columns[4].Visible = false;
        }
        private void BuscarProductos()
        {

            DataTable tablaBuscarProducto = new DataTable();
            tablaBuscarProducto = objNegocioProductos.BuscarProducto(objEntidadProductos);
            if (tablaBuscarProducto.Rows.Count > 0)
            {
                dgvEquipo.DataSource = tablaBuscarProducto;
                sw = true;
            }
            else
            {
                MessageBox.Show("El codigo no esta asociado a nada");
                ListarProductos();
            }

        }
        void ListarModelo()
        {
            DataTable TablaDatosModelo = new DataTable();
            TablaDatosModelo = objNegocioProductos.listarModelo();
            cmbUnidadMedida.DataSource = TablaDatosModelo;
            cmbUnidadMedida.DisplayMember = "DescripcionModeloMarca";
            cmbUnidadMedida.ValueMember = "codigoModelo";
        }
        void ListarEstado()
        {
            DataTable TablaDatosModelo = new DataTable();
            TablaDatosModelo = objNegocioProductos.listarEstado();
            cmbEstado.DataSource = TablaDatosModelo;
            cmbEstado.DisplayMember = "descripcion";
            cmbEstado.ValueMember = "codigo";
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            objEntidadProductos.codigo = Interaction.InputBox("Dijite el Codigo del Producto a Buscar");
            BuscarProductos();


        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            ListarProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataTable tablaEliminarProducto = new DataTable();
            objEntidadProductos.codigo = Interaction.InputBox("Dijite el Codigo del Producto a Eliminar");
            BuscarProductos();

            if (sw == true)
            {
                DialogResult Eliminar = MessageBox.Show("Esta de Seguro que desea Elimminar el producto?", "Eliminar Producto", MessageBoxButtons.YesNo);

                if (Eliminar == DialogResult.Yes)
                {
                    try
                    {
                        tablaEliminarProducto = objNegocioProductos.EliminarProducto(objEntidadProductos);
                        MessageBox.Show("El producto fue Eliminado con exito");
                    }
                    catch (MySqlException Err)
                    {
                        if (Err.Number == 1451)
                        {
                            MessageBox.Show("Error de Conexion a la base de datos");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El producto no se Elimino");

                    sw = false;
                }
                ListarProductos();

            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
       {
            /*
           try
           {
               objEntidadProductos.codigoProducto = txtCodigo.Text;
               objEntidadProductos.Nombre = txtdescripcion.Text;
               objEntidadProductos.Costo = Convert.ToInt32(txtSerial.Text);
               objEntidadProductos.Existencia = Convert.ToInt32(txtExistencia.Text);
               objEntidadProductos.UnidadMedida = cmbUnidadMedida.SelectedValue.ToString();

               objNegocioProductos.ValidarProducto(objEntidadProductos);

               if (objNegocioProductos.stringBuilder.Length != 0)
               {
                   MessageBox.Show(objNegocioProductos.stringBuilder.ToString(), "Validacion de campos");
               }
               else
               {
                   DataTable TablainsertarProducto = new DataTable();
                   TablainsertarProducto = objNegocioProductos.InsertarProducto(objEntidadProductos);
                   MessageBox.Show("Producto registrado");
                   ListarProductos();
                   limpiarDatos();
               }
           }
           catch (MySqlException Err)
           {
               if (Err.Number == 1062)
               {
                   MessageBox.Show("el codigo esta asociado a otro producto sapo chandoso revise bien antes de copiar");
                   txtCodigo.Focus();
               }
           }
           catch (Exception Err)
           {
               MessageBox.Show("Se presento el siguiente error de datos" + Err.Message);
           }
      */
        }


/*        void limpiarDatos()
        {
            txtCodigo.Clear();
            txtdescripcion.Clear();
          
            txtSerial.Text = "0";
            cmbUnidadMedida.Text = "";
        }
*/
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                objEntidadProductos.codigoProducto = txtCodigo.Text;
                objEntidadProductos.Nombre = txtdescripcion.Text;
                objEntidadProductos.Costo = Convert.ToInt32(txtSerial.Text);
                objEntidadProductos.Existencia = Convert.ToInt32(txtExistencia.Text);
                if (swunidadmedidad = true)
                {
                    objEntidadProductos.UnidadMedida = cmbUnidadMedida.SelectedValue.ToString();
                    swunidadmedidad = false;
                }
                else
                {

                    objEntidadProductos.UnidadMedida = CodigoUnidadMedida;

                }

                objNegocioProductos.ValidarProducto(objEntidadProductos);

                if (objNegocioProductos.stringBuilder.Length != 0)
                {
                    MessageBox.Show(objNegocioProductos.stringBuilder.ToString(), "Validacion de campos");
                }
                else
                {
                    DataTable TablaActualizarProducto = new DataTable();
                    TablaActualizarProducto = objNegocioProductos.ActualizarProducto(objEntidadProductos);
                    MessageBox.Show("Producto Actualizado");
                    ListarProductos();
                    limpiarDatos();
                    txtCodigo.Enabled = true;
                }
            } catch (Exception Err)

            {

                MessageBox.Show("Se Presento el siguiente error : " + Err.Message);
            }
        
            */
    }

        private void cmbUnidadMedida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvProductos_DoubleClick(object sender, EventArgs e)
        {
            int fila = dgvEquipo.CurrentRow.Index;

            txtCodigo.Enabled = false;
            txtCodigo.Text = dgvEquipo.Rows[fila].Cells[0].Value.ToString();
            txtdescripcion.Text= dgvEquipo.Rows[fila].Cells[1].Value.ToString();
            txtSerial.Text = dgvEquipo.Rows[fila].Cells[2].Value.ToString();
          
            CodigoUnidadMedida = dgvEquipo.Rows[fila].Cells[4].Value.ToString();
            cmbUnidadMedida.Text= dgvEquipo.Rows[fila].Cells[5].Value.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cmbUnidadMedida_SelectionChangeCommitted(object sender, EventArgs e)
        {
            swunidadmedidad = false;
        }
      
    }
}
