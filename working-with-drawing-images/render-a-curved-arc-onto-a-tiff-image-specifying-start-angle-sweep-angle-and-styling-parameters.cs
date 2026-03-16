using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Output TIFF file path
        string outputPath = "output.tif";

        // Image dimensions
        int width = 500;
        int height = 500;

        // Arc parameters
        int arcX = 100;          // X-coordinate of bounding rectangle
        int arcY = 100;          // Y-coordinate of bounding rectangle
        int arcWidth = 300;      // Width of bounding rectangle
        int arcHeight = 200;     // Height of bounding rectangle
        float startAngle = 30f;  // Start angle in degrees
        float sweepAngle = 120f; // Sweep angle in degrees

        // Create TIFF options and bind the output file
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new TIFF image
        using (Image image = Image.Create(tiffOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear the canvas with white background
            graphics.Clear(Color.White);

            // Draw the arc with specified styling
            Pen arcPen = new Pen(Color.Blue, 5);
            Rectangle arcRect = new Rectangle(arcX, arcY, arcWidth, arcHeight);
            graphics.DrawArc(arcPen, arcRect, startAngle, sweepAngle);

            // Save the image (output file is already bound)
            image.Save();
        }
    }
}