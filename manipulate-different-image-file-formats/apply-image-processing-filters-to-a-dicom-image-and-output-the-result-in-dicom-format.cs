using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

public class Program
{
    public static void Main(string[] args)
    {
        // Define input and output DICOM file paths
        string inputPath = "input.dcm";
        string outputPath = "output.dcm";

        // Load the DICOM image from the input file
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to DicomImage to access DICOM-specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Apply a Gaussian blur filter to the entire image area
            dicomImage.Filter(
                dicomImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image back to DICOM format using default DicomOptions
            dicomImage.Save(outputPath, new DicomOptions());
        }
    }
}