using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class DitheringExample
{
    static void Main()
    {
        // Path to the source image
        string inputPath = @"c:\temp\sample.png";
        // Directory where the dithered images will be saved
        string outputDir = @"c:\temp\";

        // ---------- Threshold Dithering (4‑bit palette) ----------
        // Load the image, cast to RasterImage to access Dither method
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Perform threshold dithering using a 4‑bit palette (16 colors)
            raster.Dither(DitheringMethod.ThresholdDithering, 4);

            // Save the result as PNG
            raster.Save(System.IO.Path.Combine(outputDir, "sample_ThresholdDithering4.png"));
        }

        // ---------- Floyd‑Steinberg Dithering (1‑bit palette) ----------
        // Reload the original image to avoid cumulative effects
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Perform Floyd‑Steinberg dithering using a 1‑bit palette (black & white)
            raster.Dither(DitheringMethod.FloydSteinbergDithering, 1);

            // Save the result as PNG
            raster.Save(System.IO.Path.Combine(outputDir, "sample_FloydSteinbergDithering1.png"));
        }
    }
}