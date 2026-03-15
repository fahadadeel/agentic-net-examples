// Load the DNG image from file
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(@"c:\temp\input.dng"))
{
    // Cast to DngImage to access format‑specific methods
    var dngImage = (Aspose.Imaging.FileFormats.Dng.DngImage)image;

    // Apply a Gaussian blur filter to the whole image (radius 5, sigma 4.0)
    dngImage.Filter(dngImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

    // Save the processed image to a new file (PNG format)
    dngImage.Save(@"c:\temp\output.png", new Aspose.Imaging.ImageOptions.PngOptions());
}