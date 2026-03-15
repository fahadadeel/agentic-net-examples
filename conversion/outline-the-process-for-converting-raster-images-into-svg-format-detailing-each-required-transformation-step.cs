using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

public static class RasterToSvgConverter
{
    /// <summary>
    /// Converts a raster image (e.g., PNG, JPEG, BMP) to an SVG file.
    /// The raster data is embedded into the SVG as a base‑64 encoded image.
    /// </summary>
    /// <param name="inputPath">Full path to the source raster image.</param>
    /// <param name="outputPath">Full path where the resulting SVG will be saved.</param>
    public static void Convert(string inputPath, string outputPath)
    {
        // Load the raster image using the unified Image.Load method.
        using (Image rasterImage = Image.Load(inputPath))
        {
            // Prepare SVG rasterization options.
            // PageSize defines the dimensions of the resulting SVG canvas.
            // BackgroundColor can be set if a specific background is required.
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = rasterImage.Size,
                BackgroundColor = Color.White // optional: set background to white
            };

            // Configure SVG save options.
            // TextAsShapes is irrelevant for raster images but shown for completeness.
            SvgOptions svgSaveOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions,
                TextAsShapes = false,   // keep text as text (no effect for raster)
                Compress = false        // output plain SVG (set true for .svgz)
            };

            // Save the raster image as SVG. The raster data will be embedded.
            rasterImage.Save(outputPath, svgSaveOptions);
        }
    }
}

// Example usage:
// RasterToSvgConverter.Convert(@"C:\Images\photo.jpg", @"C:\Images\photo.svg");