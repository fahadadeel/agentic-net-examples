using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input TIFF file paths (replace with actual paths or obtain from args)
        string[] inputPaths = new string[]
        {
            "input1.tif",
            "input2.tif",
            "input3.tif"
        };

        // Output combined TIFF file path
        string outputPath = "combined.tif";

        // Collect frames from each input TIFF stream
        List<TiffFrame> frames = new List<TiffFrame>();
        foreach (string path in inputPaths)
        {
            // Open the source file as a stream
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                // Create a TiffFrame from the stream (preserves metadata)
                TiffFrame frame = new TiffFrame(stream);
                frames.Add(frame);
            }
        }

        if (frames.Count == 0)
        {
            Console.WriteLine("No input TIFF files were provided.");
            return;
        }

        // Configure output TIFF options
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
        {
            Source = new FileCreateSource(outputPath, false)
        };

        // Create the output TIFF image using the first frame
        using (TiffImage tiffImage = new TiffImage(frames[0]))
        {
            // Add remaining frames
            for (int i = 1; i < frames.Count; i++)
            {
                tiffImage.AddFrame(frames[i]);
            }

            // Save the combined TIFF (metadata from each frame is retained)
            tiffImage.Save();
        }

        Console.WriteLine($"Combined TIFF saved to: {outputPath}");
    }
}