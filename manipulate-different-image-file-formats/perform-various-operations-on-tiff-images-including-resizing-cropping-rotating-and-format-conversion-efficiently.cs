using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string resizedPath = "resized.tif";
        string croppedPath = "cropped.tif";
        string rotatedPath = "rotated.tif";
        string pngPath = "converted.png";

        // Resize
        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            image.Resize(200, 200);
            image.Save(resizedPath);
        }

        // Crop
        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            int cropWidth = 100;
            int cropHeight = 100;
            int cropX = (image.Width - cropWidth) / 2;
            int cropY = (image.Height - cropHeight) / 2;
            var cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            image.Crop(cropRect);
            image.Save(croppedPath);
        }

        // Rotate
        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            image.Rotate(45f, true, Color.White);
            image.Save(rotatedPath);
        }

        // Convert to PNG
        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            image.Save(pngPath, new PngOptions());
        }
    }
}