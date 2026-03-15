using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source DNG file
        string inputPath = "input.dng";

        // Load the DNG image
        using (Image image = Image.Load(inputPath))
        {
            DngImage dng = (DngImage)image;

            // Ensure image data is cached before processing
            if (!dng.IsCached)
                dng.CacheData();

            // Apply adjustments
            dng.AdjustBrightness(20);               // Increase brightness
            dng.AdjustContrast(0.2f);               // Increase contrast
            dng.AdjustGamma(1.1f);                  // Gamma correction

            // Rotate the image by 5 degrees, resizing canvas and filling background with light gray
            dng.Rotate(5f, true, Color.LightGray);

            // Save changes back to the original DNG file, preserving native format
            dng.Save();
        }
    }
}