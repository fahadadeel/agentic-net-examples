using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class DitherToApng
{
    static void Main()
    {
        // Paths for input raster image and output APNG file
        string inputPath = @"c:\temp\sample.png";
        string outputPath = @"c:\temp\sample_dithered.apng";

        // Load the raster image using the library's load rule
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the Dither method
            RasterImage raster = (RasterImage)image;

            // Apply Floyd‑Steinberg dithering with an 8‑bit palette (256 colors)
            raster.Dither(DitheringMethod.FloydSteinbergDithering, 8);

            // Prepare APNG save options (no custom settings required for default behavior)
            ApngOptions apngOptions = new ApngOptions();

            // Save the processed image as an APNG using the library's save rule
            raster.Save(outputPath, apngOptions);
        }
    }
}