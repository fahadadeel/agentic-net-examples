using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        int width = 800;
        int height = 600;

        using (Image svgImage = Image.Load(inputPath))
        {
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = new SizeF(width, height),
                BackgroundColor = Color.White,
                SmoothingMode = SmoothingMode.AntiAlias,
                TextRenderingHint = TextRenderingHint.AntiAlias
            };

            using (PngOptions pngOptions = new PngOptions())
            {
                pngOptions.BitDepth = 8;
                pngOptions.PngCompressionLevel = PngCompressionLevel.Level6;
                pngOptions.VectorRasterizationOptions = rasterOptions;

                svgImage.Save(outputPath, pngOptions);
            }
        }
    }
}