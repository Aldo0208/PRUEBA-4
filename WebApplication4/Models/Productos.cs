using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication4.Models
{
    public class Productos
    {
        private string CadenaBD = ConfigurationManager.ConnectionStrings["CadenaNegocios"].ConnectionString;

        #region Atributos
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string UnidadMedida { get; set; }
        public decimal PrecioUnidad { get; set; }
        public int UnidadesEnExistencia { get; set; }
        #endregion

        #region Métodos
        public List<Productos> Listar()
        {
            try
            {
                List<Productos> listaProductos = new List<Productos>();

                SqlConnection cnn = new SqlConnection(CadenaBD);
                SqlCommand cmd = new SqlCommand("usp_Productos_Listar", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Productos producto = new Productos()
                    {
                        IdProducto = Convert.ToInt32(dr["IdProducto"]),
                        NombreProducto = dr.GetString(1),
                        UnidadMedida = dr.GetString(2),
                        PrecioUnidad = dr.GetDecimal(3),
                        UnidadesEnExistencia = dr.GetInt16(4)
                    };
                    listaProductos.Add(producto);
                }
                cnn.Close();
                dr.Close();

                return listaProductos;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Productos> ListarPorCategoria(int idCategoria)
        {
            try
            {
                List<Productos> listaProductos = new List<Productos>();

                SqlConnection cnn = new SqlConnection(CadenaBD);
                SqlCommand cmd = new SqlCommand("usp_Productos_ListarPorCategoria", cnn);
                cmd.Parameters.AddWithValue("IdCategoria", idCategoria);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Productos producto = new Productos()
                    {
                        IdProducto = Convert.ToInt32(dr["IdProducto"]),
                        NombreProducto = dr.GetString(1),
                        UnidadMedida = dr.GetString(2),
                        PrecioUnidad = dr.GetDecimal(3),
                        UnidadesEnExistencia = dr.GetInt16(4)
                    };
                    listaProductos.Add(producto);
                }
                cnn.Close();
                dr.Close();

                return listaProductos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion
    }
}