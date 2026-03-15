using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input and output SVG files
        string inputPath = "input.svg";
        string outputPath = "output.svg";

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure SVG save options
            SvgOptions saveOptions = new SvgOptions
            {
                // Keep text as text to allow font embedding
                TextAsShapes = false
            };

            // Optional: set vector rasterization options (e.g., page size)
            VectorRasterizationOptions vectorOpts = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };
            saveOptions.VectorRasterizationOptions = vectorOpts;

            // Save the SVG with embedded fonts (if fonts are referenced in the source)
            image.Save(outputPath, saveOptions);
        }
    }
}