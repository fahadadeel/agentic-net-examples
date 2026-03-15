using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png; // For PngColorType if needed
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class SvgToApngConverter
{
    static void Main()
    {
        // Input SVG file path
        string inputSvgPath = "input.svg";

        // Desired dimensions for the resized image
        int newWidth = 800;
        int newHeight = 600;

        // Output APNG file path
        string outputApngPath = "output.apng";

        // Load the SVG image from file
        using (SvgImage svgImage = new SvgImage(inputSvgPath))
        {
            // Resize the SVG while preserving aspect ratio (choose a resize type)
            svgImage.Resize(newWidth, newHeight, ResizeType.Lanczos);

            // Prepare rasterization options for converting SVG to raster frames
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Set the page size to match the resized dimensions
                PageSize = new Size(newWidth, newHeight)
            };

            // Configure APNG export options
            ApngOptions apngOptions = new ApngOptions
            {
                // Set default frame duration (in milliseconds)
                DefaultFrameTime = 500,

                // Use truecolor with alpha for full color support
                ColorType = PngColorType.TruecolorWithAlpha,

                // Assign the rasterization options so the SVG is rasterized correctly
                VectorRasterizationOptions = rasterOptions,

                // Optional: specify the source for the created APNG file
                Source = new FileCreateSource(outputApngPath, false)
            };

            // Save the resized SVG as an animated PNG (APNG)
            svgImage.Save(outputApngPath, apngOptions);
        }
    }
}