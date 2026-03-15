using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input folder containing source images
        string inputFolder = args.Length > 0 ? args[0] : "InputImages";
        // Output APNG file path
        string outputPath = args.Length > 1 ? args[1] : "output_animation.apng";

        // Collect image file paths (supported formats) and sort to preserve order
        var imageFiles = new List<string>();
        foreach (var file in Directory.GetFiles(inputFolder))
        {
            string ext = Path.GetExtension(file).ToLowerInvariant();
            if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".bmp" || ext == ".tif" || ext == ".tiff")
                imageFiles.Add(file);
        }
        imageFiles.Sort();

        if (imageFiles.Count == 0)
        {
            Console.WriteLine("No source images found.");
            return;
        }

        // Load the first image to obtain canvas size
        using (RasterImage firstImage = (RasterImage)Image.Load(imageFiles[0]))
        {
            int width = firstImage.Width;
            int height = firstImage.Height;

            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // default frame duration in milliseconds
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create APNG image with the specified size
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, width, height))
            {
                // Remove the default empty frame
                apngImage.RemoveAllFrames();

                // Add each source image as a frame
                foreach (string filePath in imageFiles)
                {
                    using (RasterImage frame = (RasterImage)Image.Load(filePath))
                    {
                        // Ensure frame size matches canvas; resize if necessary
                        if (frame.Width != width || frame.Height != height)
                        {
                            frame.Resize(width, height, ResizeType.NearestNeighbourResample);
                        }
                        apngImage.AddFrame(frame);
                    }
                }

                // Save the animated PNG (output is already bound to the source)
                apngImage.Save();
            }
        }
    }
}