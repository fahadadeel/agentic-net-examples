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
        // Expect input image path as first argument and output APNG path as second argument
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <program> <inputImagePath> <outputApngPath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the source image as a raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Apply Bradley adaptive thresholding
            double brightnessDifference = 5.0; // typical value
            int windowSize = 10;               // 10x10 window
            sourceImage.BinarizeBradley(brightnessDifference, windowSize);

            // Prepare APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 1000, // 1 second per frame (single frame)
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create APNG image with the same dimensions as the processed source
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                // Ensure no default frame remains
                apngImage.RemoveAllFrames();

                // Add the processed raster image as the sole frame
                apngImage.AddFrame(sourceImage);

                // Save the APNG to the specified output path
                apngImage.Save();
            }
        }
    }
}