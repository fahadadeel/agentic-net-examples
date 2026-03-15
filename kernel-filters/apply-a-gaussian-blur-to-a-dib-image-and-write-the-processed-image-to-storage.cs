// Path to the folder that contains the source DIB image and where the result will be saved
string dataDir = @"c:\temp\";

// Load the DIB image, apply a Gaussian blur filter, and save the processed image
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dataDir + "sample.dib"))
{
    // Cast to RasterImage to gain access to the Filter method
    Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)image;

    // Apply Gaussian blur with a kernel size of 5 and sigma of 4.0 to the whole image
    rasterImage.Filter(
        rasterImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

    // Save the blurred image back to disk (format inferred from the file extension)
    rasterImage.Save(dataDir + "sample.GaussianBlur.dib");
}