using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

namespace ImageProcessingDemo
{
    public class WebPResizer
    {
        /// <summary>
        /// Resizes a WebP image to fit within the specified dimensions while preserving the original aspect ratio.
        /// The resized image is saved using the provided output path and format (PNG in this example).
        /// </summary>
        /// <param name="inputPath">Full path to the source WebP image.</param>
        /// <param name="outputPath">Full path where the resized image will be saved.</param>
        /// <param name="maxWidth">Maximum width of the resized image.</param>
        /// <param name="maxHeight">Maximum height of the resized image.</param>
        public static void ResizeWebP(string inputPath, string outputPath, int maxWidth, int maxHeight)
        {
            // Load the WebP image using the supported load rule.
            using (WebPImage image = (WebPImage)Image.Load(inputPath))
            {
                // Original dimensions.
                int originalWidth = image.Width;
                int originalHeight = image.Height;

                // Determine scaling factor to maintain aspect ratio.
                double widthRatio = (double)maxWidth / originalWidth;
                double heightRatio = (double)maxHeight / originalHeight;
                double scale = Math.Min(widthRatio, heightRatio);

                // If the image is already smaller than the target size, keep original size.
                if (scale > 1.0)
                    scale = 1.0;

                // Compute new dimensions.
                int newWidth = (int)Math.Round(originalWidth * scale);
                int newHeight = (int)Math.Round(originalHeight * scale);

                // Perform resizing using Bilinear resampling for good quality.
                image.Resize(newWidth, newHeight, ResizeType.BilinearResample);

                // Save the resized image. Here we use PNG format, but any supported format can be used.
                image.Save(outputPath, new PngOptions());
            }
        }

        // Example usage.
        public static void Main()
        {
            string inputFile = @"C:\Images\sample.webp";
            string outputFile = @"C:\Images\sample_resized.png";
            int targetWidth = 800;   // Desired maximum width.
            int targetHeight = 600;  // Desired maximum height.

            ResizeWebP(inputFile, outputFile, targetWidth, targetHeight);
        }
    }
}