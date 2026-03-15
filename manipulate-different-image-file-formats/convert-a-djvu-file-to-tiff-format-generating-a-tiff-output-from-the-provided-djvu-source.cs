using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input DjVu file and output TIFF file
        string inputPath = "input.djvu";
        string outputPath = "output.tif";

        // Open the DjVu file as a stream
        using (Stream stream = File.OpenRead(inputPath))
        {
            // Load the DjVu image from the stream
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Configure TIFF save options (default format)
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                // Export all pages of the DjVu document to the TIFF
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions();

                // Save the DjVu image as a multi-page TIFF
                djvuImage.Save(outputPath, tiffOptions);
            }
        }
    }
}