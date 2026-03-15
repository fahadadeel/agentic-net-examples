using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input frame image files (must support transparency, e.g., PNG)
        List<string> framePaths = new List<string>
        {
            "frame1.png",
            "frame2.png",
            "frame3.png"
        };

        // Output APNG file
        string outputPath = "output_animation.png";

        // Load the first frame to obtain canvas size
        using (RasterImage firstFrame = (RasterImage)Image.Load(framePaths[0]))
        {
            int canvasWidth = firstFrame.Width;
            int canvasHeight = firstFrame.Height;

            // Create APNG options with alpha support
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // default 100 ms per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG canvas
            using (ApngImage apng = (ApngImage)Image.Create(createOptions, canvasWidth, canvasHeight))
            {
                // Ensure no default frame remains
                apng.RemoveAllFrames();

                // Add each frame preserving its transparency
                foreach (string path in framePaths)
                {
                    using (RasterImage frame = (RasterImage)Image.Load(path))
                    {
                        // If frame size differs, resize to canvas size (optional)
                        if (frame.Width != canvasWidth || frame.Height != canvasHeight)
                        {
                            frame.Resize(canvasWidth, canvasHeight, ResizeType.NearestNeighbourResample);
                        }

                        apng.AddFrame(frame);
                    }
                }

                // Save the animated PNG
                apng.Save();
            }
        }
    }
}