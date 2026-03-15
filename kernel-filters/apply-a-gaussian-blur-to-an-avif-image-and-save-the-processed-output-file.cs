using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Avif;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = @"C:\Temp\input.avif";
        string outputPath = @"C:\Temp\output.avif";

        // Load the AVIF image using Aspose.Imaging's Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to AvifImage to access AVIF‑specific features
            AvifImage avif = (AvifImage)image;

            // Define Gaussian blur parameters: radius = 5, sigma = 4.0
            var blurOptions = new GaussianBlurFilterOptions(5, 4.0);

            // Apply the Gaussian blur filter to the whole image bounds
            avif.Filter(avif.Bounds, blurOptions);

            // Save the processed image back to AVIF format
            avif.Save(outputPath);
        }
    }
}