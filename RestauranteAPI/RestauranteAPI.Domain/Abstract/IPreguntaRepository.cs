using System;
using System.Collections.Generic;
using System.Text;
using RestauranteAPI.Domain.Entities;

namespace RestauranteAPI.Domain.Abstract
{
    public interface IPreguntaRepository
    {
        IEnumerable<Pregunta> Preguntas { get; }
        void Save(Pregunta pregunta);
        void Delete(int id);
    }
}
