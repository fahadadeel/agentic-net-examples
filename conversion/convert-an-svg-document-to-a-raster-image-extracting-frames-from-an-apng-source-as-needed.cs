using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        // Input and output paths
        string svgPath = "input.svg";
        string rasterOutputPath = "output.png";
        string apngPath = "input.apng";
        string framesOutputDir = "apng_frames";

        // Create directory for extracted frames
        Directory.CreateDirectory(framesOutputDir);

        // Convert SVG to raster PNG
        using (Image svgImage = Image.Load(svgPath))
        {
            var rasterOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
            var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
            svgImage.Save(rasterOutputPath, pngOptions);
        }

        // Extract frames from APNG
        using (Image apngImage = Image.Load(apngPath))
        {
            ApngImage apng = apngImage as ApngImage;
            if (apng != null)
            {
                for (int i = 0; i < apng.PageCount; i++)
                {
                    var frame = (ApngFrame)apng.Pages[i];
                    string framePath = Path.Combine(framesOutputDir, $"frame_{i}.png");
                    frame.Save(framePath, new PngOptions());
                }
            }
        }
    }
}