using Aspose.Imaging;
using Aspose.Imaging.Shapes;

namespace ProgramNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input and output BMP images
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Load the existing BMP image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Initialize graphics for drawing on the image
                Graphics graphics = new Graphics(image);

                // Create a graphics path to hold multiple figures
                GraphicsPath path = new GraphicsPath();

                // First figure: a rectangle and an ellipse
                Figure figure1 = new Figure();
                figure1.AddShape(new RectangleShape(new RectangleF(50, 50, 200, 150)));
                figure1.AddShape(new EllipseShape(new RectangleF(300, 100, 150, 150)));

                // Second figure: a closed polygon
                Figure figure2 = new Figure();
                figure2.AddShape(new PolygonShape(new[]
                {
                    new PointF(100, 300),
                    new PointF(200, 350),
                    new PointF(150, 400),
                    new PointF(80, 380)
                }, true));

                // Add both figures to the graphics path
                path.AddFigures(new[] { figure1, figure2 });

                // Draw the combined path onto the image using a red pen
                graphics.DrawPath(new Pen(Color.Red, 3), path);

                // Save the modified image to the output file
                image.Save(outputPath);
            }
        }
    }
}