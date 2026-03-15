using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class MetafileProcessing
{
    static void Main()
    {
        // Input WMF file path
        string inputPath = @"C:\Images\sample.wmf";

        // Output PNG file path (rasterized version of the WMF)
        string outputPath = @"C:\Images\sample_converted.png";

        // Load the WMF image using the unified Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast to WmfImage to access vector‑specific functionality
            WmfImage wmfImage = (WmfImage)image;

            // Example operation: resize the metafile to 800x600 pixels
            // (Resize uses the default NearestNeighbourResample algorithm)
            wmfImage.Resize(800, 600);

            // Prepare rasterization options for converting the vector WMF to a raster format
            WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
            {
                // Set the page size to match the resized image dimensions
                PageSize = wmfImage.Size,

                // Optional: set background color for the rasterized image
                BackgroundColor = Color.White
            };

            // Configure PNG save options and attach the rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as PNG
            wmfImage.Save(outputPath, pngOptions);
        }

        Console.WriteLine("Metafile conversion completed successfully.");
    }
}