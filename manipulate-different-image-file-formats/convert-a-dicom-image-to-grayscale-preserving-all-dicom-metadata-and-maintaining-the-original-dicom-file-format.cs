using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;

class DicomGrayscaleConverter
{
    static void Main()
    {
        // Path to the source DICOM file
        string sourcePath = @"C:\Temp\sample.dcm";

        // Path for the grayscale DICOM output (can be the same as source to overwrite)
        string outputPath = @"C:\Temp\sample_grayscale.dcm";

        // Load the DICOM image using Aspose.Imaging's generic Image loader
        using (Image image = Image.Load(sourcePath))
        {
            // Cast the generic Image to a DicomImage to access DICOM‑specific operations
            DicomImage dicomImage = (DicomImage)image;

            // Convert the image to grayscale while preserving all existing metadata
            dicomImage.Grayscale();

            // Save the modified image back to DICOM format, keeping the original metadata intact
            dicomImage.Save(outputPath);
        }
    }
}