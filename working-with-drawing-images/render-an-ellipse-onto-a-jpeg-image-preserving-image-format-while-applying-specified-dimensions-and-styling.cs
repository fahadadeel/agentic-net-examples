using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Paths for the source JPEG and the result JPEG
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Load the existing JPEG image
        using (JpegImage image = (JpegImage)Image.Load(inputPath))
        {
            // Initialize Graphics for drawing on the image
            Graphics graphics = new Graphics(image);

            // Define the bounding rectangle for the ellipse
            int ellipseX = image.Width / 4;
            int ellipseY = image.Height / 4;
            int ellipseWidth = image.Width / 2;
            int ellipseHeight = image.Height / 2;

            // Create a Pen with desired color and thickness
            Pen pen = new Pen(Color.Blue, 5);

            // Draw the ellipse onto the image
            graphics.DrawEllipse(pen, ellipseX, ellipseY, ellipseWidth, ellipseHeight);

            // Save the modified image, preserving JPEG format
            image.Save(outputPath);
        }
    }
}