using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

class MotionBlurTiff
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = @"c:\temp\sample.tif";
        string outputPath = @"c:\temp\sample.MotionWienerFilter.tif";

        // Load the TIFF image using Aspose.Imaging's Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to TiffImage to access TIFF-specific functionality
            TiffImage tiffImage = (TiffImage)image;

            // Apply a motion blur (motion wiener) filter to the entire image.
            // Parameters: length = 10, smooth = 1.0, angle = 90.0 degrees
            tiffImage.Filter(
                tiffImage.Bounds,
                new MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the processed image to the specified output file
            tiffImage.Save(outputPath);
        }
    }
}