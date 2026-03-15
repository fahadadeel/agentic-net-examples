using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input raster image path
        string inputPath = "input.png";
        // Output APNG file path
        string outputPath = "output.apng";

        // Load the source raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Apply bilateral smoothing filter to improve visual quality
            sourceImage.Filter(
                sourceImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.BilateralSmoothingFilterOptions(5));

            // Set up APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 70, // frame duration in milliseconds
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create APNG image with the same dimensions as the source
            using (ApngImage apngImage = (ApngImage)Image.Create(
                createOptions,
                sourceImage.Width,
                sourceImage.Height))
            {
                // Remove the default frame
                apngImage.RemoveAllFrames();

                // Add multiple frames using the filtered source image
                int frameCount = 5;
                for (int i = 0; i < frameCount; i++)
                {
                    apngImage.AddFrame(sourceImage);
                }

                // Save the APNG file
                apngImage.Save();
            }
        }
    }
}