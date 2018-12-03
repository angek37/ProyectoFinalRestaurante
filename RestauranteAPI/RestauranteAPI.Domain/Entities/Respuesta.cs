using System;
using System.Collections.Generic;

namespace RestauranteAPI.Domain.Entities
{
    public partial class Respuesta
    {
        public int RespuestaId { get; set; }
        public string Enunciado { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public bool? Servicio { get; set; }
        public bool? Restaurante { get; set; }
        public string Recomendaciones { get; set; }
        public int? Calificacion { get; set; }
    }
}
