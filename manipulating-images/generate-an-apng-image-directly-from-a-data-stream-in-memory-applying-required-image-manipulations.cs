using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png; // for PngColorType

// Example input raster image data (replace with actual image bytes)
byte[] inputImageData = File.ReadAllBytes("not_animated.png");

// Load the source raster image from a memory stream
using (var inputStream = new MemoryStream(inputImageData))
using (RasterImage sourceImage = (RasterImage)Image.Load(inputStream))
{
    // Configure APNG creation options
    ApngOptions createOptions = new ApngOptions
    {
        // Default duration for each frame (in milliseconds)
        DefaultFrameTime = 70,
        // Use truecolor with alpha to preserve transparency
        ColorType = PngColorType.TruecolorWithAlpha
        // No Source is set because we will save to a memory stream later
    };

    // Create an empty APNG image with the same dimensions as the source
    using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
    {
        // Remove the automatically added first frame
        apngImage.RemoveAllFrames();

        // Add the first frame (the original image)
        apngImage.AddFrame(sourceImage);

        // Define animation parameters
        const int animationDurationMs = 1000; // total animation length
        const int frameDurationMs = 70;       // duration per frame
        int totalFrames = animationDurationMs / frameDurationMs;
        int halfFrames = totalFrames / 2;

        // Add intermediate frames and apply a gamma adjustment to each
        for (int i = 1; i < totalFrames - 1; ++i)
        {
            apngImage.AddFrame(sourceImage);
            ApngFrame lastFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
            float gamma = i >= halfFrames ? totalFrames - i - 1 : i;
            lastFrame.AdjustGamma(gamma);
        }

        // Add the final frame
        apngImage.AddFrame(sourceImage);

        // Save the APNG to a memory stream
        using (var outputStream = new MemoryStream())
        {
            apngImage.Save(outputStream);
            // The APNG data is now available in outputStream
            byte[] apngData = outputStream.ToArray();

            // Example: write the APNG to a file (optional)
            File.WriteAllBytes("output_animation.png", apngData);
        }
    }
}