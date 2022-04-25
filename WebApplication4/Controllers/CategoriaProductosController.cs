using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.ViewModels;

namespace WebApplication4.Controllers
{
    public class CategoriaProductosController : Controller
    {
        // GET: CategoriaProductos
        public ActionResult Listar()
        {
            Categorias categoria = new Categorias();

            CategoriaProductoViewModel viewModel = new CategoriaProductoViewModel();
            viewModel.ListaCategorias = categoria.Listar();
            Session["Categorias"] = viewModel.ListaCategorias;

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Listar(CategoriaProductoViewModel oViewModel)
        {
            Productos producto = new Productos();

            CategoriaProductoViewModel viewModel = new CategoriaProductoViewModel();
            viewModel.ListaCategorias = (List<Categorias>) Session["Categorias"];
            viewModel.ListaProductos = producto.ListarPorCategoria(oViewModel.categoria.IdCategoria);

            return View(viewModel);
        }
    }
}