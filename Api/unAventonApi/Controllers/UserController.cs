using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using unAventonApi.Controllers.Base;
using unAventonApi.Data;
using unAventonApi.Data.DTOEntities;

namespace unAventonApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : GenericController<IUserRepository, User>
    {
        public UserController(IUserRepository genericRepo) : base(genericRepo)
        {
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
                var user = this.genericRepo.GetAllUserById(id);

                if (user.Id != 1)
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
                var user = this.genericRepo.GetAllUserById(id);

                if (user.Id != 3)
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
    }
}
