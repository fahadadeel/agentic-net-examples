using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path (first argument) and output BMP file path (second argument)
        string inputPath = args.Length > 0 ? args[0] : "input.svg";
        string outputPath = args.Length > 1 ? args[1] : "output.bmp";

        // Load the SVG image using the unified Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Prepare BMP save options with desired color depth
            using (BmpOptions bmpOptions = new BmpOptions())
            {
                // Set bits per pixel (24 for true color without alpha)
                bmpOptions.BitsPerPixel = 24;

                // Configure vector rasterization to preserve visual fidelity
                // SvgRasterizationOptions derives from VectorRasterizationOptions
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    // Use the original SVG size as the page size
                    PageSize = image.Size
                };

                // Assign rasterization options to BMP options
                bmpOptions.VectorRasterizationOptions = rasterOptions;

                // Save the rasterized image as BMP
                image.Save(outputPath, bmpOptions);
            }
        }
    }
}