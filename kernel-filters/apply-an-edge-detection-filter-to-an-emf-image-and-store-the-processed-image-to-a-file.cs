using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Filters;

class Program
{
    static void Main()
    {
        // Path to the source EMF image
        string inputPath = @"C:\Images\source.emf";

        // Path where the processed image will be saved
        string outputPath = @"C:\Images\edge_detected.emf";

        // Load the EMF image using Aspose.Imaging's unified loader
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to EmfImage to access EMF‑specific members
            EmfImage emfImage = (EmfImage)image;

            // Apply an edge detection filter to the whole image area
            // EdgeDetectionFilterOptions uses default parameters; customize if needed
            emfImage.Filter(emfImage.Bounds, new EdgeDetectionFilterOptions());

            // Save the processed image back to EMF format
            emfImage.Save(outputPath);
        }
    }
}