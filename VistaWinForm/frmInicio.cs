using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;
using Controlador;

namespace VistaWinForm
{
    public partial class frmInicio : Form
    {
        private List<Articulo> listaArticulo;
        public frmInicio()
        {
            InitializeComponent();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articulonegocio = new ArticuloNegocio();


            try
            {
                listaArticulo = articulonegocio.listar2();
                list.DataSource = listaArticulo;
                list.Columns["ID"].Visible = false;
                list.Columns["Codigo"].Visible = false;
                list.Columns["Precio"].Visible = false;
                list.Columns["Idmarca"].Visible = false;
                list.Columns["IdCategoria"].Visible = false;
                list.Columns["ImagenUrl"].Visible = false;


                RecargarImg(listaArticulo[0].imagenUrl);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAgegarArt agregar = new FrmAgegarArt();
            agregar.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FrmEliminar eliminar = new FrmEliminar();
            eliminar.Show();
        }
        private void RecargarImg(string img)
        {
            try
            {
                pbxArticulo.Load(img);
            }


            catch (Exception ex1)
            {
                pbxArticulo.Load("https://www.cuestalibros.com/content/images/thumbs/default-image_550.png");
                MessageBox.Show(ex1.Message);
                //throw ex;

            }
        }

        private void MouseListado(object sender, DataGridViewCellEventArgs e)
        {
            Articulo seleccionado = (Articulo)list.CurrentRow.DataBoundItem;
            RecargarImg(seleccionado.imagenUrl);
        }

        private void pbxArticulo_Click(object sender, EventArgs e)
        {

        }
    }
}
