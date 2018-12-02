using System;
using System.Collections.Generic;
using System.Text;
using RestauranteAPI.Domain.Abstract;
using RestauranteAPI.Domain.Entities;

namespace RestauranteAPI.Domain.Concrete
{
    public class PreguntaRepository : IPreguntaRepository
    {
        private readonly RestauranteContext _ctx;
        
        public PreguntaRepository(RestauranteContext ctx)
        {
            _ctx = ctx;
        }
        
        public IEnumerable<Pregunta> Preguntas => _ctx.Pregunta;
        
        public void Save(Pregunta pregunta)
        {
            if (pregunta.PreguntaId == 0)
            {
                _ctx.Pregunta.Add(pregunta);
            }
            else
            {
                Pregunta dbEntry = _ctx.Pregunta.Find(pregunta.PreguntaId);
                if (dbEntry != null)
                {
                    dbEntry.Enunciado = pregunta.Enunciado;
                    dbEntry.Tipo = pregunta.Tipo;
                }
            }

            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Pregunta pregunta = _ctx.Pregunta.Find(id);
            if (pregunta != null)
            {
                _ctx.Pregunta.Remove(pregunta);
            }

            _ctx.SaveChanges();
        }
    }
}
