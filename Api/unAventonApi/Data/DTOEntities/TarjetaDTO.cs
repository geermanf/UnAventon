using System;
using System.ComponentModel.DataAnnotations;
using unAventonApi.Data.Entities;

namespace unAventonApi.Data.DTOEntities
{
    public class TarjetaDTO
    {
        public int NumeroTarjeta { get; set; }

        public int Banco { get; set; }

        public int Tipo { get; set; }
        public string NombreTitular { get; set; }

        public DateTime FechaVencimiento { get; set; }

    }
}