using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input CDR and output image
        string inputCdrPath = "input.cdr";
        string outputPngPath = "output.png";

        // Load the CDR vector image
        using (Image cdrImage = Image.Load(inputCdrPath))
        {
            CdrImage cdr = (CdrImage)cdrImage;

            // Rasterize the CDR image to a memory stream in PNG format
            using (MemoryStream rasterStream = new MemoryStream())
            {
                PngOptions pngOptions = new PngOptions();
                cdr.Save(rasterStream, pngOptions);
                rasterStream.Position = 0; // Reset stream for reading

                // Load the rasterized image as a RasterImage
                using (Image rasterImage = Image.Load(rasterStream))
                {
                    RasterImage raster = (RasterImage)rasterImage;

                    // Apply motion blur (motion wiener) filter to the entire image
                    // Parameters: length = 10, smooth = 1.0, angle = 90 degrees
                    raster.Filter(raster.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

                    // Save the processed raster image to the output file
                    using (FileStream outStream = new FileStream(outputPngPath, FileMode.Create, FileAccess.Write))
                    {
                        raster.Save(outStream, new PngOptions());
                    }
                }
            }
        }
    }
}