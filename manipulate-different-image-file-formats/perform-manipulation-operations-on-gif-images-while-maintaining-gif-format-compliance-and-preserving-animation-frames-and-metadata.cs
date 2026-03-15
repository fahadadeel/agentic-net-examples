using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class GifManipulation
{
    static void Main()
    {
        // Paths for input and output GIF files
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        // Load the existing GIF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to GifImage to access GIF‑specific functionality
            GifImage gif = image as GifImage;
            if (gif == null)
                throw new InvalidOperationException("The loaded file is not a GIF image.");

            // Preserve original metadata (Exif and XMP) before modifications
            var originalExif = gif.ExifData;
            var originalXmp = gif.XmpData;

            // Example operation: resize the whole animation using full‑frame resizing
            int newWidth = gif.Width / 2;   // halve the width
            int newHeight = gif.Height / 2; // halve the height
            gif.ResizeFullFrame(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            // Example operation: adjust brightness uniformly across all frames
            gif.AdjustBrightness(20); // increase brightness by 20 units

            // Restore metadata (if any changes cleared them)
            gif.ExifData = originalExif;
            gif.XmpData = originalXmp;

            // Prepare save options to keep GIF‑specific settings and metadata
            GifOptions saveOptions = new GifOptions
            {
                KeepMetadata = true,                     // retain original metadata
                LoopsCount = gif.LoopsCount,             // preserve loop count
                BackgroundColor = gif.BackgroundColor,   // preserve background color
                FullFrame = true                         // ensure full‑frame handling on save
            };

            // Save the modified GIF while maintaining format compliance
            gif.Save(outputPath, saveOptions);
        }
    }
}