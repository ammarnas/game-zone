namespace GameZone.ViewModels;

public class CreateGameFormViewModel
{
    [MaxLength(250)]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    [AllowedExtensions(FileSettings.AllowedImageExtensions)]
    public IFormFile Cover { get; set; } = default!;
    [Display(Name = "Category")]
    public int  CategoryId { get; set; }
    public IEnumerable<SelectListItem> Categories { get; set; } = [];
    [Display(Name = "Supported Devices")]
    public List<int> SelectedDevices { get; set; } = default!;
    public IEnumerable<SelectListItem> Devices { get; set; } = [];

}
