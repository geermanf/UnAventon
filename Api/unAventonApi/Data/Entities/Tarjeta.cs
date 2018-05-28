using System;
using System.ComponentModel.DataAnnotations;

namespace unAventonApi.Data
{
    public class Tarjeta : IEntity
    {
        public int Id { get; set; }

        public int NumeroTarjeta { get; set; }

        public string Banco { get; set; }

        public string Tipo { get; set; }
        public string NombreTitular { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public User Usuario { get; set; }

    }
}