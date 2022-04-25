using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.ViewModels;

namespace WebApplication4.Controllers
{
    public class ClienteProductoController : Controller
    {
        // GET: ClienteProducto
        public ActionResult Listar()
        {
            Clientes cliente = new Clientes();
            Productos producto = new Productos();

            ClienteProductoViewModel viewModel = new ClienteProductoViewModel();
            viewModel.ListaClientes = cliente.Listar();
            viewModel.ListaProductos = producto.Listar();

            return View(viewModel);
        }
    }
}