using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source image (blurred image)
        string inputPath = @"C:\Temp\blurred_image.png";

        // Path where the restored image will be saved
        string outputPath = @"C:\Temp\restored_image.png";

        // Load the image using Aspose.Imaging's Load method (lifecycle rule)
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Define deconvolution filter options.
            // GaussWienerFilterOptions implements GaussianDeconvolutionFilterOptions,
            // which is a subclass of DeconvolutionFilterOptions.
            // Adjust radius and sigma as needed for the specific blur characteristics.
            int radius = 5;          // size of the Gaussian kernel
            double sigma = 4.0;      // standard deviation of the Gaussian kernel

            var deconvOptions = new GaussWienerFilterOptions(radius, sigma)
            {
                // Optional: tweak brightness and signal‑to‑noise ratio for better results
                Brightness = 1.15,   // default recommended value
                Snr = 0.007          // default recommended value
            };

            // Apply the deconvolution filter to the entire image bounds
            rasterImage.Filter(rasterImage.Bounds, deconvOptions);

            // Save the processed image using the Save method (lifecycle rule)
            rasterImage.Save(outputPath, new PngOptions());
        }
    }
}