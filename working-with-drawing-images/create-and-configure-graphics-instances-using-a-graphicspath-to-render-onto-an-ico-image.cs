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
        // Output ICO file path
        string outputPath = "output.ico";

        // Configure ICO options and bind to the output file
        IcoOptions icoOptions = new IcoOptions();
        icoOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 256x256 ICO image canvas
        using (Image image = Image.Create(icoOptions, 256, 256))
        {
            // Initialize Graphics for drawing on the image
            Graphics graphics = new Graphics(image);

            // Clear the canvas with a transparent background
            graphics.Clear(Color.Transparent);

            // Create a GraphicsPath to hold figures
            GraphicsPath path = new GraphicsPath();

            // Create a Figure and add shapes to it
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(20f, 20f, 200f, 200f)));
            figure.AddShape(new EllipseShape(new RectangleF(50f, 50f, 150f, 150f)));
            figure.AddShape(new PieShape(new RectangleF(new PointF(80f, 80f), new SizeF(100f, 100f)), 0f, 120f));

            // Add the figure to the graphics path
            path.AddFigure(figure);

            // Draw the path using a black pen of width 3
            graphics.DrawPath(new Pen(Color.Black, 3), path);

            // Save the image (file is already bound via FileCreateSource)
            image.Save();
        }
    }
}