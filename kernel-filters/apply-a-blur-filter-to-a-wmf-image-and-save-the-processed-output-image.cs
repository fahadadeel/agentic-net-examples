// Load the WMF image
using (Aspose.Imaging.Image wmfImg = Aspose.Imaging.Image.Load(@"C:\Images\input.wmf"))
{
    // Rasterize the WMF to a PNG image
    var rasterOptions = new Aspose.Imaging.ImageOptions.WmfRasterizationOptions
    {
        PageSize = wmfImg.Size,
        BackgroundColor = Aspose.Imaging.Color.White // optional background
    };
    var pngSaveOptions = new Aspose.Imaging.ImageOptions.PngOptions
    {
        VectorRasterizationOptions = rasterOptions
    };
    string tempPngPath = @"C:\Images\temp.png";
    wmfImg.Save(tempPngPath, pngSaveOptions);
}

// Load the rasterized PNG image
using (Aspose.Imaging.Image rasterImg = Aspose.Imaging.Image.Load(@"C:\Images\temp.png"))
{
    // Cast to a raster image type that supports filtering (e.g., PngImage)
    var pngImage = (Aspose.Imaging.FileFormats.Png.PngImage)rasterImg;

    // Apply a Gaussian blur filter to the entire image
    pngImage.Filter(pngImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(radius: 5, sigma: 4.0));

    // Save the blurred image
    pngImage.Save(@"C:\Images\output_blurred.png", new Aspose.Imaging.ImageOptions.PngOptions());
}