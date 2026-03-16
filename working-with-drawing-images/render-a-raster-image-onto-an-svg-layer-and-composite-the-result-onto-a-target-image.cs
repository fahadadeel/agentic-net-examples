using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Paths (adjust as needed)
        string sourceImagePath = "source.png";
        string targetImagePath = "target.jpg";
        string tempSvgPath = "temp.svg";
        string tempPngPath = "temp_raster.png";
        string outputPath = "output.jpg";

        // Load the raster image to be rendered onto the SVG layer
        using (RasterImage sourceImage = (RasterImage)Image.Load(sourceImagePath))
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;
            int dpi = 96; // typical screen DPI

            // Create an SVG graphics context
            SvgGraphics2D svgGraphics = new SvgGraphics2D(width, height, dpi);

            // Draw the raster image onto the SVG canvas at (0,0)
            svgGraphics.DrawImage(sourceImage, new Point(0, 0));

            // Finalize SVG recording
            using (SvgImage svgImage = svgGraphics.EndRecording())
            {
                // Save the SVG (optional, can be omitted)
                svgImage.Save(tempSvgPath);

                // Rasterize the SVG to a PNG image
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                svgImage.Save(tempPngPath, pngOptions);
            }
        }

        // Load the rasterized SVG image
        using (RasterImage rasterizedSvg = (RasterImage)Image.Load(tempPngPath))
        {
            // Load the target image onto which the SVG result will be composited
            using (RasterImage targetImage = (RasterImage)Image.Load(targetImagePath))
            {
                // Composite the rasterized SVG onto the target at position (0,0)
                Rectangle destRect = new Rectangle(0, 0, rasterizedSvg.Width, rasterizedSvg.Height);
                targetImage.SaveArgb32Pixels(destRect, rasterizedSvg.LoadArgb32Pixels(rasterizedSvg.Bounds));

                // Save the final composited image as JPEG
                Source outSource = new FileCreateSource(outputPath, false);
                JpegOptions jpegOptions = new JpegOptions
                {
                    Source = outSource,
                    Quality = 90
                };
                targetImage.Save(outputPath, jpegOptions);
            }
        }
    }
}