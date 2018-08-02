using System;

namespace unAventonApi.Data.DTOEntities
{
    public class ModificarViajeDTO
    {
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string Descripcion { get; set; }
        public TimeSpan Duracion { get; set; }
        public int IdViaje { get; set; }
        public double Costo { get; set; }
        public int CantidadDePlazas { get; set; }
        public int Vehiculo { get; set; }
    }
}