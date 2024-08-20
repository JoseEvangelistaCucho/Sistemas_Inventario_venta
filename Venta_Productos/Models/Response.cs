namespace Venta_Productos.Models
{
    public class Response<T> where T : class
    {
        public string Message { get; set; }
        public int Code { get; set; }
        public T Data { get; set; }
    }
}
