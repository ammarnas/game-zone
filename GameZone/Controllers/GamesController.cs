namespace GameZone.Controllers;

public class GamesController : Controller
{
    private readonly ApplicationDbContext _context;

    public GamesController(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]

    public IActionResult Create()
    {
        var categories = _context.Categories
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            })
            .OrderBy(c => c.Text)
            .ToList();
        CreateGameFormViewModel viewModel = new()
        {
            Categories = categories
        };
        return View(viewModel);
    }
}
