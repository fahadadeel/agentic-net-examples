using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png;

// Create a new PNG image with desired dimensions
PngOptions pngOptions = new PngOptions();
using (Image image = Image.Create(pngOptions, 800, 600))
{
    // Initialize graphics object for drawing
    Graphics graphics = new Graphics(image);

    // Clear the background with a light gray color
    graphics.Clear(Color.LightGray);

    // Create a GraphicsPath to hold vector shapes
    GraphicsPath graphicsPath = new GraphicsPath();

    // Create a figure that will contain multiple shapes
    Figure figure = new Figure();

    // Add a rectangle shape
    figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 300f, 200f)));

    // Add an ellipse shape
    figure.AddShape(new EllipseShape(new RectangleF(400f, 100f, 250f, 150f)));

    // Add a pie shape (arc sector)
    figure.AddShape(new PieShape(new RectangleF(200f, 300f, 200f, 200f), 30f, 120f));

    // Add a bezier curve shape
    PointF[] bezierPoints = new PointF[]
    {
        new PointF(100f, 500f),
        new PointF(150f, 450f),
        new PointF(250f, 550f),
        new PointF(300f, 500f)
    };
    figure.AddShape(new BezierShape(bezierPoints, true));

    // Add a polygon shape
    PointF[] polygonPoints = new PointF[]
    {
        new PointF(500f, 400f),
        new PointF(600f, 350f),
        new PointF(650f, 450f),
        new PointF(550f, 500f)
    };
    figure.AddShape(new PolygonShape(polygonPoints));

    // Add the figure to the graphics path
    graphicsPath.AddFigure(figure);

    // Draw the path with a thick red pen
    Pen redPen = new Pen(Color.Red, 4);
    graphics.DrawPath(redPen, graphicsPath);

    // Optionally fill the same path with a semi‑transparent brush
    SolidBrush fillBrush = new SolidBrush(Color.FromArgb(80, Color.Yellow));
    graphics.FillPath(fillBrush, graphicsPath);

    // Save the resulting image to disk
    image.Save("VectorShapesOutput.png");
}