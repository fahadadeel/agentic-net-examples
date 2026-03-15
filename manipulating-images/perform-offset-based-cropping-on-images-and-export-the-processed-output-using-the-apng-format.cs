using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input raster image and output APNG file paths
        string inputPath = "input.png";
        string outputPath = "output.apng";

        // Cropping offsets: left, right, top, bottom
        int leftShift = 10;
        int rightShift = 10;
        int topShift = 20;
        int bottomShift = 20;

        // Load the source image as a raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Cache data for better performance
            if (!sourceImage.IsCached)
                sourceImage.CacheData();

            // Perform offset-based cropping
            sourceImage.Crop(leftShift, rightShift, topShift, bottomShift);

            // Configure APNG creation options
            ApngOptions options = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // frame duration in milliseconds
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create an APNG image with the cropped dimensions
            using (ApngImage apngImage = (ApngImage)Image.Create(options, sourceImage.Width, sourceImage.Height))
            {
                // Remove the default empty frame
                apngImage.RemoveAllFrames();

                // Add the cropped raster image as a single frame
                apngImage.AddFrame(sourceImage);

                // Save the APNG file (output is bound to the FileCreateSource)
                apngImage.Save();
            }
        }
    }
}