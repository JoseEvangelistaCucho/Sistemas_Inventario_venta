using System;
using System.Collections.Generic;

namespace Venta_Productos.Models
{
    public partial class ProductoServicio
    {
        public string CodigoUnico { get; set; } = null!;
        public Categoria? Categoria { get; set; }
        public string? NombreDescripcion { get; set; }
        public string? UnidadDeMedida { get; set; }
        public decimal? PrecioVenta { get; set; }
        public decimal? PrecioCompra { get; set; }
        public string? TipoMoneda { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Igv { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public string? Ruta { get; set; }
    }
}
