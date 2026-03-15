using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Ico;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Paths for the source ICO image and the processed result
        string inputPath = "input.ico";
        string outputPath = "output.ico";

        // Load the ICO image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Cast to IcoImage to access ICO‑specific functionality
            IcoImage ico = (IcoImage)image;

            // Apply a sharpen filter to the entire image area
            // Kernel size = 5, sigma = 4.0 (as in the documentation example)
            ico.Filter(ico.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image to a new file
            ico.Save(outputPath);
        }
    }
}