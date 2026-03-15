using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Folder containing the source images
        string inputFolder = @"C:\Images\Input";

        // Output file – the combined image will be saved here.
        // The format (e.g., .tif, .pdf) can be any supported by Aspose.Imaging.
        string outputPath = @"C:\Images\Output\combined.tif";

        // Gather all image files from the input folder.
        // Adjust the search pattern if you need to limit to specific formats.
        string[] imageFiles = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);

        // Create a multipage image that contains all the specified files.
        // This uses the Image.Create(string[]) overload, preserving each file's original format.
        using (Image combinedImage = Image.Create(imageFiles))
        {
            // Save the resulting multipage image to the desired location.
            combinedImage.Save(outputPath);
        }
    }
}