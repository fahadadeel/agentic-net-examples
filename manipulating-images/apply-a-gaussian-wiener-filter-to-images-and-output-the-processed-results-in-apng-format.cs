using System;
using System.Drawing; // For Rectangle
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Apng;

class GaussWienerToApng
{
    static void Main()
    {
        // Input image path (any supported format)
        string inputPath = @"C:\Images\sample.png";

        // Output APNG path
        string outputPath = @"C:\Images\sample_processed.apng";

        // Load the image using Aspose.Imaging's generic loader
        using (Image image = Image.Load(inputPath))
        {
            // Prepare the Gauss‑Wiener filter options (radius = 5, sigma = 4.0)
            var filterOptions = new GaussWienerFilterOptions(5, 4.0);

            // Apply the filter to the whole image.
            // Different image types expose the Filter method; we try each known type.
            if (image is RasterImage raster)
            {
                raster.Filter(raster.Bounds, filterOptions);
            }
            else if (image is GifImage gif)
            {
                gif.Filter(gif.Bounds, filterOptions);
            }
            else if (image is WebPImage webp)
            {
                webp.Filter(webp.Bounds, filterOptions);
            }
            else if (image is DjvuImage djvu)
            {
                djvu.Filter(djvu.Bounds, filterOptions);
            }
            else if (image is TiffImage tiff)
            {
                tiff.Filter(tiff.Bounds, filterOptions);
            }
            else
            {
                // If the image type does not support Filter, throw an informative exception.
                throw new NotSupportedException("The loaded image type does not support filtering.");
            }

            // Save the processed image as APNG.
            // Aspose.Imaging infers the format from the file extension.
            image.Save(outputPath);
        }
    }
}