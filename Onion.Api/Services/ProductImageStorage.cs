namespace Onion.Api.Services;

/// <summary>
/// API sürecinin kendi wwwroot/Images (veya yapılandırılmış) klasörüne yazar. MVC projesine dokunulmaz.
/// </summary>
public sealed class ProductImageStorage
{
    private const long MaxBytes = 5 * 1024 * 1024;
    private static readonly HashSet<string> AllowedExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".jpg", ".jpeg", ".png", ".gif", ".webp"
    };

    public ProductImageStorage(IWebHostEnvironment env, IConfiguration configuration)
    {
        var configured = configuration["ProductImages:PhysicalRoot"];
        if (!string.IsNullOrWhiteSpace(configured))
        {
            PhysicalRoot = Path.IsPathRooted(configured)
                ? Path.GetFullPath(configured)
                : Path.GetFullPath(Path.Combine(env.ContentRootPath, configured));
        }
        else
        {
            var wwwroot = env.WebRootPath ?? Path.Combine(env.ContentRootPath, "wwwroot");
            PhysicalRoot = Path.GetFullPath(Path.Combine(wwwroot, "Images"));
        }

        Directory.CreateDirectory(PhysicalRoot);
    }

    public string PhysicalRoot { get; }

    public async Task<string> SaveAsync(Stream content, string originalFileName, long? declaredLength, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(content);

        if (declaredLength.HasValue && declaredLength.Value > MaxBytes)
            throw new InvalidOperationException($"Dosya en fazla {MaxBytes / (1024 * 1024)} MB olabilir.");

        var ext = Path.GetExtension(originalFileName);
        if (string.IsNullOrEmpty(ext) || !AllowedExtensions.Contains(ext))
            throw new InvalidOperationException("İzin verilen uzantılar: .jpg, .jpeg, .png, .gif, .webp.");

        var fileName = Guid.NewGuid().ToString("N") + ext;
        var fullPath = Path.Combine(PhysicalRoot, fileName);

        await using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 81920, useAsync: true))
        {
            await content.CopyToAsync(fs, cancellationToken);
        }

        var written = new FileInfo(fullPath).Length;
        if (written > MaxBytes)
        {
            try { File.Delete(fullPath); } catch { /* ignore */ }
            throw new InvalidOperationException($"Dosya en fazla {MaxBytes / (1024 * 1024)} MB olabilir.");
        }

        return fileName;
    }
}
