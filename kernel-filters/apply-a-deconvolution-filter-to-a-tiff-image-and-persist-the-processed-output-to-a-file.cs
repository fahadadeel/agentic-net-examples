using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access TIFF-specific methods
            TiffImage tiffImage = (TiffImage)image;

            // Apply a Gauss-Wiener deconvolution filter to the entire image
            // Parameters: radius = 5, sigma = 4.0
            tiffImage.Filter(tiffImage.Bounds, new GaussWienerFilterOptions(5, 4.0));

            // Prepare TIFF save options
            TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Save the processed image
            tiffImage.Save(outputPath, saveOptions);
        }
    }
}