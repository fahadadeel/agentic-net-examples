using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

namespace VectorBackgroundRemoval
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example usage:
            // args[0] - input vector image path (e.g., .svg, .cdr, .wmf)
            // args[1] - output image path (any supported format, e.g., .png)
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: VectorBackgroundRemoval <inputPath> <outputPath>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            RemoveVectorBackground(inputPath, outputPath);
        }

        /// <summary>
        /// Loads a vector image, removes its background, and saves the result.
        /// </summary>
        /// <param name="inputPath">Path to the source vector image.</param>
        /// <param name="outputPath">Path where the processed image will be saved.</param>
        static void RemoveVectorBackground(string inputPath, string outputPath)
        {
            // Load the image using Aspose.Imaging's generic loader.
            using (Image image = Image.Load(inputPath))
            {
                // Check if the loaded image is a vector image (e.g., SvgImage, VectorMultipageImage, etc.).
                if (image is VectorImage vectorImage)
                {
                    // Remove the background using the parameterless method.
                    // This replaces the background with transparency.
                    vectorImage.RemoveBackground();

                    // OPTIONAL: If you need custom settings (e.g., replace background with a specific color),
                    // you can create a RemoveBackgroundSettings instance and pass it to RemoveBackground.
                    // Example:
                    // var settings = new RemoveBackgroundSettings
                    // {
                    //     // Define a replacement color if you don't want transparency.
                    //     // BackgroundReplacementColor = Color.White
                    // };
                    // vectorImage.RemoveBackground(settings);

                    // Save the processed image.
                    // The Save method automatically selects the appropriate format based on the file extension.
                    vectorImage.Save(outputPath);
                }
                else
                {
                    Console.WriteLine("The provided file is not a supported vector image.");
                }
            }
        }
    }
}