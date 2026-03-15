using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class DeconvolutionExample
{
    static void Main()
    {
        // Input DNG file path
        string inputPath = @"c:\temp\input.dng";
        // Output file path (PNG format)
        string outputPath = @"c:\temp\output.png";

        // Load the DNG image using Aspose.Imaging's load rule
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DngImage to access RAW-specific features
            DngImage dngImage = (DngImage)image;

            // Apply a Gauss‑Wiener deconvolution filter to the entire image
            // Radius = 5, Sigma = 4.0 (adjust as needed)
            dngImage.Filter(dngImage.Bounds, new GaussWienerFilterOptions(5, 4.0));

            // Save the processed image using Aspose.Imaging's save rule
            dngImage.Save(outputPath, new PngOptions());
        }
    }
}