// Path to the folder containing the DICOM file
string dir = @"c:\temp\";

// Load the DICOM image using Aspose.Imaging's Image.Load method
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dir + "sample.dicom"))
{
    // Cast the generic Image to a DicomImage to access DICOM‑specific methods
    Aspose.Imaging.FileFormats.Dicom.DicomImage dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)image;

    // Apply gamma correction (same value for R, G, B channels)
    // Adjust the value as needed; here 2.0f is used as an example
    dicomImage.AdjustGamma(2.0f);

    // Save the modified image back to DICOM format.
    // Saving without specifying options preserves the original DICOM file format.
    dicomImage.Save(dir + "sample_gamma.dcm");
}