using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace WebApplication4.Models
{
    public class Clientes
    {
        private string cadena = ConfigurationManager.ConnectionStrings["CadenaNegocios"].ConnectionString;

        #region Atributos
        [Display(Name ="Código del Cliente", Order = 0)]
        [Required(ErrorMessage = "Ingrese el código del cliente")]
        public string IdCliente { get; set; }
        [Display(Name = "Nombre de la Compañía", Order = 1)]
        [Required(ErrorMessage = "Ingrese la Compañía")]
        public string NombreCia { get; set; }
        [Display(Name = "Dirección", Order = 2)]
        [Required(ErrorMessage = "Ingrese la dirección")]
        public string Direccion { get; set; }
        [Display(Name = "Id País", Order = 3)]
        public string IdPais { get; set; }
        [Display(Name = "Teléfono", Order = 4)]
        [Required(ErrorMessage = "Ingrese el nro. de teléfono")]
        public string Telefono { get; set; }
        #endregion

        #region Métodos
        public List<Clientes> Listar()
        {
            try
            {
                List<Clientes> listaClientes = new List<Clientes>();
                // SQLCONNECTION / SQLCOMMAND / SQLDATAREADER
                SqlConnection cnn = new SqlConnection(cadena);
                SqlCommand cmd = new SqlCommand("usp_Clientes_Listar", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
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
            catch (Exception ex)
            {
                return null;
            }
        }
        public Clientes Seleccionar(string idCliente)
        {
            try
            {
                Clientes cliente = new Clientes();

                SqlConnection cnn = new SqlConnection(cadena);
                SqlCommand cmd = new SqlCommand("usp_Clientes_Seleccionar", cnn);
                cmd.Parameters.AddWithValue("IdCliente", idCliente);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cliente.IdCliente = dr.GetString(0);
                    cliente.NombreCia = dr.GetString(1);
                    cliente.Direccion = dr.GetString(2);
                    cliente.IdPais = dr.GetString(3);
                    cliente.Telefono = dr.GetString(4);
                }
                cnn.Close();
                dr.Close();

                return cliente;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable ListarSqlDataAdapter()
        {
            try
            {
                SqlConnection cnn = new SqlConnection(cadena);
                SqlDataAdapter da = new SqlDataAdapter("usp_Clientes_Listar", cnn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Clientes");

                return ds.Tables["Clientes"];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int Insertar(Clientes cliente)
        {
            int rpta = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(cadena);
                SqlCommand cmd = new SqlCommand("usp_Clientes_Insertar", cnn);
                cmd.Parameters.AddWithValue("IdCliente", cliente.IdCliente);
                cmd.Parameters.AddWithValue("NombreCia", cliente.NombreCia);
                cmd.Parameters.AddWithValue("Direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("IdPais", cliente.IdPais);
                cmd.Parameters.AddWithValue("Telefono", cliente.Telefono);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                rpta = cmd.ExecuteNonQuery();
                cnn.Close();

                return rpta;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int Actualizar(Clientes cliente)
        {
            int rpta = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(cadena);
                SqlCommand cmd = new SqlCommand("usp_Clientes_Actualizar", cnn);
                cmd.Parameters.AddWithValue("IdCliente", cliente.IdCliente);
                cmd.Parameters.AddWithValue("NombreCia", cliente.NombreCia);
                cmd.Parameters.AddWithValue("Direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("IdPais", cliente.IdPais);
                cmd.Parameters.AddWithValue("Telefono", cliente.Telefono);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                rpta = cmd.ExecuteNonQuery();
                cnn.Close();

                return rpta;
            }
            catch (Exception ex)
            { 
                return 0;
            }
        }
        public int Eliminar(Clientes cliente)
        {
            int rpta = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(cadena);
                SqlCommand cmd = new SqlCommand("usp_Clientes_Eliminar", cnn);
                cmd.Parameters.AddWithValue("IdCliente", cliente.IdCliente);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                rpta = cmd.ExecuteNonQuery();
                cnn.Close();

                return rpta;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion
    }
}