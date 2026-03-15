using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class SharpenOtgExample
{
    static void Main()
    {
        // Paths for the source OTG, an intermediate PNG, and the final sharpened image
        string inputOtgPath = "input.otg";
        string intermediatePngPath = "intermediate.png";
        string outputPngPath = "output_sharpened.png";

        // Load the OTG image and rasterize it to PNG using vector rasterization options
        using (Image otgImage = Image.Load(inputOtgPath))
        {
            // Cast to the specific OTG image type
            OtgImage otg = (OtgImage)otgImage;

            // Prepare PNG save options with rasterization settings
            var pngOptions = new PngOptions();
            var otgRasterization = new OtgRasterizationOptions
            {
                // Use the original OTG page size for rasterization
                PageSize = otg.Size
            };
            pngOptions.VectorRasterizationOptions = otgRasterization;

            // Save the rasterized version to a temporary PNG file
            otg.Save(intermediatePngPath, pngOptions);
        }

        // Load the rasterized PNG, apply the Sharpen filter, and save the result
        using (Image rasterImage = Image.Load(intermediatePngPath))
        {
            // Cast to RasterImage to access the Filter method
            var raster = (RasterImage)rasterImage;

            // Apply Sharpen filter to the whole image (kernel size 5, sigma 4.0)
            raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the sharpened image
            raster.Save(outputPngPath, new PngOptions());
        }
    }
}