using System;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Expect the image file path as the first argument.
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the image file path as an argument.");
            return;
        }

        string inputPath = args[0];

        // Load the image using Aspose.Imaging. The Image class is the base for all formats.
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the GetModifyDate method.
            RasterImage raster = (RasterImage)image;

            // Retrieve the last modified timestamp.
            // The 'true' argument tells the method to fall back to FileInfo if metadata is missing.
            DateTime modifyDate = raster.GetModifyDate(true);

            Console.WriteLine($"Last modified timestamp: {modifyDate}");
        }
    }
}