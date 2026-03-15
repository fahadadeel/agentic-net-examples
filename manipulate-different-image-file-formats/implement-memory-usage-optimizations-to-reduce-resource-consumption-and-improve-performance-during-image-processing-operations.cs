using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Pcx;
using Aspose.Imaging.FileFormats.Ico;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Pcx;
using Aspose.Imaging.FileFormats.Ico;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Pdf;

class MemoryOptimizedProcessing
{
    static void Main()
    {
        // Configure global cache settings to limit memory usage and improve performance
        Aspose.Imaging.Cache.CacheType = Aspose.Imaging.CacheType.Auto;          // Auto mode selects optimal caching strategy
        Aspose.Imaging.Cache.MaxMemoryForCache = 512;                           // Limit in-memory cache to 512 MB (0 = no limit)
        Aspose.Imaging.Cache.ExactReallocateOnly = false;                      // Allow non‑exact reallocation for faster operations

        // Define a buffer size hint (in megabytes) for internal buffers of the created image
        const int bufferHintMb = 50;                                            // 50 MB limit for internal buffers

        // Prepare image creation options (PNG in this example) with the buffer size hint
        var createOptions = new PngOptions
        {
            Source = new FileCreateSource(@"C:\Temp\OptimizedImage.png", false),
            BufferSizeHint = bufferHintMb
        };

        // Create a new image with the specified options and dimensions
        using (var image = Image.Create(createOptions, 2000, 2000) as RasterImage)
        {
            // Perform a series of graphics operations while staying within the memory limits
            var graphics = new Graphics(image);
            graphics.Clear(Color.LightSkyBlue);

            // Example: draw a grid of lines (complex but memory‑light)
            const int step = 20;
            for (int x = 0; x < image.Width; x += step)
            {
                graphics.DrawLine(new Pen(Color.Gray, 1f), x, 0, x, image.Height);
            }
            for (int y = 0; y < image.Height; y += step)
            {
                graphics.DrawLine(new Pen(Color.Gray, 1f), 0, y, image.Width, y);
            }

            // Example: resize the image to a smaller size to further reduce memory footprint
            image.Resize(1000, 1000);

            // Save the processed image using the same options (buffer hint is retained)
            image.Save();
        }

        // After processing, output current cache usage for diagnostics
        long allocatedMemory = Aspose.Imaging.Cache.AllocatedMemoryBytesCount;
        long allocatedDisk = Aspose.Imaging.Cache.AllocatedDiskBytesCount;
        Console.WriteLine($"Allocated Memory Cache: {allocatedMemory / (1024 * 1024)} MB");
        Console.WriteLine($"Allocated Disk Cache: {allocatedDisk / (1024 * 1024)} MB");
    }
}