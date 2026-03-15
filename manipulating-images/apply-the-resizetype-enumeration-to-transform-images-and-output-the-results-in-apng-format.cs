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
        // Paths for input raster image and output APNG file
        string inputPath = "input.png";
        string outputPath = "output.apng";

        // Desired dimensions after resizing
        int newWidth = 200;
        int newHeight = 200;

        // Load the source image as a raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Resize using Lanczos resampling (high‑quality)
            sourceImage.Resize(newWidth, newHeight, ResizeType.LanczosResample);

            // Set up APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // 100 ms per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create an APNG canvas bound to the output file
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                // Remove the default single frame
                apngImage.RemoveAllFrames();

                // Add multiple frames (e.g., 5) with slight gamma adjustments
                int frameCount = 5;
                for (int i = 0; i < frameCount; i++)
                {
                    apngImage.AddFrame(sourceImage);
                    ApngFrame frame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                    frame.AdjustGamma(i); // simple variation per frame
                }

                // Save the APNG; the file is already bound via FileCreateSource
                apngImage.Save();
            }
        }
    }
}