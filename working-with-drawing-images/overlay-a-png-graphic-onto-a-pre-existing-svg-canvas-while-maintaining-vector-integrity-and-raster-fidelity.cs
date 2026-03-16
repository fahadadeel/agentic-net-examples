using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.ImageOptions;

class OverlayPngOnSvg
{
    static void Main()
    {
        // Paths to the source SVG, the PNG overlay, and the output SVG
        string svgPath = @"C:\Images\canvas.svg";
        string pngPath = @"C:\Images\overlay.png";
        string outputPath = @"C:\Images\canvas_with_overlay.svg";

        // Load the existing SVG image
        using (SvgImage svgImage = new SvgImage(svgPath))
        // Load the PNG image as a raster image
        using (RasterImage pngImage = (RasterImage)Image.Load(pngPath))
        {
            // Create a graphics object that draws onto the loaded SVG
            SvgGraphics2D graphics = new SvgGraphics2D(svgImage);

            // Define where the PNG should be placed on the SVG canvas
            // Here we place it at (50,50) with its original dimensions
            graphics.DrawImage(pngImage, new Point(50, 50), new Size(pngImage.Width, pngImage.Height));

            // Finalize drawing and obtain the updated SVG image
            using (SvgImage resultSvg = graphics.EndRecording())
            {
                // Save the resulting SVG, preserving vector data and the raster overlay
                resultSvg.Save(outputPath);
            }
        }
    }
}