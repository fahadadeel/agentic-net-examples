using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg; // Example format, adjust as needed
using Aspose.Imaging.ImageOptions;

class ImageCorrectionExample
{
    static void Main()
    {
        // Paths to the source and destination images
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Load the image using Aspose.Imaging's built‑in load method
        // The Load method returns an Image object; cast to RasterImage to access adjustment methods
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Increase contrast (value range: -100 to 100)
            image.AdjustContrast(30f); // +30 makes details stand out

            // Increase brightness (integer value, typical range: -255 to 255)
            image.AdjustBrightness(20); // +20 brightens the image

            // Adjust color balance via gamma correction per channel
            // Values >1 brighten the channel, <1 darken it
            image.AdjustGamma(1.1f, 1.0f, 0.9f); // Slightly boost Red, keep Green, reduce Blue

            // Save the processed image using Aspose.Imaging's save method
            image.Save(outputPath);
        }
    }
}