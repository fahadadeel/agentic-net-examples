using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;

string inputPath = "input.apng";
string outputPath = "output_blur.apng";

using (Image image = Image.Load(inputPath))
{
    // Cast the loaded image to ApngImage
    ApngImage apng = (ApngImage)image;

    // Apply a Gaussian blur filter to the whole image
    // radius = 5, sigma = 4.0 (adjust as needed)
    apng.Filter(apng.Bounds, new GaussianBlurFilterOptions(5, 4.0));

    // Save the processed APNG to disk
    apng.Save(outputPath);
}