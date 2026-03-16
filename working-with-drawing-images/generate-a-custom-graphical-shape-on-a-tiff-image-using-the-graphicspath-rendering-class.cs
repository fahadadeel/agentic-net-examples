using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Output TIFF file path
        string outputPath = "customShape.tif";

        // Configure TIFF options and bind the output file
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 500x500 TIFF image
        using (Image image = Image.Create(tiffOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Wheat);

            // Build a custom shape using GraphicsPath
            GraphicsPath graphicsPath = new GraphicsPath();
            Figure figure = new Figure();

            // Rectangle shape
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));

            // Ellipse shape
            figure.AddShape(new EllipseShape(new RectangleF(100f, 200f, 250f, 150f)));

            // Polygon shape (triangle)
            figure.AddShape(new PolygonShape(new PointF[]
            {
                new PointF(300f, 300f),
                new PointF(350f, 320f),
                new PointF(340f, 380f)
            }, true));

            // Add the figure to the path
            graphicsPath.AddFigure(figure);

            // Draw the path with a blue pen
            Pen pen = new Pen(Color.Blue, 5);
            graphics.DrawPath(pen, graphicsPath);

            // Save the image (output is already bound to the file)
            image.Save();
        }
    }
}