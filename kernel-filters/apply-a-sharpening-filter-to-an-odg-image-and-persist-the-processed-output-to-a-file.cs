using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Input ODG file path
        string inputPath = @"C:\temp\sample.odg";

        // Output ODG file path
        string outputPath = @"C:\temp\sample_sharpened.odg";

        // Load the ODG image using the unified Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to OdgImage to access ODG‑specific members
            OdgImage odgImage = (OdgImage)image;

            // Each page of an ODG file is a raster image; apply the sharpen filter to every page
            foreach (Image page in odgImage.Pages)
            {
                // Cast the page to RasterImage to use the Filter method
                RasterImage rasterPage = (RasterImage)page;

                // Apply a sharpen filter with kernel size 5 and sigma 4.0 to the whole page
                rasterPage.Filter(rasterPage.Bounds, new SharpenFilterOptions(5, 4.0));
            }

            // Save the processed ODG image to the specified output file
            odgImage.Save(outputPath);
        }
    }
}