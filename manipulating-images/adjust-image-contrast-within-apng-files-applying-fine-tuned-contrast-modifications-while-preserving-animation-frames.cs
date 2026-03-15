using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Path to the source APNG file
        string inputPath = "input.apng";

        // Path where the adjusted APNG will be saved
        string outputPath = "output.apng";

        // Desired contrast adjustment (range: -100 to 100)
        float contrast = 30f;

        // Load the APNG image (all frames are loaded automatically)
        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            // Apply the contrast adjustment to the entire animation
            apng.AdjustContrast(contrast);

            // Save the modified APNG, preserving all original frames
            apng.Save(outputPath);
        }
    }
}