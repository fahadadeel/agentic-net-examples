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
        // Input image path (must support transparency)
        string inputPath = "input.png";
        // Output APNG file path
        string outputPath = "output.apng";
        // Desired dimensions for the resized image
        int targetWidth = 200;
        int targetHeight = 150;

        // Load the source image as a raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Cache data for better performance before processing
            if (!sourceImage.IsCached)
                sourceImage.CacheData();

            // Resize the image while preserving its alpha channel
            sourceImage.Resize(targetWidth, targetHeight);

            // Configure APNG creation options with alpha support
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create an APNG canvas matching the resized image size
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                // Remove the default frame that exists upon creation
                apngImage.RemoveAllFrames();

                // Add the resized raster image as the sole frame
                apngImage.AddFrame(sourceImage);

                // Save the APNG file
                apngImage.Save();
            }
        }
    }
}