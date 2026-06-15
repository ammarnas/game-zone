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

        var devices = _context.Devices
            .Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            })
            .OrderBy(d => d.Text)
            .ToList();
        CreateGameFormViewModel viewModel = new()
        {
            Devices = devices,
            Categories = categories
        };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CreateGameFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Categories = _context.Categories
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            })
            .OrderBy(c => c.Text)
            .ToList();

            model.Devices = _context.Devices
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                })
                .OrderBy(d => d.Text)
                .ToList();
             return View(model);
        }
        return View();
    }
}
