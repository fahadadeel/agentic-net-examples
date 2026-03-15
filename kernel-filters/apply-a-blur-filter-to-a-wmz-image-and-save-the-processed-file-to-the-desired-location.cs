using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <program> <input.wmz> <output.png>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        using (Image vectorImage = Image.Load(inputPath))
        {
            var rasterOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height
            };

            string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath) ?? "", "temp_raster.png");

            vectorImage.Save(tempPngPath, new PngOptions { VectorRasterizationOptions = rasterOptions });

            using (RasterImage rasterImage = (RasterImage)Image.Load(tempPngPath))
            {
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                rasterImage.Save(outputPath, new PngOptions());
            }

            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
            }
        }
    }
}