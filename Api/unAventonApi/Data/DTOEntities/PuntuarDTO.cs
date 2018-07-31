namespace unAventonApi.Data.DTOEntities
{
    public class PuntuarDTO
    {
        public int IdRol { get; set; }

        public int IdPuntuacion { get; set; }

        public string Comentario { get; set; }
        
        public int IdUsuarioPuntuador { get; set; }

        public int IdPendiente { get; set; }
    }
}