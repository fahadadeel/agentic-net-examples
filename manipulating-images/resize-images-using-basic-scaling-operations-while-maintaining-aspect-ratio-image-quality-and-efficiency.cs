using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class ImageResizer
{
    // Resizes an image to fit within the specified max dimensions while preserving aspect ratio.
    // The resize operation uses the provided ResizeType for quality control.
    public static void ResizeImage(string inputPath, string outputPath, int maxWidth, int maxHeight, ResizeType resizeType)
    {
        // Load the image (supports any format recognized by Aspose.Imaging)
        using (Image image = Image.Load(inputPath))
        {
            // Determine scaling factor to keep aspect ratio
            double widthRatio = (double)maxWidth / image.Width;
            double heightRatio = (double)maxHeight / image.Height;
            double scale = Math.Min(widthRatio, heightRatio);

            // If the image is already smaller than the target size, keep original dimensions
            if (scale > 1.0) scale = 1.0;

            int newWidth = (int)Math.Round(image.Width * scale);
            int newHeight = (int)Math.Round(image.Height * scale);

            // Perform the resize using the specified algorithm
            image.Resize(newWidth, newHeight, resizeType);

            // Save the resized image using default options for the target format
            // The format is inferred from the output file extension
            image.Save(outputPath, new PngOptions());
        }
    }

    static void Main()
    {
        string inputFile = @"C:\temp\sample.webp";
        string outputFileBilinear = @"C:\temp\sample_resized_bilinear.png";
        string outputFileNearest = @"C:\temp\sample_resized_nearest.png";

        // Resize with Bilinear resampling (good quality)
        ResizeImage(inputFile, outputFileBilinear, 800, 600, ResizeType.BilinearResample);

        // Resize with NearestNeighbour resampling (faster, lower quality)
        ResizeImage(inputFile, outputFileNearest, 800, 600, ResizeType.NearestNeighbourResample);
    }
}