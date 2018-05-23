using System.ComponentModel.DataAnnotations;

namespace unAventonApi.Data
{
    public class Vehiculo : IEntity
    {
        public string Marca { get; set; }

        public string Modelo { get; set; }
        public int CantidadPlazas { get; set; }
        public string Patente { get; set; }
        public string Color { get; set; }
        public TipoVehiculo TipoVehiculo { get; set; }
        [Key]
        public int Id { get; set; }
    }
}