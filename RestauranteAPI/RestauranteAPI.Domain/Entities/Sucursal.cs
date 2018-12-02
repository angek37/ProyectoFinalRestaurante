using System;
using System.Collections.Generic;

namespace RestauranteAPI.Domain.Entities
{
    public partial class Sucursal
    {
        public int SucursalId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Telefono { get; set; }
    }
}
