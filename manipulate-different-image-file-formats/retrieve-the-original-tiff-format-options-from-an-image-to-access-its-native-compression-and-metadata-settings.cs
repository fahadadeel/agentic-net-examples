using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Input TIFF file path (first argument or default)
        string inputPath = args.Length > 0 ? args[0] : "input.tif";

        // Load the TIFF image
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // Retrieve original saving options from the loaded image
            TiffOptions originalOptions = tiffImage.GetOriginalOptions() as TiffOptions;

            if (originalOptions != null)
            {
                // Output native compression
                Console.WriteLine("Original Compression: " + originalOptions.Compression);

                // Output bits per sample (e.g., [8,8,8] for RGB)
                if (originalOptions.BitsPerSample != null)
                {
                    Console.WriteLine("Bits Per Sample: " + string.Join(", ", originalOptions.BitsPerSample));
                }

                // Output photometric interpretation
                Console.WriteLine("Photometric: " + originalOptions.Photometric);
            }
            else
            {
                Console.WriteLine("Failed to retrieve original TIFF options.");
            }
        }
    }
}