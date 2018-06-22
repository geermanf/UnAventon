using System.ComponentModel.DataAnnotations;

namespace unAventonApi.Data.Entities.TablasIntermedias
{
    public class Viajeros
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ViajeId { get; set; }
        public Viaje Viaje { get; set; }
    }
}