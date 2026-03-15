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
        // Input raster image (single frame) and output APNG path
        string inputPath = "input.png";
        string outputPath = "output_animation.png";

        // Animation parameters
        const int animationDuration = 1000; // total duration in ms
        const int frameDuration = 70; // each frame duration in ms

        // Load the source raster image
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = (uint)frameDuration,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG canvas with the same dimensions as the source image
            using (ApngImage apngImage = (ApngImage)Image.Create(
                createOptions,
                sourceImage.Width,
                sourceImage.Height))
            {
                // Remove the default frame that exists after creation
                apngImage.RemoveAllFrames();

                // Calculate number of frames based on total animation duration
                int numOfFrames = animationDuration / frameDuration;
                int halfFrames = numOfFrames / 2;

                // Add the first frame
                apngImage.AddFrame(sourceImage);

                // Add intermediate frames with gamma adjustment for visual effect
                for (int i = 1; i < numOfFrames - 1; ++i)
                {
                    apngImage.AddFrame(sourceImage);
                    ApngFrame lastFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                    float gamma = i >= halfFrames ? numOfFrames - i - 1 : i;
                    lastFrame.AdjustGamma(gamma);
                }

                // Add the final frame
                apngImage.AddFrame(sourceImage);

                // Save the APNG (output file is already bound via FileCreateSource)
                apngImage.Save();
            }
        }
    }
}