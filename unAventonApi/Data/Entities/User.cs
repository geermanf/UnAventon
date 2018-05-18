namespace unAventonApi.Data
{
    public class User : IEntity
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Category Category { get; set; }
    }
}