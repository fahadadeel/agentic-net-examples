using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        // Input GIF file path
        string inputPath = @"C:\temp\input.gif";
        // Output GIF file path
        string outputPath = @"C:\temp\output_blur.gif";

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to GifImage to access GIF-specific methods
            GifImage gif = (GifImage)image;

            // Apply Gaussian blur filter to the entire image
            // Parameters: radius = 5, sigma = 4.0
            gif.Filter(gif.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as GIF
            gif.Save(outputPath, new GifOptions());
        }
    }
}