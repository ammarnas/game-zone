namespace GameZone.Models;

public class Game : BaseEntity
{
    [MaxLength(2000)]
    public string Description { get; set; } = string.Empty;
    [MaxLength(500)]
    public string Cover { get; set; } = string.Empty;

    // Navigation properties
    public int CategoryId { get; set; }
    public Category Category { get; set; } = default!;
    public ICollection<GameDevice> Devices { get; set; } = [];
}
