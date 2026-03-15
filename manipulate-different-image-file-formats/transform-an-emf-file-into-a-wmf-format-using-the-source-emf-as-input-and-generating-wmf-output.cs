using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source EMF file
        string inputFile = @"C:\Temp\source.emf";

        // Desired output WMF file path
        string outputFile = @"C:\Temp\converted.wmf";

        // Load the EMF image using the unified Image.Load method
        using (Image image = Image.Load(inputFile))
        {
            // Prepare vector rasterization options for WMF output.
            // PageSize is set to the original image size to preserve dimensions.
            var wmfRasterOptions = new WmfRasterizationOptions
            {
                PageSize = image.Size
            };

            // Save the loaded image as WMF using WmfOptions.
            // The VectorRasterizationOptions property tells Aspose.Imaging how to render the vector data.
            image.Save(outputFile, new WmfOptions { VectorRasterizationOptions = wmfRasterOptions });
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}