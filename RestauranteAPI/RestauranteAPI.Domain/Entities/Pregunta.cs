using System;
using System.Collections.Generic;

namespace RestauranteAPI.Domain.Entities
{
    public partial class Pregunta
    {
        public Pregunta()
        {
            Respuesta = new HashSet<Respuesta>();
        }

        public int PreguntaId { get; set; }
        public string Enunciado { get; set; }
        public int? Tipo { get; set; }

        public ICollection<Respuesta> Respuesta { get; set; }
    }
}
