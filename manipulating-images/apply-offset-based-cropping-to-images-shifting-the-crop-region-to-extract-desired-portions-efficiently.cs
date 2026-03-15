using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string dir = @"c:\temp\";
        string inputPath = System.IO.Path.Combine(dir, "input.png");
        string outputPath = System.IO.Path.Combine(dir, "output.Crop.png");

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Offset values: how many pixels to trim from each side
            int leftShift = 30;   // trim 30 pixels from the left edge
            int rightShift = 30;  // trim 30 pixels from the right edge
            int topShift = 20;    // trim 20 pixels from the top edge
            int bottomShift = 20; // trim 20 pixels from the bottom edge

            // Apply cropping using the shift-based overload
            image.Crop(leftShift, rightShift, topShift, bottomShift);

            // Save the cropped image as PNG
            image.Save(outputPath, new PngOptions());
        }
    }
}