namespace unAventonApi.Data.Entities
{
    public class TipoCalificacion : IEntity
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        // Positiva, Neutra, Negativa, Penalizacion
    }
}