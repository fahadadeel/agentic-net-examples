using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output JPEG2000 file paths
        string inputPath = "input.jp2";
        string outputPath = "output.jp2";

        // Load the JPEG2000 image
        using (Image image = Image.Load(inputPath))
        {
            // If the image supports raster operations, perform a resize
            if (image is RasterImage raster)
            {
                if (!raster.IsCached) raster.CacheData();

                // Resize to 75% of original dimensions using nearest-neighbour resampling
                int newWidth = raster.Width * 3 / 4;
                int newHeight = raster.Height * 3 / 4;
                raster.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
            }

            // Configure JPEG2000 save options
            var jp2Options = new Jpeg2000Options
            {
                Irreversible = false,                     // lossless compression
                CompressionRatios = new double[] { 2.0 }, // example compression ratio
                KeepMetadata = true,                       // retain original metadata
                Comments = new string[] { "Processed by Aspose.Imaging" } // add comment
            };

            // Save the image back as JPEG2000 without changing the format
            image.Save(outputPath, jp2Options);
        }
    }
}