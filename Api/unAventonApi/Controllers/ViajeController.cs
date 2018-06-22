using System;
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

        public ViajeController(IViajeRepository genericRepo, IViajerosRepository viajerosRepository, IPostulantesRepository postulantesRepository,
                                IUserRepository userRepository) : base(genericRepo)
        {
            this.postulantesRepository = postulantesRepository;
            this.viajerosRepository = viajerosRepository;
            this.userRepository = userRepository;
        }

        
        [HttpGet("AgregarViajero")]
        public IActionResult addViajero(int idViaje, int idViajero)
        {
            try
            {
                var user = this.userRepository.GetAllUserById(idViajero);
                var viaje = this.genericRepo.GetAllById(idViaje);
                var postulantes = this.postulantesRepository.GetByIds(idViajero, idViaje);
                this.postulantesRepository.DeleteByIds(idViajero, idViaje);
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
                return BadRequest("Hubo un error en AgregarViajero");
            }
        }

        // [HttpGet("BorrarViajero")]
        // public IActionResult removeViajero(int idViaje, int idViajero)
        // {
        //     try
        //     {
        //         this.postulantesRepository.DeleteByIds(idViajero, idViaje);
        //         return Ok();
        //     }
        //     catch (Exception)
        //     {
        //         return BadRequest("Hubo un error en AgregarViajero");
        //     }
        // }

        // [HttpGet("BorrarPostulante")]
        // public IActionResult removePostulante(int idViaje, int idPostulante)
        // {
        //     try
        //     {
        //         var user = this.userRepository.GetAllUserById(idPostulante);
        //         var viaje = this.genericRepo.GetById(idViaje);
        //         var postulantes = new Postulantes() {
        //             User = user,
        //             UserId = idPostulante,
        //             Viaje = viaje,
        //             ViajeId = idViaje
        //         };

        //         this.postulantesRepository.Create(postulantes);
        //         return Ok();
        //     }
        //     catch (Exception)
        //     {
        //         return BadRequest("Hubo un error en AgregarViajero");
        //     }
        // }

    }
}
