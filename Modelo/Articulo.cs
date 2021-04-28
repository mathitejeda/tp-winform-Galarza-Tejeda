using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Articulo
    {
        public int id { get; set; }
        public String codigo { get; set; }
        public String nombre { get; set; }
        public String descripcion { get; set; }
        public int idMarca { get; set; }
        public int idCategoria { get; set; }
        public String imagenUrl { get; set; }
        public decimal precio { get; set; }
        public String marca { get; set; }
        public String categoria { get; set; }

        public Marca marca1 { get; set; }
        public Categoria categoria1 { get; set; }
    }
}
