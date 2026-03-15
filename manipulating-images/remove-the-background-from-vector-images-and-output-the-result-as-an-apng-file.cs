using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Input vector image (e.g., SVG) and output APNG file paths
        string inputPath = "input.svg";
        string outputPath = "output.apng";

        // Load the vector image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to VectorImage to access background removal
            var vectorImage = (VectorImage)image;
            // Remove the background from the vector image
            vectorImage.RemoveBackground();

            // Define rasterization options for converting vector to raster
            var rasterOptions = new SvgRasterizationOptions
            {
                // Use the original size of the vector image
                PageSize = vectorImage.Size
            };

            // Configure APNG saving options, including rasterization settings
            var apngOptions = new ApngOptions
            {
                VectorRasterizationOptions = rasterOptions,
                // Ensure the output supports alpha channel
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Save the processed image as an APNG file
            image.Save(outputPath, apngOptions);
        }
    }
}