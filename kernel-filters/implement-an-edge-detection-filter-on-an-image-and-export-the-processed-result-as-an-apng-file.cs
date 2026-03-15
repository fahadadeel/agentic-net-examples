using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Input and output paths (can be overridden via command‑line arguments)
        string inputPath = "input.png";
        string outputPath = "output.apng";

        if (args.Length > 0) inputPath = args[0];
        if (args.Length > 1) outputPath = args[1];

        // Load the source image as a raster image
        using (RasterImage source = (RasterImage)Image.Load(inputPath))
        {
            // Edge detection kernel (simple Laplacian)
            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            // Apply convolution filter with the edge detection kernel
            var filterOptions = new ConvolutionFilterOptions(kernel);
            source.Filter(source.Bounds, filterOptions);

            // Configure APNG creation options
            ApngOptions apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 1000, // 1 second per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create an APNG canvas matching the processed image size
            using (ApngImage apng = (ApngImage)Image.Create(apngOptions, source.Width, source.Height))
            {
                // Remove the default empty frame
                apng.RemoveAllFrames();

                // Add the processed image as the sole frame
                apng.AddFrame(source);

                // Save the APNG file
                apng.Save();
            }
        }
    }
}