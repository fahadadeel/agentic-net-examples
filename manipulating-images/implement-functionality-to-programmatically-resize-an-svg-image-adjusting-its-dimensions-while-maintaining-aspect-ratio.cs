using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

namespace SvgResizeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example usage:
            // Resize "input.svg" so that it fits within 800x600 while keeping aspect ratio,
            // and save the result as "output.svg".
            ResizeSvg("input.svg", "output.svg", 800, 600);
        }

        /// <summary>
        /// Loads an SVG image, resizes it to fit within the specified dimensions while preserving
        /// the aspect ratio, and saves the resized image.
        /// </summary>
        /// <param name="inputPath">Path to the source SVG file.</param>
        /// <param name="outputPath">Path where the resized SVG will be saved.</param>
        /// <param name="maxWidth">Maximum width of the resized image.</param>
        /// <param name="maxHeight">Maximum height of the resized image.</param>
        static void ResizeSvg(string inputPath, string outputPath, int maxWidth, int maxHeight)
        {
            // Load the SVG image using the provided Image.Load method.
            using (Image image = Image.Load(inputPath))
            {
                // Cast the loaded image to SvgImage to access SVG-specific functionality.
                SvgImage svgImage = image as SvgImage;
                if (svgImage == null)
                {
                    throw new InvalidOperationException("The loaded file is not a valid SVG image.");
                }

                // Resize the SVG. The Resize method automatically preserves the aspect ratio.
                // ResizeType.Lanczos provides high-quality resampling.
                svgImage.Resize(maxWidth, maxHeight, ResizeType.Lanczos);

                // Save the resized SVG using the provided Save method.
                svgImage.Save(outputPath);
            }
        }
    }
}