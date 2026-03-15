using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Define the folder containing the images.
        string dir = @"c:\temp\";

        // Load the PNG image from a file using the provided constructor.
        using (PngImage pngImage = new PngImage(dir + "input.png"))
        {
            // Apply a Gaussian blur filter to the entire image.
            // Radius = 5, Sigma = 4.0 (adjust as needed).
            pngImage.Filter(pngImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image back to storage using the provided Save method.
            pngImage.Save(dir + "output.png");
        }
    }
}