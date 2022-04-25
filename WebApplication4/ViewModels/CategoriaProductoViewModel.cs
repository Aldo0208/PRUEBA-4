using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models;

namespace WebApplication4.ViewModels
{
    public class CategoriaProductoViewModel
    {
        public Categorias categoria { get; set; }
        public List<Categorias> ListaCategorias { get; set; }
        public List<Productos> ListaProductos { get; set; }
    }
}