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
        // Input frame file paths (replace with actual paths)
        string[] frameFiles = new string[]
        {
            "frame1.png",
            "frame2.png",
            "frame3.png"
        };

        // Output APNG file path
        string outputPath = "output_animation.apng";

        // Load the first frame to obtain canvas size
        using (RasterImage firstFrame = (RasterImage)Image.Load(frameFiles[0]))
        {
            int width = firstFrame.Width;
            int height = firstFrame.Height;

            // Configure APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // default frame duration in ms
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG image canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, width, height))
            {
                // Remove the default empty frame
                apngImage.RemoveAllFrames();

                // Add each loaded frame as a page
                foreach (string framePath in frameFiles)
                {
                    using (RasterImage frame = (RasterImage)Image.Load(framePath))
                    {
                        apngImage.AddPage(frame);
                    }
                }

                // Save the APNG (output is already bound to the source)
                apngImage.Save();
            }
        }
    }
}