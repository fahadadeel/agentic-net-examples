using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class ConfigurePngResolution
{
    static void Main()
    {
        // Paths to the source PNG and the output PNG
        string inputPath = @"c:\temp\sample.png";
        string outputPath = @"c:\temp\sample_300dpi.png";

        // Load the existing PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to PngImage to access PNG‑specific members
            PngImage pngImage = (PngImage)image;

            // Set the desired horizontal and vertical DPI (e.g., 300 DPI)
            pngImage.SetResolution(300.0, 300.0);

            // Create PNG save options and explicitly set the resolution settings
            PngOptions pngOptions = new PngOptions
            {
                ResolutionSettings = new ResolutionSetting(300.0, 300.0)
            };

            // Save the image with the new DPI settings
            image.Save(outputPath, pngOptions);
        }

        Console.WriteLine("PNG saved with 300 DPI resolution at: " + outputPath);
    }
}