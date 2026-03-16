using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Input GIF file path
        string gifPath = "input.gif";
        // Output EMF file path
        string emfPath = "output.emf";

        // Load the GIF raster image
        using (RasterImage gifImage = (RasterImage)Image.Load(gifPath))
        {
            // Determine canvas size based on GIF dimensions
            int canvasWidth = gifImage.Width;
            int canvasHeight = gifImage.Height;

            // Convert size to millimeters (approximation: 1 pixel = 0.01 mm)
            int canvasWidthMm = (int)(canvasWidth / 100f);
            int canvasHeightMm = (int)(canvasHeight / 100f);

            // Define the frame rectangle for the EMF canvas
            Rectangle frame = new Rectangle(0, 0, canvasWidth, canvasHeight);

            // Create EMF graphics recorder (do NOT wrap in using)
            EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
                frame,
                new Size(canvasWidth, canvasHeight),
                new Size(canvasWidthMm, canvasHeightMm));

            // Draw the GIF onto the EMF canvas, scaling to fit exactly
            graphics.DrawImage(
                gifImage,
                new Rectangle(0, 0, canvasWidth, canvasHeight),   // destination rectangle
                gifImage.Bounds,                                 // source rectangle (full GIF)
                GraphicsUnit.Pixel);                             // source unit

            // Finalize recording and obtain the EMF image
            using (EmfImage emfImage = graphics.EndRecording())
            {
                // Save the EMF file
                emfImage.Save(emfPath);
            }
        }
    }
}