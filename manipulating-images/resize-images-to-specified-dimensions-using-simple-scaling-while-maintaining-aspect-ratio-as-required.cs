using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class ImageResizer
{
    // Resizes an image to fit within the specified max dimensions while preserving aspect ratio.
    // The resized image is saved in PNG format.
    public static void ResizeImage(string inputPath, string outputPath, int maxWidth, int maxHeight)
    {
        // Load the image using Aspose.Imaging's generic loader.
        using (Image image = Image.Load(inputPath))
        {
            // Determine scaling factor to maintain aspect ratio.
            float widthRatio = (float)maxWidth / image.Width;
            float heightRatio = (float)maxHeight / image.Height;
            float scale = Math.Min(widthRatio, heightRatio);

            // If the image is already smaller than the target size, keep original dimensions.
            if (scale > 1f)
                scale = 1f;

            int newWidth = (int)Math.Round(image.Width * scale);
            int newHeight = (int)Math.Round(image.Height * scale);

            // Perform the resize using nearest neighbour resampling (simple scaling).
            image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            // Save the resized image as PNG.
            image.Save(outputPath, new PngOptions());
        }
    }

    // Example usage.
    static void Main()
    {
        string inputFile = @"C:\temp\sample.jpg";
        string outputFile = @"C:\temp\sample_resized.png";
        int targetMaxWidth = 800;
        int targetMaxHeight = 600;

        ResizeImage(inputFile, outputFile, targetMaxWidth, targetMaxHeight);
        Console.WriteLine("Image resized and saved to: " + outputFile);
    }
}