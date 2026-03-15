// Path to the folder containing the source WMZ image
string dataDir = @"c:\temp\";

// Load the WMZ image
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dataDir + "sample.wmz"))
{
    // Cast to RasterImage to access the Filter method
    Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)image;

    // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
    rasterImage.Filter(rasterImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

    // Save the processed image (keeping the original WMZ format)
    rasterImage.Save(dataDir + "sample.GaussianBlur.wmz");
}