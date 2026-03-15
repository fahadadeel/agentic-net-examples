using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source CMX file
        string inputCmxPath = "input.cmx";
        // Desired output TIFF file path
        string outputTiffPath = "output.tif";

        // Load the CMX vector image
        using (CmxImage cmx = (CmxImage)Image.Load(inputCmxPath))
        {
            // Configure TIFF save options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            // Bind the output file to the options
            tiffOptions.Source = new FileCreateSource(outputTiffPath, false);

            // Create a raster TIFF image with the same dimensions as the CMX canvas
            using (Image tiffImage = Image.Create(tiffOptions, cmx.Width, cmx.Height))
            {
                // Since the output file is already bound via FileCreateSource, just call Save()
                tiffImage.Save();
            }
        }
    }
}