using System;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

public class Program
{
    public static void Main(string[] args)
    {
        // Input and output file paths (use defaults if not provided)
        string inputPath = args.Length > 0 ? args[0] : "input.webp";
        string outputPath = args.Length > 1 ? args[1] : "output.webp";

        // Load the WebP image
        using (WebPImage webpImage = new WebPImage(inputPath))
        {
            // Apply a motion blur (motion Wiener) filter to the entire image
            // Parameters: length = 10, smooth = 1.0, angle = 45 degrees
            webpImage.Filter(
                webpImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 45.0));

            // Save the processed image back to WebP format
            webpImage.Save(outputPath, new WebPOptions());
        }
    }
}