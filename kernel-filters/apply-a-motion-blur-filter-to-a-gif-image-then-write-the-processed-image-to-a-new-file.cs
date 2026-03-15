using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.gif";
        string outputPath = "output_motion_blur.gif";

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to GifImage to access GIF-specific methods
            GifImage gif = (GifImage)image;

            // Apply a motion Wiener (motion blur) filter to the entire image
            // Parameters: length = 10, smooth = 1.0, angle = 90.0 degrees
            gif.Filter(gif.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the processed GIF using default GifOptions
            gif.Save(outputPath, new GifOptions());
        }
    }
}