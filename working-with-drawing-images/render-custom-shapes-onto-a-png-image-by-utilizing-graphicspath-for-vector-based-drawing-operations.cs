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
        // Define output PNG path and canvas size
        string outputPath = "output.png";
        int width = 500;
        int height = 400;

        // Configure PNG options with a FileCreateSource (binds the output file)
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas
        using (Image image = Image.Create(pngOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.LightGray);

            // Create a GraphicsPath to hold figures
            GraphicsPath graphicsPath = new GraphicsPath();

            // Create a figure and add custom shapes
            Figure figure = new Figure();

            // Rectangle shape
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));

            // Ellipse shape
            figure.AddShape(new EllipseShape(new RectangleF(300f, 100f, 150f, 150f)));

            // Polygon shape (triangle)
            figure.AddShape(new PolygonShape(
                new PointF[]
                {
                    new PointF(100f, 300f),
                    new PointF(150f, 350f),
                    new PointF(200f, 300f)
                },
                true));

            // Add the figure to the graphics path
            graphicsPath.AddFigure(figure);

            // Draw the path with a black pen
            graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

            // Save the image (output file is already bound via FileCreateSource)
            image.Save();
        }
    }
}