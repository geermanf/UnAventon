using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using unAventonApi.Controllers.Base;
using unAventonApi.Data;
using unAventonApi.Data.DTOEntities;
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
        private readonly IDiaDeViajeRepository diaDeViajeRepository;

        public ViajeController(IViajeRepository genericRepo, IPostulantesRepository postulantesRepository, IViajerosRepository viajerosRepository,
        IUserRepository userRepository, IVehiculoRepository vehiculoRepository, ITipoViajeRepository tipoViajeRepository, IDiaDeViajeRepository diaDeViajeRepository) : base(genericRepo)
        {
            this.postulantesRepository = postulantesRepository;
            this.viajerosRepository = viajerosRepository;
            this.userRepository = userRepository;
            this.vehiculoRepository = vehiculoRepository;
            this.tipoViajeRepository = tipoViajeRepository;
            this.diaDeViajeRepository = diaDeViajeRepository;
        }

        [HttpPost("Crear")]
        public IActionResult Crear([FromBody]ViajeDTO viajeDTO)
        {
            var viaje = new Viaje()
            {
                Origen = viajeDTO.Origen,
                Destino = viajeDTO.Destino,
                Duracion = viajeDTO.Duracion,
                Costo = viajeDTO.Costo,
                DiasDeViaje = viajeDTO.DiasDeViaje.Select(fecha => new DiaDeViaje() { fechaDeViaje = fecha }).ToList(),
                HoraPartida = viajeDTO.HoraPartida,
                CantidadDePlazas = viajeDTO.CantidadDePlazas,
                Descripcion = viajeDTO.Descripcion
            };
            try
            {
                var user = this.userRepository.GetAllUserById(viajeDTO.Creador);
                viaje.Creador = user;
                viaje.Vehiculo = this.vehiculoRepository.GetById(viajeDTO.Vehiculo);
                viaje.TipoViaje = this.tipoViajeRepository.GetById(viajeDTO.TipoViaje);
                var nuevoViaje = this.genericRepo.Create(viaje).Result;

                this.addPostulante(nuevoViaje.Id, user.Id);
                this.addViajero(nuevoViaje.Id, user.Id);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al registrar el viaje");
            }
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody]ModificarViajeDTO viajeDto)
        {

            try
            {
                var viaje = this.genericRepo.GetAllById(viajeDto.IdViaje);

                viaje.Origen = viajeDto.Origen;
                viaje.Destino = viajeDto.Destino;
                viaje.Descripcion = viajeDto.Descripcion;
                viaje.Duracion = viajeDto.Duracion;
                viaje.Costo = viajeDto.Costo;
                viaje.Vehiculo = this.vehiculoRepository.GetById(viajeDto.Vehiculo);
                viaje.CantidadDePlazas = viajeDto.CantidadDePlazas;

                this.genericRepo.Update(viajeDto.IdViaje, viaje);
                
                return Ok(true);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al modificar");
            }
        }

        [HttpPost("Delete")]
        public IActionResult DeleteViaje([FromBody]int id)
        {

            try
            {
                var viaje = this.genericRepo.GetAllById(id);
                viaje.DiasDeViaje.Clear();
                viaje.Postulantes.Clear();
                viaje.Viajeros.Clear();
                viaje.Preguntas.Clear();

                this.genericRepo.Update(viaje.Id, viaje);
                this.genericRepo.Delete(id);

                // return BuildApiResponse.BuildOk();
                return Ok();
            }
            catch (Exception)
            {
                // return BuildApiResponse.BuildNotOk("Hubo un error al modificar");
                return BadRequest("Hubo un error al borrar con id: " + id);
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
                var vj = new Viajeros()
                {
                    User = user,
                    UserId = user.Id,
                    Viaje = viaje,
                    ViajeId = viaje.Id
                };
                viaje.Viajeros.Add(vj);
                viaje.Postulantes.Remove(postulantes);

                var vp = new ViajesPendientes()
                {
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
                var postulantes = new Postulantes()
                {
                    User = user,
                    UserId = idPostulante,
                    Viaje = viaje,
                    ViajeId = idViaje
                };

                // var pst = this.postulantesRepository.Create(postulantes);
                var pst = new Postulantes()
                {
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
                var viaje = this.genericRepo.GetAllById(idViaje);
                var viajero = viaje.Viajeros.First(p => p.ViajeId == idViaje && p.UserId == idViajero);
                var user = this.userRepository.GetAllUserById(idViajero);
                viaje.Viajeros.Remove(viajero);
                var vp = user.ViajesPendientes.First(v => v.ViajeId == viaje.Id);
                user.ViajesPendientes.Remove(vp);
                this.genericRepo.Update(viaje.Id, viaje);
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
                var viaje = this.genericRepo.GetAllById(idViaje);
                var postulantes = viaje.Postulantes.First(p => p.ViajeId == idViaje && p.UserId == idPostulante);
                viaje.Postulantes.Remove(postulantes);
                this.genericRepo.Update(viaje.Id, viaje);
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

                var postulantes = response.Select(r => r.User).ToList();

                return Ok(postulantes);
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

                var viajeros = response.Select(r => r.User).ToList();

                return Ok(viajeros);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al listar");
            }
        }

        [HttpGet("ListarViajes")]
        public new IActionResult Get()
        {
            var response = new List<Object>();

            try
            {
                response = this.genericRepo.GetAllNotIncludes().ToList();
                response.Reverse();
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al listar");
            }
        }

        [HttpGet("ListarViajesProximos")]
        public IActionResult ListarViajesProximos()
        {
            var response = new List<Object>();

            try
            {
                response = this.genericRepo.GetAllProximosNotIncludes().ToList();
                response.Reverse();
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al listar");
            }
        }

        [HttpGet("ListarViajesRealizados")]
        public new IActionResult GetViajesRealizados(int idUsuario)
        {
            var response = new List<Object>();

            try
            {
                response = this.genericRepo.GetRealizadosByUserId(idUsuario).ToList();
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al listar los viajes realizados");
            }
        }

        [HttpGet("ListarId")]
        public IActionResult GetByIdNotIncludes(int id)
        {
            try
            {
                var response = this.genericRepo.GetByIdNotIncludes(id);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al listar");
            }

        }

        [HttpGet("ListarViajeCompleto")]
        public IActionResult GetAllById(int id)
        {
            try
            {
                var response = this.genericRepo.GetAllById(id);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al listar");
            }
            
        }

        [HttpGet("ListarPreguntas")]
        public IActionResult ListarPreguntas(int id)
        {
            try
            {
                var response = this.genericRepo.GetAllById(id).Preguntas;
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al listar preguntas");
            }
            
        }

        [HttpPost("FiltrarViajes")]
        public IActionResult FiltrarViajes([FromBody]FiltrosDto dto)
        {
            try
            {
                var response = this.genericRepo.GetAll().ToList();
                if (dto.Origen != null) {response = response.Where(v => v.Origen == dto.Origen).ToList();}
                if (dto.Destino != null) {response = response.Where(v => v.Destino == dto.Destino).ToList();}
                if (dto.Fecha != null) {response = response.Where(v => v.DiasDeViaje.All(dv => dv.fechaDeViaje == dto.Fecha)).ToList();}
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al listar preguntas");
            }
            
        }

    }
}
