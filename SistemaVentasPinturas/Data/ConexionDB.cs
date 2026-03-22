using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace SistemaVentasPinturas.Data
{
    public class ConexionDB
    {
        private string cadena = "Server=localhost;Database=SistemaVentas;Trusted_Connection=True;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}