using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Psd; // Namespace for PSD handling (if needed)

class ApplyMotionWienerFilter
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = @"c:\temp\sample.psd";
        string outputPath = @"c:\temp\sample.MotionWienerFilter.psd";

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering functionality
            RasterImage rasterImage = (RasterImage)image;

            // Create MotionWienerFilterOptions:
            // length = 10 (filter length), smooth = 1.0 (smoothing factor), angle = 90.0 degrees
            var motionWienerOptions = new MotionWienerFilterOptions(10, 1.0, 90.0);

            // Apply the filter to the entire image bounds
            rasterImage.Filter(rasterImage.Bounds, motionWienerOptions);

            // Save the processed image back to disk (preserves PSD format)
            rasterImage.Save(outputPath);
        }
    }
}