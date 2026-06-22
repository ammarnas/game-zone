namespace GameZone.Settings;

public class FileSettings
{
    public const string ImagesPath = "/assets/images/games";
    public const string AllowedImageExtensions = ".jpg,.jpeg,.png,.gif";
    public const int MaxImageSizeInMB = 2;
    public const int MaxImageSizeInBytes = MaxImageSizeInMB * 1024 * 1024; // 2 MB
}
