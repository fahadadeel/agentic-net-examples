using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.apng";

        // Load the source image as a raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Apply Gaussian blur filter (radius 5, sigma 4.0) to the entire image
            sourceImage.Filter(sourceImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Set up APNG creation options
            ApngOptions apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // frame duration in milliseconds
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create an APNG canvas with the same dimensions as the source image
            using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, sourceImage.Width, sourceImage.Height))
            {
                // Remove the default frame that exists upon creation
                apngImage.RemoveAllFrames();

                // Add the blurred image as a single frame
                apngImage.AddFrame(sourceImage);

                // Save the APNG file (output is already bound via FileCreateSource)
                apngImage.Save();
            }
        }
    }
}