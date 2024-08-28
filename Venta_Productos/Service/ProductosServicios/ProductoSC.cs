using Microsoft.Data.SqlClient;
using System.Data;
using Venta_Productos.Infrastructure.Data;
using Venta_Productos.Models;
using Venta_Productos.Service.ProductosServicios.Command;

namespace Venta_Productos.Service.ProductosServicios
{
    public class ProductoSC
    {
        private ConexionBD _conexionBD;
        public ProductoSC(ConexionBD conexionBD)
        {
            _conexionBD = conexionBD;
        }

        public Response<bool> GuardarProducto(CrearProductoCommand producto)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                using (SqlConnection connection = _conexionBD.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("InsertarProducto", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregamos los parámetros de entrada
                        command.Parameters.AddWithValue("@categoria", producto.productoDetalle.Categoria);
                        command.Parameters.AddWithValue("@cantidad", producto.productoDetalle.Categoria);

                        // Agregamos los parámetros de salida
                        SqlParameter codigoSalidaParam = new SqlParameter("@CodigoSalida", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(codigoSalidaParam);

                        SqlParameter mensajeSalidaParam = new SqlParameter("@MensajeSalida", SqlDbType.VarChar, 255)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(mensajeSalidaParam);

                        // Abrimos la conexión y ejecutamos el procedimiento
                        connection.Open();
                        command.ExecuteNonQuery();

                        response = new Response<bool>()
                        {
                            Code = (int)codigoSalidaParam.Value,
                            Message = (string)mensajeSalidaParam.Value
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                response = new Response<bool>()
                {
                    Code = 99,
                    Message = ex.Message
                };
            }
            return response;
        }


        public Response<List<ProductoServicio>> ConsultarProducto(string codigoUnico)
        {
            Response<List<ProductoServicio>> response = new Response<List<ProductoServicio>>();
            try
            {
                using (SqlConnection connection = _conexionBD.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("ConsultarProducto", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetro de entrada
                        command.Parameters.AddWithValue("@CodigoUnico", codigoUnico);

                        // Agregar parámetros de salida
                        SqlParameter codigoSalidaParam = new SqlParameter("@CodigoSalida", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(codigoSalidaParam);

                        SqlParameter mensajeSalidaParam = new SqlParameter("@MensajeSalida", SqlDbType.VarChar, 255)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(mensajeSalidaParam);

                        // Abrir la conexión y ejecutar el procedimiento
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        // Procesar el resultado de la consulta (si es necesario)
                       /* response = new Response<List<ProductoServicio>>()
                        {
                            Code = (int)codigoSalidaParam.Value,
                            Message = (string)mensajeSalidaParam.Value
                        };*/

                        if (reader.HasRows)
                        {
                            response.Data = new List<ProductoServicio>();
                            while (reader.Read())
                            {
                                Categoria categoria = new Categoria(){
                                    CategoriaID = reader["CategoriaID"].ToString(),
                                    Descripcion = reader["descripcionCategoria"].ToString()
                                };

                                ProductoServicio productoServicio = new ProductoServicio()
                                {
                                    CodigoUnico = reader["CodigoUnico"].ToString(),
                                    Categoria = categoria,
                                    NombreDescripcion = reader["NombreDescripcion"].ToString(),
                                    UnidadDeMedida = reader["UnidadDeMedida"].ToString(),
                                    PrecioVenta = decimal.Parse(reader["PrecioVenta"].ToString()),
                                    PrecioCompra = decimal.Parse(reader["PrecioCompra"].ToString()),
                                    TipoMoneda = reader["TipoMoneda"].ToString(),
                                    Cantidad = int.Parse(reader["Cantidad"].ToString()),
                                    Ruta = reader["RutaImagen"].ToString()
                                };
                                response.Data.Add(productoServicio);

                            }
                            reader.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }



    }
}
