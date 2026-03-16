using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main()
    {
        // Paths for input PNG and output SVG
        string dir = @"C:\temp\";
        string pngPath = System.IO.Path.Combine(dir, "sample.png");
        string svgPath = System.IO.Path.Combine(dir, "canvas.svg");

        // Load the PNG raster image
        using (RasterImage raster = (RasterImage)Image.Load(pngPath))
        {
            // Define SVG canvas dimensions (using the raster size here)
            int canvasWidth = raster.Width;
            int canvasHeight = raster.Height;
            int dpi = 96; // standard screen DPI

            // Create an SVG graphics context
            SvgGraphics2D graphics = new SvgGraphics2D(canvasWidth, canvasHeight, dpi);

            // Draw the raster image at the desired location (top‑left corner)
            graphics.DrawImage(raster, new Aspose.Imaging.Point(0, 0));

            // Finalize the SVG recording and obtain the SVG image object
            using (SvgImage svgImage = graphics.EndRecording())
            {
                // Save the SVG file preserving the raster image fidelity
                svgImage.Save(svgPath);
            }
        }
    }
}