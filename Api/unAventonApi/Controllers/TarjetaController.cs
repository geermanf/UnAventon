using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using unAventonApi.Controllers.Base;
using unAventonApi.Data;
using unAventonApi.Data.DTOEntities;

namespace unAventonApi.Controllers
{
    [Route("api/[controller]")]
    public class TarjetaController : GenericController<ITarjetaRepository, Tarjeta>
    {
        private readonly IBancoRepository bancoRepository;
        private readonly IUserRepository userRepository;
        private readonly ITipoTarjetaRepository tipoTarjetaRepository;

        public TarjetaController(ITarjetaRepository genericRepo, IUserRepository userRepository,
                                ITipoTarjetaRepository tipoTarjetaRepository, IBancoRepository bancoRepository) : base(genericRepo)
        {
            this.userRepository = userRepository;
            this.tipoTarjetaRepository = tipoTarjetaRepository;
            this.bancoRepository = bancoRepository;
        }

        [HttpPost("RegistrarEnUser")]
        public async Task<IActionResult> Registrar([FromBody] TarjetaDTO tarjeta, [FromQuery]int userId)
        {
            var card = new Tarjeta() {
                NumeroTarjeta = tarjeta.NumeroTarjeta,
                NombreTitular = tarjeta.NombreTitular,
                FechaVencimiento = tarjeta.FechaVencimiento
            };
            try
            {
                card.Banco = this.bancoRepository.GetById(tarjeta.Banco);
                card.Tipo = this.tipoTarjetaRepository.GetById(tarjeta.Tipo);
                
                var user = this.userRepository.GetAllUserById(userId);

                var newCard = this.genericRepo.Create(card);

                user.Tarjetas.Add(newCard.Result);
                this.userRepository.Update(user.Id, user);

                return Ok();
            }
            catch (Exception)
            {
                // return BuildApiResponse.BuildNotOk( "Hubo un error al registrar");
                return BadRequest("Hubo un error al registrar");
            }
        }
    }
}