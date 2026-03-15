using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path (first argument or default)
        string inputPath = args.Length > 0 ? args[0] : "input.svg";
        // Output BMP file path (second argument or default)
        string outputPath = args.Length > 1 ? args[1] : "output.bmp";

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options to preserve visual fidelity
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size,
                BackgroundColor = Color.White,
                SmoothingMode = SmoothingMode.AntiAlias,
                TextRenderingHint = TextRenderingHint.AntiAlias
            };

            // Set BMP export options with the rasterization settings
            BmpOptions bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rendered image as BMP
            image.Save(outputPath, bmpOptions);
        }
    }
}