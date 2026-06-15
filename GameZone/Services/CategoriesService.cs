namespace GameZone.Services;
public class CategoriesService(ApplicationDbContext dbContext) : ICategoriesService
{
    private readonly ApplicationDbContext _context = dbContext;

    public IEnumerable<SelectListItem> GetSelectList()
    {
        return _context.Categories
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            })
            .OrderBy(c => c.Text)
            .AsNoTracking()
            .ToList();
    }
}
