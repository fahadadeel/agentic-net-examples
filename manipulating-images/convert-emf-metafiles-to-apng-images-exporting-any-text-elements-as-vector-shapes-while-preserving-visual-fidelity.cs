using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input EMF file path
        string inputPath = "input.emf";
        // Output APNG file path
        string outputPath = "output.apng";

        // Load the EMF image
        using (Image emfImage = Image.Load(inputPath))
        {
            // Configure vector rasterization options for EMF rendering
            EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
            {
                PageSize = emfImage.Size,
                BackgroundColor = Color.White,
                RenderMode = EmfRenderMode.Auto,
                // Optional: improve rendering quality
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };

            // Set up APNG options with the rasterization settings
            ApngOptions apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                VectorRasterizationOptions = rasterOptions,
                // Single-frame APNG (no animation)
                DefaultFrameTime = 1000 // 1 second per frame (arbitrary for static image)
            };

            // Save the EMF as an APNG, converting text to shapes via rasterization
            emfImage.Save(outputPath, apngOptions);
        }
    }
}