using System;
using System.Collections.Generic;

namespace Venta_Productos.Models
{
    public partial class ClienteProveedor
    {
        public string TipoDocumento { get; set; } = null!;
        public string? NumeroDocumento { get; set; }
        public string? NombreEmpresa { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Observaciones { get; set; }
        public string? Ruta { get; set; }
    }
}
