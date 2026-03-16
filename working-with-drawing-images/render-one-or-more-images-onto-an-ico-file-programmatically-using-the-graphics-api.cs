using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Ico;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output ICO file path
        string outputIcoPath = "output.ico";

        // Desired icon size (e.g., 256x256)
        int iconSize = 256;

        // Create an in‑memory stream to hold the temporary PNG canvas
        using (MemoryStream tempStream = new MemoryStream())
        {
            // Source for the PNG canvas (bound to the stream)
            Source canvasSource = new StreamSource(tempStream);

            // PNG options for the canvas
            PngOptions pngOptions = new PngOptions() { Source = canvasSource };

            // Create a raster canvas of the required size
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, iconSize, iconSize))
            {
                // Draw on the canvas using Graphics
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                // Example drawing: a blue ellipse
                Pen bluePen = new Pen(Color.Blue, 5);
                graphics.DrawEllipse(bluePen, new Rectangle(20, 20, iconSize - 40, iconSize - 40));

                // Save the canvas (required because it is bound to a stream)
                canvas.Save();

                // Prepare ICO creation options (default 32‑bit PNG)
                IcoOptions icoOptions = new IcoOptions();

                // Create the ICO image
                using (IcoImage icoImage = new IcoImage(iconSize, iconSize, icoOptions))
                {
                    // Add the drawn raster image as a page/frame
                    icoImage.AddPage(canvas);

                    // Save the final ICO file
                    icoImage.Save(outputIcoPath);
                }
            }
        }
    }
}