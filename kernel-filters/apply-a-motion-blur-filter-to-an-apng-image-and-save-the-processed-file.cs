using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            ApngImage apng = (ApngImage)image;

            // Apply motion blur (motion wiener) filter to each frame
            for (int i = 0; i < apng.PageCount; i++)
            {
                // Each page is a frame; cast to RasterImage for filtering
                var frame = (RasterImage)apng.Pages[i];
                // Apply motion wiener filter (used here as motion blur)
                frame.Filter(frame.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));
            }

            // Save the processed APNG image
            apng.Save(outputPath, new ApngOptions());
        }
    }
}