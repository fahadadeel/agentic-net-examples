using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output JPEG file paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Load the JPEG image
        using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
        {
            // Initialize Graphics for the loaded image
            Graphics graphics = new Graphics(jpegImage);

            // Create a GraphicsPath that covers the entire image area
            GraphicsPath path = new GraphicsPath();

            // Create a Figure and add a rectangle shape matching the image bounds
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(0f, 0f, jpegImage.Width, jpegImage.Height)));

            // Add the Figure to the GraphicsPath
            path.AddFigure(figure);

            // Fill the path with white color to clear the canvas
            SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.White);
            graphics.FillPath(brush, path);

            // Save the cleared image to the output file
            jpegImage.Save(outputPath);
        }
    }
}