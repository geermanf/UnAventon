namespace unAventonApi.Data.Entities.TablasIntermedias
{
    public class ViajesRealizados
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ViajeId { get; set; }
        public Viaje Viaje { get; set; }

        //generar id compuesto userId, viajeId
    }
}