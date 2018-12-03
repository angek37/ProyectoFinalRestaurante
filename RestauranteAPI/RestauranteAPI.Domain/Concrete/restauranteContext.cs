using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RestauranteAPI.Domain.Entities;

namespace RestauranteAPI.Domain.Concrete
{
    public partial class restauranteContext : DbContext
    {
        public restauranteContext()
        {
        }

        public restauranteContext(DbContextOptions<restauranteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pregunta> Pregunta { get; set; }
        public virtual DbSet<Respuesta> Respuesta { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pregunta>(entity =>
            {
                entity.Property(e => e.PreguntaId).HasColumnName("PreguntaID");

                entity.Property(e => e.Enunciado).HasMaxLength(300);
            });

            modelBuilder.Entity<Respuesta>(entity =>
            {
                entity.Property(e => e.RespuestaId).HasColumnName("RespuestaID");

                entity.Property(e => e.Enunciado).HasMaxLength(500);

                entity.Property(e => e.Genero).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(200);

                entity.Property(e => e.Recomendaciones).HasMaxLength(300);
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.Property(e => e.SucursalId).HasColumnName("SucursalID");

                entity.Property(e => e.Ciudad).HasMaxLength(100);

                entity.Property(e => e.Direccion).HasMaxLength(300);

                entity.Property(e => e.Estado).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(300);

                entity.Property(e => e.Telefono).HasMaxLength(10);
            });
        }
    }
}
