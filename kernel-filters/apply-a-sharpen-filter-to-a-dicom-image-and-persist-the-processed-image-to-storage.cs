using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source DICOM file
        string inputPath = @"c:\temp\sample.dicom";

        // Path where the sharpened image will be saved
        string outputPath = @"c:\temp\sample.Sharpened.png";

        // Load the DICOM image from storage
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to DicomImage to access DICOM-specific functionality
            DicomImage dicomImage = (DicomImage)image;

            // Apply a sharpen filter to the entire image.
            // SharpenFilterOptions takes kernel size and sigma as parameters.
            dicomImage.Filter(dicomImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image in PNG format
            dicomImage.Save(outputPath, new PngOptions());
        }
    }
}