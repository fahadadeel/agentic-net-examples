using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class BackgroundRemovalToApng
{
    static void Main()
    {
        // Input vector graphic (SVG) and output APNG file paths
        string inputVectorPath = "input.svg";
        string outputApngPath = "output.apng";

        // Load the vector image (SVG) using the unified Image.Load method
        using (Image vectorImage = Image.Load(inputVectorPath))
        {
            // Cast to VectorImage to access vector‑specific functionality
            var vector = (VectorImage)vectorImage;

            // Remove the background from the vector graphic
            vector.RemoveBackground();

            // Prepare rasterization options to convert the vector image to a raster PNG
            var pngOptions = new PngOptions();
            var svgRasterOptions = new SvgRasterizationOptions
            {
                PageSize = vector.Size,                     // Preserve original size
                BackgroundColor = Aspose.Imaging.Color.Transparent // Keep transparency after background removal
            };
            pngOptions.VectorRasterizationOptions = svgRasterOptions;

            // Rasterize the vector image into a memory stream (PNG format)
            using (var rasterStream = new MemoryStream())
            {
                vector.Save(rasterStream, pngOptions);
                rasterStream.Position = 0; // Reset stream position for reading

                // Load the rasterized PNG as a RasterImage
                using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                {
                    // Create APNG image with desired options
                    var apngCreateOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputApngPath, false), // Output file
                        DefaultFrameTime = 100, // Frame duration in milliseconds (single frame)
                        ColorType = PngColorType.TruecolorWithAlpha // Preserve alpha channel
                    };

                    // Use Image.Create to instantiate an ApngImage with the same dimensions as the raster image
                    using (ApngImage apngImage = (ApngImage)Image.Create(apngCreateOptions, rasterImage.Width, rasterImage.Height))
                    {
                        // Remove the automatically added default frame
                        apngImage.RemoveAllFrames();

                        // Add the raster image as the sole frame of the APNG
                        apngImage.AddFrame(rasterImage);

                        // Save the APNG to the specified file
                        apngImage.Save();
                    }
                }
            }
        }
    }
}