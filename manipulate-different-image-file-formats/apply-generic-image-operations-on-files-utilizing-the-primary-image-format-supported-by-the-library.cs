using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class GenericImageProcessor
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Load the image using Aspose.Imaging's built‑in load method
        using (RasterImage image = Image.Load(inputPath) as RasterImage)
        {
            if (image == null)
                throw new InvalidOperationException("The loaded file is not a raster image.");

            // Resize the image to 200x200 pixels (default NearestNeighbourResample)
            image.Resize(200, 200);

            // Convert the image to grayscale
            image.Grayscale();

            // Save the processed image as PNG using the appropriate save options
            var pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }

        Console.WriteLine("Image processing completed successfully.");
    }
}