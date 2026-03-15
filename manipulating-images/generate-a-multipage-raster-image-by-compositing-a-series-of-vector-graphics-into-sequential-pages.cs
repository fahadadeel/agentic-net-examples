using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Png;

// Example: create a multipage raster image (TIFF) from a series of vector graphics (e.g., SVG files)
class Program
{
    static void Main()
    {
        // Paths to the source vector graphics
        string[] vectorFiles = new string[]
        {
            @"C:\Images\vector1.svg",
            @"C:\Images\vector2.svg",
            @"C:\Images\vector3.svg"
        };

        // List to hold rasterized pages
        List<Image> rasterPages = new List<Image>();

        foreach (string filePath in vectorFiles)
        {
            // Load the vector image (SVG, WMF, EMF, etc.)
            using (Image vectorImage = Image.Load(filePath))
            {
                // Prepare rasterization options for converting vector to raster (PNG in this case)
                PngOptions pngOptions = new PngOptions
                {
                    // Configure vector rasterization (background, page size, etc.)
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = vectorImage.Size // preserve original size
                    }
                };

                // Rasterize the vector image into a memory stream
                using (MemoryStream rasterStream = new MemoryStream())
                {
                    vectorImage.Save(rasterStream, pngOptions);
                    rasterStream.Position = 0; // reset stream for reading

                    // Load the rasterized page back as an Image (RasterImage)
                    Image rasterPage = Image.Load(rasterStream);
                    rasterPages.Add(rasterPage);
                }
            }
        }

        // Create a multipage image from the raster pages
        // Image.Create(Image[]) returns an IMultipageImage implementation (e.g., TiffImage)
        Image multipageImage = Image.Create(rasterPages.ToArray());

        // Save the resulting multipage raster image to a file (TIFF format)
        // The Save method will infer format from the file extension
        multipageImage.Save(@"C:\Images\MultipageOutput.tif");

        // Dispose all images
        foreach (var page in rasterPages)
        {
            page.Dispose();
        }
        multipageImage.Dispose();
    }
}