using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SistemaVentasPinturas.Data;

namespace SistemaVentasPinturas.Services
{
    public class ProductoService
    {
        ConexionDB conexionDB = new ConexionDB();

        public void AgregarProducto(string nombre, double precio)
        {
            try
            {
                using (SqlConnection conn = conexionDB.ObtenerConexion())
                {
                    conn.Open();

                    string query = "INSERT INTO Productos (Nombre, Precio) VALUES (@nombre, @precio)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@precio", precio);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar: " + ex.Message);
            }
        }

        public void MostrarProductos()
        {
            using (SqlConnection conn = conexionDB.ObtenerConexion())
            {
                conn.Open();

                string query = "SELECT Nombre, Precio FROM Productos";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\nProductos en BD:");

                while (reader.Read())
                {
                    Console.WriteLine($"- {reader["Nombre"]} | S/ {reader["Precio"]}");
                }
            }

        }
        public void EliminarProducto(string nombre)
        {
            try
            {
                using (SqlConnection conn = conexionDB.ObtenerConexion())
                {
                    conn.Open();

                    string query = "DELETE FROM Productos WHERE Nombre = @nombre";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@nombre", nombre);

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                        Console.WriteLine("Producto eliminado.");
                    else
                        Console.WriteLine("Producto no encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar: " + ex.Message);
            }
        }

        public void ActualizarProducto(string nombre, double nuevoPrecio)
        {
            try
            {
                using (SqlConnection conn = conexionDB.ObtenerConexion())
                {
                    conn.Open();

                    string query = "UPDATE Productos SET Precio = @precio WHERE Nombre = @nombre";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@precio", nuevoPrecio);

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                        Console.WriteLine("Producto actualizado.");
                    else
                        Console.WriteLine("Producto no encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar: " + ex.Message);
            }
        }
    }
}