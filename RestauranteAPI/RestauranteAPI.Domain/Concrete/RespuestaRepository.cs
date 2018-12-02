using System;
using System.Collections.Generic;
using System.Text;
using RestauranteAPI.Domain.Abstract;
using RestauranteAPI.Domain.Entities;

namespace RestauranteAPI.Domain.Concrete
{
    public class RespuestaRepository : IRespuestaRepository
    {
        private readonly RestauranteContext _ctx;

        public RespuestaRepository(RestauranteContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Respuesta> Respuestas => _ctx.Respuesta;

        public void Save(Respuesta respuesta)
        {
            if (respuesta.RespuestaId == 0)
            {
                respuesta.CreatedOn = DateTime.Now;
                _ctx.Respuesta.Add(respuesta);
            }
            else
            {
                Respuesta dbEntry = _ctx.Respuesta.Find(respuesta);
                if (dbEntry != null)
                {
                    dbEntry.Enunciado = respuesta.Enunciado;
                    dbEntry.PreguntaId = respuesta.PreguntaId;
                }
            }

            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Respuesta respuesta = _ctx.Respuesta.Find(id);
            if (respuesta != null)
            {
                _ctx.Respuesta.Remove(respuesta);
            }

            _ctx.SaveChanges();
        }
    }
}
