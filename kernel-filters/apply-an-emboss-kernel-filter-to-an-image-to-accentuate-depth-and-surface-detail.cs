// Load an image, apply a 3x3 emboss convolution filter, and save the result.
// Adjust the paths as needed.

string dataDir = @"c:\temp\";

// Load the image using Aspose.Imaging's load rule.
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dataDir + "input.jpg"))
{
    // Cast to RasterImage to access the Filter method.
    Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)image;

    // Create convolution filter options using the built‑in 3x3 emboss kernel.
    var embossOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);

    // Apply the emboss filter to the whole image.
    rasterImage.Filter(rasterImage.Bounds, embossOptions);

    // Save the processed image using Aspose.Imaging's save rule.
    rasterImage.Save(dataDir + "output_emboss.png");
}