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

        public ViajeController(IViajeRepository genericRepo, IViajerosRepository viajerosRepository, IPostulantesRepository postulantesRepository,
                                IUserRepository userRepository, IVehiculoRepository vehiculoRepository, ITipoViajeRepository tipoViajeRepository) : base(genericRepo)
        {
            this.postulantesRepository = postulantesRepository;
            this.viajerosRepository = viajerosRepository;
            this.userRepository = userRepository;
            this.vehiculoRepository = vehiculoRepository;
            this.tipoViajeRepository = tipoViajeRepository;
        }

        [HttpPost("RegistrarEnUser")]
        public IActionResult Registrar([FromBody] ViajeDTO viajeDTO, [FromQuery]int userId)
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
                var nuevoViaje = this.genericRepo.Create(viaje);

                this.addPostulante(nuevoViaje.Id,user.Id);
                this.addViajero(nuevoViaje.Id,user.Id);

                // this.userRepository.Update(user.Id, user);

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
                var postulantes = this.postulantesRepository.GetByIds(idViajero, idViaje);
                this.postulantesRepository.Delete(idViajero, idViaje);
                var viajeros = new Viajeros() {
                    User = user,
                    UserId = idViajero,
                    Viaje = viaje,
                    ViajeId = idViaje
                };

                var vj = this.viajerosRepository.Create(viajeros);
                viaje.Viajeros.Add(vj.Result);
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

                var pst = this.postulantesRepository.Create(postulantes);
                viaje.Postulantes.Add(pst.Result);
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
