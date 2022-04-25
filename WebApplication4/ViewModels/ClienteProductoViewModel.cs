using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models;

namespace WebApplication4.ViewModels
{
    public class ClienteProductoViewModel
    {
        public string Codigo { get; set; }
        public Clientes cliente { get; set; }
        public Productos producto { get; set; }
        public List<Clientes> ListaClientes { get; set; }
        public List<Productos> ListaProductos { get; set; }
    }
}