using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using unAventonApi.Controllers.Base;
using unAventonApi.Data;

namespace unAventonApi.Controllers
{
    [Route("api/[controller]")]
    public class VehiculoController : GenericController<IVehiculoRepository, Vehiculo>
    {
        public IUserRepository userRepository { get; }

        public VehiculoController(IVehiculoRepository genericRepo, IUserRepository userRepository) : base(genericRepo)
        {
            this.userRepository = userRepository;
        }

[HttpPost("RegistrarEnUser")]
        public async Task<IActionResult> Registrar([FromBody] VehiculoDTO vehiculo, [FromQuery]int userId)
        {
            var car = new Vehiculo() {
                Marca = vehiculo.Marca,
                Modelo = vehiculo.Modelo,
                CantidadPlazas = vehiculo.CantidadPlazas,
                Patente = vehiculo.Patente,
                Color = vehiculo.Color,
                Foto = vehiculo.Foto,
                TipoVehiculo = vehiculo.TipoVehiculo
            };
            try
            {
                var user = this.userRepository.GetAllUserById(userId);

                var newCar = this.genericRepo.Create(car);

                user.Vehiculos.Add(newCar.Result);
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
