using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using unAventonApi.Data.Entities;

namespace unAventonApi.Data
{
    public class Tarjeta : IEntity
    {
        public int Id { get; set; }

        public int NumeroTarjeta { get; set; }
        [ForeignKey("BancoId")]
        public Banco Banco { get; set; }
        [ForeignKey("TipoId")]
        public TipoTarjeta Tipo { get; set; }
        public string NombreTitular { get; set; }

        public DateTime FechaVencimiento { get; set; }

    }
}