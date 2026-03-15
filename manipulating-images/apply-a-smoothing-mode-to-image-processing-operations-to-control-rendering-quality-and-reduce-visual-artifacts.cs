using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Drawing;

class ApplySmoothingModeExample
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = @"c:\temp\sample.png";
        string outputPath = @"c:\temp\sample_smooth.png";

        // Load the raster image using the unified load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access drawing capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Create a Graphics object for the raster image
            using (Graphics graphics = new Graphics(rasterImage))
            {
                // Set the desired smoothing mode (high quality with antialiasing)
                graphics.SmoothingMode = Aspose.Imaging.SmoothingMode.HighQuality;

                // Example drawing operation: draw a filled ellipse with a border
                // This operation will benefit from the smoothing mode set above
                Pen pen = new Pen(Color.Blue, 3);
                Brush brush = new SolidBrush(Color.FromArgb(128, Color.Red));
                graphics.FillEllipse(brush, new RectangleF(50, 50, 200, 150));
                graphics.DrawEllipse(pen, new RectangleF(50, 50, 200, 150));
            }

            // Save the modified image using the appropriate save method
            rasterImage.Save(outputPath);
        }
    }
}