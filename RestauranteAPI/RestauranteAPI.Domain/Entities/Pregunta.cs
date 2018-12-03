using System;
using System.Collections.Generic;

namespace RestauranteAPI.Domain.Entities
{
    public partial class Pregunta
    {
        public int PreguntaId { get; set; }
        public string Enunciado { get; set; }
        public int? Tipo { get; set; }
    }
}
