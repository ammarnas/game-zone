
namespace GameZone.Services;

public class GameService(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment) : IGameService
{
    public ApplicationDbContext _dbContext { get; set; } = dbContext;
    public IWebHostEnvironment _webHostEnvironment { get; set; } = webHostEnvironment;
    private readonly string _imagesPath;

    public GameService() : this(null!, null!)
    {
        _imagesPath = Path.Combine(_webHostEnvironment.WebRootPath,"assets","images", "games");
    }

    public void Create(CreateGameFormViewModel game)
    {
        var coverName = $"{Guid.NewGuid()}{Path.GetExtension(game.Cover.FileName)}";

        var coverPath = Path.Combine(_imagesPath, coverName);
    }
}
