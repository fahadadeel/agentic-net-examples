using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string svgPath = "input.svg";
        string bmpPath = "overlay.bmp";
        string pngPath = "overlay.png";
        string outputPath = "result.svg";

        using (SvgImage svgImage = (SvgImage)Image.Load(svgPath))
        {
            var graphics = new Aspose.Imaging.FileFormats.Svg.Graphics.SvgGraphics2D(svgImage);

            using (RasterImage bmpImage = (RasterImage)Image.Load(bmpPath))
            {
                graphics.DrawImage(bmpImage, new Point(50, 50), new Size(bmpImage.Width, bmpImage.Height));
            }

            using (RasterImage pngImage = (RasterImage)Image.Load(pngPath))
            {
                graphics.DrawImage(pngImage, new Point(200, 150), new Size(pngImage.Width, pngImage.Height));
            }

            svgImage.Save(outputPath);
        }
    }
}