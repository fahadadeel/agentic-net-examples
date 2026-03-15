using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Input and output DICOM file paths
        string inputPath = "input.dcm";
        string outputPath = "output.dcm";

        // Load the DICOM image
        using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
        {
            // Adjust brightness (+30)
            dicom.AdjustBrightness(30);

            // Resize image to double its size using nearest neighbour resampling
            dicom.Resize(dicom.Width * 2, dicom.Height * 2, ResizeType.NearestNeighbourResample);

            // Configure DICOM save options with JPEG compression and RGB color type
            DicomOptions options = new DicomOptions
            {
                ColorType = ColorType.Rgb24Bit,
                Compression = new Compression
                {
                    Type = CompressionType.Jpeg,
                    Jpeg = new JpegOptions
                    {
                        CompressionType = JpegCompressionMode.Baseline,
                        SampleRoundingMode = SampleRoundingMode.Truncate,
                        Quality = 70
                    }
                }
            };

            // Save the modified DICOM image with the specified options
            dicom.Save(outputPath, options);
        }
    }
}