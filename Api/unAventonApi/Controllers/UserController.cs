using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using unAventonApi.Controllers.Base;
using unAventonApi.Data;
using unAventonApi.Data.DTOEntities;
using unAventonApi.Data.Entities;

namespace unAventonApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : GenericController<IUserRepository, User>
    {
        private readonly ITipoCalificacionRepository tipoCalificacionRepository;
        private readonly IRolRepository rolRepository;
        private readonly IViajeRepository viajeRepo;
        private readonly ITarjetaRepository tarjetaRepo;

        public UserController(IUserRepository genericRepo, ITipoCalificacionRepository tipoCalificacionRepository, IRolRepository rolRepository,
                            IViajeRepository viajeRepo, ITarjetaRepository tarjetaRepo) : base(genericRepo)
        {
            this.tipoCalificacionRepository = tipoCalificacionRepository;
            this.rolRepository = rolRepository;
            this.viajeRepo = viajeRepo;
            this.tarjetaRepo = tarjetaRepo;

        }

        [HttpPost("ListarPorEmail")]
        public IActionResult Get([FromBody]string email)
        {
            try
            {
                var response = this.genericRepo.GetByEmail(email).Result;

                // return BuildApiResponse.BuildOk();
                return Ok(response);
            }
            catch (Exception)
            {
                // return BuildApiResponse.BuildNotOk("Hubo un error al modificar");
                return BadRequest("Hubo un error al listar con id: " + email);
            }
        }

        [HttpGet("ExisteVehiculo")]
        public IActionResult ExisteVehiculo(string patente, int userId)
        {
            try
            {
                var response = this.genericRepo.GetVehiculos(userId);
                var ret = response.Any(v => v.Patente == patente);
                return Ok(ret);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error");
            }
        }


        [HttpGet("ListarVehiculos")]
        public IActionResult GetVehiculos(int id)
        {
            try
            {
                var response = this.genericRepo.GetVehiculos(id);

                // return BuildApiResponse.BuildOk();
                return Ok(response);
            }
            catch (Exception)
            {
                // return BuildApiResponse.BuildNotOk("Hubo un error al modificar");
                return BadRequest("Hubo un error al listar con id: " + id);
            }
        }

        [HttpGet("ListarTarjetas")]
        public IActionResult GetTarjetas(int id)
        {
            try
            {
                var response = this.genericRepo.GetTarjetas(id);

                // return BuildApiResponse.BuildOk();
                return Ok(response);
            }
            catch (Exception)
            {
                // return BuildApiResponse.BuildNotOk("Hubo un error al modificar");
                return BadRequest("Hubo un error al listar con id: " + id);
            }
        }

        [HttpGet("TienePagosPendientes")]
        public IActionResult CheckPagos(int id)
        {
            try
            {
                var pagosPendientes = this.genericRepo.GetAllUserById(id).Pagos.Where(c => c.FechaDePago == null).ToList();
                

                if (!pagosPendientes.Any())
                    return Ok(true);
                else
                    return Ok(false);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al obtener pagos pendientes del usuario id: " + id);
            }
        }

        [HttpGet("TieneCalificacionesPendientes")]
        public IActionResult CheckCalificaciones(int id)
        {
            try
            {
                var calificacionesPendientes = this.genericRepo.GetAllUserById(id).CalificacionesBrindadas.Where(c => c.Puntuacion.Descripcion == "Pendiente").ToList();
                

                if (!calificacionesPendientes.Any())
                    return Ok(true);
                else
                    return Ok(false);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al obtener puntuaciones pendientes del usuario id: " + id);
            }
        }

        [HttpPost("HorarioLibrePara")]
        public IActionResult CheckHorarioLibre([FromBody] CheckHorarioDTO horarioDTO, [FromQuery]int userId)
        {
            try
            {
                var viajesPendientes = this.genericRepo.GetAllUserById(userId).ViajesPendientes.ToList();
                var viajes = viajesPendientes.Select(vp => new CheckHorarioDTO()
                {
                    Duracion = vp.Viaje.Duracion,
                    HoraPartida = vp.Viaje.HoraPartida,
                    DiasDeViaje = vp.Viaje.DiasDeViaje.Select(dv => dv.fechaDeViaje).ToList()
                }).ToList();

                var superpuestosPorHorario = viajes
                    .Where(d => ((horarioDTO.HoraPartida >= d.HoraPartida && horarioDTO.HoraPartida < (d.HoraPartida + d.Duracion))
                       || ((horarioDTO.HoraPartida + horarioDTO.Duracion) > d.HoraPartida && (horarioDTO.HoraPartida + horarioDTO.Duracion) <= (d.HoraPartida + d.Duracion))
                       || ((horarioDTO.HoraPartida) <= d.HoraPartida && (horarioDTO.HoraPartida + horarioDTO.Duracion) >= (d.HoraPartida + d.Duracion)))).ToList();

                var superpuestos = superpuestosPorHorario.Where(s => s.DiasDeViaje.Select(e => e.ToString("dd/M/yyyy")).Intersect(horarioDTO.DiasDeViaje.Select(e => e.ToString("dd/M/yyyy"))).Any()).ToList();
                return Ok(!superpuestos.Any());
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al obtener validar horarios del usuario id: " + userId);
            }
        }

        [HttpGet("ListarReputacionConductor")]
        public IActionResult GetReputacionConductor(int id)
        {
            try
            {
                var response = this.genericRepo.GetAllUserById(id).CalificacionesRecibidas.Where(c => c.Rol.Descripcion == "Conductor").ToList();

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al listar con id: " + id);
            }
        }

        [HttpGet("ListarReputacionViajero")]
        public IActionResult GetReputacionViajero(int id)
        {
            try
            {
                var response = this.genericRepo.GetAllUserById(id).CalificacionesRecibidas.Where(c => c.Rol.Descripcion == "Viajero").ToList();

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al listar las calificaciones del usuario con id: " + id);
            }
        }

        [HttpGet("ListarPuntuacionesPendientes")]
        public IActionResult PuntuacionesPendientes(int id)
        {
            try
            {
                var response = this.genericRepo.GetAllUserById(id).CalificacionesBrindadas.Where(c => c.Puntuacion.Descripcion == "Pendiente").ToList();

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al listar las calificaciones del usuario con id: " + id);
            }
        }

        [HttpPost("Puntuar")]
        public IActionResult Puntuar([FromBody]PuntuarDTO puntuarDTO, [FromQuery]int userId)
        {
            try
            {
                var user = this.genericRepo.GetAllUserById(userId);
                var calificacion = new Data.Entities.Calificacion(){
                    Comentario = puntuarDTO.Comentario,
                    Rol = rolRepository.GetById(puntuarDTO.IdRol),
                    Puntuacion = tipoCalificacionRepository.GetById(puntuarDTO.IdPuntuacion),
                    UsuarioPuntuador = genericRepo.GetAllUserById(puntuarDTO.IdUsuarioPuntuador),
                    Valor = puntuarDTO.Valor
                };
                user.CalificacionesRecibidas.Add(calificacion);
                var calificacionPendiente = calificacion.UsuarioPuntuador.CalificacionesBrindadas.First(c => c.Id == puntuarDTO.IdPendiente);
                calificacion.UsuarioPuntuador.CalificacionesBrindadas.Remove(calificacionPendiente);
                this.genericRepo.Update(userId, user);

                return Ok(true);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al calificar al usuario con id: " + userId);
            }
        }

        [HttpGet("ListarPagosPendientes")]
        public IActionResult PagosPendientes(int id)
        {
            try
            {
                var response = this.genericRepo.GetAllUserById(id).Pagos.Where(c => c.FechaDePago == null).ToList();

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al listar los pagos del usuario con id: " + id);
            }
        }

        [HttpPost("PagarViaje")]
        public IActionResult PagarViaje([FromBody]PagoDTO pagoDto)
        {
            try
            {
                var usuario = this.genericRepo.GetAllUserById(pagoDto.IdUser);
                var pago = usuario.Pagos.Where(c => c.FechaDePago == null).ToList().Find(p => p.Id == pagoDto.IdPago);
                pago.FechaDePago = DateTime.Now;
                pago.Tarjeta = this.tarjetaRepo.GetById(pagoDto.IdTarjeta);

                this.genericRepo.Update(pagoDto.IdUser, usuario);


                return Ok(true);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al intentar realizar el pago con id: " + pagoDto.IdPago);
            }
        }

        [HttpGet("ListarPreguntasPendientes")]
        public IActionResult PreguntasPendientes(int id)
        {
            try
            {
                var viajes = this.viajeRepo.GetAll().Where(v => v.Creador.Id == id).ToList();
                var response = viajes.Select(v => v.Preguntas.Where(p => p.Respuesta == null).ToList()).SelectMany( i => i ).ToList();

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al listar las preguntas del usuario con id: " + id);
            }
        }

        [HttpPost("ResponderPregunta")]
        public IActionResult ResponderPregunta([FromBody]ResponderPreguntaDTO responderPreguntaDTO)
        {
            try
            {
                var viaje = this.viajeRepo.GetAllById(responderPreguntaDTO.IdViaje);
                var pregunta = viaje.Preguntas.ToList().Find(p => p.Id == responderPreguntaDTO.IdPregunta);
                pregunta.Respuesta = responderPreguntaDTO.Respuesta;

                this.viajeRepo.Update(viaje.Id, viaje);

                return Ok(true);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al responder la pregunta con id: " + responderPreguntaDTO.IdPregunta);
            }
        }

        [HttpPost("GenerarPregunta")]
        public IActionResult GenerarPregunta([FromBody]AltaPreguntaDTO altaPreguntaDTO)
        {
            try
            {
                var viaje = this.viajeRepo.GetAllById(altaPreguntaDTO.IdViaje);
                var pregunta = new Pregunta() {
                    Enunciado = altaPreguntaDTO.Enunciado,
                    Usuario = this.genericRepo.GetById(altaPreguntaDTO.IdUsuario),
                    FechaDeEmision = DateTime.Now
                };
                viaje.Preguntas.Add(pregunta);
                
                this.viajeRepo.Update(viaje.Id, viaje);

                return Ok(true);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error al responder la pregunta del usuario con id: " + altaPreguntaDTO.IdUsuario);
            }
        }
    }
}
