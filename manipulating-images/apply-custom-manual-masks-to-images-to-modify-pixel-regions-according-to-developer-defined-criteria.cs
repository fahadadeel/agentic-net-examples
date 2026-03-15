using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the source image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Define a manual mask using geometric shapes
            GraphicsPath manualMask = new GraphicsPath();
            Figure figure = new Figure();
            // Example shapes: an ellipse and a rectangle
            figure.AddShape(new EllipseShape(new RectangleF(50, 50, 100, 80)));
            figure.AddShape(new RectangleShape(new RectangleF(200, 150, 120, 90)));
            manualMask.AddFigure(figure);

            // Set up manual masking arguments
            ManualMaskingArgs maskingArgs = new ManualMaskingArgs
            {
                Mask = manualMask
            };

            // Export options for the resulting image (transparent PNG)
            PngOptions exportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            // Configure masking options
            MaskingOptions maskingOptions = new MaskingOptions
            {
                Method = SegmentationMethod.Manual,
                Decompose = false,
                Args = maskingArgs,
                BackgroundReplacementColor = Color.Transparent,
                ExportOptions = exportOptions,
                // Optional: limit masking to a specific area
                //MaskingArea = new Rectangle(0, 0, image.Width, image.Height)
            };

            // Create the ImageMasking instance
            ImageMasking masking = new ImageMasking(image);

            // Perform the manual masking operation
            using (MaskingResult result = masking.Decompose(maskingOptions))
            {
                // Retrieve the foreground (masked) image (index 1)
                using (RasterImage maskedImage = (RasterImage)result[1].GetImage())
                {
                    // Save the masked image to the output path
                    maskedImage.Save(outputPath, exportOptions);
                }
            }
        }
    }
}