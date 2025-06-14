using MRB.Domain.Exceptions;

namespace MRB.Application.Helpers;

public static class ImageHelper
{
    private static (byte[], string) ValidateBase64Image(string base64Image)
    {
        byte[] imageBytes = Convert.FromBase64String(base64Image);

        string extension;

        if (IsPng(imageBytes))
            extension = ".png";
        else if (IsBmp(imageBytes))
            extension = ".bmp";
        else
            throw new InvalidFormatImageException("Invalid image format");
        
        return (imageBytes, extension);
    }

    public static string SaveBase64Image(string base64Image)
    {
        var (imageBytes, extension) = ValidateBase64Image(base64Image);

        var directoryPath = @$"c:\temp\mrb_images";
            
        string fileName = $"image{Guid.NewGuid()}{extension}";
        string fullPath = Path.Combine(directoryPath, fileName);

        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);
        
        File.WriteAllBytes(fullPath, imageBytes);

        return fullPath;
    }
    
    private static bool IsPng(byte[] bytes)
    {
        // PNG começa com: 89 50 4E 47
        return bytes.Length > 4 &&
               bytes[0] == 0x89 &&
               bytes[1] == 0x50 &&
               bytes[2] == 0x4E &&
               bytes[3] == 0x47;
    }

    private static bool IsBmp(byte[] bytes)
    {
        // BMP começa com: 42 4D
        return bytes.Length > 2 &&
               bytes[0] == 0x42 &&
               bytes[1] == 0x4D;
    }
}