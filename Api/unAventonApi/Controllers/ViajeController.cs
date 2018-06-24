using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using unAventonApi.Controllers.Base;
using unAventonApi.Data;
using unAventonApi.Data.Entities;
using unAventonApi.Data.Entities.TablasIntermedias;

namespace unAventonApi.Controllers
{
    [Route("api/[controller]")]
    public class ViajeController : GenericController<IViajeRepository, Viaje>
    {
        private readonly IPostulantesRepository postulantesRepository;
        private readonly IViajerosRepository viajerosRepository;
        private readonly IUserRepository userRepository;
        private readonly IVehiculoRepository vehiculoRepository;
        private readonly ITipoViajeRepository tipoViajeRepository;

        public ViajeController(IViajeRepository genericRepo, IPostulantesRepository postulantesRepository, IViajerosRepository viajerosRepository,
        IUserRepository userRepository, IVehiculoRepository vehiculoRepository, ITipoViajeRepository tipoViajeRepository) : base(genericRepo)
        {
            this.postulantesRepository = postulantesRepository;
            this.viajerosRepository = viajerosRepository;
            this.userRepository = userRepository;
            this.vehiculoRepository = vehiculoRepository;
            this.tipoViajeRepository = tipoViajeRepository;
        }

        [HttpPost("Crear")]
        public IActionResult Crear([FromBody]ViajeDTO viajeDTO)
        {
            var viaje = new Viaje() {
                Origen = viajeDTO.Origen,
                Destino = viajeDTO.Destino,
                Duracion = viajeDTO.Duracion,
                Costo = viajeDTO.Costo,
                FechaPartida = viajeDTO.FechaPartida
            };
            try
            {
                var user = this.userRepository.GetAllUserById(viajeDTO.Creador);
                viaje.Creador = user;
                viaje.Vehiculo = this.vehiculoRepository.GetById(viajeDTO.Vehiculo);
                viaje.TipoViaje = this.tipoViajeRepository.GetById(viajeDTO.TipoViaje);
                var nuevoViaje = this.genericRepo.Create(viaje).Result;

                this.addPostulante(nuevoViaje.Id,user.Id);
                this.addViajero(nuevoViaje.Id,user.Id);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al registrar el viaje");
            }
        }

        [HttpGet("AgregarViajero")]
        public IActionResult addViajero(int idViaje, int idViajero)
        {
            try
            {
                var user = this.userRepository.GetAllUserById(idViajero);
                var viaje = this.genericRepo.GetAllById(idViaje);
                var postulantes = viaje.Postulantes.First(p => p.ViajeId == idViaje && p.UserId == idViajero);
                // var postulantes = this.postulantesRepository.GetByIds(idViajero, idViaje);
                // this.postulantesRepository.Delete(idViajero, idViaje);

                // var vj = this.viajerosRepository.Create(viajeros);
                var vj = new Viajeros() {
                    User = user,
                    UserId = user.Id,
                    Viaje = viaje,
                    ViajeId = viaje.Id
                };
                viaje.Viajeros.Add(vj);
                viaje.Postulantes.Remove(postulantes);

                var vp = new ViajesPendientes() {
                    User = user,
                    UserId = user.Id,
                    Viaje = viaje,
                    ViajeId = viaje.Id
                };
                user.ViajesPendientes.Add(vp);
                this.userRepository.Update(user.Id, user);

                this.genericRepo.Update(viaje.Id, viaje);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error en AgregarViajero");
            }
        }

        [HttpGet("AgregarPostulante")]
        public IActionResult addPostulante(int idViaje, int idPostulante)
        {
            try
            {
                var user = this.userRepository.GetAllUserById(idPostulante);
                var viaje = this.genericRepo.GetAllById(idViaje);
                var postulantes = new Postulantes() {
                    User = user,
                    UserId = idPostulante,
                    Viaje = viaje,
                    ViajeId = idViaje
                };

                // var pst = this.postulantesRepository.Create(postulantes);
                var pst = new Postulantes(){
                    User = user,
                    UserId = user.Id,
                    Viaje = viaje,
                    ViajeId = viaje.Id
                };
                viaje.Postulantes.Add(pst);
                this.genericRepo.Update(viaje.Id, viaje);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error en AgregarPostulante");
            }
        }

        [HttpGet("BorrarViajero")]
        public IActionResult removeViajero(int idViaje, int idViajero)
        {
            try
            {
                this.viajerosRepository.Delete(idViajero, idViaje);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error en BorrarViajero");
            }
        }

        [HttpGet("BorrarPostulante")]
        public IActionResult removePostulante(int idViaje, int idPostulante)
        {
            try
            {
                this.viajerosRepository.Delete(idPostulante, idViaje);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error en BorrarPostulante");
            }
        }

        [HttpGet("ListarPostulantes")]
        public IActionResult GetPostulantes(int idViaje)
        {
            var response = new List<Postulantes>();

            try
            {
                response = this.postulantesRepository.GetByIdViaje(idViaje).ToList();

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al listar");
            }
        }

        [HttpGet("ListarViajeros")]
        public IActionResult GetViajeros(int idViaje)
        {
            var response = new List<Viajeros>();

            try
            {
                response = this.viajerosRepository.GetByIdViaje(idViaje).ToList();

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al listar");
            }
        }

    }
}
