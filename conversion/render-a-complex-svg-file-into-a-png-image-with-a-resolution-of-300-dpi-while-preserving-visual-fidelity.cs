using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

namespace RenderingSvgToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source SVG file
            string inputSvgPath = "input.svg";

            // Desired output PNG file path
            string outputPngPath = "output.png";

            // Load the SVG image using Aspose.Imaging.Image.Load
            using (Image image = Image.Load(inputSvgPath))
            {
                // Cast the generic Image to SvgImage for SVG-specific properties
                SvgImage svgImage = (SvgImage)image;

                // Configure rasterization options to control how the SVG is rasterized
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                rasterOptions.PageSize = svgImage.Size;                 // Preserve original dimensions
                rasterOptions.BackgroundColor = Color.White;            // Set background to white
                rasterOptions.SmoothingMode = SmoothingMode.AntiAlias; // Enable antialiasing for smooth edges
                rasterOptions.TextRenderingHint = TextRenderingHint.AntiAlias; // High‑quality text rendering

                // Configure PNG export options and set the target resolution to 300 DPI
                PngOptions pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = rasterOptions;
                pngOptions.ResolutionSettings = new ResolutionSetting(300, 300); // 300 DPI horizontal & vertical

                // Save the rasterized image as PNG
                svgImage.Save(outputPngPath, pngOptions);
            }
        }
    }
}