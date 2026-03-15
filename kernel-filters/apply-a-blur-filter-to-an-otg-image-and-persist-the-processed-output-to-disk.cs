string inputPath = "input.otg";
string tempPngPath = "temp.png";
string outputPath = "output.png";

using (Aspose.Imaging.Image otgImage = Aspose.Imaging.Image.Load(inputPath))
{
    // Convert OTG to a raster PNG using vector rasterization options
    var otgRasterOptions = new Aspose.Imaging.ImageOptions.OtgRasterizationOptions();
    otgRasterOptions.PageSize = otgImage.Size; // preserve original size

    var pngOptions = new Aspose.Imaging.ImageOptions.PngOptions();
    pngOptions.VectorRasterizationOptions = otgRasterOptions;

    otgImage.Save(tempPngPath, pngOptions); // save intermediate raster image
}

using (Aspose.Imaging.Image rasterImage = Aspose.Imaging.Image.Load(tempPngPath))
{
    // Apply Gaussian blur to the entire raster image
    var raster = (Aspose.Imaging.RasterImage)rasterImage;
    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

    // Persist the blurred image to disk
    raster.Save(outputPath);
}