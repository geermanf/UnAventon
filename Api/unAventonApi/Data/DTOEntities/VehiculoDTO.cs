using System.ComponentModel.DataAnnotations;

namespace unAventonApi.Data
{
    public class VehiculoDTO
    {
        public string Marca { get; set; }

        public string Modelo { get; set; }
        public int CantidadPlazas { get; set; }
        public string Patente { get; set; }
        public string Color { get; set; }
        public string Foto { get; set; }
        public string TipoVehiculo { get; set; }

    }
}