using System;
using System.Drawing; // For Rectangle
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class MotionBlurDngExample
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = @"C:\Temp\sample.dng";
        string outputPath = @"C:\Temp\sample_motionblur.png";

        // Load the DNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DngImage to access DNG‑specific members
            DngImage dngImage = (DngImage)image;

            // Apply a motion blur (motion wiener) filter to the whole image.
            // Parameters: length = 10, smooth = 1.0, angle = 0 degrees.
            dngImage.Filter(
                dngImage.Bounds,
                new MotionWienerFilterOptions(10, 1.0, 0.0));

            // Save the processed image (as PNG for easy viewing)
            dngImage.Save(outputPath, new PngOptions());
        }
    }
}