using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Path to the source image (any supported format)
        string inputPath = @"C:\Images\input.jpg";

        // Desired output PSD file path
        string outputPath = @"C:\Images\output.psd";

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PSD saving options to preserve image fidelity
            PsdOptions psdOptions = new PsdOptions
            {
                // No compression – keeps raw pixel data
                CompressionMethod = CompressionMethod.Raw,

                // Preserve color information; most images use RGB
                ColorMode = ColorModes.Rgb,

                // Standard 8 bits per channel
                ChannelBitsCount = 8,

                // Number of channels (RGBA = 4, RGB = 3). Here we assume 4 for maximum compatibility.
                ChannelsCount = 4,

                // Keep original metadata (EXIF, XMP, etc.)
                KeepMetadata = true
            };

            // Save the image as a PSD file using the configured options
            image.Save(outputPath, psdOptions);
        }
    }
}