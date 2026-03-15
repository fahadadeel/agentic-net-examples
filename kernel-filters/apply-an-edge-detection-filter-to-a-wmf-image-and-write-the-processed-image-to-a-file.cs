using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.wmf";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
        {
            var rasterOptions = new WmfRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = wmfImage.Size
            };
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };
            wmfImage.Save(tempPngPath, pngOptions);
        }

        using (Image img = Image.Load(tempPngPath))
        {
            var rasterImage = (RasterImage)img;

            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };
            var convOptions = new ConvolutionFilterOptions(kernel);
            rasterImage.Filter(rasterImage.Bounds, convOptions);
            rasterImage.Save(outputPath);
        }

        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}