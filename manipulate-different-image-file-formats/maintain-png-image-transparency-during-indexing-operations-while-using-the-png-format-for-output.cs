using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths (provide via command line or use defaults)
        string inputPath = args.Length > 0 ? args[0] : "input.png";
        string outputPath = args.Length > 1 ? args[1] : "output_indexed.png";

        // Load the source image (preserves transparency)
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for palette generation
            RasterImage raster = (RasterImage)image;

            // Configure PNG options for indexed color while keeping transparency
            PngOptions options = new PngOptions
            {
                ColorType = PngColorType.IndexedColor,
                CompressionLevel = 9,
                // Generate an optimal 8‑bit palette (includes transparent entries if present)
                Palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256, PaletteMiningMethod.Histogram)
            };

            // Save the image as an indexed PNG; transparency is retained in the palette
            image.Save(outputPath, options);
        }
    }
}