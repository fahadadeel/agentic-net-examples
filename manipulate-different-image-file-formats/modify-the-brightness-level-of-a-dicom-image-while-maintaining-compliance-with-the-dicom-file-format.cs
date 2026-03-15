using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class DicomBrightnessAdjustment
{
    static void Main()
    {
        // Define input and output file paths
        string dir = @"c:\temp\";
        string inputPath = Path.Combine(dir, "sample.dicom");
        string outputPath = Path.Combine(dir, "sample.brightnessAdjusted.dcm");

        // Load the DICOM image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DicomImage to access DICOM‑specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Adjust brightness; allowed range is [-255, 255]
            dicomImage.AdjustBrightness(50);

            // Save the modified image back as a DICOM file,
            // using DicomOptions to keep the file format compliant
            dicomImage.Save(outputPath, new DicomOptions());
        }
    }
}