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
            cargarGrilla();
        }


        private void cargarGrilla()
        {
            ArticuloNegocio articulonegocio = new ArticuloNegocio();
            try
            {
                listaArticulo = articulonegocio.Listar();
                list.DataSource = listaArticulo;
                ocultarColumnas();
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
            agregar.ShowDialog();
            cargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)list.CurrentRow.DataBoundItem;
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if(MessageBox.Show("¿Esta seguro de que desea eliminar?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    ArticuloNegocio articulonegocio = new ArticuloNegocio();
                    articulonegocio.eliminar(seleccionado.id);
                    cargarGrilla();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void textBoxBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            if(textBoxBusqueda.Text != "" && textBoxBusqueda.Text.Length >= 2)
            {
                List<Articulo> listaFiltrada= listaArticulo.FindAll(X =>
                X.codigo.ToUpper().Contains(textBoxBusqueda.Text.ToUpper()) ||
                X.nombre.ToUpper().Contains(textBoxBusqueda.Text.ToUpper()) ||
                X.marca.Nombre.ToUpper().Contains(textBoxBusqueda.Text.ToUpper()) ||
                X.categoria.Nombre.ToUpper().Contains(textBoxBusqueda.Text.ToUpper())
                ) ;
                list.DataSource = null;
                list.DataSource = listaFiltrada;
                if (listaFiltrada.Count != 0)
                {
                    RecargarImg(listaFiltrada[0].imagenUrl);
                }
                else
                {
                    pbxArticulo.Image = null;
                }
            }
            else
            {
                list.DataSource = null;
                list.DataSource = listaArticulo;
                RecargarImg(listaArticulo[0].imagenUrl);
            }
            ocultarColumnas();
        }
        private void ocultarColumnas()
        {
            list.Columns["ID"].Visible = false;
            list.Columns["Precio"].Visible = false;
            list.Columns["Idmarca"].Visible = false;
            list.Columns["IdCategoria"].Visible = false;
            list.Columns["ImagenUrl"].Visible = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)list.CurrentRow.DataBoundItem;
            FrmAgegarArt modificar = new FrmAgegarArt(seleccionado);
            modificar.ShowDialog();
            cargarGrilla();
        }
    }
}
