using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class BradleyThresholdExample
{
    static void Main()
    {
        // Path to the source image
        string inputPath = @"c:\temp\sample.png";

        // Path for the binarized output image
        string outputPath = @"c:\temp\sample.Binarized.png";

        // Load the image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage which supports BinarizeBradley
            RasterImage rasterImage = (RasterImage)image;

            // Apply Bradley's adaptive thresholding
            // brightnessDifference: 5 (pixel vs. local average)
            // windowSize: 10 (10x10 pixel window)
            rasterImage.BinarizeBradley(5, 10);

            // Save the binarized image (default PNG format)
            rasterImage.Save(outputPath);
        }
    }
}