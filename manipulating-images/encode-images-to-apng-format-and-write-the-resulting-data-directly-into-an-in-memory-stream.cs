using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class ApngEncoder
{
    // Encodes a single raster image into an animated PNG (APNG) with multiple identical frames.
    // The resulting APNG data is written into an in‑memory stream and returned.
    public static MemoryStream EncodeToApng(string sourceImagePath, int frameCount, uint frameDurationMs)
    {
        // Load the source raster image (any format supported by Aspose.Imaging)
        using (RasterImage source = (RasterImage)Image.Load(sourceImagePath))
        {
            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                // Set the default duration for each frame (in milliseconds)
                DefaultFrameTime = frameDurationMs,
                // Use truecolor with alpha to preserve full color information
                ColorType = PngColorType.TruecolorWithAlpha
                // No Source is set – the image will be created in memory
            };

            // Create an empty APNG image with the same dimensions as the source
            using (ApngImage apng = (ApngImage)Image.Create(createOptions, source.Width, source.Height))
            {
                // Remove the default single frame that exists after creation
                apng.RemoveAllFrames();

                // Add the desired number of frames, reusing the same source image
                for (int i = 0; i < frameCount; i++)
                {
                    // Each added frame inherits the DefaultFrameTime set in createOptions
                    apng.AddFrame(source);
                }

                // Prepare an in‑memory stream to receive the encoded APNG data
                MemoryStream outputStream = new MemoryStream();

                // Save the APNG image directly into the stream using the same options
                apng.Save(outputStream, createOptions);

                // Reset the stream position so it can be read from the beginning by the caller
                outputStream.Position = 0;
                return outputStream;
            }
        }
    }

    // Example usage
    static void Main()
    {
        // Path to a non‑animated source image
        string inputPath = "input.png";

        // Encode to APNG with 10 frames, each lasting 100 ms
        using (MemoryStream apngData = EncodeToApng(inputPath, 10, 100))
        {
            // The APNG bytes are now available in apngData.
            // For demonstration, write them to a file (optional).
            File.WriteAllBytes("output.apng", apngData.ToArray());
        }
    }
}