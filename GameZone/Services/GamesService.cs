

namespace GameZone.Services;

public class GamesService : IGamesService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly string _imagesPath;

    public GamesService(
        ApplicationDbContext dbContext, 
        IWebHostEnvironment webHostEnvironment)
    {
        _dbContext = dbContext;
        _webHostEnvironment = webHostEnvironment;
        _imagesPath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
    }

    public IEnumerable<Game> GetAll()
    {
        return _dbContext.Games
            .Include(g => g.Category)
            .Include(g => g.Devices)
                .ThenInclude(d => d.Device)
            .AsNoTracking()
            .ToList();
    }
    public async Task Create(CreateGameFormViewModel model)
    {
        var coverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";

        var coverPath = Path.Combine(_imagesPath, coverName);

        using var stream = File.Create(coverPath);
        await model.Cover.CopyToAsync(stream);

        Game game = new()
        {
            Name = model.Name,
            Description = model.Description,
            Cover = coverName,
            CategoryId = model.CategoryId,
            Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList()
        };

        _dbContext.Add(game);
        _dbContext.SaveChanges();
    }
}
