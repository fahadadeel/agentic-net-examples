using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path
        string inputPath = "input.svg";
        // Output PNG file path
        string outputPath = "output.png";

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to VectorImage to access vector-specific methods
            var vectorImage = image as VectorImage;
            if (vectorImage != null)
            {
                // Remove background using default settings
                vectorImage.RemoveBackground(new RemoveBackgroundSettings());
            }

            // Configure PNG options with transparency and rasterization settings
            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.Transparent,
                    PageSize = image.Size
                }
            };

            // Save the result as PNG preserving transparency
            image.Save(outputPath, pngOptions);
        }
    }
}