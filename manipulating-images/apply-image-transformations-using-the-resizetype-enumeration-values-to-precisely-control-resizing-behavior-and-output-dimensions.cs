using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input image path (first argument) or default.
        string inputPath = args.Length > 0 ? args[0] : "input.jpg";
        // Output directory (second argument) or current directory.
        string outputDir = args.Length > 1 ? args[1] : Directory.GetCurrentDirectory();

        // Ensure the output directory exists.
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Define the resize types to demonstrate.
        ResizeType[] resizeTypes = new ResizeType[]
        {
            ResizeType.NearestNeighbourResample,
            ResizeType.BilinearResample,
            ResizeType.LanczosResample,
            ResizeType.CatmullRom,
            ResizeType.CubicConvolution,
            ResizeType.AdaptiveResample
        };

        // Corresponding names for output files.
        string[] typeNames = new string[]
        {
            "NearestNeighbour",
            "Bilinear",
            "Lanczos",
            "CatmullRom",
            "CubicConvolution",
            "Adaptive"
        };

        // Process each resize type.
        for (int i = 0; i < resizeTypes.Length; i++)
        {
            // Load the original image for each iteration to avoid cumulative resizing.
            using (Image image = Image.Load(inputPath))
            {
                // Example: double the dimensions.
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;

                // Apply resizing with the specific ResizeType.
                image.Resize(newWidth, newHeight, resizeTypes[i]);

                // Construct the output file path.
                string outputPath = Path.Combine(outputDir, $"resized_{typeNames[i]}.png");

                // Save the resized image as PNG.
                image.Save(outputPath, new PngOptions());
            }
        }
    }
}