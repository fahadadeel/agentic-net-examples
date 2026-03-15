using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class SvgToJpegConverter
{
    static void Main()
    {
        // Path to the source SVG file
        string inputSvgPath = @"C:\Images\source.svg";

        // Desired output JPEG file path
        string outputJpegPath = @"C:\Images\converted.jpg";

        // Load the SVG image using the unified Image.Load method
        using (Image svgImage = Image.Load(inputSvgPath))
        {
            // Configure rasterization options for the SVG.
            // PageSize is set to the original image size to keep the aspect ratio.
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size,
                // Optional: improve quality with antialiasing
                SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias
            };

            // Set JPEG saving options, including compression quality.
            var jpegOptions = new JpegOptions
            {
                VectorRasterizationOptions = rasterOptions,
                Quality = 90 // Adjust 0‑100; higher = better quality, lower = higher compression
            };

            // Save the rasterized image as JPEG.
            svgImage.Save(outputJpegPath, jpegOptions);
        }
    }
}