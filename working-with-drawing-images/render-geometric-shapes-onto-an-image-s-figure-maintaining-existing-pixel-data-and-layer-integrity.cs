using System;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Output file path and canvas size
        string outputPath = "output.png";
        int width = 500;
        int height = 500;

        // Configure PNG options with a file create source (output is bound to the file)
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, width, height))
        {
            // Initialize graphics for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

            // Clear the canvas with a background color
            graphics.Clear(Aspose.Imaging.Color.LightGray);

            // Prepare a graphics path and a figure to hold shapes
            Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();
            Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

            // Add a rectangle shape
            figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, 200f, 150f)));
            // Add an ellipse shape
            figure.AddShape(new EllipseShape(new Aspose.Imaging.RectangleF(300f, 100f, 150f, 150f)));
            // Add a pie shape
            figure.AddShape(new PieShape(new Aspose.Imaging.RectangleF(150f, 250f, 200f, 200f), 0f, 120f));

            // Add the figure to the graphics path
            path.AddFigure(figure);

            // Draw the path using a pen
            Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3);
            graphics.DrawPath(pen, path);

            // Save the image (file is already bound to the output path)
            image.Save();
        }
    }
}