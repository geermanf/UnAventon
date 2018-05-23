using System.ComponentModel.DataAnnotations;

namespace unAventonApi.Data
{
    public interface IEntity
    {
        [Key]
        int Id { get; set; }
    }
}