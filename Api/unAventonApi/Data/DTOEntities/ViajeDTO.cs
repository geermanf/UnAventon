using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using unAventonApi.Data.Entities.TablasIntermedias;

namespace unAventonApi.Data.Entities
{
    public class ViajeDTO
    {
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string Descripcion { get; set; }
        public TimeSpan Duracion { get; set; }
        public int TipoViaje { get; set; }
        public double Costo { get; set; }
        public int CantidadDePlazas { get; set; }
        public IList<DateTime> DiasDeViaje { get; set; }
        public TimeSpan HoraPartida { get; set; }
        public int Vehiculo { get; set; }
        public int Creador { get; set; }
    }
}