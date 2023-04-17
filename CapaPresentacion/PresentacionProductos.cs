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
    public partial class PresentacionProductos : Form
    {
        CapaNegocio.NegocioProductos objNegocioProductos = new CapaNegocio.NegocioProductos();
        CapaEntidad.EntidadProductos objEntidadProductos = new CapaEntidad.EntidadProductos();
        Boolean sw;

        public PresentacionProductos()
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
            ListarUnidadMedida();

        }
        //funciones
        private void ListarProductos()
        {
            DataTable TablaDatosProductos = new DataTable();
            TablaDatosProductos = objNegocioProductos.listarProductos();
            dgvProductos.DataSource = TablaDatosProductos;
            dgvProductos.Columns[4].Visible = false;
        }
        private void BuscarProductos()
        {

            DataTable tablaBuscarProducto = new DataTable();
            tablaBuscarProducto = objNegocioProductos.BuscarProducto(objEntidadProductos);
            if (tablaBuscarProducto.Rows.Count > 0)
            {
                dgvProductos.DataSource = tablaBuscarProducto;
                sw = true;
            }
            else
            {
                MessageBox.Show("El codigo no esta asociado a nada");
                ListarProductos();
            }

        }
        void ListarUnidadMedida()
        {
            DataTable TablaDatosUnidadMedida = new DataTable();
            TablaDatosUnidadMedida = objNegocioProductos.listarUnidadesMedida();
            cmbUnidadMedida.DataSource = TablaDatosUnidadMedida;
            cmbUnidadMedida.DisplayMember = "descripcion";
            cmbUnidadMedida.ValueMember = "codigo";
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            objEntidadProductos.codigoProducto = Interaction.InputBox("Dijite el Codigo del Producto a Buscar");
            BuscarProductos();


        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            ListarProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataTable tablaEliminarProducto = new DataTable();
            objEntidadProductos.codigoProducto = Interaction.InputBox("Dijite el Codigo del Producto a Eliminar");
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
            try
            {
                objEntidadProductos.codigoProducto = txtCodigo.Text;
                objEntidadProductos.Nombre = txtnombre.Text;
                objEntidadProductos.Costo = Convert.ToInt32(txtCosto.Text);
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
        }

  
        void limpiarDatos()
        {
            txtCodigo.Clear();
            txtnombre.Clear();
            txtExistencia.Text = "0";
            txtCosto.Text = "0";
            cmbUnidadMedida.Text = "";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
