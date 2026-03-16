using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Gif; // Ensure GIF format support

// Create a GIF image, draw vector paths on it, and save the result.
public class GifVectorPathExample
{
    public static void Main()
    {
        // Output file path
        string outputPath = "vector_path_output.gif";

        // Create a file stream for the output GIF
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Initialize GIF options and associate the stream as the source
            GifOptions gifOptions = new GifOptions();
            gifOptions.Source = new StreamSource(stream);

            // Create a new GIF image with desired dimensions (e.g., 400x300)
            using (Image image = Image.Create(gifOptions, 400, 300))
            {
                // Initialize graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Clear the background with a light color
                graphics.Clear(Color.LightBlue);

                // Build a graphics path containing a rectangle and an ellipse
                GraphicsPath graphicsPath = new GraphicsPath();
                Figure figure = new Figure();

                // Add a rectangle shape to the figure
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));

                // Add an ellipse shape to the figure
                figure.AddShape(new EllipseShape(new RectangleF(120f, 80f, 150f, 100f)));

                // Add the figure to the graphics path
                graphicsPath.AddFigure(figure);

                // Draw the path using a red pen of width 3
                graphics.DrawPath(new Pen(Color.Red, 3), graphicsPath);

                // Save all changes to the GIF image (the stream is automatically flushed on dispose)
                image.Save();
            }
        }
    }
}