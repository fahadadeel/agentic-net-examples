using System;
using System.IO;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Path to the TIFF file to be loaded
        string inputPath = "input.tif";

        // Load the TIFF file into a TiffFrame.
        // The TiffFrame constructor that accepts a file path reads the image data
        // using Aspose.Imaging's native TIFF handling.
        TiffFrame frame = new TiffFrame(inputPath);

        // Create a TiffImage from the loaded frame.
        // This wraps the frame in a multipage TIFF image object.
        using (TiffImage tiffImage = new TiffImage(frame))
        {
            // Example usage: output basic image information.
            Console.WriteLine($"Width: {tiffImage.Width}");
            Console.WriteLine($"Height: {tiffImage.Height}");
            Console.WriteLine($"Page count: {tiffImage.PageCount}");

            // Optionally, save the loaded image to verify that it was read correctly.
            // The Save method uses the native TIFF writer internally.
            tiffImage.Save("output_copy.tif");
        }
    }
}