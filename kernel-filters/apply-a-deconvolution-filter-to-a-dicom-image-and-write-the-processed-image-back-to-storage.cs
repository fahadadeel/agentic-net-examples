using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class DeconvolutionExample
{
    static void Main()
    {
        // Paths for input DICOM file and output processed image
        string inputPath = @"c:\temp\sample.dicom";
        string outputPath = @"c:\temp\sample.Deconvolution.png";

        // Load the DICOM image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DicomImage to access DICOM‑specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Create deconvolution filter options (Gauss‑Wiener filter)
            // Radius = 5, Sigma = 4.0 (adjust as needed)
            var deconvOptions = new GaussWienerFilterOptions(5, 4.0);

            // Apply the filter to the entire image area
            dicomImage.Filter(dicomImage.Bounds, deconvOptions);

            // Save the processed image (PNG format in this example)
            dicomImage.Save(outputPath, new PngOptions());
        }
    }
}