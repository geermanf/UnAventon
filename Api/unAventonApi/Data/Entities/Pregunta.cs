using System;

namespace unAventonApi.Data.Entities
{
    public class Pregunta: IEntity
    {
        public int Id { get; set; }
        
        public string Enunciado { get; set; }

        public string Respuesta { get; set; }

        public DateTime FechaDeEmision { get; set; }

        public User Usuario { get; set; }
    }
}