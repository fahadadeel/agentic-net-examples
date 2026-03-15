// Path to the folder containing the DICOM file
string dir = @"c:\temp\";

// Load the DICOM image
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dir + "sample.dicom"))
{
    // Cast the generic Image to DicomImage to access DICOM‑specific methods
    Aspose.Imaging.FileFormats.Dicom.DicomImage dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)image;

    // Apply a motion blur (motion‑Wiener) filter to the whole image.
    // Parameters: length = 10, smooth = 1.0, angle = 90 degrees
    dicomImage.Filter(
        dicomImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));

    // Save the processed image as PNG
    dicomImage.Save(dir + "sample.MotionWienerFilter.png", new Aspose.Imaging.ImageOptions.PngOptions());
}