using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Expect two arguments: input vector file path and output folder path
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <program> <inputVectorFile> <outputFolder>");
            return;
        }

        string inputFile = args[0];
        string outputFolder = args[1];

        if (!File.Exists(inputFile))
        {
            Console.WriteLine($"Input file does not exist: {inputFile}");
            return;
        }

        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        // Load the vector image and extract embedded raster images
        using (Image image = Image.Load(inputFile))
        {
            var vectorImage = (VectorImage)image;
            var embeddedImages = vectorImage.GetEmbeddedImages();

            int index = 0;
            foreach (var embedded in embeddedImages)
            {
                string outFile = Path.Combine(outputFolder, $"image{index++}.png");
                using (embedded)
                {
                    // Save each embedded raster image as PNG to preserve original quality
                    embedded.Image.Save(outFile, new PngOptions());
                }
            }
        }

        Console.WriteLine("Extraction completed.");
    }
}