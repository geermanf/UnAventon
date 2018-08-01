using System.ComponentModel.DataAnnotations.Schema;

namespace unAventonApi.Data.Entities
{
    public class Calificacion
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public TipoCalificacion Puntuacion { get; set; }

        public Rol Rol { get; set; }

        public User UsuarioPuntuador { get; set; }

        public User UsuarioCalificado { get; set; }

        public int Valor { get; set; }
    }
}