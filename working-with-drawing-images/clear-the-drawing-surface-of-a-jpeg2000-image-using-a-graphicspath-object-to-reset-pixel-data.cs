using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output JPEG2000 file path
        string outputPath = "output.jp2";

        // Define image dimensions
        int width = 500;
        int height = 500;

        // Configure JPEG2000 options with a FileCreateSource (binds the output file)
        Jpeg2000Options jp2Options = new Jpeg2000Options();
        jp2Options.Source = new FileCreateSource(outputPath, false);

        // Create the JPEG2000 image canvas
        using (Image image = Image.Create(jp2Options, width, height))
        {
            // Initialize Graphics for drawing on the image
            Graphics graphics = new Graphics(image);

            // Create a GraphicsPath that covers the entire canvas
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            // Add a rectangle shape matching the canvas size
            figure.AddShape(new RectangleShape(new RectangleF(0f, 0f, width, height)));
            path.AddFigure(figure);

            // Fill the path with a solid white brush to clear the surface
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                graphics.FillPath(brush, path);
            }

            // Save the image (file is already bound via FileCreateSource)
            image.Save();
        }
    }
}