using System;
using System.ComponentModel.DataAnnotations;
using unAventonApi.Data.Entities;

namespace unAventonApi.Data
{
    public class Tarjeta : IEntity
    {
        public int Id { get; set; }

        public int NumeroTarjeta { get; set; }

        public Banco Banco { get; set; }

        public TipoTarjeta Tipo { get; set; }
        public string NombreTitular { get; set; }

        public DateTime FechaVencimiento { get; set; }

    }
}