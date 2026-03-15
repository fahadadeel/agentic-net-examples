using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class PngMemoryOptimization
{
    // Optimizes memory usage while processing a PNG image.
    public static void OptimizePng(string inputPath, string outputPath)
    {
        // Open the source file as a stream to avoid loading the whole file into memory at once.
        using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            // Load the image from the stream (Aspose.Imaging handles internal buffering).
            using (Image image = Image.Load(inputStream))
            {
                // Configure PNG save options for low memory footprint.
                PngOptions options = new PngOptions
                {
                    // Reduce color depth by using an indexed palette (max 256 colors).
                    ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.IndexedColor,
                    Palette = Aspose.Imaging.ColorPaletteHelper.GetCloseImagePalette(
                        (RasterImage)image, 256, Aspose.Imaging.PaletteMiningMethod.Histogram),

                    // Highest compression level (more CPU, less output size).
                    CompressionLevel = 9,

                    // Choose a fast filter that works well for many images.
                    FilterType = Aspose.Imaging.FileFormats.Png.PngFilterType.Sub,

                    // Enable progressive PNG to allow incremental decoding.
                    Progressive = true,

                    // Hint to limit internal buffer size (e.g., 4 MB) to cap peak memory usage.
                    BufferSizeHint = 4 * 1024 * 1024
                };

                // Save directly to a file stream to keep memory usage minimal.
                using (FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    image.Save(outputStream, options);
                }
            }
        }
    }

    // Sample entry point demonstrating the optimization.
    static void Main()
    {
        string inputFile = @"C:\temp\large_input.png";
        string outputFile = @"C:\temp\optimized_output.png";

        OptimizePng(inputFile, outputFile);
    }
}