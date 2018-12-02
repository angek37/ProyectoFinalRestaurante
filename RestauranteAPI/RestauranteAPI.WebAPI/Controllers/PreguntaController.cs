using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteAPI.Domain.Abstract;
using RestauranteAPI.Domain.Entities;

namespace RestauranteAPI.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Pregunta")]
    public class PreguntaController : Controller
    {
        private readonly IPreguntaRepository _repository;

        public PreguntaController(IPreguntaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Pregunta> Get()
        {
            return _repository.Preguntas;
        }

        [HttpPost]
        [HttpPut]
        public HttpResponseMessage Post([FromBody] Pregunta pregunta)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                _repository.Save(pregunta);
                response.StatusCode = HttpStatusCode.OK;
                return response;
            }
            catch (Exception e)
            {
                response.ReasonPhrase = e.Message;
                response.StatusCode = HttpStatusCode.InternalServerError;
                return response;
            }
        }


        [Route("{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response.StatusCode = HttpStatusCode.OK;
                _repository.Delete(id);
                return response;
            }
            catch (Exception e)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.ReasonPhrase = e.Message;
                return response;
            }
        }
    }
}