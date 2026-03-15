using System.Drawing;                         // For Rectangle
using Aspose.Imaging;                           // Core imaging classes
using Aspose.Imaging.ImageOptions;               // For ApngOptions
using Aspose.Imaging.FileFormats.Apng;           // For ApngImage

class CropToApngExample
{
    static void Main()
    {
        // Load the source raster image (any format supported by Aspose.Imaging)
        using (Image sourceImage = Image.Load("input.png"))
        {
            // Define the area to keep (left, top, width, height)
            var cropArea = new Rectangle(50, 50, 200, 200);

            // Crop the image in‑place – this preserves all pixel data, including alpha channel
            sourceImage.Crop(cropArea);

            // Option 1: Directly save the cropped raster as an APNG file.
            // The ApngOptions object can be customized (e.g., frame duration, loop count).
            sourceImage.Save("cropped_direct.apng", new ApngOptions());

            // Option 2: Create an explicit ApngImage, add the cropped raster as a frame,
            // and then save. This gives full control over frame handling.
            var createOptions = new ApngOptions
            {
                // The file that will be created.
                Source = new FileCreateSource("cropped_explicit.apng", false),

                // Preserve transparency (Truecolor with Alpha).
                ColorType = PngColorType.TruecolorWithAlpha,

                // Default frame duration in milliseconds.
                DefaultFrameTime = 100
            };

            // Create an empty APNG canvas with the same dimensions as the cropped image.
            using (ApngImage apng = (ApngImage)Image.Create(
                       createOptions,
                       sourceImage.Width,
                       sourceImage.Height))
            {
                // The newly created APNG contains one default frame; remove it.
                apng.RemoveAllFrames();

                // Add the cropped raster as the sole frame of the animation.
                apng.AddFrame((RasterImage)sourceImage);

                // Save the APNG to the path specified in createOptions.Source.
                apng.Save();
            }
        }
    }
}