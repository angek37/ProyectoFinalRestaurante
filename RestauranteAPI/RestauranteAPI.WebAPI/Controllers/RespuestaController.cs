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
    [Route("api/Respuesta")]
    public class RespuestaController : Controller
    {
        private IRespuestaRepository _repository;

        public RespuestaController(IRespuestaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Respuesta> Get()
        {
            return _repository.Respuestas;
        }

        [HttpPost]
        [HttpPut]
        public HttpResponseMessage Post([FromBody] Respuesta respuesta)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                _repository.Save(respuesta);
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