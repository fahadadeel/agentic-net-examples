using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class SvgToBmpConverter
{
    static void Main()
    {
        // Path to the source SVG file
        string inputSvgPath = @"C:\Images\source.svg";

        // Desired output BMP file path
        string outputBmpPath = @"C:\Images\converted.bmp";

        // Load the SVG image using Aspose.Imaging's unified loader
        using (Image image = Image.Load(inputSvgPath))
        {
            // Obtain rasterization options that match the SVG's dimensions.
            // The first argument sets the background color for rasterization.
            var rasterizationOptions = (SvgRasterizationOptions)image.GetDefaultOptions(
                new object[] { Color.White, image.Width, image.Height });

            // Create BMP save options and attach the rasterization settings.
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized image as BMP, preserving visual fidelity.
            image.Save(outputBmpPath, bmpOptions);
        }
    }
}