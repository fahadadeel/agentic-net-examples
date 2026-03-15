using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class EmbossExample
{
    static void Main()
    {
        // Path to the folder containing the source image
        string dataDir = @"C:\Temp\";

        // Load the source image
        using (Image image = Image.Load(dataDir + "sample.png"))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Create convolution filter options using the built‑in 3x3 emboss kernel
            var embossOptions = new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3);

            // Apply the emboss filter to the entire image
            rasterImage.Filter(rasterImage.Bounds, embossOptions);

            // Save the processed image
            rasterImage.Save(dataDir + "sample_Emboss.png", new PngOptions());
        }
    }
}