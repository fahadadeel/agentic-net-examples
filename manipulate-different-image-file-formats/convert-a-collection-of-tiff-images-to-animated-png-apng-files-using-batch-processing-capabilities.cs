using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class TiffToApngBatchConverter
{
    // Folder containing source TIFF files
    private const string SourceFolder = @"C:\Images\TiffSource";

    // Folder where the resulting APNG files will be saved
    private const string OutputFolder = @"C:\Images\ApngOutput";

    // Default duration for each frame in milliseconds
    private const uint DefaultFrameDuration = 500; // 0.5 seconds

    static void Main()
    {
        // Ensure the output directory exists
        Directory.CreateDirectory(OutputFolder);

        // Get all TIFF files in the source folder (including subfolders if needed)
        string[] tiffFiles = Directory.GetFiles(SourceFolder, "*.tif", SearchOption.TopDirectoryOnly);

        foreach (string tiffPath in tiffFiles)
        {
            // Build the output file name (same name with .png extension)
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(tiffPath);
            string apngPath = Path.Combine(OutputFolder, fileNameWithoutExt + ".png");

            // Load the TIFF image (multi‑page TIFF is supported)
            using (Image tiffImage = Image.Load(tiffPath))
            {
                // Save as APNG using ApngOptions.
                // The ApngOptions class inherits from PngOptions and allows us to set
                // the default frame time and other animation parameters.
                var apngOptions = new ApngOptions
                {
                    DefaultFrameTime = DefaultFrameDuration,
                    // NumPlays = 0; // 0 means infinite looping (default)
                };

                // Export the TIFF (all its pages/frames) to an animated PNG.
                tiffImage.Save(apngPath, apngOptions);
            }

            Console.WriteLine($"Converted '{tiffPath}' to '{apngPath}'.");
        }

        Console.WriteLine("Batch conversion completed.");
    }
}