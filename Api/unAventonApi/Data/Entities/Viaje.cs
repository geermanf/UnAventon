using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using unAventonApi.Data.Entities.TablasIntermedias;

namespace unAventonApi.Data.Entities
{
    public class Viaje : IEntity
    {
        public string Origen { get; set; }
        public string Destino { get; set; }
        public TimeSpan Duracion { get; set; }
        public TipoViaje TipoViaje { get; set; }
        public double Costo { get; set; }
        public DateTime FechaPartida { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public IList<Postulantes> Postulantes { get; set; }
        public IList<Viajeros> Viajeros { get; set; }
        public User Creador { get; set; }
        [Key]
        public int Id { get; set; }
    }
}