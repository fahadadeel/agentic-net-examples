using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "output.png";

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set PNG options and bind the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a new image with the specified dimensions
            using (Image image = Image.Create(pngOptions, 600, 400))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.LightGray);

                // Create a graphics path and a figure to hold shapes
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                // Add a rectangle shape
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
                // Add an ellipse shape
                figure.AddShape(new EllipseShape(new RectangleF(300f, 100f, 150f, 150f)));
                // Add a pie shape
                figure.AddShape(new PieShape(new RectangleF(new PointF(200f, 200f), new SizeF(200f, 200f)), 0f, 120f));

                // Add the figure to the path
                path.AddFigure(figure);

                // Apply a rotation transformation (45 degrees)
                graphics.RotateTransform(45f);

                // Draw the path outline with a blue pen
                graphics.DrawPath(new Pen(Color.Blue, 3), path);

                // Fill the path with a semi‑transparent red brush
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
                {
                    graphics.FillPath(brush, path);
                }

                // Save the image (stream is already bound)
                image.Save();
            }
        }
    }
}