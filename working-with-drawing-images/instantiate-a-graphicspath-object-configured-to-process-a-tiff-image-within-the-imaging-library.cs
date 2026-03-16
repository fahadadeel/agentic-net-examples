using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Shapes;

public class Program
{
    public static void Main(string[] args)
    {
        // Load an existing TIFF image
        using (TiffImage tiffImage = (TiffImage)Image.Load("input.tif"))
        {
            // Create a new empty GraphicsPath
            GraphicsPath graphicsPath = new GraphicsPath();

            // Add a rectangle shape to the path
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 200f, 200f)));
            graphicsPath.AddFigure(figure);

            // Draw the path onto the TIFF image
            Graphics graphics = new Graphics(tiffImage);
            graphics.DrawPath(new Pen(Color.Blue, 5), graphicsPath);

            // Save the modified image
            tiffImage.Save("output.tif");
        }
    }
}