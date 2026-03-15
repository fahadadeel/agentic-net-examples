using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.odg";
        string outputPath = "output.png";

        using (Image odgImage = Image.Load(inputPath))
        {
            var rasterizationOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = odgImage.Size
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            using (var memoryStream = new MemoryStream())
            {
                odgImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                using (Image rasterImageContainer = Image.Load(memoryStream))
                {
                    RasterImage rasterImage = (RasterImage)rasterImageContainer;

                    double[,] edgeKernel = new double[,]
                    {
                        { -1, -1, -1 },
                        { -1,  8, -1 },
                        { -1, -1, -1 }
                    };

                    var convolutionOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(edgeKernel);
                    rasterImage.Filter(rasterImage.Bounds, convolutionOptions);

                    rasterImage.Save(outputPath);
                }
            }
        }
    }
}