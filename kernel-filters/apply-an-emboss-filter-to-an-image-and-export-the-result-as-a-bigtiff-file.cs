using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string tempTiffPath = "temp.tif";
        string outputPath = "output.tif";

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
            raster.Save(tempTiffPath, new TiffOptions(TiffExpectedFormat.Default));
        }

        using (Image tiffImageContainer = Image.Load(tempTiffPath))
        {
            TiffImage tiffImage = (TiffImage)tiffImageContainer;
            using (BigTiffImage bigTiff = new BigTiffImage(tiffImage.ActiveFrame))
            {
                BigTiffOptions bigTiffOptions = new BigTiffOptions(TiffExpectedFormat.Default);
                bigTiff.Save(outputPath, bigTiffOptions);
            }
        }
    }
}