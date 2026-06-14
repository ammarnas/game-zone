namespace GameZone.Models;

public class Category : BaseEntity
{
        // Navigation properties
        public ICollection<Game> Games { get; set; } = [];
}
