using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;
using Modelo;

namespace VistaWinForm
{
    public partial class FrmAgegarArt : Form
    {
        public FrmAgegarArt()
        {
            InitializeComponent();
        }

        private void FrmAgegarArt_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcanegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            try
            {
                comboBoxMarca.DataSource = marcanegocio.listar();
                comboBoxCategoria.DataSource = categoriaNegocio.listar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            ArticuloNegocio artNegocio = new ArticuloNegocio();
            try
            {
                nuevo.codigo = textBoxCodigo.Text;
                nuevo.nombre = textBoxNombre.Text;
                nuevo.descripcion = textBoxDescripcion.Text;
                nuevo.marca = (Marca)comboBoxMarca.SelectedItem;
                nuevo.categoria = (Categoria)comboBoxCategoria.SelectedItem;
                nuevo.precio = decimal.Parse(textBoxPrecio.Text);
                nuevo.imagenUrl = textBoxURLImagen.Text;

                artNegocio.agregar(nuevo);
                MessageBox.Show("Articulo agregado.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(DialogResult.OK == MessageBox.Show("Seguro queres salir? Vas a perder todos los cambios","Seguro queres salir?",MessageBoxButtons.OKCancel))
            {
                FrmAgegarArt.ActiveForm.Close();
            }
        }
    }
}
