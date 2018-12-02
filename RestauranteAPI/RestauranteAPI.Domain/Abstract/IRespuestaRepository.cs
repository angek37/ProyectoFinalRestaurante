using System;
using System.Collections.Generic;
using System.Text;
using RestauranteAPI.Domain.Entities;

namespace RestauranteAPI.Domain.Abstract
{
    public interface IRespuestaRepository
    {
        IEnumerable<Respuesta> Respuestas { get; }
        void Save(Respuesta respuesta);
        void Delete(int id);
    }
}
