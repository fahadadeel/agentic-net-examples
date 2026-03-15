using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class ApngToSvgConverter
{
    static void Main()
    {
        // Path to the source APNG file
        string inputFile = @"C:\Images\animation.apng";

        // Desired output SVG file path
        string outputFile = @"C:\Images\animation_converted.svg";

        // Load the APNG image (raster image with multiple frames)
        using (Image image = Image.Load(inputFile))
        {
            // Obtain default vector rasterization options.
            // This creates options that will embed the raster data into an SVG,
            // preserving visual fidelity of the original APNG.
            var vectorOptions = (VectorRasterizationOptions)image.GetDefaultOptions(
                new object[] { Aspose.Imaging.Color.White, image.Width, image.Height });

            // Configure SVG save options with the rasterization settings.
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = vectorOptions,
                // Optional: keep original metadata if needed
                KeepMetadata = true
            };

            // Save the image as an SVG file.
            image.Save(outputFile, svgOptions);
        }
    }
}