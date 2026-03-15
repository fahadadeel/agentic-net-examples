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
        // Expect input image path and output APNG path as arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <program> <inputImagePath> <outputApngPath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the source raster image (preserves transparency)
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            const int AnimationDuration = 1000; // total animation time in ms
            const int FrameDuration = 70;       // each frame duration in ms

            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = (uint)FrameDuration,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG canvas with the same dimensions as the source image
            using (ApngImage apngImage = (ApngImage)Image.Create(
                createOptions,
                sourceImage.Width,
                sourceImage.Height))
            {
                // Ensure the image starts with no frames
                apngImage.RemoveAllFrames();

                int numOfFrames = AnimationDuration / FrameDuration;
                int halfFrames = numOfFrames / 2;

                // Add the first frame (original image)
                apngImage.AddFrame(sourceImage);

                // Add intermediate frames with varying gamma adjustments
                for (int frameIndex = 1; frameIndex < numOfFrames - 1; ++frameIndex)
                {
                    // Duplicate the source image into a new frame
                    apngImage.AddFrame(sourceImage);

                    // Retrieve the newly added frame
                    ApngFrame lastFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];

                    // Calculate gamma value: increase then decrease across the animation
                    float gamma = frameIndex >= halfFrames
                        ? numOfFrames - frameIndex - 1
                        : frameIndex;

                    // Apply gamma correction to the frame
                    lastFrame.AdjustGamma(gamma);
                }

                // Add the final frame (original image)
                apngImage.AddFrame(sourceImage);

                // Save the APNG; the output path is already bound via FileCreateSource
                apngImage.Save();
            }
        }
    }
}