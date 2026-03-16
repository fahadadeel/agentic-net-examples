using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Input ICO file path
        string inputPath = "input.ico";
        // Output ICO file path
        string outputPath = "output.ico";

        // Load the existing ICO image
        using (Image image = Image.Load(inputPath))
        {
            // Create a Graphics instance for drawing on the image
            Graphics graphics = new Graphics(image);

            // Create a GraphicsPath to hold vector figures
            GraphicsPath graphicsPath = new GraphicsPath();

            // Create a Figure and add shapes to it
            Figure figure = new Figure();

            // Add a rectangle shape (e.g., 32x32 pixels)
            figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 32f, 32f)));

            // Add an ellipse shape inside the rectangle
            figure.AddShape(new EllipseShape(new RectangleF(12f, 12f, 28f, 28f)));

            // Add the figure to the graphics path
            graphicsPath.AddFigure(figure);

            // Draw the path onto the image using a black pen with width 2
            graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

            // Save the modified image back as ICO
            image.Save(outputPath);
        }
    }
}