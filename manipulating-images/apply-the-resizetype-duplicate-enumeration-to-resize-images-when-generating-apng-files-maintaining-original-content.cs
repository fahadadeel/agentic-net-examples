using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input raster image path
        const string inputPath = "input.png";
        // Output APNG file path
        const string outputPath = "output.apng";

        // Load the source raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Apply Resize with ResizeType.Duplicate to keep original content unchanged
            sourceImage.Resize(sourceImage.Width, sourceImage.Height, ResizeType.Duplicate);

            // Set up APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 70, // frame duration in milliseconds
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG image canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                // Ensure the canvas starts without any default frames
                apngImage.RemoveAllFrames();

                // Add multiple frames using the resized (but unchanged) source image
                const int frameCount = 5;
                for (int i = 0; i < frameCount; i++)
                {
                    apngImage.AddFrame(sourceImage);
                }

                // Save the APNG file (output is already bound to the FileCreateSource)
                apngImage.Save();
            }
        }
    }
}