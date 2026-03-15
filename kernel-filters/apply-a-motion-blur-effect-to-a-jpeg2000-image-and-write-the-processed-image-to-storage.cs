using System;
using System.Drawing; // For Rectangle
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class MotionBlurExample
{
    static void Main()
    {
        // Path to the source JPEG2000 image
        string inputPath = @"C:\Images\source.jp2";

        // Path where the processed image will be saved
        string outputPath = @"C:\Images\motion_blur.jp2";

        // Load the JPEG2000 image using Aspose.Imaging's load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Define motion blur parameters:
            // length  – length of the motion blur kernel
            // smooth  – smoothing factor
            // angle   – direction of motion in degrees
            int length = 10;          // example length
            double smooth = 1.0;      // example smoothing factor
            double angle = 45.0;      // example angle (45 degrees)

            // Apply the motion Wiener filter (acts as a motion blur) to the whole image
            rasterImage.Filter(
                rasterImage.Bounds,
                new MotionWienerFilterOptions(length, smooth, angle));

            // Save the processed image back to JPEG2000 format using appropriate save options
            var saveOptions = new Jpeg2000Options(); // default options; customize if needed
            rasterImage.Save(outputPath, saveOptions);
        }
    }
}