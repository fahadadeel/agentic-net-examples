using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class TiffFrameExtractor
{
    static void Main()
    {
        // Path to the multi‑page TIFF file
        string sourcePath = @"C:\Images\multiframe.tif";

        // Directory where individual frames will be saved
        string outputDir = @"C:\Images\Frames";
        Directory.CreateDirectory(outputDir);

        // Load the multi‑page TIFF using the provided Image.Load method
        using (TiffImage multiPage = Image.Load(sourcePath) as TiffImage)
        {
            if (multiPage == null)
                throw new InvalidOperationException("The file is not a valid TIFF image.");

            // Iterate through each frame in the TIFF
            for (int i = 0; i < multiPage.Frames.Length; i++)
            {
                // Create a new TiffImage that contains only the current frame
                using (TiffImage singleFrame = new TiffImage(multiPage.Frames[i]))
                {
                    // Build the output file name (e.g., page_1.tif, page_2.tif, ...)
                    string outPath = Path.Combine(outputDir, $"page_{i + 1}.tif");

                    // Save the single‑frame TIFF using the provided Save(string) method
                    singleFrame.Save(outPath);
                }
            }
        }
    }
}