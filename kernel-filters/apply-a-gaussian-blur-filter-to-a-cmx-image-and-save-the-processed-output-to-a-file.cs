using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputCmxPath = "input.cmx";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        CmxImage cmx = (CmxImage)Image.Load(inputCmxPath);
        using (cmx)
        {
            PngOptions pngOptions = new PngOptions();
            cmx.Save(tempPngPath, pngOptions);
        }

        RasterImage raster = (RasterImage)Image.Load(tempPngPath);
        using (raster)
        {
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));
            PngOptions outOptions = new PngOptions();
            raster.Save(outputPath, outOptions);
        }
    }
}