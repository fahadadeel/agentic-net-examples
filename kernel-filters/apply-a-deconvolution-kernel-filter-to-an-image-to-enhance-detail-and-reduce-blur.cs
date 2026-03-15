using System;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = args.Length > 0 ? args[0] : "input.jpg";
        string outputPath = args.Length > 1 ? args[1] : "output.jpg";

        // Load the image as a raster image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

            // Apply Gauss-Wiener deconvolution filter to enhance details and reduce blur
            // Parameters: radius = 5, sigma = 4.0 (adjust as needed)
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0));

            // Save the processed image
            raster.Save(outputPath);
        }
    }
}