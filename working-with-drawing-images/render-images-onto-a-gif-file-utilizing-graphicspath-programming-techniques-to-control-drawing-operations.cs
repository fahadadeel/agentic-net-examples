using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

public class Program
{
    public static void Main(string[] args)
    {
        // Output GIF file path
        string outputPath = "output.gif";

        // Define frame dimensions
        int width = 100;
        int height = 100;

        // Create the first frame block and fill background
        using (GifFrameBlock firstBlock = new GifFrameBlock((ushort)width, (ushort)height))
        {
            // Graphics does not implement IDisposable; do not wrap in using
            Graphics graphicsFirst = new Graphics(firstBlock);
            SolidBrush backgroundBrush = new SolidBrush(Color.White);
            graphicsFirst.FillRectangle(backgroundBrush, firstBlock.Bounds);

            // Initialize GIF image with the first frame
            using (GifImage gif = new GifImage(firstBlock))
            {
                // Create additional frames with varying shapes
                for (int i = 0; i < 10; i++)
                {
                    using (GifFrameBlock frame = new GifFrameBlock((ushort)width, (ushort)height))
                    {
                        // Fill frame background
                        Graphics graphics = new Graphics(frame);
                        SolidBrush bgBrush = new SolidBrush(Color.White);
                        graphics.FillRectangle(bgBrush, frame.Bounds);

                        // Build a GraphicsPath with a rectangle and an ellipse
                        GraphicsPath path = new GraphicsPath();
                        Figure figure = new Figure();

                        // Add a static rectangle shape
                        RectangleF rect = new RectangleF(10f, 10f, 80f, 80f);
                        figure.AddShape(new RectangleShape(rect));

                        // Add an ellipse that changes size each frame
                        float offset = i * 5;
                        RectangleF ellipseRect = new RectangleF(10f + offset, 10f + offset, 80f - 2 * offset, 80f - 2 * offset);
                        figure.AddShape(new EllipseShape(ellipseRect));

                        // Add the figure to the path
                        path.AddFigure(figure);

                        // Draw the path outline
                        Pen pen = new Pen(Color.Blue, 2);
                        graphics.DrawPath(pen, path);

                        // Add the completed frame to the GIF
                        gif.AddBlock(frame);
                    }
                }

                // Set infinite looping (0 means infinite)
                gif.LoopsCount = 0;

                // Save the animated GIF
                gif.Save(outputPath);
            }
        }
    }
}