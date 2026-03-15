using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class DeconvolutionExample
{
    static void Main()
    {
        // Path to the folder containing the EMF file
        string dataDir = @"c:\temp\";

        // Load the EMF image
        using (Image image = Image.Load(dataDir + "sample.emf"))
        {
            // Cast to RasterImage to gain access to the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Apply a Gauss‑Wiener deconvolution filter to the whole image
            // Parameters: radius = 5, sigma = 4.0 (adjust as needed)
            rasterImage.Filter(
                rasterImage.Bounds,
                new GaussWienerFilterOptions(5, 4.0));

            // Save the processed image as PNG
            rasterImage.Save(
                dataDir + "sample.GaussWienerFilter.png",
                new PngOptions());
        }
    }
}