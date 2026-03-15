using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source DICOM file
        string inputPath = @"c:\temp\sample.dicom";

        // Path for the output DICOM file
        string outputPath = @"c:\temp\sample.BinarizeOtsu.dicom";

        // Load the DICOM image using Aspose.Imaging's generic Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to a DicomImage to access DICOM‑specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Apply Otsu thresholding – the library determines the optimal threshold automatically
            dicomImage.BinarizeOtsu();

            // Save the processed image back to DICOM format.
            // DicomOptions is the appropriate options class for DICOM output.
            dicomImage.Save(outputPath, new DicomOptions());
        }
    }
}