using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class DicomAdjustmentExample
{
    static void Main()
    {
        // Path to the source DICOM file
        string inputPath = @"C:\Temp\sample.dicom";

        // Path where the adjusted DICOM file will be saved
        string outputPath = @"C:\Temp\sample_adjusted.dicom";

        // Load the DICOM image using Aspose.Imaging's generic Image loader
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to DicomImage to access DICOM‑specific adjustment methods
            DicomImage dicomImage = (DicomImage)image;

            // Adjust brightness: value range is [-255, 255]
            dicomImage.AdjustBrightness(50);   // increase brightness

            // Adjust contrast: value range is [-100, 100]
            dicomImage.AdjustContrast(30f);    // increase contrast

            // Adjust gamma uniformly for all channels
            dicomImage.AdjustGamma(1.2f);      // slight gamma correction

            // Save the image back in DICOM format.
            // Using the file extension ".dicom" lets Aspose.Imaging infer the correct format.
            // Alternatively, explicit DicomOptions can be supplied.
            dicomImage.Save(outputPath, new DicomOptions());
        }

        Console.WriteLine("Brightness, contrast, and gamma adjustments applied and saved to DICOM file.");
    }
}