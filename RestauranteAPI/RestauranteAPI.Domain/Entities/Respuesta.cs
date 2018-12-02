using System;
using System.Collections.Generic;

namespace RestauranteAPI.Domain.Entities
{
    public partial class Respuesta
    {
        public int RespuestaId { get; set; }
        public string Enunciado { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int PreguntaId { get; set; }

        public Pregunta Pregunta { get; set; }
    }
}
