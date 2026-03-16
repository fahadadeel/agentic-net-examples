using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Output PNG file path
        string outputPath = "output.png";

        // Desired canvas size
        int width = 400;
        int height = 400;

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Configure PNG options with the stream source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create the PNG image canvas
            using (Image image = Image.Create(pngOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear the canvas with white background
                graphics.Clear(Color.White);

                // Build a graphics path containing multiple vector shapes
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                // Rectangle shape
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
                // Ellipse shape
                figure.AddShape(new EllipseShape(new RectangleF(100f, 200f, 150f, 100f)));
                // Pie shape (arc sector)
                figure.AddShape(new PieShape(new RectangleF(200f, 50f, 150f, 150f), 0f, 120f));

                // Add the figure to the path
                path.AddFigure(figure);

                // Draw the constructed path using a blue pen
                Pen pen = new Pen(Color.Blue, 3);
                graphics.DrawPath(pen, path);

                // Save the image (stream source is already bound)
                image.Save();
            }
        }
    }
}