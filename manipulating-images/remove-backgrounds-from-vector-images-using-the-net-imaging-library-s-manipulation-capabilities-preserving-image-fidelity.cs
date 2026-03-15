using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;

class RemoveVectorBackground
{
    static void Main()
    {
        // Path to the source vector image (e.g., SVG, CDR, etc.)
        string inputPath = @"C:\Images\source_vector.svg";

        // Path where the background‑removed image will be saved
        string outputPath = @"C:\Images\source_vector_no_bg.svg";

        // Load the image using Aspose.Imaging's generic loader
        using (Image image = Image.Load(inputPath))
        {
            // Ensure the loaded image is a vector type
            if (image is VectorImage vectorImage)
            {
                // Remove the background using the built‑in method
                vectorImage.RemoveBackground();

                // Save the modified image back to a file
                vectorImage.Save(outputPath);
            }
            else
            {
                Console.WriteLine("The provided file is not a vector image.");
            }
        }
    }
}