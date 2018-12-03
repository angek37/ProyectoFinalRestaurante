using System;
using System.Collections.Generic;
using System.Text;
using RestauranteAPI.Domain.Abstract;
using RestauranteAPI.Domain.Entities;

namespace RestauranteAPI.Domain.Concrete
{
    public class SucursalRepository : ISucursalRepository
    {
        private readonly restauranteContext _ctx;

        public SucursalRepository(restauranteContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Sucursal> Sucursal => _ctx.Sucursal;

        public void Save(Sucursal sucursal)
        {
            if (sucursal.SucursalId == 0)
            {
                _ctx.Sucursal.Add(sucursal);
            }
            else
            {
                Sucursal dbEntry = _ctx.Sucursal.Find(sucursal);
                if (dbEntry != null)
                {
                    dbEntry.Nombre = sucursal.Nombre;
                    dbEntry.Direccion = sucursal.Direccion;
                    dbEntry.Ciudad = sucursal.Ciudad;
                    dbEntry.Estado = sucursal.Estado;
                    dbEntry.Telefono = sucursal.Telefono;
                }
            }

            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Sucursal sucursal = _ctx.Sucursal.Find(id);
            if (sucursal != null)
            {
                _ctx.Sucursal.Remove(sucursal);
            }

            _ctx.SaveChanges();
        }
    }
}
