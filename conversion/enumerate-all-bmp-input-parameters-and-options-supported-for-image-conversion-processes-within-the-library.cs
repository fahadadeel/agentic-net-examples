using System;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // BMP Options (BmpOptions) supported properties
        List<string> bmpOptionsProperties = new List<string>
        {
            "BitsPerPixel (int) – Image bits per pixel count.",
            "BufferSizeHint (int) – Maximum allowed size for internal buffers.",
            "Compression (BitmapCompression) – Compression type (e.g., Bitfields, Rgb, Rle8).",
            "Disposed (bool) – Indicates whether the instance is disposed (read‑only).",
            "ExifData (IExifData) – EXIF metadata container.",
            "FullFrame (bool) – Indicates full‑frame processing.",
            "KeepMetadata (bool) – Preserve original metadata on export.",
            "MultiPageOptions (MultiPageOptions) – Options for multi‑page export.",
            "Palette (IColorPalette) – Color palette for palettized images.",
            "ProgressEventHandler (ProgressEventHandler) – Progress callback.",
            "ResolutionSettings (ResolutionSetting) – Horizontal and vertical DPI.",
            "Source (Source) – Destination source for image creation (e.g., FileCreateSource).",
            "VectorRasterizationOptions (VectorRasterizationOptions) – Rasterization settings for vector sources.",
            "XmpData (IXmpData) – XMP metadata container."
        };

        // BMP Options constructors
        List<string> bmpOptionsConstructors = new List<string>
        {
            "BmpOptions() – Default constructor.",
            "BmpOptions(BmpOptions) – Copy constructor."
        };

        // BmpImage constructors (input parameters)
        List<string> bmpImageConstructors = new List<string>
        {
            "BmpImage(RasterImage) – Create from existing RasterImage.",
            "BmpImage(Stream) – Load from a stream (default 24‑bpp, no compression).",
            "BmpImage(string) – Load from file path (default 24‑bpp, no compression).",
            "BmpImage(int width, int height) – Create blank image with specified size (default 24‑bpp).",
            "BmpImage(int width, int height, ushort bitsPerPixel, IColorPalette palette) – Create with custom depth and palette.",
            "BmpImage(RasterImage rasterImage, ushort bitsPerPixel, BitmapCompression compression, double hRes, double vRes) – From RasterImage with explicit settings.",
            "BmpImage(Stream stream, ushort bitsPerPixel, BitmapCompression compression, double hRes, double vRes) – From stream with explicit settings.",
            "BmpImage(string path, ushort bitsPerPixel, BitmapCompression compression, double hRes, double vRes) – From file with explicit settings.",
            "BmpImage(int width, int height, ushort bitsPerPixel, IColorPalette palette, BitmapCompression compression, double hRes, double vRes) – Full custom constructor."
        };

        Console.WriteLine("=== BMP Conversion Input Parameters and Options ===");
        Console.WriteLine();
        Console.WriteLine("BmpOptions Properties:");
        foreach (var prop in bmpOptionsProperties)
        {
            Console.WriteLine("- " + prop);
        }
        Console.WriteLine();
        Console.WriteLine("BmpOptions Constructors:");
        foreach (var ctor in bmpOptionsConstructors)
        {
            Console.WriteLine("- " + ctor);
        }
        Console.WriteLine();
        Console.WriteLine("BmpImage Constructors (input parameters):");
        foreach (var ctor in bmpImageConstructors)
        {
            Console.WriteLine("- " + ctor);
        }
        Console.WriteLine();
        Console.WriteLine("=== End of Enumeration ===");
    }
}