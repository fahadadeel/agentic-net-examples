using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input CMX file path
        string inputPath = "input.cmx";
        // Output raster image path (PNG)
        string outputPath = "output.png";

        // Load the CMX vector image
        using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
        {
            // Rasterize CMX to a memory stream using PNG options
            using (MemoryStream rasterStream = new MemoryStream())
            {
                // Set up PNG options with vector rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    Source = new StreamSource(rasterStream),
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageSize = cmx.Size
                    }
                };

                // Save the rasterized image to the memory stream
                cmx.Save(rasterStream, pngOptions);
                rasterStream.Position = 0;

                // Load the rasterized image from the memory stream
                using (RasterImage raster = (RasterImage)Image.Load(rasterStream))
                {
                    // Apply emboss filter using a predefined 3x3 kernel
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                    // Save the processed raster image to the output file
                    using (FileCreateSource outSource = new FileCreateSource(outputPath, false))
                    {
                        PngOptions outOptions = new PngOptions { Source = outSource };
                        raster.Save(outputPath, outOptions);
                    }
                }
            }
        }
    }
}