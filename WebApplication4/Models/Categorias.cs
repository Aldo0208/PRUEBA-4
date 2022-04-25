using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication4.Models
{
    public class Categorias
    {
        [Display(Name = "Código Categoría", Order = 0)]
        public int IdCategoria { get; set; }
        [Display(Name = "Nombre Categoría", Order = 1)]
        public string NombreCategoria { get; set; }
        [Display(Name = "Descripción", Order = 2)]
        public string Descripcion { get; set; }

        public List<Categorias> Listar()
        {
            List<Categorias> listaCategorias = new List<Categorias>();

            string cadena = ConfigurationManager.ConnectionStrings["CadenaNegocios"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand("SELECT * FROM tb_categorias", cnn);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Categorias categoria = new Categorias()
                {
                    IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                    NombreCategoria = dr["NombreCategoria"].ToString(),
                    Descripcion = dr["Descripcion"].ToString()
                };
                listaCategorias.Add(categoria);
            }

            return listaCategorias;
        }
    }
}