using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.jpg";
        string resizedPath = "resized.png";
        string croppedPath = "cropped.png";
        string convertedPath = "converted.webp";

        // Load image from a file stream, resize, and save as PNG
        using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
        using (Image image = Image.Load(inputStream))
        {
            // Cast to RasterImage for raster operations
            RasterImage raster = (RasterImage)image;
            if (!raster.IsCached) raster.CacheData();

            // Resize to 800x600 using nearest neighbour resampling
            raster.Resize(800, 600, ResizeType.NearestNeighbourResample);
            raster.Save(resizedPath, new PngOptions());

            // Crop a rectangle (x=100, y=100, width=400, height=300)
            Aspose.Imaging.Rectangle cropRect = new Aspose.Imaging.Rectangle(100, 100, 400, 300);
            raster.Crop(cropRect);
            raster.Save(croppedPath, new PngOptions());
        }

        // Load the original image again and convert it to WebP format
        using (FileStream inputStream2 = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
        using (Image image2 = Image.Load(inputStream2))
        {
            image2.Save(convertedPath, new WebPOptions());
        }
    }
}