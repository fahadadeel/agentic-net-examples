using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class MultiFrameTiffProcessor
{
    static void Main()
    {
        // Path to the source multi‑frame TIFF file
        string sourcePath = @"C:\Images\source_multi.tif";

        // Path where the processed TIFF will be saved
        string destinationPath = @"C:\Images\preserved_multi.tif";

        // Load the existing TIFF image (multi‑frame) using Aspose.Imaging's load mechanism
        using (TiffImage tiffImage = (TiffImage)Image.Load(sourcePath))
        {
            // Iterate through each frame to demonstrate that frames are accessible
            // No modifications are performed to keep each frame's integrity intact
            for (int i = 0; i < tiffImage.Frames.Length; i++)
            {
                TiffFrame frame = tiffImage.Frames[i];
                // Example placeholder: you could read metadata or perform read‑only operations here
                Console.WriteLine($"Frame {i + 1}: {frame.Width}x{frame.Height} pixels");
            }

            // Save the TIFF image back to disk.
            // The Save method preserves all frames exactly as they were loaded.
            tiffImage.Save(destinationPath);
        }

        Console.WriteLine("Multi‑frame TIFF processing completed successfully.");
    }
}