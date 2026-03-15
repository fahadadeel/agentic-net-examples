using System;
using System.Drawing; // For Rectangle
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class DeconvolutionExample
{
    static void Main()
    {
        // Paths for input ODG, temporary rasterized PNG, and final output
        string inputOdgPath = "sample.odg";
        string tempPngPath = "temp.png";
        string outputPath = "sample_deconvolution.png";

        // Load the ODG image and rasterize it by saving to PNG
        using (Image odgImage = Image.Load(inputOdgPath))
        {
            // Saving as PNG forces rasterization of the vector ODG content
            odgImage.Save(tempPngPath, new PngOptions());
        }

        // Load the rasterized PNG image
        using (Image rasterImage = Image.Load(tempPngPath))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage raster = (RasterImage)rasterImage;

            // Create deconvolution filter options (Gauss-Wiener filter in this case)
            // Parameters: radius = 5, sigma = 4.0
            var deconvOptions = new GaussWienerFilterOptions(5, 4.0)
            {
                // Optional: set additional properties
                Grayscale = false,   // Process in RGB mode
                Brightness = 1.15,   // Default brightness
                Snr = 0.007           // Default signal‑to‑noise ratio
            };

            // Apply the filter to the entire image bounds
            raster.Filter(raster.Bounds, deconvOptions);

            // Save the processed image to the desired output file
            raster.Save(outputPath, new PngOptions());
        }

        Console.WriteLine("Deconvolution filter applied and saved to: " + outputPath);
    }
}