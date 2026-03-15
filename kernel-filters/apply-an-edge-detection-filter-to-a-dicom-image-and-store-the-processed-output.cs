using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

string dir = @"c:\temp\";

// Load the DICOM image
using (Image image = Image.Load(dir + "input.dicom"))
{
    // Cast to DicomImage to access DICOM‑specific methods
    DicomImage dicomImage = (DicomImage)image;

    // Apply an edge detection effect using the Sharpen filter on the whole image
    dicomImage.Filter(dicomImage.Bounds, new SharpenFilterOptions(5, 4.0));

    // Save the processed result as PNG
    dicomImage.Save(dir + "output_edge.png", new PngOptions());
}