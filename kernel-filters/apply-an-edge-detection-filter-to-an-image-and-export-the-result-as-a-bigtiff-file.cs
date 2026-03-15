using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.tif";

        using (Image image = Image.Load(inputPath))
        {
            TiffImage tiffImage = (TiffImage)image;

            double[,] kernel = new double[,]
            {
                { -1, 0, 1 },
                { -2, 0, 2 },
                { -1, 0, 1 }
            };

            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
            tiffImage.Filter(tiffImage.Bounds, filterOptions);

            TiffFrame processedFrame = tiffImage.ActiveFrame;

            using (BigTiffImage bigTiff = new BigTiffImage(processedFrame))
            {
                BigTiffOptions options = new BigTiffOptions(TiffExpectedFormat.Default);
                options.Compression = TiffCompressions.AdobeDeflate;
                options.Photometric = TiffPhotometrics.Rgb;
                options.BitsPerSample = new ushort[] { 8, 8, 8 };

                bigTiff.Save(outputPath, options);
            }
        }
    }
}