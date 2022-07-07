using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLDirector.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        [NotMapped]
        public string? NombreCompleto => $"{Nombre} {Apellido}";

        public virtual ICollection<Video>? Videos { get; set; }
    }
}
