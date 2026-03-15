using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;

class ApplyFiltersToApng
{
    static void Main()
    {
        // Path to the folder containing the APNG file
        string dir = @"c:\temp\";

        // Load the APNG image
        using (Image image = Image.Load(dir + "sample.apng"))
        {
            // Cast to ApngImage (inherits from RasterImage, so Filter method is available)
            ApngImage apngImage = (ApngImage)image;

            // Apply a median filter with a kernel size of 5 to the whole image
            apngImage.Filter(apngImage.Bounds, new MedianFilterOptions(5));

            // Apply a Gauss‑Wiener filter (Wiener deblurring) with radius 5 and sigma 4.0
            apngImage.Filter(apngImage.Bounds, new GaussWienerFilterOptions(5, 4.0));

            // Save the filtered image back to APNG format
            apngImage.Save(dir + "sample.filtered.apng");
        }
    }
}