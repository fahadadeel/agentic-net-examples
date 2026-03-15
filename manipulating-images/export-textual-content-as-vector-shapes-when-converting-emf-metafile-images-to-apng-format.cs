using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input EMF file path (first argument) or default.
        string inputPath = args.Length > 0 ? args[0] : "input.emf";
        // Output APNG file path (second argument) or default.
        string outputPath = args.Length > 1 ? args[1] : "output.apng";

        // Load the EMF image.
        using (Image image = Image.Load(inputPath))
        {
            // Cast to EmfImage to access EMF‑specific properties.
            EmfImage emfImage = (EmfImage)image;

            // Configure rasterization options.
            // Text will be rendered as vector shapes during rasterization.
            var vectorOptions = new EmfRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = emfImage.Size,
                RenderMode = EmfRenderMode.Auto,
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };

            // Set up APNG options with the vector rasterization settings.
            var apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                VectorRasterizationOptions = vectorOptions,
                // Optional: set default frame duration (in milliseconds).
                DefaultFrameTime = 500
            };

            // Save the EMF content as an APNG file.
            emfImage.Save(outputPath, apngOptions);
        }
    }
}