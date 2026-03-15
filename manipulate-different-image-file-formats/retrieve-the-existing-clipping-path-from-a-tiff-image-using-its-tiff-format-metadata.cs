using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;

class Program
{
    static void Main()
    {
        // Load the TIFF image from file
        using (var image = (TiffImage)Image.Load("Sample.tif"))
        {
            // Retrieve the collection of clipping paths stored in the TIFF metadata
            var paths = image.ActiveFrame.PathResources;

            // Check if any clipping paths exist
            if (paths == null || paths.Count == 0)
            {
                Console.WriteLine("No clipping paths found in the TIFF image.");
                return;
            }

            // Output the name of each clipping path
            foreach (var path in paths)
            {
                Console.WriteLine($"Clipping Path: {path.Name}");
            }
        }
    }
}