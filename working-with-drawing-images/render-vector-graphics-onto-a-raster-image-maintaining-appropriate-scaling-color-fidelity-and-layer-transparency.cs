using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class VectorToRaster
{
    static void Main()
    {
        // Path to the source SVG file (vector graphic)
        string inputPath = @"C:\Images\source.svg";

        // Path where the rasterized PNG will be saved
        string outputPath = @"C:\Images\output.png";

        // Load the SVG image using the unified Image.Load method
        using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
        {
            // Configure rasterization options to control scaling, background, and rendering quality
            var rasterOptions = new SvgRasterizationOptions
            {
                // Preserve the original SVG dimensions
                PageSize = svgImage.Size,

                // Keep transparency by using a transparent background
                BackgroundColor = Color.Transparent,

                // Apply anti-aliasing for smoother lines and curves
                SmoothingMode = SmoothingMode.AntiAlias,

                // Render text with anti-aliasing for better readability
                TextRenderingHint = TextRenderingHint.AntiAlias,

                // Scale factors (1.0 = original size). Adjust if you need different output dimensions.
                ScaleX = 1.0f,
                ScaleY = 1.0f
            };

            // Create PNG save options and attach the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image to the specified PNG file
            svgImage.Save(outputPath, pngOptions);
        }
    }
}