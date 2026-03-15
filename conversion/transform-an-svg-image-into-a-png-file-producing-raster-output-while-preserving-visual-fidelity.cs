using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

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
            // Cast the loaded image to SvgImage
            SvgImage svgImage = (SvgImage)image;

            // Configure rasterization options for high-fidelity rendering
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size,
                BackgroundColor = Color.White,
                SmoothingMode = SmoothingMode.AntiAlias,
                TextRenderingHint = TextRenderingHint.AntiAlias
            };

            // Set up PNG save options and attach rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as PNG
            svgImage.Save(outputPath, pngOptions);
        }
    }
}