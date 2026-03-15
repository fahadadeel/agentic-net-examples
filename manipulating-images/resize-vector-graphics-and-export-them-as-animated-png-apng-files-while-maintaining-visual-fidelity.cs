using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Input SVG file (vector graphic)
        const string inputSvgPath = "input.svg";

        // Output APNG file (animated PNG)
        const string outputApngPath = "output.apng";

        // Desired dimensions for the rasterized output
        const int targetWidth = 800;
        const int targetHeight = 600;

        // Load the vector image using Aspose.Imaging's generic Image loader
        using (Image vectorImage = Image.Load(inputSvgPath))
        {
            // Resize the vector image – this changes the vector's viewport size.
            // The Resize method works for VectorImage derivatives such as SvgImage.
            vectorImage.Resize(targetWidth, targetHeight);

            // Configure rasterization options so the vector is rasterized at the target size.
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = new Size(targetWidth, targetHeight)
            };

            // Set up APNG export options.
            // DefaultFrameTime defines the duration of each frame (in milliseconds).
            // NumPlays = 0 means the animation will loop infinitely.
            // VectorRasterizationOptions tells the saver how to rasterize the vector content.
            var apngOptions = new ApngOptions
            {
                DefaultFrameTime = 100,               // 100 ms per frame
                NumPlays = 0,                         // infinite looping
                ColorType = PngColorType.TruecolorWithAlpha,
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the resized vector as an animated PNG.
            // This uses the built‑in Save method with ApngOptions, complying with the lifecycle rules.
            vectorImage.Save(outputApngPath, apngOptions);
        }
    }
}