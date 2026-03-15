using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class ConfigureJpegExample
{
    static void Main()
    {
        // Define input and output file paths
        string dataDir = @"c:\temp\";
        string inputPath = Path.Combine(dataDir, "input.png");
        string outputPath = Path.Combine(dataDir, "output.jpg");

        // Create JPEG options and configure color model and compression algorithm
        JpegOptions jpegOptions = new JpegOptions();

        // Set the desired compression type (e.g., Progressive JPEG)
        jpegOptions.CompressionType = JpegCompressionMode.Progressive;

        // Set the desired color model (e.g., YCbCr – standard JPEG color space)
        jpegOptions.ColorType = JpegCompressionColorMode.YCbCr;

        // Optional: set additional common JPEG parameters
        jpegOptions.Quality = 90;                     // Quality range: 1‑100
        jpegOptions.BitsPerChannel = 8;               // 8 bits per channel
        jpegOptions.ResolutionSettings = new ResolutionSetting(96.0, 96.0);
        jpegOptions.ResolutionUnit = ResolutionUnit.Inch;

        // Load the source image using the standard load rule
        using (Image image = Image.Load(inputPath))
        {
            // Save the image with the configured JPEG options using the standard save rule
            image.Save(outputPath, jpegOptions);
        }

        Console.WriteLine("Image saved with configured JPEG settings to: " + outputPath);
    }
}