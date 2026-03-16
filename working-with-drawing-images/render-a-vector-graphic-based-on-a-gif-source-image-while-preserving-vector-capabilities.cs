using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class GifToSvgConverter
{
    static void Main()
    {
        // Path to the source GIF image
        string gifPath = @"C:\Temp\source.gif";

        // Path where the resulting SVG will be saved
        string svgPath = @"C:\Temp\result.svg";

        // Load the GIF image using Aspose.Imaging
        using (Image gifImage = Image.Load(gifPath))
        {
            // Prepare SVG rasterization options.
            // PageSize is set to the original image size to keep dimensions unchanged.
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = gifImage.Size,
                BackgroundColor = Color.White // optional background
            };

            // Configure SVG save options and attach the rasterization options.
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions,
                Compress = false // keep SVG uncompressed for readability
            };

            // Save the GIF as an SVG file. The raster image will be embedded,
            // preserving the ability to treat the result as a vector graphic.
            gifImage.Save(svgPath, svgOptions);
        }
    }
}