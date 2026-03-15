using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class DicomDitheringExample
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = @"C:\Temp\sample.dicom";
        string outputPath = @"C:\Temp\sample.dithered.dcm";

        // Load the DICOM image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DicomImage to access DICOM-specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Apply Floyd‑Steinberg dithering with a 1‑bit palette (black & white)
            dicomImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

            // Prepare DICOM save options and preserve original metadata
            DicomOptions saveOptions = new DicomOptions
            {
                KeepMetadata = true
            };

            // Save the processed image back to DICOM format
            dicomImage.Save(outputPath, saveOptions);
        }
    }
}