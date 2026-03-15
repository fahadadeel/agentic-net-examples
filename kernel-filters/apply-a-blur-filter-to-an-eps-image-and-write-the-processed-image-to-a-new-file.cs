using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Eps.EpsPreviewFormat;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

string inputPath = "input.eps";          // Path to the source EPS file
string outputPath = "blurred_output.png"; // Path for the processed image

// Load the EPS image
using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
{
    // Obtain a raster preview of the EPS using PostScript rendering
    RasterImage preview = epsImage.GetPreviewImage(EpsPreviewFormat.PostScriptRendering);

    // Apply a Gaussian blur filter to the whole preview image
    preview.Filter(preview.Bounds, new GaussianBlurFilterOptions(5, 4.0));

    // Save the blurred preview as a PNG file
    preview.Save(outputPath, new PngOptions());
}