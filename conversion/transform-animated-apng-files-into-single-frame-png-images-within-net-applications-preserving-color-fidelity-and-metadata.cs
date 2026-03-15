using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;

class ApngToPngConverter
{
    static void Main()
    {
        // Path to the animated APNG file
        string inputApngPath = "animation.apng";

        // Path for the resulting single‑frame PNG file
        string outputPngPath = "single_frame.png";

        // Load the APNG image using the standard Image.Load method
        using (Image loadedImage = Image.Load(inputApngPath))
        {
            // Cast the loaded image to ApngImage to access frame collection
            ApngImage apngImage = loadedImage as ApngImage;
            if (apngImage == null || apngImage.PageCount == 0)
                throw new InvalidOperationException("The file does not contain any APNG frames.");

            // The first frame (index 0) is the default image shown by decoders that do not support APNG
            // Retrieve it as a RasterImage for saving
            using (RasterImage firstFrame = (RasterImage)apngImage.Pages[0])
            {
                // Prepare PNG save options – keep original metadata and use default compression
                PngOptions pngOptions = new PngOptions
                {
                    // Preserve EXIF/XMP metadata from the source APNG
                    KeepMetadata = true
                };

                // Save the single frame as a regular PNG file
                firstFrame.Save(outputPngPath, pngOptions);
            }
        }
    }
}