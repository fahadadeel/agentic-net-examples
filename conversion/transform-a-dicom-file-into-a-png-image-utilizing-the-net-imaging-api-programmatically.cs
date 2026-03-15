using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class DicomToPngConverter
{
    static void Main()
    {
        // Path to the source DICOM file
        string dicomFilePath = @"C:\Temp\sample.dicom";

        // Path for the output PNG file
        string pngFilePath = @"C:\Temp\sample.png";

        // Load the DICOM image using Aspose.Imaging
        using (Image image = Image.Load(dicomFilePath))
        {
            // Cast the generic Image to DicomImage to access DICOM-specific features
            DicomImage dicomImage = (DicomImage)image;

            // If the DICOM file contains multiple pages, you can save each page separately.
            // Here we assume a single-page DICOM; otherwise, iterate over dicomImage.DicomPages.
            dicomImage.Save(pngFilePath, new PngOptions());
        }

        Console.WriteLine("DICOM file has been converted to PNG successfully.");
    }
}