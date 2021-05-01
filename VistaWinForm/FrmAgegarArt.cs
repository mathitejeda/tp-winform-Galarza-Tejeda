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
        
        private Articulo articulo = null;

        public FrmAgegarArt()
        {
            InitializeComponent();
        }
        public FrmAgegarArt(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
        }
        

        private void FrmAgegarArt_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcanegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            try
            {
                comboBoxMarca.DataSource = marcanegocio.listar();
                comboBoxCategoria.DataSource = categoriaNegocio.listar();
                comboBoxMarca.ValueMember = "id";
                comboBoxMarca.DisplayMember = "Nombre";
                comboBoxCategoria.ValueMember = "id";
                comboBoxCategoria.DisplayMember = "Nombre";

                if(articulo != null)
                {
                    textBoxNombre.Text = articulo.nombre;
                    textBoxDescripcion.Text = articulo.descripcion;
                    textBoxURLImagen.Text = articulo.imagenUrl;
                    textBoxCodigo.Text = articulo.codigo;
                    comboBoxMarca.SelectedValue = articulo.idMarca;
                    comboBoxCategoria.SelectedValue = articulo.idCategoria;    
                    textBoxPrecio.Text = Convert.ToString(articulo.precio);
                    RecargarImg(textBoxURLImagen.Text);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Articulo nuevo = new Articulo();
            ArticuloNegocio artNegocio = new ArticuloNegocio();
            try
            {
                if (articulo == null)
                    articulo = new Articulo();
                articulo.codigo = textBoxCodigo.Text;
                articulo.nombre = textBoxNombre.Text;
                articulo.descripcion = textBoxDescripcion.Text;
                articulo.marca = (Marca)comboBoxMarca.SelectedItem;
                articulo.categoria = (Categoria)comboBoxCategoria.SelectedItem;
                articulo.precio = decimal.Parse(textBoxPrecio.Text);
                articulo.imagenUrl = textBoxURLImagen.Text;
                articulo.idCategoria = Convert.ToInt32(comboBoxCategoria.SelectedValue);
                //articulo.idCategoria = Convert.ToInt32(Convert.ToString((Categoria)comboBoxCategoria.SelectedValue));
                articulo.idMarca = Convert.ToInt32(comboBoxCategoria.SelectedValue);

                if (articulo.id == 0)
                {
                    artNegocio.agregar(articulo);
                    MessageBox.Show("Se agrego correctamente");
                              

                }
                else
                {
                    artNegocio.modificar(articulo);
                    MessageBox.Show("Se modifico correctamente");
                }

                Close();
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
         private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void RecargarImg(string img)
        {
            try
            {
                pbxImagen.Load(img);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }
        }
        private void textBoxURLImagen_TextChanged(object sender, EventArgs e)
        {
            //RecargarImg(textBoxURLImagen.Text);
        }

        private void comboBoxMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxURLImagen_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                RecargarImg(textBoxURLImagen.Text);
            }
        }
    }
}
