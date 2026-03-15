using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = args.Length > 0 ? args[0] : "input.dcm";
        string outputPath = args.Length > 1 ? args[1] : "output_resized.dcm";

        // Load the DICOM image
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Determine new dimensions (e.g., double the size)
            int newWidth = dicomImage.Width * 2;
            int newHeight = dicomImage.Height * 2;

            // Resize while preserving aspect ratio using nearest neighbour resampling
            dicomImage.ResizeProportional(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            // Prepare DICOM save options and keep original metadata
            DicomOptions options = new DicomOptions
            {
                KeepMetadata = true
            };

            // Save the resized image back to DICOM format
            dicomImage.Save(outputPath, options);
        }
    }
}