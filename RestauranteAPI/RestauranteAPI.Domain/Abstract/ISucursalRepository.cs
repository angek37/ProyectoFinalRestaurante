using System;
using System.Collections.Generic;
using System.Text;
using RestauranteAPI.Domain.Entities;

namespace RestauranteAPI.Domain.Abstract
{
    public interface ISucursalRepository
    {
        IEnumerable<Sucursal> Sucursal { get; }
        void Save(Sucursal sucursal);
        void Delete(int id);
    }
}
