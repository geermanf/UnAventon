using System;
using System.ComponentModel.DataAnnotations;

namespace unAventonApi.Data
{
    public class Tarjeta : IEntity
    {
        public int Id { get; set; }

        public int NumeroTarjeta { get; set; }
        public int CodigoSeguridad { get; set; }

        public int DniTitular { get; set; }

        public string NombreTitular { get; set; }

        public DateTime FechaVencimiento { get; set; }

    }
}