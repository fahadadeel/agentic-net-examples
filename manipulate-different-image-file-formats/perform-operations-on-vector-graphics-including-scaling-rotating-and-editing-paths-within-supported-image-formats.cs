using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.svg";
        string outputPath = "output.svg";

        // Load the SVG image
        using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
        {
            // Scale the image to new dimensions
            svgImage.Resize(800, 600);

            // Rotate the image by 45 degrees
            svgImage.Rotate(45f);

            // Create a Graphics object for drawing
            Graphics graphics = new Graphics(svgImage);
            graphics.Clear(Color.White);

            // Create a GraphicsPath with a rectangle shape
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(100f, 100f, 200f, 150f)));
            path.AddFigure(figure);

            // Draw the path onto the SVG image
            graphics.DrawPath(new Pen(Color.Blue, 3), path);

            // Save the modified SVG image
            SvgOptions saveOptions = new SvgOptions();
            svgImage.Save(outputPath, saveOptions);
        }
    }
}