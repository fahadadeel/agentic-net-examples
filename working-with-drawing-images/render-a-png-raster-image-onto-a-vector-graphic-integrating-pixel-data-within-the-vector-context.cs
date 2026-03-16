using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input PNG and output SVG
        string inputPngPath = "input.png";
        string outputSvgPath = "output.svg";

        // Load the PNG raster image
        using (RasterImage raster = (RasterImage)Image.Load(inputPngPath))
        {
            // Create an SVG canvas with the same dimensions as the PNG
            int width = raster.Width;
            int height = raster.Height;
            int dpi = 96; // Standard screen DPI

            SvgGraphics2D svgGraphics = new SvgGraphics2D(width, height, dpi);

            // Draw the raster image onto the SVG at the origin (0,0) with its original size
            svgGraphics.DrawImage(raster, new Point(0, 0), new Size(width, height));

            // Finalize the SVG image and save it to file
            using (SvgImage svgImage = svgGraphics.EndRecording())
            {
                svgImage.Save(outputSvgPath);
            }
        }
    }
}