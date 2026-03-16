using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Shapes;

public class Program
{
    static void Main(string[] args)
    {
        // Paths for input GIF, overlay image, and output GIF
        string inputGifPath = "input.gif";
        string overlayImagePath = "overlay.png";
        string outputGifPath = "output.gif";

        // Load the overlay image once
        using (RasterImage overlay = (RasterImage)Image.Load(overlayImagePath))
        // Load the animated GIF
        using (GifImage gif = (GifImage)Image.Load(inputGifPath))
        {
            // Iterate through each frame of the GIF
            for (int i = 0; i < gif.PageCount; i++)
            {
                // Set the current frame as active
                gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];

                // Create a Graphics object for drawing on the active frame
                Graphics graphics = new Graphics(gif.ActiveFrame);

                // Define the area where the overlay will be placed (top‑left corner at (10,10))
                float overlayX = 10f;
                float overlayY = 10f;
                float overlayWidth = overlay.Width;
                float overlayHeight = overlay.Height;

                // Build a GraphicsPath containing a rectangle shape for the overlay region
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(overlayX, overlayY, overlayWidth, overlayHeight)));
                path.AddFigure(figure);

                // Draw a border around the overlay region
                Pen borderPen = new Pen(Color.Blue, 2);
                graphics.DrawPath(borderPen, path);

                // Draw the overlay image onto the frame within the defined rectangle
                graphics.DrawImage(overlay, new RectangleF(overlayX, overlayY, overlayWidth, overlayHeight));
            }

            // Save the modified GIF preserving animation
            GifOptions saveOptions = new GifOptions();
            gif.Save(outputGifPath, saveOptions);
        }
    }
}