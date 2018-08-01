using System;
using unAventonApi.Data.Entities;

namespace unAventonApi.Data
{
    public class Pago: IEntity
    {
        public int Id { get; set; }
        public Tarjeta Tarjeta { get; set; }
        public DateTime? FechaDePago { get; set; }

        public int Monto { get; set; }

        public Viaje Viaje { get; set; }
    }
}