using System;

namespace unAventonApi.Data.Entities
{
    public class DiaDeViaje : IEntity
    {
        public int Id { get; set; }

        public int ViajeId { get; set; }

        public DateTime fechaDeViaje { get; set; }
    }
}