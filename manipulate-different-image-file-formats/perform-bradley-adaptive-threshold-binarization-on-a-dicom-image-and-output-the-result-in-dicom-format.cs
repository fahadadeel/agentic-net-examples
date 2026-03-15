// Load the DICOM image from disk
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(@"c:\temp\sample.dicom"))
{
    // Cast the generic Image to DicomImage to access DICOM‑specific methods
    Aspose.Imaging.FileFormats.Dicom.DicomImage dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)image;

    // Apply Bradley's adaptive thresholding
    // brightnessDifference = 5, windowSize = 10 (10x10 pixel window)
    dicomImage.BinarizeBradley(5, 10);

    // Save the processed image back in DICOM format
    dicomImage.Save(@"c:\temp\sample.BinarizeBradley5_10x10.dcm", new Aspose.Imaging.ImageOptions.DicomOptions());
}