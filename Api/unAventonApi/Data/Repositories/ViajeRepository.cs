using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using unAventonApi.Data.DTOEntities;
using unAventonApi.Data.Entities;
using unAventonApi.Data.Repositories.Base;

namespace unAventonApi.Data
{
    public class ViajeRepository : GenericRepository<Viaje>, IViajeRepository
    {
        public ViajeRepository(UnAventonDbContext dbContext)
        : base(dbContext)
        {
        }

        public Viaje GetAllById(int id)
        {
            var viaje = _dbContext.Viaje
                    .Include(v => v.TipoViaje)
                    .Include(v => v.Vehiculo)
                    .Include(v => v.Postulantes).ThenInclude(p => p.User)
                    .Include(v => v.Viajeros).ThenInclude(p => p.User)
                    .Include(v => v.Creador)
                    .Include(v => v.Preguntas).ThenInclude(p => p.Usuario)
                    .FirstOrDefault(x => x.Id == id);
            return viaje;
        }

        public new IQueryable<Viaje> GetAll()
        {
            var viajes = _dbContext.Viaje
                    .Include(v => v.TipoViaje)
                    .Include(v => v.Vehiculo)
                    .Include(v => v.Postulantes).ThenInclude(p => p.User)
                    .Include(v => v.Viajeros).ThenInclude(p => p.User)
                    .Include(v => v.Preguntas).ThenInclude(p => p.Usuario)
                    .Include(v => v.Creador).AsNoTracking();
            return viajes;
        }

        public IQueryable<Object> GetAllNotIncludes()
        {
            var viajes = _dbContext.Viaje
                    .Include(v => v.TipoViaje)
                    .Include(v => v.Vehiculo)
                    .Include(v => v.Creador)
                    .Select(viaje => new
                    {
                        Origen = viaje.Origen,
                        Destino = viaje.Destino,
                        Duracion = viaje.Duracion,
                        TipoViaje = viaje.TipoViaje.Descripcion,
                        Costo = viaje.Costo,
                        DiasDeViaje = viaje.DiasDeViaje.Select(dv => dv.fechaDeViaje),
                        HoraPartida = viaje.HoraPartida,
                        Vehiculo = viaje.Vehiculo,
                        Creador = (new {Id = viaje.Creador.Id, Nombre = viaje.Creador.Nombre, Apellido = viaje.Creador.Apellido, FotoPerfil = viaje.Creador.FotoPerfil}),
                        Viajeros = viaje.Viajeros.Select(v => new {Id = v.UserId, Nombre = v.User.Nombre, Apellido = v.User.Apellido, FotoPerfil = v.User.FotoPerfil}),
                        CantidadDePlazas = viaje.CantidadDePlazas,
                        Descripcion = viaje.Descripcion,
                        Id = viaje.Id
                    }).AsNoTracking();
            return viajes;
        }

        public IQueryable<Object> GetRealizadosByUserId(int id)
        {
            var viajes = _dbContext.ViajesRealizados.Where(vr => vr.UserId == id)
                    .Include(vr => vr.Viaje)
                    .Select(vr => new
                    {
                        Origen = vr.Viaje.Origen,
                        Destino = vr.Viaje.Destino,
                        Duracion = vr.Viaje.Duracion,
                        TipoViaje = vr.Viaje.TipoViaje.Descripcion,
                        Costo = vr.Viaje.Costo,
                        DiasDeViaje = vr.Viaje.DiasDeViaje.Select(dv => dv.fechaDeViaje),
                        HoraPartida = vr.Viaje.HoraPartida,
                        Vehiculo = vr.Viaje.Vehiculo,
                        Creador = (new {Id = vr.Viaje.Creador.Id, Nombre = vr.Viaje.Creador.Nombre, Apellido = vr.Viaje.Creador.Apellido, FotoPerfil = vr.Viaje.Creador.FotoPerfil}),
                        Viajeros = vr.Viaje.Viajeros.Select(v => new {Id = v.UserId, Nombre = v.User.Nombre, Apellido = v.User.Apellido, FotoPerfil = v.User.FotoPerfil}),
                        CantidadDePlazas = vr.Viaje.CantidadDePlazas,
                        Descripcion = vr.Viaje.Descripcion,
                        Id = vr.Viaje.Id
                    }).AsNoTracking();
            return viajes;
        }

        public Object GetByIdNotIncludes(int id)
        {
            var viajes = _dbContext.Viaje
                    .Include(v => v.TipoViaje)
                    .Include(v => v.Vehiculo)
                    .Include(v => v.Creador)
                    .Select(viaje => new
                    {
                        Origen = viaje.Origen,
                        Destino = viaje.Destino,
                        Duracion = viaje.Duracion,
                        TipoViaje = viaje.TipoViaje.Descripcion,
                        Costo = viaje.Costo,
                        DiasDeViaje = viaje.DiasDeViaje.Select(dv => dv.fechaDeViaje).ToList(),
                        HoraPartida = viaje.HoraPartida,
                        Vehiculo = viaje.Vehiculo,
                        Creador = (new {Id = viaje.Creador.Id, Nombre = viaje.Creador.Nombre, Apellido = viaje.Creador.Apellido, FotoPerfil = viaje.Creador.FotoPerfil}),
                        Viajeros = viaje.Viajeros.Select(v => new {Id = v.UserId, Nombre = v.User.Nombre, Apellido = v.User.Apellido, FotoPerfil = v.User.FotoPerfil}).ToList(),
                        CantidadDePlazas = viaje.CantidadDePlazas,
                        Descripcion = viaje.Descripcion,
                        Id = viaje.Id
                    }).FirstOrDefault(x => x.Id == id);
            return viajes;
        }

        public List<Viaje> GetByVehiculoId(int vehiculoId)
        {
            var viajes = _dbContext.Viaje.Where(v => v.Vehiculo.Id == vehiculoId).AsNoTracking();
            return viajes.ToList();
        }
    }
}