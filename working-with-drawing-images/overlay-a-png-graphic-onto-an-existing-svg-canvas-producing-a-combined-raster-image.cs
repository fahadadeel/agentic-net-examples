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
        // Input SVG and PNG file paths
        string svgPath = "input.svg";
        string pngPath = "overlay.png";
        // Output raster image path (PNG format)
        string outputPath = "combined.png";

        // Load the SVG image
        using (Image svgImage = Image.Load(svgPath))
        {
            // Set up rasterization options to convert SVG to raster
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size // Preserve original SVG size
            };

            // Configure PNG options with the vector rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Rasterize SVG into a memory stream
            using (MemoryStream rasterStream = new MemoryStream())
            {
                svgImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0;

                // Load the rasterized SVG as a RasterImage (canvas)
                using (RasterImage canvas = (RasterImage)Image.Load(rasterStream))
                {
                    // Load the PNG graphic to overlay
                    using (RasterImage overlay = (RasterImage)Image.Load(pngPath))
                    {
                        // Define the area on the canvas where the PNG will be placed (top‑left corner)
                        Rectangle overlayBounds = new Rectangle(0, 0, overlay.Width, overlay.Height);
                        // Copy PNG pixels onto the canvas
                        canvas.SaveArgb32Pixels(overlayBounds, overlay.LoadArgb32Pixels(overlay.Bounds));
                    }

                    // Prepare output options for the final PNG file
                    Source outSource = new FileCreateSource(outputPath, false);
                    PngOptions outOptions = new PngOptions { Source = outSource };

                    // Save the combined raster image
                    canvas.Save(outputPath, outOptions);
                }
            }
        }
    }
}