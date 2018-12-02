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
    [Route("api/Sucursal")]
    public class SucursalController : Controller
    {
        private ISucursalRepository _repository;

        public SucursalController(ISucursalRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Sucursal> Get()
        {
            return _repository.Sucursal;
        }

        [HttpPost]
        [HttpPut]
        public HttpResponseMessage Post([FromBody] Sucursal sucursal)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                _repository.Save(sucursal);
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