using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source APNG file
        string inputPath = @"C:\Images\input.apng";

        // Path where the manipulated APNG will be saved
        string outputPath = @"C:\Images\output.apng";

        // Load the APNG image from the file system
        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            // Iterate through all frames (pages) of the animation
            foreach (var page in apng.Pages)
            {
                // Each page is an ApngFrame; cast it to access frame-specific methods
                ApngFrame frame = (ApngFrame)page;

                // Example manipulation: increase brightness by 30 units
                frame.AdjustBrightness(30);

                // Example manipulation: convert the frame to grayscale
                frame.Grayscale();
            }

            // Example manipulation on the whole animation: resize to 200x200 pixels
            apng.Resize(200, 200);

            // Save the modified APNG back to the file system
            apng.Save(outputPath);
        }
    }
}