using System;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input PNG with transparent background
        string inputPath = "input.png";
        // Output PNG with background replaced
        string outputPath = "output.png";

        // Opaque red color in ARGB format (Alpha=255, Red=255, Green=0, Blue=0)
        int replaceArgb = unchecked((int)0xFFFF0000);

        // Load the PNG as a raster image
        using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Load all pixels (including alpha channel)
            int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);

            // Replace fully transparent pixels (alpha == 0) with the specified color
            for (int i = 0; i < pixels.Length; i++)
            {
                if ((pixels[i] & unchecked((int)0xFF000000)) == 0)
                {
                    pixels[i] = replaceArgb;
                }
            }

            // Write modified pixels back to the image
            raster.SaveArgb32Pixels(raster.Bounds, pixels);

            // Prepare PNG save options
            PngOptions options = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Save the modified image as PNG
            raster.Save(outputPath, options);
        }
    }
}