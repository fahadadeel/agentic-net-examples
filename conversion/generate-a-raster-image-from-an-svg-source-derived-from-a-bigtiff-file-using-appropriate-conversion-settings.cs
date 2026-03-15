using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string bigTiffPath = "input.tif";
        string intermediateSvgPath = "intermediate.svg";
        string outputRasterPath = "output.png";

        using (Image bigTiffImage = Image.Load(bigTiffPath))
        {
            using (SvgOptions svgExportOptions = new SvgOptions())
            {
                SvgRasterizationOptions svgRaster = new SvgRasterizationOptions
                {
                    PageWidth = bigTiffImage.Width,
                    PageHeight = bigTiffImage.Height,
                    BackgroundColor = Color.White,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };
                svgExportOptions.VectorRasterizationOptions = svgRaster;
                bigTiffImage.Save(intermediateSvgPath, svgExportOptions);
            }
        }

        using (Image svgImage = Image.Load(intermediateSvgPath))
        {
            SvgRasterizationOptions svgRasterOptions = new SvgRasterizationOptions
            {
                PageWidth = svgImage.Width,
                PageHeight = svgImage.Height,
                BackgroundColor = Color.White,
                SmoothingMode = SmoothingMode.AntiAlias,
                TextRenderingHint = TextRenderingHint.AntiAlias
            };
            using (PngOptions pngSaveOptions = new PngOptions())
            {
                pngSaveOptions.VectorRasterizationOptions = svgRasterOptions;
                svgImage.Save(outputRasterPath, pngSaveOptions);
            }
        }

        if (File.Exists(intermediateSvgPath))
        {
            File.Delete(intermediateSvgPath);
        }
    }
}