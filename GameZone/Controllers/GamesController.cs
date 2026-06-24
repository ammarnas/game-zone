using System.Threading.Tasks;

namespace GameZone.Controllers;

public class GamesController : Controller
{
    private readonly IDevicesService _devicesService;
    private readonly ICategoriesService _categoriesService;
    private readonly IGamesService _gamesService;
    public GamesController(
        IGamesService gamesService,
        IDevicesService devicesService,
        ICategoriesService categoriesService)
    {
        _gamesService = gamesService;
        _devicesService = devicesService;
        _categoriesService = categoriesService;
    }
    public IActionResult Index()
    {
        var games = _gamesService.GetAll();
        return View(games);
    }
    public IActionResult Details(int id)
    {
        var game = _gamesService.GetById(id);
        if (game is null)
        {
            return NotFound();
        }
        return View(game);
    }
    [HttpGet]
    public IActionResult Create()
    {
        CreateGameFormViewModel viewModel = new()
        {
            Devices = _devicesService.GetSelectList(),
            Categories = _categoriesService.GetSelectList()
        };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateGameFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Devices = _devicesService.GetSelectList();
            model.Categories = _categoriesService.GetSelectList();

            return View(model);
        }

        await _gamesService.Create(model);
        return RedirectToAction(nameof(Index));
    }
}
