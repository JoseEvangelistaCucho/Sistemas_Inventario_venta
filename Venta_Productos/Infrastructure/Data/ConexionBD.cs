using Microsoft.Data.SqlClient;

namespace Venta_Productos.Infrastructure.Data
{
    public class ConexionBD
    {
        private readonly string _connectionString;

        public ConexionBD(IConfiguration configuration)
        {
            // Obtiene la cadena de conexión del archivo appsettings.json
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public SqlConnection GetConnection()
        {
            // Crea y retorna la conexión a la base de datos
            return new SqlConnection(_connectionString);
        }
    }
}
