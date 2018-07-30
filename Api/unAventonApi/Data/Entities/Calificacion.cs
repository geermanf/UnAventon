namespace unAventonApi.Data.Entities
{
    public class Calificacion
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public TipoCalificacion Puntuacion { get; set; }

        public Rol Rol { get; set; }

        public int idUsuarioPuntuador { get; set;}
    }
}