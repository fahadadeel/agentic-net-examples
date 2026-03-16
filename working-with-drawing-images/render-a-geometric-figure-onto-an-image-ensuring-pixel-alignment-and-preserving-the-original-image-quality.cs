using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspise.Imaging; // placeholder for any missing namespaces

class RenderGeometricFigure
{
    static void Main()
    {
        // Define image dimensions and DPI
        int width = 500;
        int height = 500;
        int dpi = 96;

        // Create a PNG image with the specified size
        PngOptions pngOptions = new PngOptions
        {
            Source = new StreamSource(new System.IO.MemoryStream()), // placeholder stream source
            HorizontalResolution = dpi,
            VerticalResolution = dpi
        };

        using (Image image = Image.Create(pngOptions, width, height))
        {
            // Initialize Graphics object for drawing
            using (Graphics graphics = new Graphics(image))
            {
                // Clear background with a light color
                graphics.Clear(Color.Wheat);

                // Ensure pixel-perfect rendering by disabling anti-aliasing
                graphics.SmoothingMode = SmoothingMode.None;

                // Draw a black rectangle border (pixel-aligned)
                Pen borderPen = new Pen(Color.Black, 1);
                graphics.DrawRectangle(borderPen, 0, 0, width - 1, height - 1);

                // Fill a centered rectangle with a solid color
                Brush fillBrush = new SolidBrush(Color.WhiteSmoke);
                graphics.FillRectangle(fillBrush, new Rectangle(50, 50, width - 100, height - 100));

                // Draw a diagonal line using integer coordinates
                Pen linePen = new Pen(Color.DarkGreen, 1);
                graphics.DrawLine(linePen, 0, 0, width - 1, height - 1);
                graphics.DrawLine(linePen, 0, height - 1, width - 1, 0);

                // Draw an ellipse inside the filled rectangle
                Pen ellipsePen = new Pen(Color.Blue, 2);
                graphics.DrawEllipse(ellipsePen, 100, 100, width - 200, height - 200);

                // Load an external raster image (preserve original quality)
                using (RasterImage overlay = (RasterImage)Image.Load("sample.bmp"))
                {
                    // Draw the overlay image without scaling (pixel-aligned)
                    graphics.DrawImageUnscaled(overlay, new Point(200, 200));
                }

                // Optionally draw a string with a solid brush
                Font font = new Font("Arial", 24, FontStyle.Regular);
                Brush textBrush = new SolidBrush(Color.DarkRed);
                graphics.DrawString("Aspose.Imaging Demo", font, textBrush, new PointF(120, height - 40));
            }

            // Save the resulting image preserving original quality
            image.Save("output.png");
        }
    }
}