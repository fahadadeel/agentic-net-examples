// Load the EMF vector image
using (Aspose.Imaging.Image emfImage = Aspose.Imaging.Image.Load(@"C:\Images\input.emf"))
{
    // Rasterize the EMF to a bitmap in memory using EmfRasterizationOptions
    var rasterizationOptions = new Aspose.Imaging.ImageOptions.EmfRasterizationOptions
    {
        // Use the original EMF size for the raster page
        PageSize = emfImage.Size,
        // Optional: set background color if needed
        BackgroundColor = Aspose.Imaging.Color.White
    };

    // Save the rasterized image to a memory stream in PNG format
    using (var rasterStream = new System.IO.MemoryStream())
    {
        emfImage.Save(rasterStream,
            new Aspose.Imaging.ImageOptions.PngOptions { VectorRasterizationOptions = rasterizationOptions });

        // Reset stream position for reading
        rasterStream.Position = 0;

        // Load the rasterized PNG as a RasterImage
        using (Aspose.Imaging.Image rasterImg = Aspose.Imaging.Image.Load(rasterStream))
        {
            // Cast to RasterImage to access filtering capabilities
            var raster = (Aspose.Imaging.RasterImage)rasterImg;

            // Apply a Sharpen filter to the whole image
            raster.Filter(raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Save the sharpened result to a new EMF file (rasterized back to EMF)
            var saveRasterOptions = new Aspose.Imaging.ImageOptions.EmfOptions
            {
                // Use the same rasterization options to embed the raster data into EMF
                VectorRasterizationOptions = rasterizationOptions
            };
            raster.Save(@"C:\Images\output_sharpened.emf", saveRasterOptions);
        }
    }
}