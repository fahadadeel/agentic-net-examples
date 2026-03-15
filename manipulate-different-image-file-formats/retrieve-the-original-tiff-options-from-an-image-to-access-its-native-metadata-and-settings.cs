using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.tif";
        string outputPath = "output_copy.tif";

        // Load the TIFF image
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // Retrieve the original saving options derived from the file
            ImageOptionsBase originalOptionsBase = tiffImage.GetOriginalOptions();

            // Cast to TiffOptions to access TIFF-specific properties
            TiffOptions originalOptions = originalOptionsBase as TiffOptions;
            if (originalOptions != null)
            {
                // Example: display some native metadata
                Console.WriteLine("BitsPerSample: " + string.Join(",", originalOptions.BitsPerSample));
                Console.WriteLine("Compression: " + originalOptions.Compression);
                Console.WriteLine("Photometric: " + originalOptions.Photometric);
                Console.WriteLine("Resolution (DPI): " + tiffImage.HorizontalResolution + "x" + tiffImage.VerticalResolution);
            }

            // Save a copy of the image using the retrieved original options
            tiffImage.Save(outputPath, originalOptions);
        }
    }
}