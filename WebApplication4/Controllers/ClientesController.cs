using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication4.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        string cadena = ConfigurationManager.ConnectionStrings["CadenaNegocios"].ConnectionString;
        List<Clientes> ListarClientes()
        {
            List<Clientes> listaClientes = new List<Clientes>();
            // SQLCONNECTION / SQLCOMMAND / SQLDATAREADER
            SqlConnection cnn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SELECT * FROM tb_clientes", cnn);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Clientes cliente = new Clientes()
                {
                    IdCliente = dr["IdCliente"].ToString(),
                    NombreCia = dr["NombreCia"].ToString(),
                    Direccion = dr["Direccion"].ToString(),
                    IdPais = dr["IdPais"].ToString(),
                    Telefono = dr["Telefono"].ToString()
                };
                listaClientes.Add(cliente);
            }
            cnn.Close();
            dr.Close();

            return listaClientes;
        }
        public ActionResult Listar()
        {
            //return View(ListarClientes());
            Clientes cliente = new Clientes();

            //DataTable dt = cliente.ListarSqlDataAdapter();

            return View(cliente.Listar());
        }
        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Crear(Clientes cliente)
        {
            Clientes oCliente = new Clientes();
            oCliente.Insertar(cliente);

            return RedirectToAction("Listar");
        }
        public ActionResult Actualizar(string idCliente)
        {
            Clientes cliente = new Clientes();
            return View(cliente.Seleccionar(idCliente));
        }
        [HttpPost]
        public ActionResult Actualizar(Clientes cliente)
        {
            Clientes oCliente = new Clientes();
            oCliente.Actualizar(cliente);
            return RedirectToAction("Listar");
        }
        public ActionResult Eliminar(string idCliente)
        {
            Clientes cliente = new Clientes();
            return View(cliente.Seleccionar(idCliente));
        }
        [HttpPost]
        public ActionResult Eliminar(Clientes cliente)
        {
            Clientes oCliente = new Clientes();
            oCliente.Eliminar(cliente);
            return RedirectToAction("Listar");
        }
    }
}