using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Define output path
        string outputPath = @"C:\temp\GraphicsPathOutput.png";

        // Create a FileStream for the PNG file
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Initialize PNG options and associate the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a new PNG image with desired dimensions (500x500)
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize Graphics object for drawing on the image
                Graphics graphics = new Graphics(image);

                // Clear the background with a light color
                graphics.Clear(Color.Wheat);

                // Create a GraphicsPath to hold figures (shapes)
                GraphicsPath graphicsPath = new GraphicsPath();

                // Create a Figure and add various shapes to it
                Figure figure = new Figure();

                // Rectangle shape
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));

                // Ellipse shape
                figure.AddShape(new EllipseShape(new RectangleF(100f, 200f, 250f, 150f)));

                // Pie shape
                figure.AddShape(new PieShape(new RectangleF(new PointF(150f, 100f), new SizeF(200f, 200f)), 0f, 120f));

                // Add the figure to the graphics path
                graphicsPath.AddFigure(figure);

                // Draw the path using a black pen with thickness 3
                graphics.DrawPath(new Pen(Color.Black, 3), graphicsPath);

                // Save all changes to the PNG file
                image.Save();
            }
        }

        Console.WriteLine("Image created successfully.");
    }
}