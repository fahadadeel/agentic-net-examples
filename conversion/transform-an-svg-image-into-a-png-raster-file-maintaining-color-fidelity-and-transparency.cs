using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source SVG file
        string inputSvgPath = @"C:\temp\input.svg";
        // Desired path for the resulting PNG file
        string outputPngPath = @"C:\temp\output.png";

        // Open the SVG file as a read‑only stream
        using (FileStream svgStream = File.OpenRead(inputSvgPath))
        // Load the SVG image from the stream
        using (SvgImage svgImage = new SvgImage(svgStream))
        {
            // Configure rasterization options:
            // - Use the original SVG dimensions (PageSize)
            // - Preserve transparency by setting a transparent background
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size,
                BackgroundColor = Aspose.Imaging.Color.Transparent
            };

            // Set up PNG save options and attach the rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize the SVG and save it as a PNG file
            svgImage.Save(outputPngPath, pngOptions);
        }
    }
}