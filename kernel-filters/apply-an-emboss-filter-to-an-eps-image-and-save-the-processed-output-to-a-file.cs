using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Input EPS file path
        string epsPath = "input.eps";
        // Temporary rasterized PNG path
        string tempPngPath = "temp.png";
        // Final output path after applying emboss filter
        string outputPath = "output.png";

        // Load EPS image and rasterize it to PNG
        using (Image epsImage = Image.Load(epsPath))
        {
            // Configure rasterization options (use original dimensions)
            var rasterOptions = new EpsRasterizationOptions
            {
                PageWidth = epsImage.Width,
                PageHeight = epsImage.Height
            };

            // Save rasterized version to a temporary PNG file
            epsImage.Save(tempPngPath, new PngOptions { VectorRasterizationOptions = rasterOptions });
        }

        // Load the rasterized PNG as a RasterImage
        using (Image img = Image.Load(tempPngPath))
        {
            RasterImage raster = (RasterImage)img;

            // Apply emboss filter using a predefined convolution kernel
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the processed image
            raster.Save(outputPath, new PngOptions());
        }
    }
}