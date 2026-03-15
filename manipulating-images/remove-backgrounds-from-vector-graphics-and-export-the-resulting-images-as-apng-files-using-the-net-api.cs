using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Expect input vector file path and output APNG file path as arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <inputVectorPath> <outputApngPath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the vector image
        using (Image image = Image.Load(inputPath))
        {
            // Remove background if the image is a vector type
            if (image is VectorImage vectorImage)
            {
                vectorImage.RemoveBackground(new RemoveBackgroundSettings());
            }

            // Configure APNG options with transparent background and proper rasterization settings
            var apngOptions = new ApngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.Transparent,
                    PageSize = image.Size
                }
            };

            // Save the result as an APNG file
            image.Save(outputPath, apngOptions);
        }
    }
}