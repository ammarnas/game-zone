namespace GameZone.Controllers;

public class GamesController : Controller
{
    private readonly IDevicesService _devicesService;
    private readonly ICategoriesService _categoriesService;

    public GamesController(
        IDevicesService devicesService,
        ICategoriesService categoriesService)
    {
        _devicesService = devicesService;
        _categoriesService = categoriesService;
    }
    public IActionResult Index()
    {
        return View();
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
    public IActionResult Create(CreateGameFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Devices = _devicesService.GetSelectList();
            model.Categories = _categoriesService.GetSelectList();

            return View(model);
        }
        return View();
    }
}
