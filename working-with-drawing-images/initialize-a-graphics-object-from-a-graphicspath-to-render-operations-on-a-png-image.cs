using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png;

// Define output file path
string outputPath = "output.png";

// Create a stream for the output file
using (FileStream stream = new FileStream(outputPath, FileMode.Create))
{
    // Set PNG options and associate the stream as the source
    PngOptions pngOptions = new PngOptions
    {
        Source = new StreamSource(stream)
    };

    // Create a new PNG image with desired dimensions
    using (Image image = Image.Create(pngOptions, 400, 400))
    {
        // Initialize Graphics object for drawing on the image
        Graphics graphics = new Graphics(image);

        // Clear the canvas with a white background
        graphics.Clear(Color.White);

        // Create a GraphicsPath to hold drawing figures
        GraphicsPath graphicsPath = new GraphicsPath();

        // Build a figure containing a rectangle and an ellipse
        Figure figure = new Figure();
        figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 300f, 300f)));
        figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 200f, 200f)));

        // Add the figure to the graphics path
        graphicsPath.AddFigure(figure);

        // Define a pen for stroking the path
        Pen pen = new Pen(Color.Blue, 3);

        // Render the path onto the image
        graphics.DrawPath(pen, graphicsPath);

        // Save all changes to the PNG file
        image.Save();
    }
}