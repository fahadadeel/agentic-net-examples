using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Input and output ODG file paths
        string inputPath = "input.odg";
        string outputPath = "output.odg";

        // Load the ODG image using the unified Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to OdgImage to access its pages
            OdgImage odgImage = (OdgImage)image;

            // Iterate through each page (each page is a raster image)
            foreach (Image page in odgImage.Pages)
            {
                // Cast the page to RasterImage to apply raster filters
                RasterImage rasterPage = (RasterImage)page;

                // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole page
                rasterPage.Filter(
                    rasterPage.Bounds,
                    new GaussianBlurFilterOptions(5, 4.0));
            }

            // Save the processed ODG image to the specified output file
            odgImage.Save(outputPath);
        }
    }
}